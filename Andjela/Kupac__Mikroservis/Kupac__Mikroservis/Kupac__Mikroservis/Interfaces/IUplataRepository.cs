using Kupac__Mikroservis.Models;

namespace Kupac__Mikroservis.Interfaces
{
    public interface IUplataRepository
    {
        ICollection<Uplata> GetUplatas();

        Uplata GetUplataById(int id);


        bool UplataExist(int UpltId);

        bool CreateUplata(Uplata uplata);
        bool Save();

        bool UpdateUplata(Uplata uplata);
        bool DeleteUplata(Uplata uplata);

    }
}
