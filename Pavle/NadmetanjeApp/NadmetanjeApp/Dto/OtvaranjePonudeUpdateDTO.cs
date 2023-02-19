using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace NadmetanjeApp.Dto
{
    public class OtvaranjePonudeUpdateDTO
    {

        [Key] 
        public int OtvaranjePonudeID { get; set; }

        [ForeignKey(name: "Nadmetanje")]
        public int NadmetanjeID { get; set; }
    }
}
