using Base.Domain.Enums;
using Base.Shared.Enum;
using AutoMapper;
using System;

namespace Base.Application.ViewModels
{
    public class IntentionViewModel
    {
        //[Key]
        //public Guid Id { get; set; }

        //[Required(ErrorMessage = "The Name is Required")]
        //[MinLength(2)]
        //[MaxLength(100)]
        //[DisplayName("Name")]
        //public string Name { get; set; }

        //[Required(ErrorMessage = "The E-mail is Required")]
        //[EmailAddress]
        //[DisplayName("E-mail")]
        //public string Email { get; set; }

        //[Required(ErrorMessage = "The BirthDate is Required")]
        //[DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        //[DataType(DataType.Date, ErrorMessage = "Data em formato inválido")]
        //[DisplayName("Birth Date")]
        //public DateTime BirthDate { get; set; }

        
        public decimal? Rent { get; set; }
        public Guid ProspectId { get; set; }
        public decimal LowestPrice { get; set; }
        public decimal MaximumPrice { get; set; }
        public int Bedroom { get; set; }
        public EState State { get; set; }
        public string City { get; set; }
        public string Neighborhood { get; set; }
        public EPropertyType PropertyType { get; set; }
        public EPropertySituation PropertySituation { get; set; }
    }
}
