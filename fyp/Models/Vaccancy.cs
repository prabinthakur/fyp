using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace fyp.Models
{
    public class Vaccancy
    {
        [Key]
        public int  VaccancyID { get; set; }

        [ForeignKey(nameof(Category))]
        public  int  vaccancytype { get; set; }

        public string  VaccancyName { get; set; }

        [DataType(DataType.Date)]
        public DateOnly PostedDate { get; set; }


        public virtual Category Category { get; set; }

    }
}
