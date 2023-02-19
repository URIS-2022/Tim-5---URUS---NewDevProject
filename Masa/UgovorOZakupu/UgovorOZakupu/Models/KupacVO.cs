using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace UgovorOZakupu.Models
{
    public class KupacVO
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int KupacID { get; set; }
        public string Prioritet { get; set; }
        public string Lice { get; set; }
        public int OstvarenaPovrsina { get; set; }
   
        public bool ImaZabranu { get; set; }
      
        public DateTime DatumPocetkaZabrane { get; set; }
        public int DuzinaTrajanjaZabraneUGodinama { get; set; }
        
        public DateTime DatumPrestankaZabrane { get; set; }



    }
}
