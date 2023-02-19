using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

/// <summary>
/// Predstavlja model kupca
/// </summary>
namespace UgovorOZakupu.Models.DTOs
{
    public class KupacVOdtos
    {
        /// <summary>
        /// Id kupca
        /// </summary>
        public int KupacID { get; set; }
        /// <summary>
        /// prioritet
        /// </summary>
        public string Prioritet { get; set; }
        /// <summary>
        /// lice
        /// </summary>
        public string Lice { get; set; }

        /// <summary>
        /// ostvarena povrsina
        /// </summary>
        public int OstvarenaPovrsina { get; set; }

        /// <summary>
        ///  ima zabranu
        /// </summary>
        public bool ImaZabranu { get; set; }

        /// <summary>
        /// datum pocetka zabrane
        /// </summary>

        public DateTime DatumPocetkaZabrane { get; set; }
        /// <summary>
        /// duzina trajanje zabrane u godinama
        /// </summary>
        public int DuzinaTrajanjaZabraneUGodinama { get; set; }
    }
}
