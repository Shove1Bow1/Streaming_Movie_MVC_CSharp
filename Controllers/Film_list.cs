using Firebase.Auth;
using Firebase.Storage;
using System.Web;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Streaming_Video_MVC.Models;
namespace Streaming_Video_MVC.Controllers
{
   
    public class ViewModel
    {
        public IEnumerable<country> Countries{ get; set; }
        public IEnumerable<Film> Films { get; set; }
    }
    public class Film_list : Controller
    { string linkImg;
        webnangcaoContext context = new webnangcaoContext();
        private static string ApiKey = "AIzaSyBnkZPA6HSV7EL2pzjToUIx_kYjeUhjETY";
        private static string Bucket = "netflix-clone-423a7.appspot.com";
        private static string AuthEmail = "loser@gmail.com";
        private static string AuthPassword = "slowly123";

        public IActionResult Index()
        {
             var blogs = context.Films.Where(x=>x.StatusDelete==false).ToList();    
                return View(blogs);
      
        }
        public IActionResult add_film()
        {
            return View();
        }
        public IActionResult Add_actor()
        {
            return View();
        }
        public IActionResult Delete (string id)
        {
            var blogs = context.Films.Where(x => x.IdFilm == id).FirstOrDefault();
            blogs.StatusDelete = true;
            context.Entry(blogs).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            var blog = context.Films.Where(x => x.StatusDelete == false).ToList();
            return View("Index", blog);
    
        }
        public IActionResult Create()
        {
            ViewBag.IdAdmin = HttpContext.Session.GetString("AdminId");
            List<Film> films = new List<Film>();
            List<country> countriess = new List<country>();
            countriess.Add(new country(1, "Afghanistan"));
            countriess.Add(new country(2, "Albania"));
            countriess.Add(new country(3, "Algeria"));
            countriess.Add(new country(4, "Andorra"));
            countriess.Add(new country(5, "Angola"));
            countriess.Add(new country(6, "Antigua and Barbuda"));
            countriess.Add(new country(7, "Argentina"));
            countriess.Add(new country(8, "Armenia"));
            countriess.Add(new country(9, "Australia"));
            countriess.Add(new country(10, "Austria"));
            countriess.Add(new country(11, "Azerbaijan"));
            countriess.Add(new country(12, "Bahamas"));
            countriess.Add(new country(13, "Bahrain"));
            countriess.Add(new country(14, "Bangladesh"));
            countriess.Add(new country(15, "Barbados"));
            countriess.Add(new country(16, "Belarus"));
            countriess.Add(new country(17, "Belgium"));
            countriess.Add(new country(18, "Belize"));
            countriess.Add(new country(19, "Benin"));
            countriess.Add(new country(20, "Bhutan"));
            countriess.Add(new country(21, "Bolivia"));
            countriess.Add(new country(22, "Bosnia and Herzegovina"));
            countriess.Add(new country(23, "Botswana"));
            countriess.Add(new country(24, "Brazil"));
            countriess.Add(new country(25, "Brunei"));
            countriess.Add(new country(26, "Bulgaria"));
            countriess.Add(new country(27, "Burkina Faso"));
            countriess.Add(new country(28, "Burundi"));
            countriess.Add(new country(29, "Côte d'Ivoire"));
            countriess.Add(new country(30, "Cabo Verde"));
            countriess.Add(new country(31, "Cambodia"));
            countriess.Add(new country(32, "Cameroon"));
            countriess.Add(new country(33, "Canada"));
            countriess.Add(new country(34, "Central African Republic"));
            countriess.Add(new country(35, "Chad"));
            countriess.Add(new country(36, "Chile"));
            countriess.Add(new country(37, "China"));
            countriess.Add(new country(38, "Colombia"));
            countriess.Add(new country(39, "Comoros"));
            countriess.Add(new country(40, "Congo (Congo-Brazzaville)"));
            countriess.Add(new country(41, "Costa Rica"));
            countriess.Add(new country(42, "Croatia"));
            countriess.Add(new country(43, "Cuba"));
            countriess.Add(new country(44, "Cyprus"));
            countriess.Add(new country(45, "Czechia (Czech Republic)"));
            countriess.Add(new country(46, "Democratic Republic of the Congo"));
            countriess.Add(new country(47, "Denmark"));
            countriess.Add(new country(48, "Djibouti"));
            countriess.Add(new country(49, "Dominica"));
            countriess.Add(new country(50, "Dominican Republic"));
            countriess.Add(new country(51, "Ecuador"));
            countriess.Add(new country(52, "Egypt"));
            countriess.Add(new country(53, "El Salvador"));
            countriess.Add(new country(54, "Equatorial Guinea"));
            countriess.Add(new country(55, "Eritrea"));
            countriess.Add(new country(56, "Estonia"));
            countriess.Add(new country(57, "Eswatini"));
            countriess.Add(new country(58, "Ethiopia"));
            countriess.Add(new country(59, "Fiji"));
            countriess.Add(new country(60, "Finland"));
            countriess.Add(new country(61, "France"));
            countriess.Add(new country(62, "Gabon"));
            countriess.Add(new country(63, "Gambia"));
            countriess.Add(new country(64, "Georgia"));
            countriess.Add(new country(65, "Germany"));
            countriess.Add(new country(66, "Ghana"));
            countriess.Add(new country(67, "Greece"));
            countriess.Add(new country(68, "Grenada"));
            countriess.Add(new country(69, "Guatemala"));
            countriess.Add(new country(70, "Guinea"));
            countriess.Add(new country(71, "Guinea-Bissau"));
            countriess.Add(new country(72, "Guyana"));
            countriess.Add(new country(73, "Haiti"));
            countriess.Add(new country(74, "Holy See"));
            countriess.Add(new country(75, "Honduras"));
            countriess.Add(new country(76, "Hungary"));
            countriess.Add(new country(77, "Iceland"));
            countriess.Add(new country(78, "India"));
            countriess.Add(new country(79, "Indonesia"));
            countriess.Add(new country(80, "Iran"));
            countriess.Add(new country(81, "Iraq"));
            countriess.Add(new country(82, "Ireland"));
            countriess.Add(new country(83, "Israel"));
            countriess.Add(new country(84, "Italy"));
            countriess.Add(new country(85, "Jamaica"));
            countriess.Add(new country(86, "Japan"));
            countriess.Add(new country(87, "Jordan"));
            countriess.Add(new country(88, "Kazakhstan"));
            countriess.Add(new country(89, "Kenya"));
            countriess.Add(new country(90, "Kiribati"));
            countriess.Add(new country(91, "Kuwait"));
            countriess.Add(new country(92, "Kyrgyzstan"));
            countriess.Add(new country(93, "Laos"));
            countriess.Add(new country(94, "Latvia"));
            countriess.Add(new country(95, "Lebanon"));
            countriess.Add(new country(96, "Lesotho"));
            countriess.Add(new country(97, "Liberia"));
            countriess.Add(new country(98, "Libya"));
            countriess.Add(new country(99, "Liechtenstein"));
            countriess.Add(new country(100, "Lithuania"));
            countriess.Add(new country(101, "Luxembourg"));
            countriess.Add(new country(102, "Madagascar"));
            countriess.Add(new country(103, "Malawi"));
            countriess.Add(new country(104, "Malaysia"));
            countriess.Add(new country(105, "Maldives"));
            countriess.Add(new country(106, "Mali"));
            countriess.Add(new country(107, "Malta"));
            countriess.Add(new country(108, "Marshall Islands"));
            countriess.Add(new country(109, "Mauritania"));
            countriess.Add(new country(110, "Mauritius"));
            countriess.Add(new country(111, "Mexico"));
            countriess.Add(new country(112, "Micronesia"));
            countriess.Add(new country(113, "Moldova"));
            countriess.Add(new country(114, "Monaco"));
            countriess.Add(new country(115, "Mongolia"));
            countriess.Add(new country(116, "Montenegro"));
            countriess.Add(new country(117, "Morocco"));
            countriess.Add(new country(118, "Mozambique"));
            countriess.Add(new country(119, "Myanmar (formerly Burma)"));
            countriess.Add(new country(120, "Namibia"));
            countriess.Add(new country(121, "Nauru"));
            countriess.Add(new country(122, "Nepal"));
            countriess.Add(new country(123, "Netherlands"));
            countriess.Add(new country(124, "New Zealand"));
            countriess.Add(new country(125, "Nicaragua"));
            countriess.Add(new country(126, "Niger"));
            countriess.Add(new country(127, "Nigeria"));
            countriess.Add(new country(128, "North Korea"));
            countriess.Add(new country(129, "North Macedonia"));
            countriess.Add(new country(130, "Norway"));
            countriess.Add(new country(131, "Oman"));
            countriess.Add(new country(132, "Pakistan"));
            countriess.Add(new country(133, "Palau"));
            countriess.Add(new country(134, "Palestine State"));
            countriess.Add(new country(135, "Panama"));
            countriess.Add(new country(136, "Papua New Guinea"));
            countriess.Add(new country(137, "Paraguay"));
            countriess.Add(new country(138, "Peru"));
            countriess.Add(new country(139, "Philippines"));
            countriess.Add(new country(140, "Poland"));
            countriess.Add(new country(141, "Portugal"));
            countriess.Add(new country(142, "Qatar"));
            countriess.Add(new country(143, "Romania"));
            countriess.Add(new country(144, "Russia"));
            countriess.Add(new country(145, "Rwanda"));
            countriess.Add(new country(146, "Saint Kitts and Nevis"));
            countriess.Add(new country(147, "Saint Lucia"));
            countriess.Add(new country(148, "Saint Vincent and the Grenadines"));
            countriess.Add(new country(149, "Samoa"));
            countriess.Add(new country(150, "San Marino"));
            countriess.Add(new country(151, "Sao Tome and Principe"));
            countriess.Add(new country(152, "Saudi Arabia"));
            countriess.Add(new country(153, "Senegal"));
            countriess.Add(new country(154, "Serbia"));
            countriess.Add(new country(155, "Seychelles"));
            countriess.Add(new country(156, "Sierra Leone"));
            countriess.Add(new country(157, "Singapore"));
            countriess.Add(new country(158, "Slovakia"));
            countriess.Add(new country(159, "Slovenia"));
            countriess.Add(new country(160, "Solomon Islands"));
            countriess.Add(new country(161, "Somalia"));
            countriess.Add(new country(162, "South Africa"));
            countriess.Add(new country(163, "South Korea"));
            countriess.Add(new country(164, "South Sudan"));
            countriess.Add(new country(165, "Spain"));
            countriess.Add(new country(166, "Sri Lanka"));
            countriess.Add(new country(167, "Sudan"));
            countriess.Add(new country(168, "Suriname"));
            countriess.Add(new country(169, "Sweden"));
            countriess.Add(new country(170, "Switzerland"));
            countriess.Add(new country(171, "Syria"));
            countriess.Add(new country(172, "Tajikistan"));
            countriess.Add(new country(173, "Tanzania"));
            countriess.Add(new country(174, "Thailand"));
            countriess.Add(new country(175, "Timor-Leste"));
            countriess.Add(new country(176, "Togo"));
            countriess.Add(new country(177, "Tonga"));
            countriess.Add(new country(178, "Trinidad and Tobago"));
            countriess.Add(new country(179, "Tunisia"));
            countriess.Add(new country(180, "Turkey"));
            countriess.Add(new country(181, "Turkmenistan"));
            countriess.Add(new country(182, "Tuvalu"));
            countriess.Add(new country(183, "Uganda"));
            countriess.Add(new country(184, "Ukraine"));
            countriess.Add(new country(185, "United Arab Emirates"));
            countriess.Add(new country(186, "United Kingdom"));
            countriess.Add(new country(187, "United States of America"));
            countriess.Add(new country(188, "Uruguay"));
            countriess.Add(new country(189, "Uzbekistan"));
            countriess.Add(new country(190, "Vanuatu"));
            countriess.Add(new country(191, "Venezuela"));
            countriess.Add(new country(192, "Vietnam"));
            countriess.Add(new country(193, "Yemen"));
            countriess.Add(new country(194, "Zambia"));
            countriess.Add(new country(195, "Zimbabwe"));
            ViewModel viewModel = new ViewModel();
            viewModel.Films = films;
            viewModel.Countries = countriess;
            return View(countriess);
        }
        [HttpPost]
        public async Task<ActionResult> Create(string IdAdmin,string Name,string Country, string Description,string YearPublic, string AgeLimit, List<IFormFile> UrlImg,List<IFormFile> UrlFilm)
        {
            Console.WriteLine(Name);
         

            //if (UrlFilm != null)
            //{
            //    if (UrlFilm[0].Length > 0)
            //    {
            //        string path = Path.Combine("Upload/Films", Name + ".mp4");
            //        FileStream fs = new FileStream(Path.Combine(path), FileMode.Open);
            //        await UrlFilm[0].CopyToAsync(fs);
            //        await Task.Run(() => UploadVideo(fs, Name + ".mp4"));
            //    }
            //}
            Film film = new Film();
            film.IdAdmin = IdAdmin;
            film.Name = Name;
            film.IdFilm=" ";
            film.Country = Country;
            film.Description = Description;
            film.YearPublic = YearPublic;
            film.AgeLimit = AgeLimit;
            film.StatusDelete = false;
            context.Films.Add(film);
            context.SaveChanges();   
            if(UrlImg != null)
            {
                FileStream ms;
                string path = Path.Combine("Upload/Posters", Name + ".jpg");
                if (UrlImg[0].Length > 0)
                {
                    using (FileStream sr = new FileStream(path, FileMode.Create))
                    {
                        await UrlImg[0].CopyToAsync(sr);
                    }
                    ms = new FileStream(Path.Combine(path), FileMode.Open);
                    UploadImg(ms, Name + ".jpg", Name);
                }
            }
            if(UrlFilm != null)
            {
                FileStream ms;
                string path = Path.Combine("Upload/Films", Name + ".mp4");
                if (UrlFilm[0].Length > 0)
                {
                    using (FileStream sr = new FileStream(path, FileMode.Create))
                    {
                        await UrlFilm[0].CopyToAsync(sr);
                    }
                    ms = new FileStream(Path.Combine(path), FileMode.Open);
                    UploadVideo(ms, Name + ".mp4", Name);
                }
            }
            var blogs = context.Directors.ToList();
            ViewBag.film = film;
            return View();
        }
        public async void UploadImg(FileStream result, string fileName,string Name)
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
                .Child("Poster")
                .Child(Name + ".jpg")
                .PutAsync(result, cancellation.Token);

            task.Progress.ProgressChanged += (s, e) => Console.WriteLine($"Progress: {e.Percentage} %");
            try
            {
                link = await task;
                var Data = context.Films.Where(s => s.Name == Name).FirstOrDefault();
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
        public async void UploadVideo(FileStream result, string fileName, string Name)
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
                .Child("Video")
                .Child(Name + ".mp4")
                .PutAsync(result, cancellation.Token);

            task.Progress.ProgressChanged += (s, e) => Console.WriteLine($"Progress: {e.Percentage} %");
            try
            {
                link = await task;
                var Data = context.Films.Where(s => s.Name == Name).FirstOrDefault();
                if (Data != null)
                {
                    Data.UrlFilm = link;
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
