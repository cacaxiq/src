using Base.Domain.Enums;
using Base.Shared.Enum;
using System;
using System.ComponentModel.DataAnnotations;

namespace Base.Application.ViewModels
{
    public class IntentionViewModel
    {
        [Key]
        public Guid Id { get; set; }
        [DataType(DataType.Currency)]
        public decimal? Rent { get; set; }
        [Required(ErrorMessage = "Toda intenção de compra deve pertencer a um usuário")]
        public Guid ProspectId { get; set; }
        [Required]
        [DataType(DataType.Currency)]
        public decimal LowestPrice { get; set; }
        [Required]
        [DataType(DataType.Currency)]
        public decimal MaximumPrice { get; set; }
        [Required]
        public int Bedroom { get; set; }
        [Required]
        public EState State { get; set; }
        [Required]
        [MaxLength(50)]
        public string City { get; set; }
        [Required]
        [MaxLength(50)]
        public string Neighborhood { get; set; }
        [Required]
        public EPropertyType PropertyType { get; set; }
        [Required]
        public EPropertySituation PropertySituation { get; set; }
    }
}
