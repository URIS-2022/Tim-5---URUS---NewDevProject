using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace UgovorOZakupu.Models
{
    public class JavnoNadmetanjeVO
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int JavnoNadmetanjeID { get; set; }
        public string VremeKraja { get; set; }
        public string Tip { get; set; }
        public bool Izuzeto { get; set; }
        public int IzlicitiranaCena { get; set; }
        public int BrojUcesnika { get; set; }
        public int VisinaDopuneDepozita { get; set; }

        public string Status { get; set; }


    }
}
