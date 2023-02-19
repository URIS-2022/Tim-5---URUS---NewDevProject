using Dokument_Sergej.Models;

namespace Dokument_Sergej.Interfaces
{
    public interface ILicnostRepository
    {
        ICollection<Licnost> GetLicnosti();
        Licnost GetLicnostByID(int id);
        bool CreateLicnost(Licnost licnost);
        bool Save();
        bool UpdateLicnost(Licnost licnost);
        bool DeleteLicnost(Licnost licnost);
        bool LicnostExsists(int id);

    }
}
