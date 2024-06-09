using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Prueba.Model
{
    [Table("Contacto")]
    public class Contacto
    {
        [Key]
        [Required]
        public string Id { get; set; }

        [Required]
        public string Nombre { get; set; }

        [Required]
        public int Celular { get; set; }

    }
}