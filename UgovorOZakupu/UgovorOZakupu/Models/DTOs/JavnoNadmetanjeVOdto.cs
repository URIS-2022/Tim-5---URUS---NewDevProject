namespace UgovorOZakupu.Models.DTOs
{
    /// <summary>
    /// Predstavlja model javnog nadmetanja
    /// </summary>
    public class JavnoNadmetanjeVOdto
    {
        /// <summary>
        /// Id javnog nadmetanja
        /// </summary>
        public int JavnoNadmetanjeID { get; set; }
        /// <summary>
        /// vreme kraja
        /// </summary>
        public string VremeKraja { get; set; }
        /// <summary>
        /// tip
        /// </summary>
        public string Tip { get; set; }
        /// <summary>
        /// izuzeto
        /// </summary>
        public bool Izuzeto { get; set; }
        /// <summary>
        /// izlicitirana cena javnog nadmetanja
        /// </summary>
        public int IzlicitiranaCena { get; set; }
        /// <summary>
        /// broj ucesnika u javnom nadmetanju
        /// </summary>
        public int BrojUcesnika { get; set; }
        /// <summary>
        /// visina dopune depozita
        /// </summary>
        public int VisinaDopuneDepozita { get; set; }
        /// <summary>
        /// status
        /// </summary>

        public string Status { get; set; }
    }
}
