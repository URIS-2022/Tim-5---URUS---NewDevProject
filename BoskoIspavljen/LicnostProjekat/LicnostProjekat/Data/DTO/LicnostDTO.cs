namespace LicnostProjekat.Data.DTO
{
    public class LicnostDTO
    {
        public int LicnostID { get; set; }
        /// <summary>
        /// Predstavlja ID Licnosti
        /// </summary>
        public String Ime { get; set; }
        /// <summary>
        /// Predstavlja IME Licnosti
        /// </summary>
        public String Prezime { get; set; }
        /// <summary>
        /// Predstavlja Prezime Licnosti
        /// </summary>
        public String Funkcija { get; set; }
        /// <summary>
        /// Predstavlja Funkciju Licnosti
        /// </summary>
        public int KupacID { get; set; }
        /// <summary>
        /// Predstavlja ID Kupca
        /// </summary>
        
        public KupacDTO kupac { get; set; }
    }
}
