using AutoMapper;
using Dokument_Sergej.Data.DTO;
using Dokument_Sergej.Interfaces;
using Dokument_Sergej.Models;
using Dokument_Sergej.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Dokument_Sergej.Controllers
{
    /// <summary>
    /// Predstavlja kontroler licnosti
    /// </summary>

    [Route("api/LicnostAPI")]
    [ApiController]
    public class LicnostController : Controller
    {
        private readonly ILicnostRepository _licnostRepository;
        private readonly IMapper _mapper;
        public LicnostController(ILicnostRepository licnostRepository, IMapper mapper)
        {
            _licnostRepository = licnostRepository;
            _mapper = mapper;
        }

        /// <summary>
        /// Vraća sve licnosti
        /// </summary>
        /// <returns>Listu licnosti</returns>

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Licnost>))]
        public IActionResult GetLicnosti()
        {
            var licnosti = _licnostRepository.GetLicnosti();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            return Ok(licnosti);
        }

        /// <summary>
        /// Vraća licnost po zadatoj vrednosti id-a
        /// </summary>
        /// <param name="LicnostID"></param>
        /// <returns>Objekat licnosti</returns>

        [HttpGet("{licnostID:int}",Name = "getLicnostByID")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Licnost>))]
        [ProducesResponseType(400)]

        public async Task<IActionResult> GetLicnost(int licnostID)
        {
            if (!_licnostRepository.LicnostExsists(licnostID))
                return NotFound();
            
            var licnost = _mapper.Map<LicnostDTO>(_licnostRepository.GetLicnostByID(licnostID));
            
            
            if (!ModelState.IsValid) return BadRequest(ModelState);
            return Ok(licnost);
        }

        /// <summary>
        /// Kreira novu licnost
        /// </summary>
        /// <param name="licnost"></param>
        /// <returns>Potvrdu o kreiranoj licnosti</returns>
        /// <response code="204">Licnost uspesno obrisana</response>
        /// <response code="400">Poslat neispravan zahtev</response>
        /// <response code="404">Nije pronadjena licnost za brisanje</response>

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<Licnost> CreateLicnost([FromBody] Licnost licnosti)
        {

            try
            {
                Licnost licnost = _mapper.Map<Licnost>(licnosti);
                _licnostRepository.CreateLicnost(licnosti);
                _licnostRepository.Save();
                return Ok("Successfully created");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Post error");
            }
        }

        /// <summary>
        /// Menja vrednosti postojeće licnosti
        /// </summary>
        /// <param name="Licnost"></param>
        /// <returns>Potvrdu o izmenjenom objektu</returns>

        [HttpPut("{licnostID}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult UpdateLicnost(int licnostID, [FromBody] Licnost updatedLicnost)
        {
            if (updatedLicnost == null) return BadRequest(ModelState);
            if (licnostID != updatedLicnost.LicnostID) return BadRequest(ModelState);
            if (!_licnostRepository.LicnostExsists(licnostID)) return NotFound();

            if (!ModelState.IsValid) return BadRequest();

            if (!_licnostRepository.UpdateLicnost(updatedLicnost))
            {
                ModelState.AddModelError("", "Nesto je otislo po zlu pri Update-ovanju");
                return StatusCode(500, ModelState);
            }
            return NoContent();
        }
        /// <summary>
        /// Briše licnost po zadatoj vrednosti id-a
        /// </summary>
        /// <param name="LicnostID"></param>


        [HttpDelete("{licnostID}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult DeleteLicnost(int licnostID)
        {
            var licnostToDelete = _licnostRepository.GetLicnostByID(licnostID);
            if (!ModelState.IsValid) return BadRequest(ModelState);
            if (_licnostRepository.GetLicnostByID(licnostID) == null) return StatusCode(500, ModelState);
            if (!_licnostRepository.DeleteLicnost(licnostToDelete))
            {
                ModelState.AddModelError("", "Nesto je poslo po zlu pri Brisanju");
                return StatusCode(500, ModelState);
            }
            return NoContent();
        }
    }
}
