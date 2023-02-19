using Kupac__Mikroservis.Models;

namespace Kupac__Mikroservis.Interfaces
{
    public interface IKupacRepository
    {
        ICollection<Kupac> GetKupacs();

        Kupac GetKupacById(int id);

        bool KupacExist(int KupId);

        bool CreateKupac(Kupac kupac);
        bool Save();

        bool UpdateKupac(Kupac kupac);
        bool DeleteKupac(Kupac kupac);
    }
}
