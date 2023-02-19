using UgovorOZakupu.Models;

namespace UgovorOZakupu.Interfaces
{
    public interface IDokumentRepository
    {
        ICollection<DokumentVO> GetDokumenti();

        DokumentVO GetJDokumentByID(int id);

        bool DokumentExsists(int id);

        bool UpdateDokumentv(DokumentVO dokument);
        bool DeleteDokument(DokumentVO dokument);

        bool Save();
        bool CreateDokument(DokumentVO dokumentMap);
    }
}
