using JavnoNadPavle.Models;

namespace JavnoNadPavle.Interfaces
{
    public interface IJavnoNadmetanjeRepository
    {

        ICollection<JavnoNadmetanje> GetJavnaNadmetanja();
            JavnoNadmetanje GetJavnaNadmetanje(int id);

            bool JavnoNadmetanjeExists(int nadId);

            bool CreateJavnoNadmetanje(JavnoNadmetanje javnoNadmetanje);

            bool UpdateJavnoNadmetanje(JavnoNadmetanje javnoNadmetanje);

            bool DeleteJavnoNadmetanje(JavnoNadmetanje javnoNadmetanje);
            bool Save();

    }
}
