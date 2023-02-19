

using System.ComponentModel.DataAnnotations;

namespace NadmetanjeApp.Models
{
    public class Nadmetanje

    {

        [Key] public int NadmetanjeID { get; set; }   
       
        public DateTime Datum { get; set; }
        public int Krug { get; set; }
        public int CenaPoHektaru { get; set; }
    }

    
}
