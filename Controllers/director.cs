using Firebase.Auth;
using Firebase.Storage;
using Microsoft.AspNetCore.Mvc;
using Streaming_Video_MVC.Models;
namespace Streaming_Video_MVC.Controllers
{
    public class director : Controller
    {
        private static string ApiKey = "AIzaSyBnkZPA6HSV7EL2pzjToUIx_kYjeUhjETY";
        private static string Bucket = "netflix-clone-423a7.appspot.com";
        private static string AuthEmail = "loser@gmail.com";
        private static string AuthPassword = "slowly123";
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
        public async Task<ActionResult> Create([FromForm] string Name, [FromForm] string Description, [FromForm] IFormFile UrlImg)
        {
            string id = "saa";
            Director actor = new Director();
            actor.Id = id;
            actor.Name = Name;
            actor.Description = Description;
            actor.StatusDelete = false;
            context.Directors.Add(actor);
            context.SaveChanges();
            if (UrlImg != null)
            {
                string path = Path.Combine("Upload/Director", Name + ".jpg");
                using (FileStream fs = new FileStream(path, FileMode.Create))
                {
                    await UrlImg.CopyToAsync(fs);
                }
                FileStream ms = new FileStream(path, FileMode.Open);
                Upload(ms, Name + ".jpg", Name);
            }
            var blogs = context.Directors.ToList();
            return RedirectToAction("index", blogs);


        }
        [HttpPost]
        public async Task<ActionResult> Edit([FromForm] string Id,[FromForm] string Name, [FromForm] string Description, [FromForm] IFormFile UrlImg)
        {
            Director director = new Director();
            director.Id = Id;
            var Data = context.Directors.Where(s => s.Id == Id).FirstOrDefault();
            Data.Name = Name;
            Data.Description = Description;
            context.Entry(Data).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            Console.WriteLine(UrlImg);
            if (UrlImg != null)
            {
                string path = Path.Combine("Upload/Director", Name + ".jpg");
                using (FileStream fs = new FileStream(path, FileMode.Create))
                {
                    await UrlImg.CopyToAsync(fs);
                }
                FileStream ms = new FileStream(path, FileMode.Open);
                Upload(ms, Name + ".jpg", Name);
            }
            var blogs = context.Directors.ToList();
            return RedirectToAction("index", blogs);    
        }
        public async void Upload(FileStream result, string NameFile, string Name)
        {
            string link;
            var auth = new FirebaseAuthProvider(new FirebaseConfig(ApiKey));
            var a = await auth.SignInWithEmailAndPasswordAsync(AuthEmail, AuthPassword);

            // you can use CancellationTokenSource to cancel the upload midway
            var cancellation = new CancellationTokenSource();

            var task = new FirebaseStorage(
                Bucket,
                new FirebaseStorageOptions
                {
                    AuthTokenAsyncFactory = () => Task.FromResult(a.FirebaseToken),
                    ThrowOnCancel = true // when you cancel the upload, exception is thrown. By default no exception is thrown
                })
                .Child("DirectorImage")
                .Child(NameFile)
                .PutAsync(result, cancellation.Token);

            task.Progress.ProgressChanged += (s, e) => Console.WriteLine($"Progress: {e.Percentage} %");
            try
            {
                link = await task;
                var context = new webnangcaoContext();
                var Data = context.Directors.Where(s => s.Name == Name).FirstOrDefault();
                if (Data != null)
                {
                    Data.UrlImg = link;
                    context.Entry(Data).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                ViewBag.error = $"Exception was thrown: {ex}";
            }
        }
    }
}
