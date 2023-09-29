using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace U4_W4_BENCHMARK.Models
{
    public class Trasgressore
    {
        public int IdTrasgressore { get; set; }

        [Required(ErrorMessage = "Campo obbligatorio")]
        public string Cognome { get; set; }

        [Required(ErrorMessage = "Campo obbligatorio")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Campo obbligatorio")]
        public string Indirizzo { get; set; }

        [Required(ErrorMessage = "Campo obbligatorio")]
        [Display(Name = "Città")]
        public string Citta { get; set; }

        [Required(ErrorMessage = "Campo obbligatorio")]
        public int Cap { get; set; }

        [Required(ErrorMessage = "Campo obbligatorio")]
        [Display(Name = "Codice Fiscale")]
        public string CodiceFiscale { get; set; }
    }
}