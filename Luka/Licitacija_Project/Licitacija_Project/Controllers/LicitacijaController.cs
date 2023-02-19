using AutoMapper;
using Licitacija_Project.Interface;
using Licitacija_Project.Models.DTO;
using Licitacija_Project.Models;
using Microsoft.AspNetCore.Mvc;

namespace Licitacija_Project.Controllers
{
    [Route("api/LicitacijaController")]
    [ApiController]
    public class LicitacijaController : Controller
    {
        private readonly ILicitacijaRepository _licitacijaRepository;
        private readonly IMapper _mapper;

        public LicitacijaController(ILicitacijaRepository licitacijaRepository, IMapper mapper)
        {
            _licitacijaRepository = licitacijaRepository;
            _mapper = mapper;
        }
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Licitacija>))]
        public IActionResult getLicitacije()
        {
            var dokumenti = _mapper.Map<List<Licitacija>>(_licitacijaRepository.GetLicitacijas());
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            return Ok(dokumenti);

        }
        [HttpGet("{LicitacijaID}")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Licitacija>))]
        [ProducesResponseType(400)]
        public IActionResult GetLicitacije(int LicitacijaID)
        {
            var dokument = _mapper.Map<Licitacija>(_licitacijaRepository.GetLicitacijaById(LicitacijaID));
            if (!ModelState.IsValid) return BadRequest(ModelState);
            return Ok(dokument);
        }
        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult CreateLicitacije([FromBody] Licitacija licitacijeCreate)
        {
            if (licitacijeCreate == null) return BadRequest(ModelState);

            var dokument = _licitacijaRepository.GetLicitacijas().Where(c => c.DokumentID == licitacijeCreate.LicitacijaID).FirstOrDefault();
            if (dokument != null)
            {
                ModelState.AddModelError("", "Licitacija vec Postoji");
                return StatusCode(422, ModelState);
            }
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var dokumentMap = _mapper.Map<Licitacija>(licitacijeCreate);

            if (!_licitacijaRepository.CreateLicitacija(dokumentMap))
            {
                ModelState.AddModelError("", "Nesto  je poslo po zlu pri cuvanju");
                return StatusCode(500, ModelState);
            }
            return Ok("Uspesno Kreirano");
        }
        [HttpPut("{LicitacijaID}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult UpdateLicitacije (int LicitacijaID, [FromBody] Licitacija updatedLicitacija)
        {
            if (updatedLicitacija == null) return BadRequest(ModelState);
            if (LicitacijaID != updatedLicitacija.LicitacijaID) return BadRequest(ModelState);
            if (!ModelState.IsValid) return BadRequest();

            var dokumentMap = _mapper.Map<Licitacija>(updatedLicitacija);
            if (!_licitacijaRepository.UpdateLicitacija(dokumentMap))
            {
                ModelState.AddModelError("", "Nesto je otislo po zlu pri Update-ovanju");
                return StatusCode(500, ModelState);
            }
            return NoContent();
        }

  


        [HttpDelete("{LicitacijaID}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult DeleteLicitacija(int LicitacijaID)
        {
            var dokumentToDelete = _licitacijaRepository.GetLicitacijaById(LicitacijaID);
            if (!ModelState.IsValid) return BadRequest(ModelState);
            if (_licitacijaRepository.GetLicitacijaById(LicitacijaID) == null) return StatusCode(500, ModelState);
            if (!_licitacijaRepository.DeleteLicitacija(dokumentToDelete))
            {
                ModelState.AddModelError("", "Nesto je poslo po zlu pri Brisanju");
                return StatusCode(500, ModelState);
            }
            return NoContent();
        }
    }
}
