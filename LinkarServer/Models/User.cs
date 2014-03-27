using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LinkarServer.Models
{
    public class User
    {
        [Key]
        public string username { get; set; }
        [Required]
        public String email { get; set; }
        [Required]
        public String channelId { get; set; }
        public virtual ICollection<User> friends { get; set; }
    }
}