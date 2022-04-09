using Microsoft.AspNetCore.Mvc;
using Streaming_Video_MVC.Models;
using System.Web;
using System.Linq;
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
        [ValidateAntiForgeryToken]
        public ActionResult Index(string Name,string Password)
        {
            if (HttpContext.Session.GetString("AdminId") != null)
            {
                return View("Hello");
            }
            if (Name != null && Password != null)
            {
               var data=webnangcaoContext.Admins.Where(s => s.Name.Equals(Name)&& s.Password.Equals(Password)).ToList();
               if (data.Count > 0)
               {
                   HttpContext.Session.SetString("AdminId",data[0].IdAdmin);
                   HttpContext.Session.SetString("AdminName", data[0].Name);
                   return View("Hello");
               }
            }
           return View();
        }
        public IActionResult Hello()
        {
            if (HttpContext.Session.GetString("AdminId") == null && HttpContext.Session.GetString("AdminName")==null)
            {
                return View("Index");
            }
            return View();
        }
        public IActionResult login()
        {
            return View();
        }
        public IActionResult DeleteSession()
        {
            HttpContext.Session.Remove("AdminId");
            HttpContext.Session.Remove("AdminName");
            return RedirectToAction("Index");
        }

    }
}
