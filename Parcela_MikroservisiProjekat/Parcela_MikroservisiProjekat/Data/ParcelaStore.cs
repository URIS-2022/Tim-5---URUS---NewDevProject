using Parcela_MikroservisiProjekat.Models.ModelsDto;

namespace Parcela_MikroservisiProjekat.Data
{
    public class ParcelaStore
    {
        public static List<KatastarskaOpstinaVODto> KatastarskaOpstinaVOList = new List<KatastarskaOpstinaVODto>{
            new KatastarskaOpstinaVODto{
                                katastarskaOpstinaId=11,
                                katastarskaOpstinaNaziv="Leskovac"
            },
            new KatastarskaOpstinaVODto{
                                katastarskaOpstinaId=21,
                                katastarskaOpstinaNaziv="Kikinda"}
        };

        public static List<DeoParceleDto> DeoParceleList = new List<DeoParceleDto>{
            new DeoParceleDto{
                                deoParceleId=15,
                                povrsina="200m2",
                                redniBroj=3
            },
            new DeoParceleDto{
                                deoParceleId=14,
                                povrsina="200m2",
                                redniBroj=3
            }
        };

        public static List<ParcelaDto> ParcelaList = new List<ParcelaDto>{
            new ParcelaDto{
                                parcelaId = 11,
                                povrsina = "300m2",
                                korisnikParcele = "Masa Bobar",
                                brojParcele = 1,
                                brojListaNepokretnosti = 1,
                                oblikSvojine = "Nasledstvo",
                                kulturaStvarsnoStanje = "visoka",
                                klasaStvarnoStanje = "visoka",
                                obradivostStvarnoStanje = "niska",
                                zasticenaZonaStvarnoStanje = "visoka",
                                odvodnjavanjeStvarnoStanje = "povoljno",
                                deoParceleId=1,
                                katastarskaOpstinaId=1
            },
            new ParcelaDto{
                                parcelaId = 12,
                                povrsina = "300m2",
                                korisnikParcele = "Masa Bobar",
                                brojParcele = 1,
                                brojListaNepokretnosti = 1,
                                oblikSvojine = "Nasledstvo",
                                kulturaStvarsnoStanje = "visoka",
                                klasaStvarnoStanje = "visoka",
                                obradivostStvarnoStanje = "niska",
                                zasticenaZonaStvarnoStanje = "visoka",
                                odvodnjavanjeStvarnoStanje = "povoljno",
                                deoParceleId=1,
                                katastarskaOpstinaId=1
            }
        };
    }
}
