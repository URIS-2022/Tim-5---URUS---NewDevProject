using KatastarskaOpstina_MikroservisiProjekat.Models.ModelsDto;

namespace KatastarskaOpstina_MikroservisiProjekat.Data
{
    public class KatastarskaOpstinaStore
    {
        public static List<KatastarskaOpstinaDto> KatastarskaOpstinaList = new List<KatastarskaOpstinaDto>{
            new KatastarskaOpstinaDto{
                                katastarskaOpstinaId=11,
                                katastarskaOpstinaNaziv="Leskovac"
            },
            new KatastarskaOpstinaDto{
                                katastarskaOpstinaId=21,
                                katastarskaOpstinaNaziv="Kikinda"}
        };

        public static List<StatutOpstineDto> StatutOpstineList = new List<StatutOpstineDto>{
            new StatutOpstineDto{
                                statutOpstineID=11,
                                clan="prvi",
                                stav="prvi",
                                tacka="prva",
                                katastarskaOpstinaID=11
            },
            new StatutOpstineDto{
                                statutOpstineID=31,
                                clan="drugi",
                                stav="drugi",
                                tacka="druga",
                                katastarskaOpstinaID=21}
        };
    }
}
