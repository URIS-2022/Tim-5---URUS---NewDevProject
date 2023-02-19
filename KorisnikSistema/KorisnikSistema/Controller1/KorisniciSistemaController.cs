using AutoMapper;
using KorisnikSistema.Interfaces;
using KorisnikSistema.Models;
using KorisnikSistema.Models.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace KorisnikSistema.Controller1
{
    [Route("api/[controller]")]
    [ApiController]
    public class KorisniciSistemaController : ControllerBase
    {
        private readonly IKorisniciSistemaRepository korisnikSistemaRepository;
        private readonly IMapper mapper;
        private readonly ITipKorisnikaRepository tipKorisnikaRepository;

        public KorisniciSistemaController(IKorisniciSistemaRepository korisnikSistemaRepository, IMapper mapper, ITipKorisnikaRepository tipKorisnikaRepository)
        {
            this.korisnikSistemaRepository = korisnikSistemaRepository;
            this.mapper = mapper;
            this.tipKorisnikaRepository = tipKorisnikaRepository;
        }


        /// <summary>
        /// Vraća sve korisnike sistema
        /// </summary>
        /// <param name="KorisnikSistema"></param>
        /// <returns>Listu korisnika sistema</returns>

        [HttpGet]
        public ActionResult<IEnumerable<KorisniciSistemaGetDTO>> GetAll()
        {
            var korisniciSistemaDb = korisnikSistemaRepository.GetAll(includeProperties: "ListaTipovaKorisnika");
            List<KorisniciSistemaGetDTO> korisnikSistema = new List<KorisniciSistemaGetDTO>();

            foreach (var k in korisniciSistemaDb)
            {
                korisnikSistema.Add(new KorisniciSistemaGetDTO(k));
            }
            return Ok(korisnikSistema);
        }

        /// <summary>
        /// Vraća korisnika sistema po zadatoj vrednosti id-a
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Objekat korisnika sistema</returns>

        [HttpGet("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<KorisniciSistemaGetDTO> GetById(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }
            var korisniciSistemaDb = korisnikSistemaRepository.GetById(x => x.KorisnikSistemaID == id, includeProperties: "ListaTipovaKorisnika");

            if (korisniciSistemaDb == null)
            {
                return NotFound();
            }

            return Ok(new KorisniciSistemaGetDTO(korisniciSistemaDb));
        }

        /// <summary>
        /// Kreira novog korisnika sistema
        /// </summary>
        /// <param name="korisniciSistemaDTO"></param>
        /// <returns>Potvrdu o kreiranom korisniku sistema</returns>

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<KorisniciSistemaDTO> CreateKorisniciSistema([FromBody] KorisniciSistemaDTO korisniciSistemaDTO)
        {

            if (korisniciSistemaDTO == null)
            {
                return BadRequest(korisniciSistemaDTO);
            }
            if (korisniciSistemaDTO.KorisnikSistemaID > 0)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }


            KorisniciSistema korisniciSistema = new KorisniciSistema();



            List<TipKorisnika> tipoviKorisnika = new List<TipKorisnika>();
            foreach (var x in korisniciSistemaDTO.ListaTipovaKorisnika)
                tipoviKorisnika.Add(tipKorisnikaRepository.GetById(x));
            korisniciSistema.ListaTipovaKorisnika = tipoviKorisnika;
            korisniciSistema.Ime = korisniciSistemaDTO.Ime;
            korisniciSistema.Prezime = korisniciSistemaDTO.Prezime;
            korisniciSistema.Lozinka = korisniciSistemaDTO.Lozinka;
            korisnikSistemaRepository.Add(korisniciSistema);

            return Ok(korisniciSistema);

        }


        /// <summary>
        /// Menja vrednosti postojećeg korisnika sistema
        /// </summary>
        /// <param name="korisniciSistemaDTO"></param>
        /// <returns>Potvrdu o izmenjenom objektu</returns>

        [HttpPut("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<KorisniciSistemaDTO> UpdateKorisniciSistema(int id, [FromBody] KorisniciSistemaDTO korisniciSistemaDTO)
        {
            if (korisniciSistemaDTO == null)
            {
                return BadRequest(korisniciSistemaDTO);
            }

            var korisniciSistema = korisnikSistemaRepository.GetById(id);

            List<TipKorisnika> tipoviKorisnika = new List<TipKorisnika>();
            foreach (var x in korisniciSistemaDTO.ListaTipovaKorisnika)
                tipoviKorisnika.Add(tipKorisnikaRepository.GetById(x));
            korisniciSistema.ListaTipovaKorisnika = tipoviKorisnika;
            korisniciSistema.Ime = korisniciSistemaDTO.Ime;
            korisniciSistema.Prezime = korisniciSistemaDTO.Prezime;
            korisniciSistema.Lozinka = korisniciSistemaDTO.Lozinka;
            korisnikSistemaRepository.Update(korisniciSistema, id);

            return Ok(korisniciSistema);
        }


        /// <summary>
        /// Briše korisnika sistema po zadatoj vrednosti id-a
        /// </summary>
        /// <param name="id"></param>

        [HttpDelete("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult DeleteSluzbeniList(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }
            var sluzbeniList = korisnikSistemaRepository.GetById(x => x.KorisnikSistemaID == id, includeProperties: "ListaTipovaKorisnika");

            if (sluzbeniList == null)
            {
                return NotFound();
            }
            korisnikSistemaRepository.Delete(id);
            return NoContent();
        }
    }
}
