using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace UgovorOZakupu.Models
{
    public class DokumentVO
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int DokumentID { get; set; }

      
        public string ZavodniBroj { get; set; }

        public DateTime Datum { get; set; }
        public DateTime DatumDonosenjaDokumenta { get; set; }
        public string Sablon { get; set; }


    }
}
