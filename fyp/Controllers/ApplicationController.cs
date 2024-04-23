using fyp.Data;
using fyp.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using Newtonsoft.Json.Linq;

namespace fyp.Controllers
{
    public class ApplicationController : Controller
    {
        private readonly AppDbContext _context;

        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;



        public ApplicationController(AppDbContext dbContext,SignInManager<IdentityUser> signInManager,UserManager<IdentityUser> userManager)
        {

            _context = dbContext;
            _signInManager = signInManager;
            _userManager = userManager;
            
        }


      



        [HttpPost]

        public ActionResult Create(int JobId)
        {


           
            var jobid = TempData["Currentjobid"];


            if (_signInManager.IsSignedIn(User))
            {
                ApplicationModel ap = new ApplicationModel()
                {




                    AppliedDate = DateTime.Now,
                    JobsId = Convert.ToInt32(jobid),
                    status = "Pending",
                    StudentId = HttpContext.Session.GetInt32("Studentid")??0

            };
                    _context.ApplicationModel.Add(ap);
            _context.SaveChanges();

                
                
               



            }
            return RedirectPermanent("/Identity/Account/Login");
           






            return View();
        }



       

        
    }
}
