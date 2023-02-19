using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZasticenaZonaMikroservis.Models
{
    public class ZasticenaZona
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ZasticenaZonaID { get; set; }
        public string DozvoljeniRadovi { get; set; }
        public int StepenZastite { get; set; }
        public string VrstaZasticenogPodrucja { get; set; }

    }
}
