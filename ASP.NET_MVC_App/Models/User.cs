using System.ComponentModel.DataAnnotations;

namespace ASP.NET_MVC_App.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string? Email { get; set; }
        public string? Address { get; set; }
        public string? PhoneNumber { get; set; }


    }
}
