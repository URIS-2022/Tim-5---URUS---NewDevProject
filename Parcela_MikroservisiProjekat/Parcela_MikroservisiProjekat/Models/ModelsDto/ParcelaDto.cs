using System.ComponentModel.DataAnnotations.Schema;

namespace Parcela_MikroservisiProjekat.Models.ModelsDto
{
    /// <summary>
    /// Predstavlja model parcele
    /// </summary>
    public class ParcelaDto
    {
        /// <summary>
        /// Id parcele
        /// </summary>
        public int parcelaId { get; set; }

        /// <summary>
        /// Povrsine parcele
        /// </summary>
        public string povrsina { get; set; }

        /// <summary>
        /// Korisnik parcele
        /// </summary>
        public string korisnikParcele { get; set; }

        /// <summary>
        /// Broj parcele
        /// </summary>
        public int brojParcele { get; set; }

        /// <summary>
        /// Broj lista nepokretnosti parcele
        /// </summary>
        public int brojListaNepokretnosti { get; set; }

        /// <summary>
        /// Kultura parcele
        /// </summary>
        public string kultura { get; set; }

        /// <summary>
        /// Klasa parcele
        /// </summary>
        public string klasa { get; set; }

        /// <summary>
        /// Obradivost parcele
        /// </summary>
        public string obradivost { get; set; }

        /// <summary>
        /// Zasticena zona parcele
        /// </summary>
        public string zasticenaZona { get; set; }

        /// <summary>
        /// oblik svojine parcele
        /// </summary>
        public string oblikSvojine { get; set; }

        /// <summary>
        /// Odvodnjavanje parcele
        /// </summary>
        public string odvodnjavanje { get; set; }

        /// <summary>
        /// Kultura stvarno stanje parcele
        /// </summary>
        public string kulturaStvarsnoStanje { get; set; }

        /// <summary>
        /// Klasa stvarno stanje parcele
        /// </summary>
        public string klasaStvarnoStanje { get; set; }

        /// <summary>
        /// Obradivost stvarno stanje parcele
        /// </summary>
        public string obradivostStvarnoStanje { get; set; }

        /// <summary>
        /// Zasticena zona stvarno stanje parcele
        /// </summary>
        public string zasticenaZonaStvarnoStanje { get; set; }

        /// <summary>
        /// Odvodnjavanje stvarno stanje parcele
        /// </summary>
        public string odvodnjavanjeStvarnoStanje { get; set; }


        /// <summary>
        /// Id katastarke opstine (FK)
        /// </summary>
        [ForeignKey("KatastarskaOpstinaVO")]
        public int katastarskaOpstinaId { get; set; }
        public KatastarskaOpstinaVO katastarskaOpstina { get; set; }


        /// <summary>
        /// Id deo parcele (FK)
        /// </summary>
        [ForeignKey("DeoParcele")]
        public int deoParceleId { get; set; }
        public DeoParcele deoParcele { get; set; }


    }
}
