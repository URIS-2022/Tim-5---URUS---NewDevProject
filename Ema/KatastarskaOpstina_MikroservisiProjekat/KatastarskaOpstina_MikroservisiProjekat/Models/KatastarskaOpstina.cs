using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace KatastarskaOpstina_MikroservisiProjekat.Models
{
    public class KatastarskaOpstina
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int katastarskaOpstinaId { get; set; }
        public string katastarskaOpstinaNaziv { get; set; }
    }
}
