using System.ComponentModel.DataAnnotations;

namespace fyp.Models
{
    public class ApplicationModel
    {
        [Key]
        public int ApplicationId { get; set; }

        public DateOnly AppliedDate { get; set; }

        public string status { get; set; }

        public int JosbId { get; set; }

        public virtual JobsModel Jobs { get; set; }
    }
}
