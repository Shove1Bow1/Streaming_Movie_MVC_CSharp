using Microsoft.AspNetCore.Mvc;
using Streaming_Video_MVC.Models;
using System.Web;
using System.Linq;
namespace Streaming_Video_MVC.Controllers
{
    public class AdminController : Controller
    {
 
        string GenreIDforEdit;
            Context context = new Context(new usernotlogin());
        private webnangcaoContext webnangcaoContext=new webnangcaoContext();
        public ActionResult Index()
        {
            if (context.State.id != null)
            {
                return View("Hello");
            }
            else
            return View("Index");
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
                    context.changeState(new userLogin());
                    context.State.login(data[0].IdAdmin, data[0].Name);
                   HttpContext.Session.SetString("AdminName", data[0].Name);
                   return View("Hello");
               }
            }
           return View();
        }
        public IActionResult Hello()
        {
            //if (httpcontext.session.getstring("adminid") == null && httpcontext.session.getstring("adminname") == null)
            //{
            //    return view("index");
            //}
            if (context.State.id == null && context.State.name == null)
                return View("index");
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
