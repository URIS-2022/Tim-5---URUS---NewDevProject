using UgovorOZakupu.Models;

namespace UgovorOZakupu.Interfaces
{
    public interface IJavnoNadmetanjeRepository
    {
        ICollection<JavnoNadmetanjeVO> GetJavnaNadmetanja();

        JavnoNadmetanjeVO GetJavnoNadmetanjeByID(int id);

        bool JavnoNadmetanjeExsists(int id);

        bool UpdateJavnoNadmetanje(JavnoNadmetanjeVO javnonadmetanje);
        bool DeleteJavnoNadmetanje(JavnoNadmetanjeVO javnonadmetanje);

        bool Save();
        bool CreateJavnoNadmetanje(JavnoNadmetanjeVO javnonadmetanjeMap);
    }
}
