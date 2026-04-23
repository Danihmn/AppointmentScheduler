namespace AppointmentScheduler.Features.Secretary.Get
{
    public class SecretaryResponseDTO
    {
        public required int Id { get; set; }
        public required string Name { get; set; }
        public required string Cpf { get; set; }
        public required string PhoneNumber { get; set; }
        public required string Email { get; set; }
        public required DateTime HiringDate { get; set; }
        public required bool Active { get; set; }
    }
}
