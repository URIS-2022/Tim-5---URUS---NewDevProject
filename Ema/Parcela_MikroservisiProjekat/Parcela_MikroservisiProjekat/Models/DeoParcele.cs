using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Parcela_MikroservisiProjekat.Models
{
    public class DeoParcele
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int deoParceleId { get; set; }
        public string povrsina { get; set; }
        public int redniBroj { get; set; }
    }
}
