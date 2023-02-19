using Licitacija_Project.Models;

namespace Licitacija_Project.Interface
{
    public interface IJavnoNadmetanjeVORepository
    {
        ICollection<JavnoNadmetanjeVO> GetJavnoNadmetanjes();

        JavnoNadmetanjeVO GetJavnoNadmetanjeById(int id);

        bool CreateJavnoNadmetanje(JavnoNadmetanjeVO javnoNadmetanjeVO);

        bool UpdateJavnoNadmetanje(JavnoNadmetanjeVO javnoNadmetanjeVO);

        bool Save();

        bool DeleteJavnoNadmetanje(JavnoNadmetanjeVO javnoNadmetanjeVO);

        bool JavnoNadmetanjeExist(int JavnoNadmetanjeID);

    }
}
