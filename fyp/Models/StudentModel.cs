
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace fyp.Models
{
    public class StudentModel
    {

        [Key]
        public int StudentId { get; set; }
        public string FullName { get; set;}
        public string Email { get; set;}
        public string PhoneNo { get; set;}
        public string Address { get; set;}

        public string Resume { get; set;}

        [ValidateNever]
        public string ImageUrl { get; set;}
      

    }
}
