using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Licitacija_Project.Models
{
    public class JavnoNadmetanjeVO
    {
        [Key]
        public int JavnoNadmetanjeID { get; set; }

        public string VremeKraja { get; set; }

        public string Tip { get; set; }

        public Boolean Izuzeto { get; set; }

        public int IzlicitiranaCena { get; set; }

        public int PeriodZakupa { get; set; }

        public int BrojUcesnika { get; set; }

        public int VisinaDopuneDepozita { get; set; }

        public string Status { get; set; }
    }
}