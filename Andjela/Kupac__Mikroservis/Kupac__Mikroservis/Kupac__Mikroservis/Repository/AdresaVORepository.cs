using Kupac__Mikroservis.Data;
using Kupac__Mikroservis.Interfaces;
using Kupac__Mikroservis.Models;

namespace Kupac__Mikroservis.Repository
{
    public class AdresaVORepository : IAdresaVORepository
    {

        private readonly DataContext _context;
        public AdresaVORepository(DataContext context)
        {
            _context = context;
        }

        //EXIST
        public bool AdresaVOExist(int AdrId)
        {
            return _context.AdresaVOs.Any(a => a.AdresaID == AdrId);
            throw new NotImplementedException();
        }

        //POST
        public bool CreateAdresaVO(AdresaVO adresaVO)
        {
            _context.Add(adresaVO);
            _context.SaveChanges();
            return Save();
            throw new NotImplementedException();

        }


        //DELETE
        public bool DeleteAdresaVO(AdresaVO adresaVO)
        {
            _context.Remove(adresaVO);
            return Save();
        }


        //GETBYID
        public AdresaVO GetAdresaVOById(int id)
        {
            return _context.AdresaVOs.Where(a => a.AdresaID == id).FirstOrDefault();
            throw new NotImplementedException();
        }


        //GETALL
        public ICollection<AdresaVO> GetAdresaVOs()
        {
            return _context.AdresaVOs.OrderBy(a => a.AdresaID).ToList();
            throw new NotImplementedException();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
            throw new NotImplementedException();

        }

        //PUT
        public bool UpdateAdresaVO(AdresaVO adresaVO)
        {
            _context.Update(adresaVO);
            return Save();
            throw new NotImplementedException();
        }
    }
}
