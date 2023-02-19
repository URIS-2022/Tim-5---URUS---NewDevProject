using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Licitacija_Project.Models
{
    public class DokumentVO { 
   [Key]

    public int DokumentID { get; set; }

    public int ZavodniBroj { get; set; }

    public DateTime Datum { get; set; }

    public DateTime DatumDonosenjaDokumenta { get; set; }

    public string Sablon { get; set; }

}
}
