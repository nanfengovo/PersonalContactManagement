using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PersonalContactManagement.EntityFrameCore.EntityModel
{
    [Table("T_Contact")]
    public class Contact:Common
    {

        public int Id { get; set; }
        public required string Name { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Email { get; set; }
        public string? Address { get; set; }
        public string? Company { get; set; }
        public string? Keywords { get; set; }
    }
}
