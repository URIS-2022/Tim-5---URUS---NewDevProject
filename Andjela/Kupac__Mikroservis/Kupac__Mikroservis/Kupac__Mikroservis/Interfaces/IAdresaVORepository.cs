using Kupac__Mikroservis.Models;

namespace Kupac__Mikroservis.Interfaces
{
    public interface IAdresaVORepository
    {
        ICollection<AdresaVO> GetAdresaVOs();

        AdresaVO GetAdresaVOById(int id);

        bool AdresaVOExist(int AdrId);

        bool CreateAdresaVO(AdresaVO adresaVO);
        bool Save();

        bool UpdateAdresaVO(AdresaVO adresaVO);
        bool DeleteAdresaVO(AdresaVO adresaVO);
    }
}
