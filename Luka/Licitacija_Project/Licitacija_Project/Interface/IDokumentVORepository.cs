using Licitacija_Project.Models;

namespace Licitacija_Project.Interface
{
    public interface IDokumentVORepository
    {
        ICollection<DokumentVO> GetDokumentVOs();

        DokumentVO GetDokumentVOById(int DokumentID);

        bool CreateDokumentVO(DokumentVO dokumentVO);

        bool UpdateDokumentVO(DokumentVO dokumentVO);

        bool Save();

        bool DeleteDokumentVO(DokumentVO dokumentVO);

        bool DokumentVOExist(int DokumentID);

    }
}
