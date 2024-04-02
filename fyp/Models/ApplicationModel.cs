using System.ComponentModel.DataAnnotations;

namespace fyp.Models
{
    public class ApplicationModel
    {
        [Key]
        public int ApplicationId { get; set; }

        public DateOnly AppliedDate { get; set; }

        public string status { get; set; }

        public int JobsId { get; set; }
        public int StudentId { get; set; }

        public virtual JobsModel Jobs { get; set; }

       

        public virtual StudentModel Student { get; set; }



    }
}
