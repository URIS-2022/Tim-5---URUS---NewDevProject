using System.ComponentModel.DataAnnotations;

namespace Kupac__Mikroservis.Models.DTO
{
    public class AdresaVODTO
    {
        /// <summary>
        /// Id adrese
        /// </summary>
        [Key]
        public int AdresaID { get; set; }
        /// <summary>
        /// Naziv mesta
        /// </summary>
        public string Mesto { get; set; }
        /// <summary>
        /// Postanski broj grada
        /// </summary>
        public string PostanskiBroj { get; set; }
        /// <summary>
        /// Naziv drzave
        /// </summary>
        public string Drzava { get; set; }


    }
}
