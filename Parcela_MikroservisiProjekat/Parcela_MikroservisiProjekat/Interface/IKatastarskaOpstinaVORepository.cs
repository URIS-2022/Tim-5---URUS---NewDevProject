using Parcela_MikroservisiProjekat.Models;

namespace Parcela_MikroservisiProjekat.Interface
{
    public interface IKatastarskaOpstinaVORepository
    {
        //get all katastarska opstina VO
        ICollection<KatastarskaOpstinaVO> getAllKatastarskaOpstinaVO();

        //get katastarska opstina VO byID
        KatastarskaOpstinaVO getKatastarskaOpstinaVOByID(int id);

        //create katastarska opstina VO
        bool postKatastarskaOpstinaVO(KatastarskaOpstinaVO katastarskaOpstinaVOMap);

        //update katastarska opstina VO
        bool updateKatastarskaOpstinaVO(KatastarskaOpstinaVO katastarskaOpstinaVO);

        //delete katastarska opstina VO
        bool deleteKatastarskaOpstinaVO(KatastarskaOpstinaVO katastarskaOpstinaVO);

        //save changes
        bool SaveChanges();

        //da li psotoji kat opstina
        bool katastarskaOpstinaVOExsists(int id);
    }
}
