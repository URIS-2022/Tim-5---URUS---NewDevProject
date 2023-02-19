using AutoMapper;
using LicnostProjekat.Data.DTO;
using LicnostProjekat.Interfaces;
using LicnostProjekat.Models;
using LicnostProjekat.Repository;
using Microsoft.AspNetCore.Mvc;

namespace LicnostProjekat.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LicnostController : Controller
    {
        private readonly ILicnostRepository _licnostRepository;
        private readonly IMapper _mapper;

        public LicnostController(ILicnostRepository licnostRepository, IMapper mapper)
        {
            _licnostRepository= licnostRepository;
            _mapper = mapper;
        }
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Licnost>))]
        public IActionResult getLicnosti()
        {
            var licnosti = _mapper.Map<List<LicnostDTO>>(_licnostRepository.getAllLicnosts());
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            return Ok(licnosti);
        }
        /// <summary>
        /// Vraća sve licnosti 
        /// </summary>
        /// <returns>Listu licnosti</returns>


        [HttpGet("{licnostID}")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Licnost>))]
        [ProducesResponseType(400)]
        public async Task<IActionResult> GetLicnost(int licnostID)
        {
            var licnost = _mapper.Map<LicnostDTO>(_licnostRepository.getLicnostByID(licnostID));

            var path = "https://localhost:7099/api/Kupac/" + licnost.KupacID;

            var response = await HttpClient<KupacDTO>.GetAsync(path);

            licnost.kupac = response;

            if (!ModelState.IsValid) return BadRequest(ModelState);
            return Ok(licnost);
        }
        /// <summary>
        /// Vraća licnost po zadatoj vrednosti id-a
        /// </summary>
        /// <param name="licnostID"></param>
        /// <returns>Objekat Licnost</returns>
        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult CreateLicnost([FromBody] LicnostPostDTO licnostCreate)
        {
            if (licnostCreate == null) return BadRequest(ModelState);
            if (licnostCreate.LicnostID > 0)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }

                var adresa = _licnostRepository.getAllLicnosts().Where(c => c.LicnostID == licnostCreate.LicnostID).FirstOrDefault();
            if (adresa != null)
            {
                ModelState.AddModelError("", "Licnost vec Postoji");
                return StatusCode(422, ModelState);
            }
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var licnostMap = _mapper.Map<Licnost>(licnostCreate);

            if (!_licnostRepository.CreateLicnost(licnostMap))
            {
                ModelState.AddModelError("", "Nesto  je poslo po zlu pri cuvanju");
                return StatusCode(500, ModelState);
            }
            return Ok("Uspesno Kreirano");
        }
        /// <summary>
        /// Kreira novu Licnost
        /// </summary>
        /// <param name="licnostCreate"></param>
        /// <returns>Potvrdu o kreiranoj licnosti</returns>
        /// <response code="204">licnost uspesno kreirana</response>
        /// <response code="400">Poslat neispravan zahtev</response>

        [HttpPut("{licnostID}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult UpdateLicnost(int licnostID, [FromBody] LicnostUpdateDTO updatedLicnost)
        {
            if (updatedLicnost == null) return BadRequest(ModelState);
            if (licnostID != updatedLicnost.LicnostID) return BadRequest(ModelState);
            if (!ModelState.IsValid) return BadRequest();

            var licnostMap = _mapper.Map<Licnost>(updatedLicnost);
            if (!_licnostRepository.UpdateLicnost(licnostMap))
            {
                ModelState.AddModelError("", "Nesto je otislo po zlu pri Update-ovanju");
                return StatusCode(500, ModelState);
            }
            return NoContent();
        }
        /// <summary>
        /// Menja vrednosti postojećeg licnosti
        /// </summary>
        /// <param name="updatedLicnost"></param>
        /// <returns>Potvrdu o izmenjenoj Licnosti</returns>

        [HttpDelete("{licnostID}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult DeleteLicnost(int licnostID)
        {
            var licnostToDelete = _licnostRepository.getLicnostByID(licnostID);
            if (!ModelState.IsValid) return BadRequest(ModelState);
            if (_licnostRepository.getLicnostByID(licnostID) == null) return StatusCode(500, ModelState);
            if (!_licnostRepository.DeleteLicnost(licnostToDelete))
            {
                ModelState.AddModelError("", "Nesto je poslo po zlu pri Brisanju");
            }
            return NoContent();
        }
        /// <summary>
        /// Briše Licnost po zadatoj vrednosti id-a
        /// </summary>
        /// <param name="licnostID"></param>
    }
}

