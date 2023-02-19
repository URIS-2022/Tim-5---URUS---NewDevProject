using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Parcela_MikroservisiProjekat.Models
{
    public class Parcela
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int parcelaId { get; set; }
        public string povrsina { get; set; }
        public string korisnikParcele { get; set; }
        public int brojParcele { get; set; }
        public int brojListaNepokretnosti { get; set; }
        public string kultura { get; set; }
        public string klasa { get; set; }
        public string obradivost { get; set; }
        public string zasticenaZona { get; set; }
        public string oblikSvojine { get; set; }
        public string odvodnjavanje { get; set; }
        public string kulturaStvarsnoStanje { get; set; }
        public string klasaStvarnoStanje { get; set; }
        public string obradivostStvarnoStanje { get; set; }
        public string zasticenaZonaStvarnoStanje { get; set; }
        public string odvodnjavanjeStvarnoStanje { get; set; }

        [ForeignKey("KatastarskaOpstinaVO")]
        public int katastarskaOpstinaId { get; set; }
        public KatastarskaOpstinaVO katastarskaOpstina { get; set; }



        [ForeignKey("DeoParcele")]
        public int deoParceleId { get; set; }
        public DeoParcele deoParcele { get; set; }


    }
}
