using System;
using System.Collections.Generic;

#nullable disable

namespace CoreUI.Models
{
    public partial class UserPhoto
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public string PhotoPath { get; set; }

        public virtual AspNetUser User { get; set; }
    }
}
