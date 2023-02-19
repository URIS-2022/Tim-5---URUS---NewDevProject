using System.ComponentModel.DataAnnotations;

namespace Licitacija_Project.Models.DTO
{
    public class DokumentVODTO
    {
        
        public int DokumentID { get; set; }

        public int ZavodniBroj { get; set; }

        public DateTime DatumDonosenjaDokumenta { get; set; }
        public string Sablon { get; set; }

    }
}