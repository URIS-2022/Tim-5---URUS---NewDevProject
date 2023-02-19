
using UgovorOZakupu.Models;
using UgovorOZakupu.Models.DTOs;

namespace UgovorOZakupu.Interfaces

{
    public interface IUgovorOZakupuRepository
    {
        ICollection<Models.UgovorOZakupu> GetUgovoriOZakupu();

        Models.UgovorOZakupu GetUgovorOZakupuByID(int id);

        bool UgovorOZakupuExsists(int id);

        bool UpdateUgovorOZakupu(Models.UgovorOZakupu ugovor);
        bool DeleteUgovorOZakupu(Models.UgovorOZakupu ugovor);

        bool Save();
        bool CreateUgovorOZakupu(Models.UgovorOZakupu ugovorMap);
    }
}
