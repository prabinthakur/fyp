using System.ComponentModel.DataAnnotations;

namespace fyp.Models
{
    public class SkillsModel
    {
        [Key]
        public int SkillId { get; set; }
        public string SkillsTitle { get; set; }
        public int JobsId { get; set; }

        public virtual JobsModel Jobs { get; set; }

    }
}
