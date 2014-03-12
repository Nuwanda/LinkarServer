using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LinkarServer.Models
{
    public class Link
    {
        public int LinkId { get; set; }
        [Required]
        public String url { get; set; }
        [Required]
        public virtual List<User> to { get; set; }
        [Required]
        public virtual User from { get; set; }
    }
}