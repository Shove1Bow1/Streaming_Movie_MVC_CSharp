using Microsoft.AspNetCore.Mvc;
using Streaming_Video_MVC.Models;
namespace Streaming_Video_MVC.Controllers
{
    public class AdminController : Controller
    {    
        private webnangcaoContext webnangcaoContext=new webnangcaoContext();
        public IActionResult login()
        {
            return View("Login");
        }
    
        [HttpPost]
        public ActionResult Index([Bind("name,password")] Admin admin)
        {
            try
            {
                if (webnangcaoContext.Admins.Where(s => s.Name.Equals(admin.Name) && s.Password.Equals(admin.Password)).ToList().Count > 0)
                {
                    return View("Index/Hello");
                }

            }
            catch (Exception ex)
            {
                throw new Exception();
            }
            return View("Login");
        }
        public IActionResult Hello()
        {
            return View();
        }
    }
}
