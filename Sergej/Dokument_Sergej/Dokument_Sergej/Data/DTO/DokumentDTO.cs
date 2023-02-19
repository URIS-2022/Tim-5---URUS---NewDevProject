using Dokument_Sergej.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dokument_Sergej.Data.DTO
{
    /// <summary>
    /// Predstavlja model dokumenta
    /// </summary>
    public class DokumentDTO
    {
        /// <summary>
        /// Id dokumenta
        /// </summary>
        public int DokumentID { get; set; }
        /// <summary>
        /// Zavodni broj dokumenta
        /// </summary>
        public int ZavodniBroj { get; set; }
        /// <summary>
        /// Datum 
        /// </summary>
        public DateTime Datum { get; set; }
        /// <summary>
        /// Datum donosenja odluke
        /// </summary>
        public DateTime DatumDonosenjaOdluke { get; set; }

       // [ForeignKey("KorisnikSistema")]
        public int KorisnikID { get; set; }

        public KorisnikSistema KorisnikSistema { get; set; }

        //[ForeignKey("Licnost")]
        public int LicnostID { get; set; }
        public Licnost Licnost { get; set; }
    }
}
