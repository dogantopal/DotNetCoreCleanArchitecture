using System;

namespace Domain.Entities
{
    public class Visit : BaseEntity
    {
        public int AccountId { get; set; }
        public DateTime IntendedDate { get; set; }
        public DateTime? VisitDate { get; set; }
        public int UserId { get; set; }
        public string Description { get; set; }


        public virtual Account Account { get; set; }
        public virtual User User { get; set; }
    }
}
