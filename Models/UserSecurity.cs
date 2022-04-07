using System;
using System.Collections.Generic;

namespace Streaming_Video_MVC.Models
{
    public partial class UserSecurity
    {
        public string? IdUser { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }

        public virtual User? IdUserNavigation { get; set; }
    }
}
