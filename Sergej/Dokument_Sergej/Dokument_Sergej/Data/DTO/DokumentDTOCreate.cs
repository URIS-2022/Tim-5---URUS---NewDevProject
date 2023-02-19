using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Dokument_Sergej.Data.DTO
{
    public class DokumentDTOCreate
    {

        [Key] 
        public int DokumentID { get; set; }
        public int ZavodniBroj { get; set; }
        public DateTime Datum { get; set; }
        public DateTime DatumDonosenjaOdluke { get; set; }
        public string Sablon { get; set; }

        [ForeignKey("KorisnikSistema")]
        public int KorisnikID { get; set; }

        [ForeignKey("Licnost")]
        public int LicnostID { get; set; }
    }
}
