using System.ComponentModel.DataAnnotations;

namespace Commerce.Repository.Models
{
    public class AuthenticateModel
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
        public bool? KeepLogin { get; set; }
    }
}
