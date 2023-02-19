using Licitacija_Project.Data;
using Licitacija_Project.Interface;
using Licitacija_Project.Models;

namespace Licitacija_Project.Repository
{
    public class DokumentVORepository : IDokumentVORepository
    {
       
            private readonly DataContext  _context;
            public DokumentVORepository(DataContext context)
            {
                _context = context;
            }

            public bool CreateDokumentVO(DokumentVO dokumentVO)
            {
                _context.Add(dokumentVO);
                return Save();
            }

            public bool DeleteDokumentVO(DokumentVO dokumentVO)
            {
                _context.Remove(dokumentVO);
                return Save();
            }

            public bool DokumentVOExist(int DokumentID)
            {
                return _context.DokumentVOs.Any(k => k.DokumentID == DokumentID);
            }

            public DokumentVO GetDokumentVOById(int Dokumentid)
            {
                return _context.DokumentVOs.Where(k => k.DokumentID == Dokumentid).FirstOrDefault();
            }

            public ICollection<DokumentVO> GetDokumentVOs()
            {
                return _context.DokumentVOs.OrderBy(k => k.DokumentID).ToList();
            }

            public bool Save()
            {
                var saved = _context.SaveChanges();
                return saved > 0 ? true : false;
            }

            public bool UpdateDokumentVO(DokumentVO dokumentVO)
            {
                _context.Update(dokumentVO);
                return Save();
            }
        }
    }
