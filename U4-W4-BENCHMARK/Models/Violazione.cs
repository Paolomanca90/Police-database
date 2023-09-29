using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace U4_W4_BENCHMARK.Models
{
    public class Violazione
    {
        public int IdViolazione { get; set; }

        [Required(ErrorMessage = "Campo obbligatorio")]
        [Display(Name = "Violazione")]
        public string Descrizione { get; set; }
    }
}