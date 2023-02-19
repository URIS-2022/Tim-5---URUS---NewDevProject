using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Zalba_Mikroservis.Models.DTO
{
    public class ZalbaDTOCreate
    {
        [Key]
        public int ZalbaID { get; set; }
        public string Tip { get; set; }
        public DateTime DatumPodnosenjaZalbe { get; set; }
        public string PodnosilacZalbe { get; set; }
        public string RazlogZalbe { get; set; }
        public string Obrazlozenje { get; set; }
        public DateTime DatumResenja { get; set; }
        public string BrojResenja { get; set; }
        public string StatusZalbe { get; set; }
        public string BrojOdluka_BrojNadmetanja { get; set; }
        public string RadnjaNaOsnovuZalbe { get; set; }

      //  [ForeignKey("KupacVO")]
        public int KupacID { get; set; }

      //  public KupacVO Kupac { get; set; }
    }
}
