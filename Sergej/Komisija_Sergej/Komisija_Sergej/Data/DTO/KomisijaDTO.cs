namespace Komisija_Sergej.Data.DTO
{
    /// <summary>
    /// Predstavlja model komisije
    /// </summary>
    public class KomisijaDTO
    {
        /// <summary>
        /// Id komisije
        /// </summary>
        public int KomisijaID { get; set; }

        /// <summary>
        /// Predsednik komisije
        /// </summary>
        public string Predsednik { get; set; }

        /// <summary>
        /// Clan komisije
        /// </summary>
        public string Clan { get; set; }
    }
}
