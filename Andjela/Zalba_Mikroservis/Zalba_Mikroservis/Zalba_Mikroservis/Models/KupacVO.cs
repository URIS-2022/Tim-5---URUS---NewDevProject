using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Zalba_Mikroservis.Models
{
    public class KupacVO
    {
        [Key]
        public int KupacID { get; set; }
        public string Prioritet { get; set; }
        public string Lice { get; set; }
        public int OstvarenaPovrsina { get; set; }
        public bool ImaZabranu { get; set; }
        public DateTime DatumPocetkaZabrane { get; set; }
        public int DuzinaTrajanjaZabraneUGodinama { get; set; }
        public DateTime DatumPrestankaZabrane { get; set; }
        //public ICollection<KupacVO> Kupac { get; set; }

        
    }
}
