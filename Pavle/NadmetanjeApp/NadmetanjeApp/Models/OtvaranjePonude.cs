

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection.Metadata.Ecma335;

namespace NadmetanjeApp.Models
{
    public class OtvaranjePonude
    {
        
        [Key] public int OtvaranjePonudeID { get; set; }

        [ForeignKey(name:"Nadmetanje")]
        public int NadmetanjeID { get; set;}
        public Nadmetanje Nadmetanje { get; set; }
    }
}
