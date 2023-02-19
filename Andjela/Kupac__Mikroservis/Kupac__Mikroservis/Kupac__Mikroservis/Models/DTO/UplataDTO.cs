using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Kupac__Mikroservis.Models.DTO
{
    public class UplataDTO
    {
        /// <summary>
        /// Id uplate
        /// </summary>
        [Key]
        public int UplataID { get; set; }
        /// <summary>
        /// Iznos uplate
        /// </summary>
        public double Iznos { get; set; }
        /// <summary>
        /// Uplatilac
        /// </summary>
        public string Uplatilac { get; set; }
        /// <summary>
        /// Svrha uplate
        /// </summary>
        public string SvrhaUplate { get; set; }
        /// <summary>
        /// Datum uplate
        /// </summary>
        public DateTime Datum { get; set; }

        [ForeignKey("Kupac")]
        public int KupacID { get; set; }

        public KupacDTO Kupac { get; set; }
    }
}
