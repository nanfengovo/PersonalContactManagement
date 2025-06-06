namespace PersonalContactManagement.Domain.Model
{
    public class EditContactPersonDTO
    {
        public required string Name { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Email { get; set; }
        public string? Address { get; set; }
        public string? Company { get; set; }
        public string? Keywords { get; set; }
    }
}
