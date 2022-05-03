using System;
using System.Collections.Generic;

namespace Streaming_Video_MVC.Models
{
    public partial class Actor
    {
        public string IdActor { get; set; } = null!;
        public string? NameActor { get; set; }
        public string? Description { get; set; }
        public string? UrlImg { get; set; }
        public bool StatusDelete { get; set; }
    }
}
