using JavnoNadPavle.Models;
using System.Collections.ObjectModel;

namespace JavnoNadPavle.Interfaces
{
    public interface IEtapaRepository
    {
        ICollection<Etapa> GetEtape();
        Etapa GetEtapa(int id);

        bool EtapaExists(int nadId);

        bool CreateEtapa(Etapa etapa);

        bool UpdateEtapa(Etapa etapa);

        bool DeleteEtapa(Etapa etapa);
        bool Save();

    }
}
