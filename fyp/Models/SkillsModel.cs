using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace fyp.Models
{
    public class SkillsModel
    {
        [Key]
        public int SkillId { get; set; }
        public string SkillsTitle { get; set; }
        public string? JobsId { get; set; }

        [ValidateNever]
        public virtual JobsModel Jobs { get; set; }

    }
}
