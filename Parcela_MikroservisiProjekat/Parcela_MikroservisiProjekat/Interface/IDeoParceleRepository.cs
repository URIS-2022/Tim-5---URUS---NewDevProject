using Parcela_MikroservisiProjekat.Models;

namespace Parcela_MikroservisiProjekat.Interface
{
    public interface IDeoParceleRepository
    {
        //get all deo parcele
        ICollection<DeoParcele> getAllDeoParcele();

        //get katastarska opstina VO byID
        DeoParcele getDeoParceleByID(int id);

        //create deo parcele
        bool postDeoParcele(DeoParcele deoParceleMap);

        //update deo parcele
        bool updateDeoParcele(DeoParcele deoParcele);

        //delete deo parcele
        bool deleteDeoParcele(DeoParcele deoParcele);

        //save changes
        bool SaveChanges();

        //da li psotoji deo parcele
        bool deoParceleExsists(int id);
    }
}
