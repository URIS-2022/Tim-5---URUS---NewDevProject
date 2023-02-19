using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LicnostProjekat.Data.DTO
{
    public class FizickoLicePostDTO
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int FizickoLiceID { get; set; }
        /// <summary>
        /// Predstavlja ID Fizickog lica
        /// </summary>
        public String Ime { get; set; }
        /// <summary>
        /// Predstavlja Ime Fizickog Lica
        /// </summary>
        public String Prezime { get; set; }
        /// <summary>
        /// Predstavlja Prezime FIzickog Lica
        /// </summary>
        public String BrojTelefona1 { get; set; }
        /// <summary>
        /// Predstavlja broj telefona
        /// </summary>
        public String BrojTelefona2 { get; set; }
        /// <summary>
        /// Predstavlja broj telefona
        /// </summary>
        public String Email { get; set; }
        /// <summary>
        /// Predstavlja Email adresu Fizickog lica
        /// </summary>
        public String JMBG { get;  set; }
        /// <summary>
        /// Predstavlja JMBG Fizickog Lica
        /// </summary>
        public String BrojRacuna { get; set; }

        public int AdresaID { get; set; }
        public int KontaktOsobaID { get; set; }
        public int LicnostID { get; set; }
    }
}
