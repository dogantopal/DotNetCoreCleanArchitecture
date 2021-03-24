using System;

namespace Application.Dtos
{
    public class VisitDTO : BaseDTO
    {
        public int AccountId { get; set; }
        public DateTime IntendedDate { get; set; }
        public DateTime? VisitDate { get; set; }
        public int UserId { get; set; }
        public string Description { get; set; }

        public bool IsVisited
        {
            get
            {
                return VisitDate.HasValue;
            }
        }

        public AccountDTO Account { get; set; }
        public UserDTO User { get; set; }
    }
}
