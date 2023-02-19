namespace LicnostProjekat.Data.DTO
{
    public class AdresaDTO
    {
        /// <summary>
        /// Predstavlja model Adrese
        /// </summary>
        public int AdresaID { get; set; }
        /// <summary>
        /// Predstavlja ID Adrese
        /// </summary>
        public String Ulica { get; set; }
        /// <summary>
        /// Predstavlja naziv Ulice
        /// </summary>
        public String Broj { get; set; }
        /// <summary>
        /// Predstavlja Broj u ulici
        /// </summary>
        public String Mesto { get; set; }
        /// <summary>
        /// Predstavlja Grad 
        /// </summary>
        public String PostanskiBroj { get; set; }
        /// <summary>
        /// Predstavlja Postanski Broj grada
        /// </summary>
        public String Drzava { get; set; }
        /// <summary>
        /// Predstavlja naziv drzave
        /// </summary>
    }
}
