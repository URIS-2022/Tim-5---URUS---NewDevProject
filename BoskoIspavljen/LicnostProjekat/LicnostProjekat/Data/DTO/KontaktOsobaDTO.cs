namespace LicnostProjekat.Data.DTO
{
    public class KontaktOsobaDTO
    {
        public int KontaktOsobaID { get; set; }
        /// <summary>
        /// Predstavlja ID Kontakt Osobe
        /// </summary>
        public String Ime { get; set; }
        /// <summary>
        /// Predstavlja Ime Kontakt Osobe
        /// </summary>
        public String Prezime { get; set; }
        /// <summary>
        /// Predstavlja Prezime Kontakt Osobe
        /// </summary>
        public String Funkcija { get; set; }
        /// <summary>
        /// Predstavlja Funkciju Kontakt Osobe
        /// </summary>
        public String Telefon { get; set; }
        /// <summary>
        /// Predstavlja Telefon Kontakt Osobe
        /// </summary>
    }
}
