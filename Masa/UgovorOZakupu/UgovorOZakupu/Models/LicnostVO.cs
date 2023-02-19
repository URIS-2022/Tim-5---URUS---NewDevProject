using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace UgovorOZakupu.Models
{
    public class LicnostVO
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int LicnostID { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string Funkcija { get; set; }


    }
}
