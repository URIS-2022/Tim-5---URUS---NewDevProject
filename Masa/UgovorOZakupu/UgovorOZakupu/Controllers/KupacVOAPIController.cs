using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using UgovorOZakupu.Interfaces;
using UgovorOZakupu.Models.DTOs;
using UgovorOZakupu.Models;
using UgovorOZakupu.Repository;

namespace UgovorOZakupu.Controllers
{

    /// <summary>
    /// Predstavlja kontroler kupca
    /// </summary>

    //[Route("api/[controller]")]
    [Route("api/KupacVOAPIController")]
    [ApiController]
    public class KupacVOAPIController : ControllerBase
    {
        private readonly IKupacRepository _kupacRepository;
        private readonly IMapper _mapper;
        public KupacVOAPIController(IKupacRepository kupacRepository, IMapper mapper)
        {
            _kupacRepository = kupacRepository;
            _mapper = mapper;
        }
        /// <summary>
        /// Vraća sve kupce 
        /// </summary>
        /// <returns>Listu kupaca</returns>

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<KupacVO>))]

        public IActionResult GetKupci()
        {
            var kupci = _mapper.Map<List<KupacVOdtos>>(_kupacRepository.GetKupci());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(kupci);
        }


        /// <summary>
        /// Vraća kupca po zadatoj vrednosti id-a
        /// </summary>
        /// <param name="KupacID"></param>
        /// <returns>Objekat kupca</returns>
        [HttpGet("{id:int}", Name = "GetKupciById")]
        [ProducesResponseType(200, Type = typeof(KupacVOdtos))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]


        public IActionResult GetKupac(int id)
        {
            if (!_kupacRepository.KupacExsists(id))
                return NotFound();
            var kupac = _mapper.Map<KupacVOdtos>(_kupacRepository.GetKupacByID(id));

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(kupac);
        }

        /// <summary>
        /// Kreira novog kupca
        /// </summary>
        /// <param name="kupacDTO"></param>
        /// <returns>Potvrdu o kreiranom kupcu</returns>
        /// <response code="204">Kupac uspesno kreiran</response>
        /// <response code="400">Poslat neispravan zahtev</response>
        /// <response code="404">Nije pronadjen </response>



        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<KupacVOdtos> CreateKupac([FromBody] KupacVOdtos kupacDTO)
        {
            if (kupacDTO == null)
            {
                return BadRequest(kupacDTO);
            }
            if (kupacDTO.KupacID > 0)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
            var kupac = _kupacRepository.GetKupci().Where(c => c.KupacID == kupacDTO.KupacID).FirstOrDefault();

            if (kupac != null)
            {
                ModelState.AddModelError("", "Kupac already exists");
                return StatusCode(422, ModelState);
            }

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var kupacMap = _mapper.Map<KupacVO>(kupacDTO);

            if (!_kupacRepository.CreateKupac(kupacMap))
            {
                ModelState.AddModelError("", "Something went wrong while saving");
                return StatusCode(500, ModelState);
            }

            return Ok("Successfully created");

        }

        /// <summary>
        /// Briše kupca po zadatoj vrednosti id-a
        /// </summary>
        /// <param name="id"></param>

        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpDelete("{id:int}", Name = "DeleteKupac")]

        public IActionResult DeleteKupac(int id)
        {
            /*
            if (_kupacRepository.KupacExsists(id))
            {
                return NotFound();
            }

            var kupacToDelete = _kupacRepository.GetKupacByID(id);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (!_kupacRepository.DeleteKupac(kupacToDelete))
            {
                ModelState.AddModelError("", "Something went wrong deleting kupac");
            }

            _kupacRepository.DeleteKupac(kupacToDelete);
            return NoContent(); */

            var kupac = _kupacRepository.GetKupacByID(id);
            if (!ModelState.IsValid) return BadRequest(ModelState);
            if (_kupacRepository.GetKupacByID(id) == null) return StatusCode(500, ModelState);
            if (!_kupacRepository.DeleteKupac(kupac))
            {
                ModelState.AddModelError("", "Something went wrong while deleting dokument");
            }
            return NoContent();
        }

        /// <summary>
        /// Menja vrednosti postojećeg kupca
        /// </summary>
        /// <param name="updatedKupac"></param>
        /// <returns>Potvrdu o izmenjenom objektu</returns>
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPut("{id:int}", Name = "UpdateKupac")]
        public IActionResult UpdateKupac(int id, [FromBody] KupacVOdtos updatedKupac)
        {
            if (updatedKupac == null || id != updatedKupac.KupacID)
            {
                return BadRequest();
            }

            if (!_kupacRepository.KupacExsists(id))
                return NotFound();

            if (!ModelState.IsValid)
                return BadRequest();

            var kupacMap = _mapper.Map<KupacVO>(updatedKupac);

            if (!_kupacRepository.UpdateKupac(kupacMap))
            {
                ModelState.AddModelError("", "Something went wrong updating kupac");
                return StatusCode(500, ModelState);
            }

            return NoContent();

        }
    }
}
