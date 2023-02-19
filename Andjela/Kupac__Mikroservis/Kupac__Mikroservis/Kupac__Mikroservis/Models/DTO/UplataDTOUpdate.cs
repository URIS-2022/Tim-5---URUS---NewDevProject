namespace Kupac__Mikroservis.Models.DTO
{
    public class UplataDTOUpdate
    {
        public int UplataID { get; set; }
        public string BrojRacuna { get; set; }
        public string PozivNaBroj { get; set; }
        public double Iznos { get; set; }
        public string Uplatilac { get; set; }
        public string SvrhaUplate { get; set; }
        public DateTime Datum { get; set; }

        public int KupacID { get; set; }
    }
}
