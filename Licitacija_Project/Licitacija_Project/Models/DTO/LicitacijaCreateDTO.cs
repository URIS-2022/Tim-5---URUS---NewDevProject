using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Licitacija_Project.Models.DTO
{
    public class LicitacijaCreateDTO
    {
        [Key]
        public int LicitacijaID { get; set; }

        public int Godina { get; set; }

        public DateTime Datum { get; set; }

        public int Ogranicenje { get; set; }

        public int KorakCene { get; set; }

        public string ListaDokumentacijeFizickaLica { get; set; }

        public string ListaDokumentacijePravnaLica { get; set; }

        public string RokZaDostavljanjePrijava { get; set; }

        [ForeignKey("JavnoNadmetanjeVO")]

        public int JavnoNadmetanjeID { get; set; }

        [ForeignKey("DokumentVO")]

        public int DokumentID { get; set; }

    }
}
