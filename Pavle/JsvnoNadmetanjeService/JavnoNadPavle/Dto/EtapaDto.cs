using System.ComponentModel.DataAnnotations;

namespace JavnoNadPavle.Dto
{
    public class EtapaDto
    {
        [Key] public int EtapaID { get; set; }
        public int Atr { get; set; }
    }
}
