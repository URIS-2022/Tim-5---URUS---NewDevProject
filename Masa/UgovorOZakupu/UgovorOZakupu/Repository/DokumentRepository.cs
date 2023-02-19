using UgovorOZakupu.Data;
using UgovorOZakupu.Interfaces;
using UgovorOZakupu.Models;

namespace UgovorOZakupu.Repository
{
    public class DokumentRepository : IDokumentRepository
    {
        private readonly ApplicationContext _context;
        public DokumentRepository(ApplicationContext context)
        {
            _context = context;
        }

        public DokumentRepository()
        {

        }
        public bool CreateDokument(DokumentVO dokumentMap)
        {
            _context.Add(dokumentMap);
            _context.SaveChanges();
            return Save();
            throw new NotImplementedException();
        }

        public bool DeleteDokument(DokumentVO dokument)
        {
            _context.Remove(dokument);
            return Save();
            throw new NotImplementedException();
        }

        public bool DokumentExsists(int id)
        {
            return _context.Dokumenta.Any(p => p.DokumentID == id);
            throw new NotImplementedException();
        }

        public ICollection<DokumentVO> GetDokumenti()
        {
            return _context.Dokumenta.OrderBy(p => p.DokumentID).ToList();
            throw new NotImplementedException();
        }

        public DokumentVO GetJDokumentByID(int id)
        {
            return _context.Dokumenta.Where(p => p.DokumentID == id).FirstOrDefault();
            throw new NotImplementedException();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
            throw new NotImplementedException();
        }

        public bool UpdateDokumentv(DokumentVO dokument)
        {
            _context.Update(dokument);
            return Save();
            throw new NotImplementedException();
        }
    }
}
