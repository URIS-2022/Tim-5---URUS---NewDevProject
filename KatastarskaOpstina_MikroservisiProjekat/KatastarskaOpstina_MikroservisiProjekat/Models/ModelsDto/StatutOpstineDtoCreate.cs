using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace KatastarskaOpstina_MikroservisiProjekat.Models.ModelsDto
{
    /// <summary>
    /// Predstavlja model statuta opstine za kreiranje
    /// </summary>
    public class StatutOpstineDtoCreate
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        /// <summary>
        /// Id statuta opstine
        /// </summary>
        public int statutOpstineID { get; set; }

        /// <summary>
        /// Clan statuta opstine
        /// </summary>
        public string clan { get; set; }

        /// <summary>
        /// Stav statuta opstine
        /// </summary>
        public string stav { get; set; }

        /// <summary>
        /// Tacka statuta opstine
        /// </summary>
        public string tacka { get; set; }


        /// <summary>
        /// Id katastarske opstine (FK)
        /// </summary>
        [ForeignKey("KatastarskaOpstina")]
        public int katastarskaOpstinaID { get; set; }
// public KatastarskaOpstina katastarskaOpstina { get; set; }
    }
}
