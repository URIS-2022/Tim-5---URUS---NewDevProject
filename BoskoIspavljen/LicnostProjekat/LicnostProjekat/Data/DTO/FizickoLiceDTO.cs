using LicnostProjekat.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace LicnostProjekat.Data.DTO
{
    public class FizickoLiceDTO
    {
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
        public String JMBG { get; internal set; }
        /// <summary>
        /// Predstavlja JMBG Fizickog Lica
        /// </summary>
        /// public Adresa adresa { get; set; }
        public Adresa adresa { get; set; }
        public KontaktOsoba KontaktOsoba { get; set; }
        public Licnost Licnost { get; set; }
    } 
}
