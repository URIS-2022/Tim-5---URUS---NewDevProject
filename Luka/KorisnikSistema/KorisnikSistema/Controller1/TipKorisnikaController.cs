using AutoMapper;
using KorisnikSistema.Interfaces;
using KorisnikSistema.Models.DTOs;
using KorisnikSistema.Models;
using KorisnikSistema.Repository;
using Microsoft.AspNetCore.Mvc;

namespace KorisnikSistema.Controller1
{
    [Route("api/[controller]")]
    [ApiController]
    public class TipKorisnikaController : ControllerBase
    {
        private readonly ITipKorisnikaRepository tipKorisnikaRepository;
        private readonly IMapper mapper;

        public TipKorisnikaController(ITipKorisnikaRepository tipKorisnikaRepository, IMapper mapper)
        {
            this.tipKorisnikaRepository = tipKorisnikaRepository;
            this.mapper = mapper;
        }

        /// <summary>
        /// Vraća sve tipove korisnika 
        /// </summary>
        /// <returns>Listu tipova korisnika</returns>
        [HttpGet]
        public ActionResult<IEnumerable<TipKorisnikaDTO>> GetAll()
        {
            return Ok(mapper.Map<List<TipKorisnikaDTO>>(tipKorisnikaRepository.GetAll().ToList()));
        }


        /// <summary>
        /// Vraća tip korisnika po zadatoj vrednosti id-a
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Objekat tipa korisnika</returns>

        [HttpGet("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<TipKorisnikaDTO> GetById(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }
            var tipKorisnika = tipKorisnikaRepository.GetById(id);

            if (tipKorisnika == null)
            {
                return NotFound();
            }
            return Ok(mapper.Map<TipKorisnikaDTO>(tipKorisnika));
        }

        /// <summary>
        /// Kreira novi tip korisnika
        /// </summary>
        /// <param name="tipKorisnikaDTO"></param>
        /// <returns>Potvrdu o kreiranom tipu korisnika</returns>
        /// <response code="204">Tip korisnika uspesno kreiran</response>
        /// <response code="400">Poslat neispravan zahtev</response>

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<TipKorisnikaDTO> Post([FromBody] TipKorisnikaDTO tipKorisnikaDTO)
        {
            if (tipKorisnikaDTO == null)
            {
                return BadRequest(tipKorisnikaDTO);
            }
            if (tipKorisnikaDTO.TipKorisnikaID > 0)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
            var tipKorisnika = mapper.Map<TipKorisnika>(tipKorisnikaDTO);
            tipKorisnikaRepository.Add(tipKorisnika);

            return Ok(tipKorisnika);
        }


        /// <summary>
        /// Menja vrednosti postojećeg tipa korisnika
        /// </summary>
        /// <param name="tipKorisnikaDTO"></param>
        /// <returns>Potvrdu o izmenjenom objektu</returns>

        [HttpPut("{id:int}")]
        public ActionResult<TipKorisnikaDTO> Update(int id, [FromBody] TipKorisnikaDTO tipKorisnikaDTO)
        {
            if (tipKorisnikaDTO == null || id != tipKorisnikaDTO.TipKorisnikaID)
            {
                return BadRequest();
            }

            var tipKorisnika = tipKorisnikaRepository.GetById(id);
            tipKorisnika.NazivTipaKorisnika = tipKorisnikaDTO.NazivTipaKorisnika;
            tipKorisnikaRepository.Update(tipKorisnika, tipKorisnika.TipKorisnikaID);

            return NoContent();
        }


        /// <summary>
        /// Briše tip korisnika po zadatoj vrednosti id-a
        /// </summary>
        /// <param name="id"></param>
        /// /// <response code="204">Tip korisnika uspesno obrisan</response>
        /// <response code="400">Poslat neispravan zahtev</response>
        /// <response code="404">Nije pronadjen tip korisnika za brisanje</response>

        [HttpDelete("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Delete(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }
            var tipKorisnika = tipKorisnikaRepository.GetById(id);

            if (tipKorisnika == null)
            {
                return NotFound();
            }
            tipKorisnikaRepository.Delete(id);
            return NoContent();
        }
    }
}
