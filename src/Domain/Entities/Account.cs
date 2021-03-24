using System.Collections.Generic;

namespace Domain.Entities
{
    public class Account : BaseEntity
    {
        public Account()
        {
            Visits = new HashSet<Visit>();
        }

        public string Name { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string ResponsiblePerson { get; set; }
        public virtual ICollection<Visit> Visits { get; set; }
    }
}
