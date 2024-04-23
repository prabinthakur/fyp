using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace fyp.Models
{
    public class CorporationModel
    {

        [Key]
        public int CorporationId { get; set; }
        public string CorporationName { get; set; }
        public string CorporationDescription { get; set; }

        public string CorporationLocation { get; set; }


        [DataType(DataType.Url)]
        public string  CorporationUrl { get; set; }

        public string? ImageUrl { get; set; }


        [ValidateNever]
        public string? UserId { get; set; }
        [ValidateNever]
        public virtual IdentityUser User { get; set; }

    }
}
