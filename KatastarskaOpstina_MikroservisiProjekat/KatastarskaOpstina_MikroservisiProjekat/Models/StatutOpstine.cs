using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace KatastarskaOpstina_MikroservisiProjekat.Models
{
    public class StatutOpstine
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int statutOpstineID { get; set; }
        public string clan { get; set; }
        public string stav { get; set; }
        public string tacka { get; set; }

        [ForeignKey("KatastarskaOpstina")]
        public int katastarskaOpstinaID { get; set; }
        public KatastarskaOpstina katastarskaOpstina { get; set; }
    }
}
