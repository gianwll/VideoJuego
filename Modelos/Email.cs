﻿using System.ComponentModel.DataAnnotations;

namespace Universidad2.Models
{
    public class Email
    {
        [Key]
        public int idEmail { get; set; }
        public string email { get; set; }
        public int idUsuario { get; set; }
    }
}
