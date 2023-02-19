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
    public class PravnoLiceController : Controller
    {
        private readonly IPravnoLiceRepository _pravnoLiceRepository;
        private readonly IMapper _mapper;

        public PravnoLiceController(IPravnoLiceRepository pravnoLiceRepository, IMapper mapper)
        {
            _pravnoLiceRepository = pravnoLiceRepository;
            _mapper = mapper;
        }
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<PravnoLice>))]
        public IActionResult getPravnaLica()
        {
            var pravnaLica = _mapper.Map<List<PravnoLiceDTO>>(_pravnoLiceRepository.getPravnaLica());
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            return Ok(pravnaLica);
        }
        /// <summary>
        /// Vraća sva pravna lica 
        /// </summary>
        /// <returns>Listu pravnih lica</returns>


        [HttpGet("{pravnoLiceID}")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<PravnoLice>))]
        [ProducesResponseType(400)]
        public IActionResult getPravnoLice(int pravnoLiceID)
        {
            var pravnoLice = _mapper.Map<PravnoLiceDTO>(_pravnoLiceRepository.getPravnoLiceByID(pravnoLiceID));
            if (!ModelState.IsValid) return BadRequest(ModelState);
            return Ok(pravnoLice);
        }
        /// <summary>
        /// Vraća pravno lice po zadatoj vrednosti id-a
        /// </summary>
        /// <param name="pravnoLiceID"></param>
        /// <returns>Objekat PravnoLice</returns>

        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult CreateAdresa([FromBody] PravnoLicePostDTO pravnoLiceCreate)
        {
            if (pravnoLiceCreate == null) return BadRequest(ModelState);
            if (pravnoLiceCreate.PravnoLiceID > 0)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
            var pravnoLice = _pravnoLiceRepository.getPravnaLica().Where(c => c.PravnoLiceID == pravnoLiceCreate.PravnoLiceID).FirstOrDefault();
            if (pravnoLice != null)
            {
                ModelState.AddModelError("", "Pravno Lice vec Postoji");
                return StatusCode(422, ModelState);
            }
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var pravnoLiceMap = _mapper.Map<PravnoLice>(pravnoLiceCreate);

            if (!_pravnoLiceRepository.CreatePravnoLice(pravnoLiceMap))
            {
                ModelState.AddModelError("", "Nesto  je poslo po zlu pri cuvanju");
                return StatusCode(500, ModelState);
            }
            return Ok("Uspesno Kreirano");
        }
        /// <summary>
        /// Kreira novo pravno lice
        /// </summary>
        /// <param name="pravnoLiceCreate"></param>
        /// <returns>Potvrdu o kreiranom pravnom licu</returns>
        /// <response code="204">pravno lice uspesno kreirano</response>
        /// <response code="400">Poslat neispravan zahtev</response>

        [HttpPut("{pravnoLiceID}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult UpdatePravnoLice(int pravnoLiceID, [FromBody] PravnoLiceUpdateDTO updatedPravnoLice)
        {
            if (updatedPravnoLice == null) return BadRequest(ModelState);
            if (pravnoLiceID != updatedPravnoLice.PravnoLiceID) return BadRequest(ModelState);
            if (!ModelState.IsValid) return BadRequest();

            var pravnoLiceMap = _mapper.Map<PravnoLice>(updatedPravnoLice);
            if (!_pravnoLiceRepository.UpdatePravnoLice(pravnoLiceMap))
            {
                ModelState.AddModelError("", "Nesto je otislo po zlu pri Update-ovanju");
                return StatusCode(500, ModelState);
            }
            return NoContent();
        }
        /// <summary>
        /// Menja vrednosti postojećeg pravnog lica
        /// </summary>
        /// <param name="updatedPravnoLice"></param>
        /// <returns>Potvrdu o izmenjenom objektu</returns>

        [HttpDelete("{pravnoLiceID}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult DeletePravnoLice(int pravnoLiceID)
        {
            var pravnoLiceToDelete = _pravnoLiceRepository.getPravnoLiceByID(pravnoLiceID);
            if (!ModelState.IsValid) return BadRequest(ModelState);
            if (_pravnoLiceRepository.getPravnoLiceByID(pravnoLiceID) == null) return StatusCode(500, ModelState);
            if (!_pravnoLiceRepository.DeletePravnoLice(pravnoLiceToDelete))
            {
                ModelState.AddModelError("", "Nesto je poslo po zlu pri Brisanju");
            }
            return NoContent();
        }
        /// <summary>
        /// Briše pravno Lice po zadatoj vrednosti id-a
        /// </summary>
        /// <param name="pravnoLiceID"></param>
    }
}


