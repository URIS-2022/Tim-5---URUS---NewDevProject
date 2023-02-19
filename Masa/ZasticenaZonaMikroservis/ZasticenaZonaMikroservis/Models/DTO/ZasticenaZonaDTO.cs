using System.ComponentModel.DataAnnotations;

namespace ZasticenaZonaMikroservis.Models.DTO
{
    /// <summary>
    /// Predstavlja model zasticene zone
    /// </summary>
    public class ZasticenaZonaDTO
    {
        /// <summary>
        /// Id zasticene zone
        /// </summary>
        public int ZasticenaZonaID { get; set; }
        /// <summary>
        /// dozvoljeni radovi u okviru zasticene zone
        /// </summary>
        public string DozvoljeniRadovi { get; set; }

        /// <summary>
        /// Stepen zastite zasticene zone
        /// </summary>

        public int StepenZastite { get; set; }

        /// <summary>
        /// vrsta zasticenog podrucja
        /// </summary>
        public string VrstaZasticenogPodrucja { get; set; }
    }
}
