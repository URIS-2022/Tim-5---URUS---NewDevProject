using Parcela_MikroservisiProjekat.Interface;
using Parcela_MikroservisiProjekat.Models;

namespace Parcela_MikroservisiProjekat.Repositories
{
    public class KatastarskaOpstinaVORepository : IKatastarskaOpstinaVORepository
    {
        private readonly ParcelaContext _context;
        public KatastarskaOpstinaVORepository(ParcelaContext context)
        {
            _context = context;
        }
        public KatastarskaOpstinaVORepository()
        {
        }

        public ICollection<KatastarskaOpstinaVO> getAllKatastarskaOpstinaVO()
        {
            return _context.katastarskaOpstinaVO.OrderBy(p => p.katastarskaOpstinaId).ToList();
            throw new NotImplementedException();
        }

        public KatastarskaOpstinaVO getKatastarskaOpstinaVOByID(int id)
        {
            return _context.katastarskaOpstinaVO.Where(p => p.katastarskaOpstinaId == id).FirstOrDefault();
        }

        public bool postKatastarskaOpstinaVO(KatastarskaOpstinaVO katastarskaOpstinaVOMap)
        {
            _context.Add(katastarskaOpstinaVOMap);
            return SaveChanges();
            throw new NotImplementedException();
        }

        public bool updateKatastarskaOpstinaVO(KatastarskaOpstinaVO katastarskaOpstinaVO)
        {
            _context.Update(katastarskaOpstinaVO);
            return SaveChanges();
            throw new NotImplementedException();
        }

        public bool deleteKatastarskaOpstinaVO(KatastarskaOpstinaVO katastarskaOpstinaVO)
        {
            _context.Remove(katastarskaOpstinaVO);
            return SaveChanges();
            throw new NotImplementedException();
        }

        public bool SaveChanges()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
            throw new NotImplementedException();
        }

        public bool katastarskaOpstinaVOExsists(int id)
        {
            return _context.katastarskaOpstinaVO.Any(p => p.katastarskaOpstinaId == id);

            throw new NotImplementedException();
        }
    }
}
