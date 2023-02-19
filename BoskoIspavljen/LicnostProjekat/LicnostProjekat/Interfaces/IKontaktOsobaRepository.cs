using LicnostProjekat.Models;
using LicnostProjekat.Repository;

namespace LicnostProjekat.Interfaces
{
    public interface IKontaktOsobaRepository
    {
        public ICollection<KontaktOsoba> GetKontaktOsobas();
        public KontaktOsoba getKontaktOsobaByID(int id);
        bool CreateKontaktOsoba(KontaktOsoba kontaktOsoba);
        bool Save();
        bool UpdateKontaktOsoba(KontaktOsoba kontaktOsoba);
        bool DeleteKontaktOsoba(KontaktOsoba kontaktOsoba);
    }
}
