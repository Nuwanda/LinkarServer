﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LinkarServer.Models
{
    public class User
    {
        public int UserId { get; set; }
        [Required]
        public string username { get; set; }
        [Required]
        public String email { get; set; }
        [Required]
        public String channelId { get; set; }
        public virtual List<User> friends { get; set; }
    }
}