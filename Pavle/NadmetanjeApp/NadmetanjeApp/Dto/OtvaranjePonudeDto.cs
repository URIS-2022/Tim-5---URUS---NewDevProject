using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using NadmetanjeApp.Models;

namespace NadmetanjeApp.Dto
{
    public class OtvaranjePonudeDto
    {
        [Key] public int OtvaranjePonudeID { get; set; }

        [ForeignKey(name: "Nadmetanje")]
        public int NadmetanjeID { get; set; }
        public NadmetanjeDto NadmetanjeDto { get; set; }
    }
}
