using LicnostProjekat.Models;

namespace LicnostProjekat.Interfaces
{
    public interface IPravnoLiceRepository
    {
        public PravnoLice getPravnoLiceByID(int id);
        public ICollection<PravnoLice> getPravnaLica();
        bool CreatePravnoLice(PravnoLice pravnoLice);
        bool Save();
        bool UpdatePravnoLice(PravnoLice pravnoLice);
        bool DeletePravnoLice(PravnoLice pravnoLice);
    }
}
