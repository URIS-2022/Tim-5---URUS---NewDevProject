using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace UgovorOZakupu.Models
{
    public class UgovorOZakupu
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UgovorID { get; set; }
        public string Odluka { get; set; }
        public string TipGarancije { get; set; }
        public string Lice { get; set; }
        public int RokoviDospeca { get; set; }
        public string ZavodniBroj { get; set; }
       
        public DateTime DatumZavodjenja { get; set; }
        public string Ministar { get; set; }
        
        public DateTime RokZaVracanjeZemljista { get; set; }
        public string MestoPotpisivanja { get; set; }
      
        public DateTime DatumPotpisa { get; set; }

        
        [ForeignKey("JavnoNadmetanjeVO")]
        public int javnoNadmetanjeID { get; set; }
        public JavnoNadmetanjeVO javnoNadmetanje { get; set; }

        [ForeignKey("DokumentVO")]
        public int dokumentID { get; set; }
        public DokumentVO dokument { get; set; }


        [ForeignKey("KupacVO")]
        public int kupacID { get; set; }
        public KupacVO kupac { get; set; }

        [ForeignKey("LicnostVO")]
        public  int licnostID { get; set; } 
        public LicnostVO licnost { get; set; }
     /*   public List<JavnoNadmetanjeVO> javnaNadmetanja { get; set; }
        public List<DokumentVO> dokumenti { get; set; }
        public List<KupacVO> kupci { get; set; }
        public List<LicnostVO> licnosti { get; set; }*/
    }
}
