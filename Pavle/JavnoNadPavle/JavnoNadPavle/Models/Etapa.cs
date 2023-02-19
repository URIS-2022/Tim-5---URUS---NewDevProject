using System.ComponentModel.DataAnnotations;

namespace JavnoNadPavle.Models
{
    public class Etapa
    {
        [Key] public int EtapaID { get; set; }
        public int Atr { get; set; }
    }
}
