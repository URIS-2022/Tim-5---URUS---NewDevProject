using AutoMapper;
using JavnoNadPavle.Interfaces;
using JavnoNadPavle.Models;
using JavnoNadPavle.Repository;
using Microsoft.AspNetCore.Mvc;

namespace JavnoNadPavle.Controllers
{
    /// <summary>
    /// Predstavlja kontroler Etape
    /// </summary>
    [Route("api/EtapaAPI")]
    [ApiController]
    public class EtapaController : Controller
    {
        private readonly IEtapaRepository _etapaRepository;
        private readonly IMapper _mapper;

        public EtapaController(IEtapaRepository etapaRepository, IMapper mapper)
        {
            _etapaRepository = etapaRepository;
            _mapper = mapper;
        }
        /// <summary>
        /// Vraća sve Etape 
        /// </summary>
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Etapa>))]
        public IActionResult GetEtape()
        {
            var etapa = _etapaRepository.GetEtape();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(etapa);
        }
        /// <summary>
        /// Vraća Etape preko zadatog id-a 
        /// </summary>
        [HttpGet("{EtapaID}")]
        [ProducesResponseType(200, Type = typeof(Etapa))]
        [ProducesResponseType(400)]

        public IActionResult GetEtapa(int EtapaID)
        {
            if (!_etapaRepository.EtapaExists(EtapaID))
                return NotFound();

            var etapa = _etapaRepository.GetEtapa(EtapaID);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(etapa);
        }
        /// <summary>
        /// Kreira Novu Etapu 
        /// </summary>
        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult CreateEtapa([FromBody] Etapa etapaCreate)
        {
            if (etapaCreate == null)
                return BadRequest(ModelState);

            var etapa = _etapaRepository.GetEtape()
                .Where(a => a.EtapaID == etapaCreate.EtapaID).FirstOrDefault();

            if (etapa != null)
            {
                ModelState.AddModelError("", "Nadmetanje vec Postoji");
                return StatusCode(422, ModelState);
            }
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var etapaMap = _mapper.Map<Etapa>(etapaCreate);

            if (!_etapaRepository.CreateEtapa(etapaMap))
            {
                ModelState.AddModelError("", "Nesto  je poslo po zlu pri cuvanju");
                return StatusCode(500, ModelState);
            }
            return Ok("Uspesno Kreirano");

        }
        /// <summary>
        /// Modifikuje etapu zadatu preko id-a
        /// </summary>
        /// <response code="204">Predsednik uspesno obrisan</response>
        /// <response code="400">Poslat neispravan zahtev</response>
        /// <response code="404">Nije pronadjen predsednik za brisanje</response>
        [HttpPut("{EtapaID}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult UpdateEtapa(int EtapaID, [FromBody] Etapa updateEtapa)
        {
            if (updateEtapa == null)
                return BadRequest(ModelState);

            if (EtapaID != updateEtapa.EtapaID)
                return BadRequest(ModelState);

            if (!_etapaRepository.EtapaExists(EtapaID))
                return NotFound();

            if (!ModelState.IsValid) return BadRequest(ModelState);

            var etapaMap = _mapper.Map<Etapa>(updateEtapa);

            if (!_etapaRepository.UpdateEtapa(etapaMap))
            {
                ModelState.AddModelError("", "Nesto je otislo po zlu pri Update-ovanju");
                return StatusCode(500, ModelState);
            }

            return NoContent();

        }
        /// <summary>
        /// Brise zadatu etapu
        /// </summary>
        /// <response code="204">Predsednik uspesno obrisan</response>
        /// <response code="400">Poslat neispravan zahtev</response>
        /// <response code="404">Nije pronadjen predsednik za brisanje</response>
        [HttpDelete("{EtapaID}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult DeleteEtapa(int EtapaID)
        {
            if (!_etapaRepository.EtapaExists(EtapaID))
            {
                return NotFound();
            }

            var etapaToDelete = _etapaRepository.GetEtapa(EtapaID);


            if (!ModelState.IsValid)
                return BadRequest(ModelState);


            if (!_etapaRepository.DeleteEtapa(etapaToDelete))
            {
                ModelState.AddModelError("", "Nesto je poslo po zlu pri Brisanju");
            }
            return NoContent();
        }
    }
}