using Kupac__Mikroservis.Models;

namespace Kupac__Mikroservis.Interfaces
{
    public interface IOvlascenoLiceRepository
    {
        ICollection<OvlascenoLice> GetOvlascenoLices();

        OvlascenoLice GetOvlascenoLiceById(int id);


        bool OvlascenoLiceExist(int OvlLiceId);

        bool CreateOvlascenoLice(OvlascenoLice ovlascenoLice);
        bool Save();

        bool UpdateOvlascenoLice(OvlascenoLice ovlascenoLice);
        bool DeleteOvlascenoLice(OvlascenoLice ovlascenoLice);

    }
}
