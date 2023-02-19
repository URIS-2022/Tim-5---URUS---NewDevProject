using Parcela_MikroservisiProjekat.Models;

namespace Parcela_MikroservisiProjekat.Interface
{
    public interface IParcelaRepository
    {
        //get all parcela
        ICollection<Parcela> getAllParcela();

        //get parcela byID
        Parcela getParcelaByID(int id);

        //create parcela
        bool postParcela(Parcela parcela);

        //update parcela
        bool updateParcela(Parcela parcela);

        //delete parcela
        bool deleteParcela(Parcela parcela);

        //save changes
        bool SaveChanges();

        //da li psotoji parcela
        bool parcelaExsists(int id);
    }
}
