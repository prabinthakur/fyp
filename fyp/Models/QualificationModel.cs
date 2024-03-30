using System.ComponentModel.DataAnnotations;

namespace fyp.Models
{
    public class QualificationModel
    {
        [Key]
        public int QualificationId{ get; set; }
        public string CurrentEducation { get; set; }
        public string InstituteName { get; set; }
        public string MajorSubject { get; set; }
        [DataType(DataType.Date)]
        public DateOnly CompletionYear { get; set; }

        public int StudentId { get; set; }

        public virtual StudentModel Student { get; set; }



    }
}
