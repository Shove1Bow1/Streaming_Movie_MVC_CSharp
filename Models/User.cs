using System;
using System.Collections.Generic;

namespace Streaming_Video_MVC.Models
{
    public partial class User
    {
        public string IdUser { get; set; } = null!;
        public string? Name { get; set; }
        public short? Age { get; set; }
        public string? UrlImg { get; set; }
    }
}
