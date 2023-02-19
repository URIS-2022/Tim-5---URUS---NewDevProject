using LicnostProjekat.Models;

namespace LicnostProjekat.Interfaces
{
    public interface IFizickoLiceRepository
    {
        ICollection<FizickoLice> GetFizickoLices();
        FizickoLice GetFizickoLice(int id);
        bool createFizickoLice(FizickoLice item);
        bool Save();
        bool updateFizickoLice(FizickoLice fizickoLice);
        bool deleteFizickoLice(FizickoLice fizickoLice);
    }
}
