using System.ComponentModel.DataAnnotations;

namespace UserInformation.Domain.Entities
{
    #nullable disable
    public class UserInfo
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
    }
}
