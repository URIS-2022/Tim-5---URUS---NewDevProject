using UgovorOZakupu.Models;

namespace UgovorOZakupu.Interfaces
{
    public interface IKupacRepository
    {
        ICollection<KupacVO> GetKupci();

        KupacVO GetKupacByID(int id);

        bool KupacExsists(int id);

        bool UpdateKupac(KupacVO kupac);
        bool DeleteKupac(KupacVO kupac);

        bool Save();
        bool CreateKupac(KupacVO kupacMap);
    }
}
