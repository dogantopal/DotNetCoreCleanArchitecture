using System.Collections.Generic;

namespace Domain.Entities
{
    public class User : BaseEntity
    {
        public User()
        {
            Visits = new HashSet<Visit>();
        }

        public string Name { get; set; }
        public string Surname { get; set; }
        public string Username { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public string Email { get; set; }

        public virtual ICollection<Visit> Visits { get; set; }

    }
}
