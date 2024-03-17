using System.ComponentModel.DataAnnotations;

namespace fyp.Models
{
    public class Student
    {

        [Key]
        public int studentID { get; set; }

        public string Name { get; set; }

        public  string  CurrentEducation { get; set; }
    }
}
