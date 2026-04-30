namespace AppointmentSchedulerTest.UnitTests.Appointment
{
    public class ScheduleAppointmentUnitTests
    {
        private readonly Mock<IUnitOfWork> _unitOfWork = new();
        private readonly Mock<IAppointmentRepository> _appointmentRepository = new();
        private readonly Mock<IDoctorRepository> _doctorRepository = new();
        private readonly Mock<IPatientRepository> _patientRepository = new();
        private readonly Mock<IRequestRepository> _requestRepository = new();
        private readonly Mock<ISecretaryRepository> _secretaryRepository = new();
        private readonly Mock<ISpecialtyRepository> _specialtyRepository = new();
        private readonly Mock<INotificationService> _notificationService = new();
        private readonly Mock<IValidator<ScheduleAppointmentCommand>> _validator = new();
        private readonly Mock<IMapper> _mapper = new();

        private readonly ScheduleAppointmentCommandHandler _handler;

        public ScheduleAppointmentUnitTests ()
        {
            _unitOfWork.Setup(unitOfWork => unitOfWork.AppointmentRepository).Returns(_appointmentRepository.Object);
            _unitOfWork.Setup(unitOfWork => unitOfWork.DoctorRepository).Returns(_doctorRepository.Object);
            _unitOfWork.Setup(unitOfWork => unitOfWork.PatientRepository).Returns(_patientRepository.Object);
            _unitOfWork.Setup(unitOfWork => unitOfWork.RequestRepository).Returns(_requestRepository.Object);
            _unitOfWork.Setup(unitOfWork => unitOfWork.SecretaryRepository).Returns(_secretaryRepository.Object);
            _unitOfWork.Setup(unitOfWork => unitOfWork.SpecialtyRepository).Returns(_specialtyRepository.Object);

            _handler = new(_unitOfWork.Object, _mapper.Object, _notificationService.Object, _validator.Object);
        }

        [Fact]
        public async Task Handle_ValidCommand_ShouldReturnCreated ()
        {
            #region Arrange
            var command = new ScheduleAppointmentCommand(DateTime.Now.AddDays(1), "Test notes", 1, 1);

            var request = new Request
            {
                Id = command.RequestId,
                Status = ERequestStatus.Approved,
                Type = ERequestType.Scheduling,
                Description = "Test request",
                Priority = EPriority.Medium,
                PatientId = 1,
                SpecialtyId = 1,
                ProcessedBySecretaryId = 1
            };

            var doctor = new Doctor
            {
                Id = command.DoctorId,
                Name = "Dr. Test",
                Crm = "000000",
                PhoneNumber = "00000000000",
                Email = "email.test@example.com",
                HiringDate = DateTime.Now.Subtract(TimeSpan.FromDays(365)),
                SpecialtyId = request.SpecialtyId,
            };

            var appointment = new AppointmentScheduler.Domain.Entities.Appointment
            {
                Id = 1,
                Date = command.Date,
                Status = EAppointmentStatus.Scheduled,
                Notes = command.Notes,
                RequestId = command.RequestId,
                DoctorId = command.DoctorId,
            };

            var responseDTO = new AppointmentResponseDTO
            {
                Id = 1,
                Date = command.Date,
                Status = EAppointmentStatus.Scheduled.ToString(),
                Notes = command.Notes,
                RequestId = command.RequestId,
                DoctorId = command.DoctorId,
            };

            _requestRepository.Setup(repo => repo.GetByIdAsync(command.RequestId)).ReturnsAsync(request);
            _doctorRepository.Setup(repo => repo.GetByIdAsync(command.DoctorId)).ReturnsAsync(doctor);
            _appointmentRepository.Setup(repo => repo.HasConflictAsync(command.DoctorId, command.Date)).ReturnsAsync(false);
            _appointmentRepository.Setup(repo => repo.AddAsync(It.IsAny<AppointmentScheduler.Domain.Entities.Appointment>(), It.IsAny<CancellationToken>())).Returns(Task.CompletedTask);

            _unitOfWork.Setup(unitOfWork => unitOfWork.SaveChangesAsync(It.IsAny<CancellationToken>())).ReturnsAsync(1);
            #endregion

            #region Act
            var result = await _handler.Handle(command, CancellationToken.None);
            #endregion

            #region Assert
            result.Should().NotBeNull();
            result.Success.Should().BeTrue();
            _unitOfWork.Verify(unitOfWork => unitOfWork.SaveChangesAsync(It.IsAny<CancellationToken>()), Times.Once);
            #endregion
        }
    }
}
