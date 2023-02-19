using Licitacija_Project.Models;

namespace Licitacija_Project.Interface
{
    public interface ILicitacijaRepository 
    {

        ICollection<Licitacija> GetLicitacijas();

        Licitacija GetLicitacijaById(int licitacijaID);

        bool CreateLicitacija(Licitacija licitacija);

        bool UpdateLicitacija(Licitacija licitacija);
        bool Save();

        bool DeleteLicitacija(Licitacija licitacija);

        bool LicitacijaExist(int licitacijaID);

    }
}
