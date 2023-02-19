﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LicnostProjekat.Data.DTO
{
    public class PravnoLicePostDTO
    {
        [Key]
       [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int PravnoLiceID { get; set; }
        public String Ime { get; set; }
        public String Prezime { get; set; }
        public String JMBG { get; set; }
        public String BrojTelefona1 { get; set; }
        public String BrojTelefona2 { get; set; }
        public String Faks { get; set; }
        public String Email { get; set; }
        public String BrojRacuna { get; set; }
        [ForeignKey("Adresa")]
        public int AdresaID { get; set; }
        [ForeignKey("Kupac")]
        public int KupacID { get; set; }
    }
}