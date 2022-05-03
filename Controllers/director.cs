using Microsoft.AspNetCore.Mvc;
using Streaming_Video_MVC.Models;
namespace Streaming_Video_MVC.Controllers
{
    public class director : Controller
    {
        webnangcaoContext context = new webnangcaoContext();
        public IActionResult Index()
        {
            var director = context.Directors.Where(x => x.StatusDelete == false).ToList();
            return View(director);
        }
        public IActionResult Edit(string id)
        {
            var blogs = context.Directors.Where(x => x.Id == id).FirstOrDefault();
            ViewBag.Messerger = blogs;
            return View();
        }
        public ActionResult Delete(string id)
        {
            string a = id;
            var blogs = context.Directors.Where(x => x.Id == id).FirstOrDefault();
            blogs.StatusDelete = true;
            context.Entry(blogs).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            var director = context.Directors.Where(x => x.StatusDelete == false).ToList();
            return View("index", director);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create([FromForm] string Name, [FromForm] string Description, [FromForm] string UrlImg)
        {

            
                string id = "saa";
                Director actor = new Director();
                actor.Id = id;
                actor.Name = Name;
                actor.Description = Description;
                actor.UrlImg = UrlImg;
                actor.StatusDelete =false;
                context.Directors.Add(actor);
                context.SaveChanges();
                var blogs = context.Directors.ToList();
                return View("index", blogs);
            

        }
        [HttpPost]
        public IActionResult Edit([FromForm] string Id,[FromForm] string Name, [FromForm] string Description, [FromForm] string UrlImg)
        {


            Director actor = new Director();
            actor.Id = Id;
            actor.Name = Name;
            actor.Description = Description;
            actor.UrlImg = UrlImg;
            actor.StatusDelete = false;
            context.Directors.Update(actor);
            context.SaveChanges();
            var blogs = context.Directors.ToList();
            return View("index", blogs);


        }
    }
}
