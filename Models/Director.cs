using System;
using System.Collections.Generic;

namespace Streaming_Video_MVC.Models
{
    public partial class Director
    {
        public string Id { get; set; } = null!;
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? UrlImg { get; set; }
    }
}
