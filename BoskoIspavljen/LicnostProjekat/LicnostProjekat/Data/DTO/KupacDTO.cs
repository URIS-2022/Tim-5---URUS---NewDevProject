namespace LicnostProjekat.Data.DTO
{
    public class KupacDTO
    {
        public int KupacID { get; set; }
        /// <summary>
        /// Predstavlja ID Kupca
        /// </summary>
        public String Prioritet { get; set; }
        /// <summary>
        /// Predstavlja Prioritet Kupca
        /// </summary>
        public String Lice { get; set; }
        /// <summary>
        /// Predstavlja Lice 
        /// </summary>
        public int OstvarenaPovrsina { get; set; }
        /// <summary>
        /// Predstavlja Ostvarenu povrsinu Kupca
        /// </summary>
        public String Uplate { get; set; }
        
       // public String OvlascenoLice { get; set; }
        /// <summary>
        /// Predstavlja Ovlasceno lice od strane Kupca
        /// </summary>
        public Boolean ImaZabranu { get; set; }
        /// <summary>
        /// kaze da li kupac ima zabranu
        /// </summary>
    }
}
