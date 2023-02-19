using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace UgovorOZakupu.Models.DTOs
{
    /// <summary>
    /// Predstavlja model ugovora o zakupu za update objekta
    /// </summary>
    public class UgovorOZakupuDTOUpdate
    {
        [Key]
        /// <summary>
        /// Id ugovora
        /// </summary>
        public int UgovorID { get; set; }

        /// <summary>
        /// odluka
        /// </summary>
        public string Odluka { get; set; }

        /// <summary>
        /// tip garancije
        /// </summary>
        public string TipGarancije { get; set; }

        /// <summary>
        /// lice
        /// </summary>

        public string Lice { get; set; }
        /// <summary>
        /// rokovi dospeca
        /// </summary>
        public int RokoviDospeca { get; set; }

        /// <summary>
        /// zavodni broj
        /// </summary>

        public string ZavodniBroj { get; set; }

        /// <summary>
        /// datum zavodjenja
        /// </summary>

        public DateTime DatumZavodjenja { get; set; }
        /// <summary>
        /// ministar
        /// </summary>

        public string Ministar { get; set; }

        /// <summary>
        /// rok za vracanje zemljista
        /// </summary>

        public DateTime RokZaVracanjeZemljista { get; set; }

        /// <summary>
        /// mesto potpisivanja
        /// </summary>

        public string MestoPotpisivanja { get; set; }

        /// <summary>
        /// datum potpisivanja
        /// </summary>

        public DateTime DatumPotpisa { get; set; }


        [ForeignKey("JavnoNadmetanjeVO")]
        /// <summary>
        /// strani kljuc - javno nadmetanje id
        /// </summary>

        public int javnoNadmetanjeID { get; set; }
        // public JavnoNadmetanjeVO javnoNadmetanje { get; set; }

        [ForeignKey("DokumentVO")]
        /// <summary>
        /// strani kljuc - dokument id
        /// </summary>

        public int dokumentID { get; set; }
        // public DokumentVO dokument { get; set; }


        [ForeignKey("KupacVO")]
        /// <summary>
        /// strani kljuc - kupac id
        /// </summary>

        public int kupacID { get; set; }

        // public KupacVO kupac { get; set; }
        [ForeignKey("LicnostVO")]
        /// <summary>
        /// strani kljuc - licnost id
        /// </summary>

        public int licnostID { get; set; }
        // public LicnostVO licnost { get; set; }
    }
}
