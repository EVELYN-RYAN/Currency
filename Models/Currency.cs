using System;
using System.ComponentModel.DataAnnotations;

namespace Currency.Models
{
    public class Currency
    {
        [Key]
        [Required]
        public int CurrencyID { get; set; }
        [Required(ErrorMessage ="Must enter currency full name")]
        public string CurrencyFullName { get; set; }
        [Required(ErrorMessage ="Must enter currency abbreviation")]
        public string CurrencyCode { get; set; }
        [Required(ErrorMessage = "Must enter currency unit")]
        public string Unit { get; set; }
        [Required(ErrorMessage = "Must enter rate")]
        public decimal Rate { get; set; }
        public decimal PrevRate { get; set; }
    }
}
