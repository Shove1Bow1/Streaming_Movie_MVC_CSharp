using Firebase.Auth;
using Firebase.Storage;
using Microsoft.AspNetCore.Mvc;
using Streaming_Video_MVC.Models;
namespace Streaming_Video_MVC.Controllers
{
    public class actor : Controller
    {
        private static string ApiKey = "AIzaSyBnkZPA6HSV7EL2pzjToUIx_kYjeUhjETY";
        private static string Bucket = "netflix-clone-423a7.appspot.com";
        private static string AuthEmail = "loser@gmail.com";
        private static string AuthPassword = "slowly123";
        public IActionResult Index()
        {
            using (var context = new webnangcaoContext())
            {
                var blogs = context.Actors.Where(x => x.StatusDelete == false).ToList();

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
                if (blogs != null)
                {
                    blogs.StatusDelete = true;
                    context.Entry(blogs).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    context.SaveChanges();
                }
                var blog = context.Actors.Where(x => x.StatusDelete == false).ToList();
                return View("Index",blog);
            }
         
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
        public async Task<ActionResult> CreateActor([FromForm] string NameActor, [FromForm] string Description, [FromForm] List<IFormFile> UrlImg)
        {
            
            using (var context = new webnangcaoContext())
            {
                string id = "saa";
                Actor actor = new Actor();
                actor.IdActor = id;
                actor.NameActor = NameActor;
                actor.Description = Description;
                actor.StatusDelete = false;
                context.Actors.Add(actor);
                context.SaveChanges();
             
                var blogs = context.Actors.ToList();
                if (UrlImg != null)
                {
                        string path = Path.Combine("Upload/Actor", NameActor + ".jpg");
                        using (FileStream fs = new FileStream(path, FileMode.Create))
                        {
                            await UrlImg[0].CopyToAsync(fs);
                        }
                        FileStream ms = new FileStream(path, FileMode.Open);
                        Upload(ms, NameActor + ".jpg", NameActor);

                }
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
                actor.StatusDelete = true;
                context.Actors.Update(actor);
                context.SaveChanges();
                var blogs = context.Actors.ToList();

                return View("index", blogs);
            }

        }
        public async void Upload(FileStream result,string NameFile, string Name)
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
                .Child("ActorImage")
                .Child(NameFile)
                .PutAsync(result, cancellation.Token);

            task.Progress.ProgressChanged += (s, e) => Console.WriteLine($"Progress: {e.Percentage} %");
            try
            {
                link = await task;
                var context=new webnangcaoContext();
                var Data = context.Actors.Where(s => s.NameActor == Name).FirstOrDefault();
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
