using JavnoNadPavle.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace JavnoNadPavle.Dto
{
    public class JavnoNadmetanjeUpdateDTO
    {

        [Key] public int JavnoNadmetanjeID { get; set; }
        public string Tip { get; set; }
        public bool Izuzeto { get; set; }
        public int IzlicitiranaCena { get; set; }
        public int BrojUcesnika { get; set; }
        public int VisinaDopuneDepozita { get; set; }
        public string Status { get; set; }

        [ForeignKey(name: "Nadmetanje")]
        public int NadmetanjeID { get; set; }

        [ForeignKey(name: "Etapa")]
        public int EtapaID { get; set; }
    }
}
