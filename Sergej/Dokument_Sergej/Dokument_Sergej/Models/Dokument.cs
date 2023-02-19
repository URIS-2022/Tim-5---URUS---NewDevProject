using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dokument_Sergej.Models
{
    public class Dokument
    {
        
       [Key] 
        public int DokumentID { get; set; }
        public int ZavodniBroj { get; set; }
        public DateTime Datum { get; set; }
        public DateTime DatumDonosenjaOdluke { get; set; }
        public string Sablon { get; set; }

        [ForeignKey("KorisnikSistema")]
        public int KorisnikID { get; set; }

        public KorisnikSistema KorisnikSistema { get; set; }

        [ForeignKey("Licnost")]
        public int LicnostID { get; set; }
        public Licnost Licnost { get; set; }

    }
}
