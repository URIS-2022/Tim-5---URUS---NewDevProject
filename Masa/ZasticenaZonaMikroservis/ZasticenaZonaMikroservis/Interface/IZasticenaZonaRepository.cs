using System.Diagnostics.Metrics;
using ZasticenaZonaMikroservis.Models;

namespace ZasticenaZonaMikroservis.Interface
{
    public interface IZasticenaZonaRepository
    {
        ICollection<ZasticenaZona> GetZasticeneZone();

        ZasticenaZona GetZasticenaZona(int id);

        bool ZasticenaZonaExsists(int id);

        bool UpdateZasticenaZona(ZasticenaZona zasticenaZona);
        bool DeleteZasticenaZona(ZasticenaZona zasticenaZona);

        bool Save();
        bool CreateZasticenaZona(ZasticenaZona zasticenaZonaMap);
    }
}
