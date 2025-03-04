﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Entity
{
        [Table("Greetings")]
        public class Greeting
        {
            [Key]
            public int Id { get; set; }
            public string? Message { get; set; }
        }
 }

