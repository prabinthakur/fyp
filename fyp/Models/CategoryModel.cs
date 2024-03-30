using System.ComponentModel.DataAnnotations;

namespace fyp.Models
{
    public class CategoryModel
    {

        [Key]

        public int CategoryId { get; set; }
        public string CategoryName { get; set; }

    }
}
