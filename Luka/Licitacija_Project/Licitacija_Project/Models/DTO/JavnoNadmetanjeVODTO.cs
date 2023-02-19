using System.ComponentModel.DataAnnotations;

namespace Licitacija_Project.Models.DTO
{
    public class JavnoNadmetanjeVODTO
    {

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
