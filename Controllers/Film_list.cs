using Microsoft.AspNetCore.Mvc;
using Streaming_Video_MVC.Models;
namespace Streaming_Video_MVC.Controllers
{
    public class Film_list : Controller
    {
        public IActionResult Index()
        {
            using (var context = new webnangcaoContext())
            {
              var blogs = context.Films.ToList();
                return View(blogs);
            }
            
            return View();
        }
    }
}
