using fyp.Migrations;
using System.ComponentModel.DataAnnotations;

namespace fyp.Models
{
    public class JobsModel
    {
        [Key]
        public int JobId { get; set; }
        public string JobName { get; set; }
      
        public string Location { get;set; }
        public string Description { get; set; }

        public string Requirement { get; set; }

        public decimal Salary { get; set; }

        [DataType(DataType.Date)]
        public DateOnly PostedDate { get; set; }

        [DataType(DataType.Date)]
        public DateOnly Deadline { get; set; }

        public int Categoryid { get; set; }
        public int CorporationId { get; set; }

        public virtual CategoryModel Category { get; set; }
        public virtual CorporationModel Corporation { get; set; }




    }
}
