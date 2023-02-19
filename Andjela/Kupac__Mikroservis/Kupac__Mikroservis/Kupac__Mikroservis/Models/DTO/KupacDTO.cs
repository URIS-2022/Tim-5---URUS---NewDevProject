using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Kupac__Mikroservis.Models.DTO
{
    public class KupacDTO
    {
        /// <summary>
        /// Id kupca
        /// </summary>
        [Key]
        public int KupacID { get; set; }
        /// <summary>
        /// Prioritet
        /// </summary>
        public string Prioritet { get; set; }
        /// <summary>
        /// Lice
        /// </summary>
        public string Lice { get; set; }
        /// <summary>
        /// Ostvarena povrsina
        /// </summary>
        public int OstvarenaPovrsina { get; set; }
        /// <summary>
        /// Da li ima zabranu da/ne
        /// </summary>
        public bool ImaZabranu { get; set; }
        /// <summary>
        /// Id ovlascenog lica
        /// </summary>

        [ForeignKey("OvlascenoLice")]
        public int OvlascenoLiceID { get; set; }
        public OvlascenoLiceDTO OvlascenoLice { get; set; }
    }
}
