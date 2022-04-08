using Microsoft.AspNetCore.Mvc;
using Streaming_Video_MVC.Models;
namespace Streaming_Video_MVC.Controllers
{
    public class AdminController : Controller
    {    
        private webnangcaoContext webnangcaoContext=new webnangcaoContext();
        public ActionResult Index()
        {
            return View();
        }
    
        [HttpPost]
        public ActionResult Index(string Name,string Password)
        {
            if (Name != null && Password != null)
            {
               var data=webnangcaoContext.Admins.Where(s => s.Name.Equals(Name)&& s.Password.Equals(Password)).ToList();
               if (data.Count > 0)
               {
                   return View("Hello");
               }
            }
           return View();
        }
        public IActionResult Hello()
        {
            return View();
        }
        public IActionResult login()
        {
            return View();
        }
    }
}
