using LicnostProjekat.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace LicnostProjekat.Data.DTO
{
    public class LicnostUpdateDTO
    {
        [Key]
        public int LicnostID { get; set; }
        public String Ime { get; set; }
        public String Prezime { get; set; }
        public String Funkcija { get; set; }
        [ForeignKey("Kupac")]
        public int KupacID { get; set; }
    
    }
}
