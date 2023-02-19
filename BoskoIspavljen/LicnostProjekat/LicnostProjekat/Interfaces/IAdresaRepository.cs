using LicnostProjekat.Models;

namespace LicnostProjekat.Interfaces
{
    public interface IAdresaRepository
    {
        ICollection<Adresa> GetAdresas();
        Adresa getAdresaByID(int id);
        bool CreateAdresa(Adresa adresa);
        bool Save();
        bool UpdateAdresa(Adresa adresa);
        bool DeleteAdresa(Adresa adresa);
    }
}
