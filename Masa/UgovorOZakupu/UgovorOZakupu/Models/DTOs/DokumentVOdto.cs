using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace UgovorOZakupu.Models.DTOs
{
    /// <summary>
    /// Predstavlja model dokumenta
    /// </summary>
    public class DokumentVOdto
    {
        /// <summary>
        /// Id dokumenta
        /// </summary>
        public int DokumentID { get; set; }

        /// <summary>
        /// zavodni broj dokumenta
        /// </summary>
        public string ZavodniBroj { get; set; }

        /// <summary>
        /// datum
        /// </summary>
        public DateTime Datum { get; set; }
        /// <summary>
        /// datum donosenja dokumenta
        /// </summary>

        public DateTime DatumDonosenjaDokumenta { get; set; }
        /// <summary>
        /// sablon
        /// </summary>
        public string Sablon { get; set; }
    }
}
