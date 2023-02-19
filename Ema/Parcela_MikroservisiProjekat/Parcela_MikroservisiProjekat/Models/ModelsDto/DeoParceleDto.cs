namespace Parcela_MikroservisiProjekat.Models.ModelsDto
{
    /// <summary>
    /// Predstavlja model dela parcele
    /// </summary>
    public class DeoParceleDto
    {
        /// <summary>
        /// Id dela parcele
        /// </summary>
        public int deoParceleId { get; set; }

        /// <summary>
        /// Povrsina dela parcele
        /// </summary>
        public string povrsina { get; set; }

        /// <summary>
        /// Redi broj dela parcele
        /// </summary>
        public int redniBroj { get; set; }
    }
}
