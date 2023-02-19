using Zalba_Mikroservis.Data;
using Zalba_Mikroservis.Models;

namespace Zalba_Mikroservis.Interfaces
{
    public interface IZalbaRepository
    {
        ICollection<Zalba> GetZalbas();
        Zalba GetZalbaById(int id);

        bool ZalbaExist(int ZalId);

        bool CreateZalba(Zalba zalba);
        bool Save();

        bool UpdateZalba(Zalba zalba);
        bool DeleteZalba(Zalba zalba);


    }
}
