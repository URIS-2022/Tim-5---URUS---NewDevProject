using NadmetanjeApp.Models;

namespace NadmetanjeApp.Interfaces
{
    public interface IOtvaranjePonudeRepository
    {
        ICollection<OtvaranjePonude> GetOtvaranjePonuda();

        OtvaranjePonude GetOtvaranjePonude(int id);

        bool OtvaranjePonudeExists (int opId);

        bool CreateOtvaranjePonude(OtvaranjePonude otvaranjePonude);

        bool UpdateOtvaranjePonude(OtvaranjePonude otvaranjePonude);

        bool DeleteOtvaranjePonude(OtvaranjePonude otvaranjePonude);
        bool Save();
    } 
}
