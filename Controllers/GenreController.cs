using Microsoft.AspNetCore.Mvc;
using Streaming_Video_MVC.Models;

namespace Streaming_Video_MVC.Controllers
{
    
    public class GenreController : Controller
    {
        private webnangcaoContext webnangcaoContext=new webnangcaoContext();
        public IActionResult Index()
        {
            if (HttpContext.Session.GetString("AdminId") != null)
            {
                var blog = webnangcaoContext.Gernes.ToList();
                return View(blog);
            }
            else
                return RedirectToAction("Index", "Admin");
            
        }
        public ActionResult GenreEditor(string getId)
        {
            if (HttpContext.Session.GetString("AdminId") != null)
            {
                var genreData = webnangcaoContext.Gernes.Where(x => x.IdGer.Equals(getId)).FirstOrDefault();
                if (genreData != null)
                {
                    Gerne gerne = new Gerne();
                    gerne.IdGer = getId;
                    TempData["GenreID"] = getId;
                    TempData.Keep();

                    return View(genreData);
                }
                return (View());
            }
            else
            {
                return RedirectToAction("Index", "Admin");
            }
        }
        [HttpPost]
        public ActionResult GenreEditor(Gerne gerne)
        {
            string temp = (string)TempData["GenreID"];
            var GenreData = webnangcaoContext.Gernes.Where(a => a.IdGer == temp).FirstOrDefault();
            if (GenreData != null)
            {
                GenreData.Name = gerne.Name;
                GenreData.Description = gerne.Description;
                webnangcaoContext.Entry(GenreData).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                webnangcaoContext.SaveChanges();
            }
            return (RedirectToAction("Index"));
        }
        public ActionResult GenreDelete(string getId)
        {
            var genreData = webnangcaoContext.Gernes.Where(x => x.IdGer.Equals(getId)).FirstOrDefault();
            if (genreData != null)
            {
                genreData.IsDeleted = true;
                webnangcaoContext.Entry(genreData).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                webnangcaoContext.SaveChanges();
            }
            return (RedirectToAction("Index"));
        }
        public ActionResult AddGenre()
        {
            if (HttpContext.Session.GetString("AdminId") != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Index", "Admin");
            }
        }
        [HttpPost]
        public ActionResult AddGenre(string Name, string Description)
        {
            Gerne gerne = new Gerne();
            gerne.IdGer = " ";
            gerne.Name = Name;
            gerne.Description = Description;
            if (Name == null || Description == null)
            {
                return View();
            }
            else
            {
                webnangcaoContext.Gernes.Add(gerne);
                webnangcaoContext.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}
