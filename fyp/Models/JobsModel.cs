
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.CompilerServices;

namespace fyp.Models
{
    public class JobsModel
    {
        [Key]
        public int JobId { get; set; }
        public string JobName { get; set; }

        public string Location { get; set; }
        public string Description { get; set; }

        public string Requirement { get; set; }

        [Column(TypeName = "decimal(10,2)")]
        public decimal Salary { get; set; }

        [DataType(DataType.Date)]
        public DateOnly PostedDate { get; set; }

        [DataType(DataType.Date)]
        public DateOnly Deadline { get; set; }

        
        public int? Categoryid { get; set; }
       
        public int? CorporationId { get; set; }

        [ValidateNever]
        public virtual CategoryModel  Category { get; set; }
        [ValidateNever]
        public virtual CorporationModel  Corporation { get; set; }




    }
}
