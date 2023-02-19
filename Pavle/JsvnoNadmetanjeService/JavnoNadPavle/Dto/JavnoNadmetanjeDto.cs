using JavnoNadPavle.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JavnoNadPavle.Dto
{
    public class JavnoNadmetanjeDto
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
        public NadmetanjeDto NadmetanjeDto { get; set; }

        [ForeignKey(name: "Etapa")]
        public int EtapaID { get; set; }
        public Etapa EtapaDto { get; set; }

    }
}
