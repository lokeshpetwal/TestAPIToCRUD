﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TestAPIToCRUD.Models
{
    public class LogInModel
    {[Key]
        
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
       
    }
}
