using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace U4_W4_BENCHMARK.Models
{
    public class Verbale
    {
        public int IdVerbale { get; set; }

        [Required(ErrorMessage = "Campo obbligatorio")]
        [Display(Name = "Data violazione")]
        public DateTime DataViolazione { get; set; }

        [Required(ErrorMessage = "Campo obbligatorio")]
        [Display(Name = "Indirizzo violazione")]
        public string IndirizzoViolazione { get; set; }

        [Required(ErrorMessage = "Campo obbligatorio")]
        [Display(Name = "Nominativo Agente")]
        public string NominativoAgente { get; set; }

        [Required(ErrorMessage = "Campo obbligatorio")]
        [Display(Name = "Data verbale")]
        public DateTime DataVerbale { get; set; }

        [Required(ErrorMessage = "Campo obbligatorio")]
        public int Importo { get; set; }

        [Required(ErrorMessage = "Campo obbligatorio")]
        [Display(Name = "Punti decurtati")]
        public int DecurtamentoPunti { get; set; }

        [Required(ErrorMessage = "Campo obbligatorio")]
        public string Trasgressore { get; set; }

        [Required(ErrorMessage = "Campo obbligatorio")]
        public string Violazione { get; set; }
    }

    public class VerbaliTotali
    {
        public string Nome { get; set; }
        public string Cognome { get; set; }
        public int Totale { get; set; }
    }

    public class PuntiTotali
    {
        public string Nome { get; set; }
        public string Cognome { get; set; }
        public int Totale { get; set; }
    }

    public class Over10
    {
        public string Nome { get; set; }
        public string Cognome { get; set; }
        public int Importo { get; set; }
        public DateTime DataViolazione { get; set; }
        public int DecurtamentoPunti { get; set; }
    }

    public class MaxiMulte
    {
        public string Nome { get; set; }
        public string Cognome { get; set; }
        public int Importo { get; set; }
        public DateTime DataViolazione { get; set; }
    }
}