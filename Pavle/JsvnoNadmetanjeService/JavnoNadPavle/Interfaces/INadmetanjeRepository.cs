using JavnoNadPavle.Models;

namespace JavnoNadPavle.Interfaces
{
    public interface INadmetanjeRepository
    {
       
        ICollection<Nadmetanje> GetNadmetanja();

        Nadmetanje GetNadmetanje(int id);

        bool NadmetanjeExists(int nadId);

        bool CreateNadmetanje(Nadmetanje nadmetanje);

        bool UpdateNadmetanje(Nadmetanje nadmetanje);

        bool DeleteNadmetanje(Nadmetanje nadmetanje);
        bool Save();

    }
}
