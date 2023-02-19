using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Zalba_Mikroservis.Models.DTO
{
    public class ZalbaDTO
    {
        /// <summary>
        /// Id zalbe 
        /// </summary>
        [Key]
        public int ZalbaID { get; set; }
        /// <summary>
        /// Tip zalbe
        /// </summary>
        public string Tip { get; set; }
        /// <summary>
        /// Podnosilac zalbe
        /// </summary>
        public string PodnosilacZalbe { get; set; }
        /// <summary>
        /// Razlog zalbe
        /// </summary>
        public string RazlogZalbe { get; set; }
        /// <summary>
        /// Obrazlozenje
        /// </summary>
        public string Obrazlozenje { get; set; }
        /// <summary>
        /// Status zalbe
        /// </summary>
        public string StatusZalbe { get; set; }
        /// <summary>
        /// Radnja na osnovu zalbe
        /// </summary>
        public string RadnjaNaOsnovuZalbe { get; set; }

        /// <summary>
        /// Id kupca koji je podneo zalbu
        /// </summary>
        [ForeignKey("KupacVO")]
        public int KupacID { get; set; }

        public KupacVODTO Kupac { get; set; }

    }
}
