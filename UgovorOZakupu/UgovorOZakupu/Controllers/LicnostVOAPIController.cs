using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;
using UgovorOZakupu.Interfaces;
using UgovorOZakupu.Models.DTOs;
using UgovorOZakupu.Models;
using UgovorOZakupu.Repository;

namespace UgovorOZakupu.Controllers
{

    /// <summary>
    /// Predstavlja kontroler licnosti
    /// </summary>

    //[Route("api/[controller]")]
    [Route("api/LicnostVOAPIController")]
    [ApiController]
    public class LicnostVOAPIController : ControllerBase
    {
        private readonly ILicnostRepository _licnostRepository;
        private readonly IMapper _mapper;
        public LicnostVOAPIController(ILicnostRepository licnostRepository, IMapper mapper)
        {
            _licnostRepository = licnostRepository;
           
            _mapper = mapper;
        }

        /// <summary>
        /// Vraća sve licnosti
        /// </summary>
        /// <returns>Listu licnosti</returns>
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<LicnostVO>))]

        public IActionResult GetLicnosti()
        {
            var licnosti = _mapper.Map<List<LicnostVOdto>>(_licnostRepository.GetLicnosti());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(licnosti);
        }


        /// <summary>
        /// Vraća licnost po zadatoj vrednosti id-a
        /// </summary>
        /// <param name="LicnostID"></param>
        /// <returns>Objekat licnosti</returns>
        [HttpGet("{id:int}", Name = "GetLicnostByID")]
        [ProducesResponseType(200, Type = typeof(LicnostVOdto))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]


        public IActionResult GetLicnost(int id)
        {
            if (!_licnostRepository.LicnostExsists(id))
                return NotFound();
            var licnost = _mapper.Map<LicnostVOdto>(_licnostRepository.GetLicnostByID(id));

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(licnost);
        }


        /// <summary>
        /// Kreira novu licnost
        /// </summary>
        /// <param name="licnostDTO"></param>
        /// <returns>Potvrdu o kreiranoj licnosti</returns>
        /// <response code="204">Predsednik uspesno obrisan</response>
        /// <response code="400">Poslat neispravan zahtev</response>
        /// <response code="404">Nije pronadjen predsednik za brisanje</response>


        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<LicnostVOdto> CreateLicnots([FromBody] LicnostVOdto licnostDTO)
        {
            if (licnostDTO == null)
            {
                return BadRequest(licnostDTO);
            }
            if (licnostDTO.LicnostID > 0)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
            var licnost = _licnostRepository.GetLicnosti().Where(c => c.LicnostID == licnostDTO.LicnostID).FirstOrDefault();

            if (licnost != null)
            {
                ModelState.AddModelError("", "Licnost already exists");
                return StatusCode(422, ModelState);
            }

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var licnostMap = _mapper.Map<LicnostVO>(licnostDTO);

            if (!_licnostRepository.CreateLicnost(licnostMap))
            {
                ModelState.AddModelError("", "Something went wrong while saving");
                return StatusCode(500, ModelState);
            }

            return Ok("Successfully created");

        }

        /// <summary>
        /// Briše licnost po zadatoj vrednosti id-a
        /// </summary>
        /// <param name="id"></param>

        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpDelete("{id:int}", Name = "DeleteLicnost")]

        public IActionResult DeleteLicnost(int id)
        {/*

            if (_licnostRepository.LicnostExsists(id))
            {
                return NotFound();
            }

            var licnostToDelete = _licnostRepository.GetLicnostByID(id);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (!_licnostRepository.DeleteLicnost(licnostToDelete))
            {
                ModelState.AddModelError("", "Something went wrong deleting licnost");
            }

            _licnostRepository.DeleteLicnost(licnostToDelete);
            return NoContent();
            */
            var licnost = _licnostRepository.GetLicnostByID(id);
            if (!ModelState.IsValid) return BadRequest(ModelState);
            if (_licnostRepository.GetLicnostByID(id) == null) return StatusCode(500, ModelState);
            if (!_licnostRepository.DeleteLicnost(licnost))
            {
                ModelState.AddModelError("", "Something went wrong while deleting dokument");
            }
            return NoContent();
        }

        /// <summary>
        /// Menja vrednosti postojeće licnosti
        /// </summary>
        /// <param name="updatedLicnost"></param>
        /// <returns>Potvrdu o izmenjenom objektu</returns>
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPut("{id:int}", Name = "UpdateLicnost")]
        public IActionResult UpdateLicnost(int id, [FromBody] LicnostVOdto updatedLicnost)
        {
            if (updatedLicnost == null || id != updatedLicnost.LicnostID)
            {
                return BadRequest();
            }

            if (!_licnostRepository.LicnostExsists(id))
                return NotFound();

            if (!ModelState.IsValid)
                return BadRequest();

            var licnostMap = _mapper.Map<LicnostVO>(updatedLicnost);

            if (!_licnostRepository.UpdateLicnost(licnostMap))
            {
                ModelState.AddModelError("", "Something went wrong updating licnost");
                return StatusCode(500, ModelState);
            }

            return NoContent();

        }
    }
}
