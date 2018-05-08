using System;
using System.ComponentModel.DataAnnotations;

namespace Base.Application.ViewModels
{
    public class ProspectViewModel
    {
        [Key]
        public Guid Id { get; set; }
        [EmailAddress]
        public string Address { get; set; }
        [Required]
        [MaxLength(50)]
        public string FirstName { get; set; }
        [Required]
        [MaxLength(50)]
        public string LastName { get; set; }
        [MaxLength(11)]
        [MinLength(11)]
        public string CellPhone { get; set; }
        public bool IsWhatsApp { get; set; }
        [MaxLength(10)]
        [MinLength(10)]
        public string HomePhone { get; set; }
    }
}
