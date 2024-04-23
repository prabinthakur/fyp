using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace fyp.Models
{
    public class ApplicationModel
    {
        [Key]
        public int ApplicationId { get; set; }

        [DataType(DataType.Date)]
        public DateTime AppliedDate { get; set; } = DateTime.Now;

        public string status { get; set; } = "pending";


        public int JobsId { get; set; }
        public int StudentId { get; set; }

        [ValidateNever]
        public virtual JobsModel Jobs { get; set; }

       

        public virtual StudentModel Student { get; set; }



    }
}
