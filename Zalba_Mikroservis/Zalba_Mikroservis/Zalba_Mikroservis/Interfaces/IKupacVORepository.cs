using Zalba_Mikroservis.Models;

namespace Zalba_Mikroservis.Interfaces
{
    public interface IKupacVORepository
    {
        ICollection<KupacVO> GetKupacVOs();

        KupacVO GetKupacVOById(int id);

        
        bool KupacVOExist(int KupId);

        bool CreateKupacVO(KupacVO kupacVO);
        bool Save();

        bool UpdateKupacVO(KupacVO kupacVO);
        bool DeleteKupacVO(KupacVO kupacVO);


    }
}