using System;

namespace WebUI.Models
{
    public class VisitListModel
    {
        public int Id { get; set; }
        public string IntendedDate { get; set; }
        public string VisitDate { get; set; }
        public string AccountName { get; set; }
        public string UserFullName { get; set; }
    }
}
