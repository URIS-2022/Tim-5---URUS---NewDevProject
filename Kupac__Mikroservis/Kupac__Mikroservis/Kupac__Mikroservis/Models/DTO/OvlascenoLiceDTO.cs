using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Kupac__Mikroservis.Models.DTO
{
    public class OvlascenoLiceDTO
    {
        /// <summary>
        /// Id ovlascenog lica
        /// </summary>
        [Key]
        public int OvlascenoLiceID { get; set; }
        /// <summary>
        /// Ime ovlascenog lica
        /// </summary>
        public string Ime { get; set; }
        /// <summary>
        /// Prezime ovlascenog lica
        /// </summary>
        public string Prezime { get; set; }
        /// <summary>
        /// Drzava iz koje je ovlasceno lice
        /// </summary>
        public string Drazava { get; set; }

        [ForeignKey("AdresaVO")]
        public int AdresaID { get; set; }

        public AdresaVODTO Adresa { get; set; }
    }
}
