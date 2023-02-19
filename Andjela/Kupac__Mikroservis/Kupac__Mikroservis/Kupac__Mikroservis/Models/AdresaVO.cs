using System.ComponentModel.DataAnnotations;

namespace Kupac__Mikroservis.Models
{
        public class AdresaVO
        {
            [Key]
            public int AdresaID { get; set; }
            public string Ulica { get; set; }
            public string Broj { get; set; }
            public string Mesto { get; set; }
            public string PostanskiBroj { get; set; }
            public string Drzava { get; set; }

        }
    }

