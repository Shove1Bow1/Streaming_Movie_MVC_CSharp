using Microsoft.AspNetCore.Mvc;
using Streaming_Video_MVC.Models;
namespace Streaming_Video_MVC.Controllers
{
    public class actor : Controller
    {
        public IActionResult Index()
        {
            using (var context = new webnangcaoContext())
            {
                var blogs = context.Actors.Where(x => x.Status == true).ToList();

                return View(blogs);
            }
        }
        public IActionResult Create()
        {
                return View();
              
        }
        public ActionResult Delete(string id)
        {
            using (var context = new webnangcaoContext())
            {
                var blogs = context.Actors.Where(x => x.IdActor == id).FirstOrDefault();
                blogs.Status = false;
                context.Entry(blogs).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                context.SaveChanges();
                var blog = context.Actors.Where(x => x.Status == true).ToList();
                return View("Index",blog);
            }
            return View();
        }
        public IActionResult Edit(string id)
        {
            using (var context = new webnangcaoContext())
            {
                var blogs = context.Actors.Where(x=>x.IdActor==id).FirstOrDefault();
                ViewBag.Messerger = blogs;
                return View(blogs);
            }

        }
        [HttpPost]
        public IActionResult CreateActor([FromForm] string NameActor, [FromForm] string Description, [FromForm] string UrlImg)
        {
            
            using (var context = new webnangcaoContext())
            {
                string id = "saa";
                Actor actor = new Actor();
                actor.IdActor = id;
                actor.NameActor = NameActor;
                actor.Description = Description;
                actor.UrlImg = UrlImg;
                actor.Status = true;
                context.Actors.Add(actor);
                context.SaveChanges();
                var blogs = context.Actors.ToList();

                return View("index",blogs);
            }

        }
        [HttpPost]
        public IActionResult UpdateActor([FromForm] string IdActor, [FromForm] string NameActor, [FromForm] string Description, [FromForm] string UrlImg)
        {

            using (var context = new webnangcaoContext())
            {
                Actor actor = new Actor();
                actor.IdActor = IdActor;
                actor.NameActor = NameActor;
                actor.Description = Description;
                actor.UrlImg = UrlImg;
                actor.Status = true;
                context.Actors.Update(actor);
                context.SaveChanges();
                var blogs = context.Actors.ToList();

                return View("index", blogs);
            }

        }
    }
}
