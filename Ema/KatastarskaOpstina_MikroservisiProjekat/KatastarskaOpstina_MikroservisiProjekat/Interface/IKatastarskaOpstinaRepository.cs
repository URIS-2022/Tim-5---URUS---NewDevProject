using KatastarskaOpstina_MikroservisiProjekat.Models;

namespace KatastarskaOpstina_MikroservisiProjekat.Interface
{
    public interface IKatastarskaOpstinaRepository
    {
        //get all katastarska opstina
        ICollection<KatastarskaOpstina> getAllKatastarskaOpstina();

        //get katastarska opstina byID
        KatastarskaOpstina getKatastarskaOpstinaByID(int id);

        //create katastarska opstina
        bool postKatastarskaOpstina(KatastarskaOpstina katastarskaOpstina);

        //update katastarska opstina
        bool updateKatastarskaOpstina(KatastarskaOpstina katastarskaOpstina);

        //delete katastarska opstina
        bool deleteKatastarskaOpstina(KatastarskaOpstina katastarskaOpstina);

        //save changes
        bool SaveChanges();

        //da li psotoji kat opstina
        bool katastarskaOpstinaExsists(int id);
    }
}
