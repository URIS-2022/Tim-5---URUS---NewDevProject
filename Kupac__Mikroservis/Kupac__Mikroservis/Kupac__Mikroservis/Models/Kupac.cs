using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Kupac__Mikroservis.Models
{
    public class Kupac
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

        [ForeignKey("OvlascenoLice")]
        public int OvlascenoLiceID { get; set; }
        public OvlascenoLice OvlascenoLice { get; set; }


    }
}
