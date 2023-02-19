using Komisija_Sergej.Models;

namespace Komisija_Sergej.Interfaces
{
    public interface IKomisijaRepository
    {
        ICollection<Komisija> GetKomisijas();

        Komisija GetKomisijaByID(int id);
        bool CreateKomisija(Komisija komisija);
        bool Save();
        bool UpdateKomisija(Komisija komisija);
        bool DeleteKomisija(Komisija komisija);

        bool KomisijaExsists(int id);
    }
}
