using System;
using System.Collections.Generic;

namespace Streaming_Video_MVC.Models
{
    public partial class DiretorFilm
    {
        public string? IdFilm { get; set; }
        public string? Id { get; set; }

        public virtual Film? IdFilmNavigation { get; set; }
        public virtual Director? IdNavigation { get; set; }
    }
}
