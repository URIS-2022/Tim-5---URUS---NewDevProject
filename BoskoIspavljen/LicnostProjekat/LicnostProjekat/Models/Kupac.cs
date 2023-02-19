using System.ComponentModel.DataAnnotations;

namespace LicnostProjekat.Models
{
    public class Kupac
    {
        [Key]
        public int KupacID { get; set; }
        public String Prioritet { get; set; }
        public String Lice { get; set; }
        public int OstvarenaPovrsina { get; set; }
        public String Uplate { get; set; }
      //  public String OvlascenoLice { get; set; }
        public Boolean ImaZabranu { get; set; }
        public DateTime DatumPocetkaZabrane { get; set; }
        public int DuzinaTrajanjaZabraneUGodinama { get; set; }
        public DateTime DatumPrestankaZabrane { get; set; }
    }
}
