namespace UgovorOZakupu.Models.DTOs
{
    /// <summary>
    /// Predstavlja model licnosti
    /// </summary>
    public class LicnostVOdto
    {
        /// <summary>
        /// Id licnosti
        /// </summary>
        public int LicnostID { get; set; }

        /// <summary>
        /// Ime licnosti
        /// </summary>
        public string Ime { get; set; }
        /// <summary>
        /// prezime licnosti
        /// </summary>
        public string Prezime { get; set; }
        /// <summary>
        /// funkcije licnosti
        /// </summary>
        public string Funkcija { get; set; }
    }
}
