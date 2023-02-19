using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Parcela_MikroservisiProjekat.Models.ModelsDto;

namespace Parcela_MikroservisiProjekat.Models
{
    public class KatastarskaOpstinaVO
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int katastarskaOpstinaId { get; set; }
        public string katastarskaOpstinaNaziv { get; set; }

        
    }
}
