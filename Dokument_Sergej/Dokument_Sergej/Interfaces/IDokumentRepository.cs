using Dokument_Sergej.Models;

namespace Dokument_Sergej.Interfaces
{
    public interface IDokumentRepository
    {
        ICollection<Dokument> GetDokumenti();

        Dokument GetDokumentByID(int id);
        bool CreateDokument(Dokument dokument);
        bool Save();
        bool UpdateDokument(Dokument dokument);
        bool DeleteDokument(Dokument dokument);

        bool DokumentExsists(int id);
    }
}
