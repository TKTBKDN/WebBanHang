using System;

namespace Commerce.Repository.Models
{
    public class UserModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public DateTime? Birthday { get; set; }
        public int? StatusId { get; set; }
        public bool IsDeleted { get; set; }
        public int Role { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
