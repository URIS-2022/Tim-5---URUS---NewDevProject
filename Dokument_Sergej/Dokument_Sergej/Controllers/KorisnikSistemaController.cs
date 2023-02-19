using AutoMapper;
using Dokument_Sergej.Data.DTO;
using Dokument_Sergej.Interfaces;
using Dokument_Sergej.Models;
using Dokument_Sergej.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Dokument_Sergej.Controllers
{
        /// <summary>
        /// Predstavlja kontroler korisnika sistema
        /// </summary>
    
        [Route("api/KorisnikAPI")]
        [ApiController]
        public class KorisnikSistemaController : Controller
        {
            private readonly IKorisnikSistemaRepository _korisniksistemaRepository;
            private readonly IMapper _mapper;
        public KorisnikSistemaController(IKorisnikSistemaRepository korisniksistemaRepository, IMapper mapper)
            {
            _korisniksistemaRepository = korisniksistemaRepository;
            _mapper = mapper;
        }

        /// <summary>
        /// Vraća sve korisnike sistema
        /// </summary>
        /// <returns>Listu korisnikaSistema</returns>

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<KorisnikSistema>))]
        public IActionResult GetKorisniciSistema()
           {
                var korisnici = _korisniksistemaRepository.GetKorisniciSistema();

                if (!ModelState.IsValid)
                    return BadRequest(ModelState);
                return Ok(korisnici);
           }

        /// <summary>
        /// Vraća korisnika sistema po zadatoj vrednosti id-a
        /// </summary>
        /// <param name="KorisnikSistemaID"></param>
        /// <returns>Objekat korisnikaSistema</returns>

        [HttpGet("{korisnikID:int}", Name = "getKorisnikSistemaByID")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<KorisnikSistema>))]
        [ProducesResponseType(400)]

        public IActionResult GetKorisnikSistema(int korisnikID)
        {
            if(!_korisniksistemaRepository.KorisnikSistemaExsists(korisnikID)) return NotFound();
            var korisnik = _mapper.Map<KorisnikSistema>(_korisniksistemaRepository.GetKorisnikSistemaByID(korisnikID));
            if (!ModelState.IsValid) return BadRequest(ModelState);
            return Ok(korisnik);
        }


        /// <summary>
        /// Kreira novog korisnika sistema
        /// </summary>
        /// <param name="korisnik"></param>
        /// <returns>Potvrdu o kreiranom korisniku</returns>
        /// <response code="204">Korisnik uspesno obrisan</response>
        /// <response code="400">Poslat neispravan zahtev</response>
        /// <response code="404">Nije pronadjen korisnik za brisanje</response>

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<KorisnikSistema> CreateKorisniciSistema([FromBody] KorisnikSistema korisnici)
        {

            try
            {
                KorisnikSistema korisnik = _mapper.Map<KorisnikSistema>(korisnici);
                _korisniksistemaRepository.CreateKorisnikSistema(korisnici);
                _korisniksistemaRepository.Save();
                return Ok("Successfully created");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Post error");
            }
        }

        /// <summary>
        /// Menja vrednosti postojećeg korisnika
        /// </summary>
        /// <param name="KorisnikSistema"></param>
        /// <returns>Potvrdu o izmenjenom objektu</returns>

        [HttpPut("{korisnikID}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult UpdateKorisnikSistema(int korisnikID, [FromBody] KorisnikSistema updatedKorisnik)
        {
            if (updatedKorisnik == null) return BadRequest(ModelState);
            if (korisnikID != updatedKorisnik.KorisnikSistemaID) return BadRequest(ModelState);
            if (!_korisniksistemaRepository.KorisnikSistemaExsists(korisnikID)) return NotFound();

            if (!ModelState.IsValid) return BadRequest();

            if (!_korisniksistemaRepository.UpdateKorisnikSistema(updatedKorisnik))
            {
                ModelState.AddModelError("", "Nesto je otislo po zlu pri Update-ovanju");
                return StatusCode(500, ModelState);
            }
            return NoContent();
        }

        /// <summary>
        /// Briše korisnika po zadatoj vrednosti id-a
        /// </summary>
        /// <param name="KorisnikSistemaID"></param>
        
        [HttpDelete("{korisnikID}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult DeleteKorisnikSistema(int korisnikID)
        {
            var korisnikToDelete = _korisniksistemaRepository.GetKorisnikSistemaByID(korisnikID);
            if (!ModelState.IsValid) return BadRequest(ModelState);
            if (_korisniksistemaRepository.GetKorisnikSistemaByID(korisnikID) == null) return StatusCode(500, ModelState);
            if (!_korisniksistemaRepository.DeleteKorisnikSistema(korisnikToDelete))
            {
                ModelState.AddModelError("", "Nesto je poslo po zlu pri Brisanju");
                return StatusCode(500, ModelState);
            }
            return NoContent();
        }
    }
}
