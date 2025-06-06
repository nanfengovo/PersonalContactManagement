namespace PersonalContactManagement.Domain.Model
{
    public class AddContactPersonDTO
    {
        public required string Name { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Email { get; set; }
        public string? Address { get; set; }
        public string? Company { get; set; }
        public string? Keywords { get; set; }

        public DateTime UpdateTime { get; set; } = DateTime.Now;
    }
}
