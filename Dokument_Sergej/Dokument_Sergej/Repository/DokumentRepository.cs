using Dokument_Sergej.Data;
using Dokument_Sergej.Interfaces;
using Dokument_Sergej.Models;
using Microsoft.EntityFrameworkCore;

namespace Dokument_Sergej.Repository
{
    public class DokumentRepository : IDokumentRepository
    {
        private readonly DataContext _context;
        public DokumentRepository(DataContext context)
        {
            _context= context;  
        }

        public bool CreateDokument(Dokument dokument)
        {
            _context.Add(dokument);
            return Save();
        }

        public bool DeleteDokument(Dokument dokument)
        {
            _context.Remove(dokument);  
            return Save();
        }

        public bool DokumentExsists(int id)
        {
            return _context.Dokumenti.Any(p => p.DokumentID == id);
        }

        public Dokument GetDokumentByID(int id)
        {
            return _context.Dokumenti.Where(p => p.DokumentID == id).Include(x => x.KorisnikSistema).Include(x => x.Licnost).FirstOrDefault();
        }

        public ICollection<Dokument> GetDokumenti () { 
            return _context.Dokumenti.OrderBy(p => p.DokumentID)/*.Include(x => x.KorisnikSistema).Include(x => x.Licnost)*/.ToList();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges(); 
            return saved>0? true: false;   
        }

        public bool UpdateDokument(Dokument dokument)
        {
            _context.Update(dokument);
            return Save();
        }
    }
}
