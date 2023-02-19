using UgovorOZakupu.Models;

namespace UgovorOZakupu.Interfaces
{
    public interface ILicnostRepository
    {
        ICollection<LicnostVO> GetLicnosti();

        LicnostVO GetLicnostByID(int id);

        bool LicnostExsists(int id);

        bool UpdateLicnost(LicnostVO licnost);
        bool DeleteLicnost(LicnostVO licnost);

        bool Save();
        bool CreateLicnost(LicnostVO licnostMap);
    }
}
