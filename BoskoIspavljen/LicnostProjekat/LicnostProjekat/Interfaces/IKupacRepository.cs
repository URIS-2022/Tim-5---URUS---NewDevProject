using LicnostProjekat.Models;

namespace LicnostProjekat.Interfaces
{
    public interface IKupacRepository
    {
        public ICollection<Kupac> GetKupci();
        public Kupac GetKupacByID(int id);
        bool CreateKupac(Kupac kupac);
        bool Save();
        bool UpdateKupac(Kupac kupac);
        bool DeleteKupac(Kupac kupac);

    }
}
