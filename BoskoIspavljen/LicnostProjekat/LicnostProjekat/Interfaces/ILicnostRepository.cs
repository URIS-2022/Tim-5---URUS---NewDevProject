using LicnostProjekat.Models;

namespace LicnostProjekat.Interfaces
{
    public interface ILicnostRepository
    {
        public Licnost getLicnostByID(int id);
        public ICollection<Licnost> getAllLicnosts();
        bool CreateLicnost(Licnost licnost);
        bool Save();
        bool UpdateLicnost(Licnost licnost);
        bool DeleteLicnost(Licnost licnost);
    }
}
