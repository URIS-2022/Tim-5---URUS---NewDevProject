using KatastarskaOpstina_MikroservisiProjekat.Models;

namespace KatastarskaOpstina_MikroservisiProjekat.Interface
{
    public interface IStatutOpstineRepository
    {
        //get all StatutOpstine
        ICollection<StatutOpstine> getAllStatutOpstine();

        //get StatutOpstine byID
        StatutOpstine getStatutOpstineByID(int id);

        //create StatutOpstine
        bool postStatutOpstine(StatutOpstine statutOpstineMap);

        //update StatutOpstine
        bool updateStatutOpstine(StatutOpstine statutOpstine);

        //delete StatutOpstine
        bool deleteStatutOpstine(StatutOpstine statutOpstine);

        //save changes
        bool SaveChanges();

        //da li psotoji StatutOpstine
        bool statutOpstineExsists(int id);
    }
}
