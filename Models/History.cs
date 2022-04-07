using System;
using System.Collections.Generic;

namespace Streaming_Video_MVC.Models
{
    public partial class History
    {
        public string? IdUser { get; set; }
        public string? IdFilm { get; set; }
        public long? Time { get; set; }

        public virtual Film? IdFilmNavigation { get; set; }
        public virtual User? IdUserNavigation { get; set; }
    }
}
