using System;
using System.ComponentModel.DataAnnotations;
using WebUI.Attributes;
using WebUI.Constants;

namespace WebUI.Models
{
    public class VisitCreateModel
    {
        [Required(ErrorMessage = ValidationMessages.RequiredSelectField)]
        [Display(Name = "Müşteri")]
        public int AccountId { get; set; }

        [Required(ErrorMessage = ValidationMessages.RequiredSelectField)]
        [Display(Name = "Ziyaret Planlanan Tarihi")]
        public DateTime IntendedDate { get; set; }

        [Display(Name = "Ziyaret Edilen Tarih")]
        public DateTime? VisitDate { get; set; }

        public int UserId { get; set; }

        [Display(Name = "Açıklama")]
        public string Description { get; set; }
    }
}
