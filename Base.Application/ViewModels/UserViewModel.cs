using System;
using System.ComponentModel.DataAnnotations;

namespace Base.Application.ViewModels
{
    public class UserViewModel
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string FirstName { get; set; }
        [Required]
        [MaxLength(50)]
        public string LastName { get; set; }
        [EmailAddress]
        public string Address { get; set; }
        [Required]
        [MaxLength(20)]
        [MinLength(5)]
        public string UserID { get; set; }
        [Required]
        [MaxLength(50)]
        [MinLength(6)]
        public string AccessKey { get; set; }
    }
}
