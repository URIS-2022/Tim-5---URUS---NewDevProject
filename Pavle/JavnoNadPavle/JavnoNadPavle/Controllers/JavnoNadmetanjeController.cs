using AutoMapper;
using JavnoNadPavle.Dto;
using JavnoNadPavle.Interfaces;
using JavnoNadPavle.Models;
using JavnoNadPavle.Repository;
using Microsoft.AspNetCore.Mvc;

namespace JavnoNadPavle.Controllers
{
    /// <summary>
    /// Predstavlja kontroler JavnogNadmetanja
    /// </summary>
    [Route("api/JavnoNadmetanjeAPI")]
    [ApiController]
    public class JavnoNadmetanjeController : Controller
    {
        private readonly IJavnoNadmetanjeRepository _javnoNadmetanjeRepository;
        private readonly IMapper _mapper;

        public JavnoNadmetanjeController(IJavnoNadmetanjeRepository javnoNadmetanjeRepository, IMapper mapper)
        {
            _javnoNadmetanjeRepository = javnoNadmetanjeRepository;
            _mapper = mapper;
        }

        /// <summary>
        /// Vraća sva JavnaNadmetanja
        /// </summary>
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<JavnoNadmetanje>))]
        public IActionResult GetJavnaNadmetanja()
        {
            var javnaNadmetanja = _javnoNadmetanjeRepository.GetJavnaNadmetanja();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(javnaNadmetanja);
        }

        /// <summary>
        /// Vraća JavnaNadmetanja preko zaatog id-a 
        /// </summary>
        [HttpGet("{JavnoNadmetanjeID}")]
        [ProducesResponseType(200, Type = typeof(JavnoNadmetanje))]
        [ProducesResponseType(400)]

        public IActionResult GetJavnoNadmetanje(int JavnoNadmetanjeID)
        {/////////////////////////////////////////////////////////////////////////////////
            if (!_javnoNadmetanjeRepository.JavnoNadmetanjeExists(JavnoNadmetanjeID))
                return NotFound();

            var javnoNadmetanje = _javnoNadmetanjeRepository.GetJavnaNadmetanje(JavnoNadmetanjeID);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(javnoNadmetanje);
        }

        /// <summary>
        /// Kreira novo JavnoNadmetanje 
        /// </summary>
        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult CreateJavnoNadmetanje([FromBody] JavnoNadmetanjeCreateDTO javnoNadmetanjeCreate)
        {
            if (javnoNadmetanjeCreate == null)
                return BadRequest(ModelState);

            var jnad = _javnoNadmetanjeRepository.GetJavnaNadmetanja().Where(a => a.JavnoNadmetanjeID
                    == javnoNadmetanjeCreate.JavnoNadmetanjeID).FirstOrDefault();


            if (jnad != null)
            {
                ModelState.AddModelError("", "Nadmetanje vec Postoji");
                return StatusCode(422, ModelState);
            }
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var javnoNadmetanjeMap = _mapper.Map<JavnoNadmetanje>(javnoNadmetanjeCreate);

            if (!_javnoNadmetanjeRepository.CreateJavnoNadmetanje(javnoNadmetanjeMap))
            {
                ModelState.AddModelError("", "Nesto  je poslo po zlu pri cuvanju");
                return StatusCode(500, ModelState);
            }
            return Ok("Uspesno Kreirano");

        }
        /// <summary>
        /// Modifikuje JanvoNadmetanje zadato preko id-a
        /// </summary>
        /// <response code="204">Predsednik uspesno obrisan</response>
        /// <response code="400">Poslat neispravan zahtev</response>
        /// <response code="404">Nije pronadjen predsednik za brisanje</response>
        [HttpPut("{JavnoNadmetanjeID}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult UpdateJavnoNadmetanje(int JavnoNadmetanjeID, [FromBody] JavnoNadmetanjeUpdateDTO updatedJavnoNametanje)
        {
            if (updatedJavnoNametanje == null)
                return BadRequest(ModelState);

            if (JavnoNadmetanjeID != updatedJavnoNametanje.JavnoNadmetanjeID)
                return BadRequest(ModelState);

            if (!_javnoNadmetanjeRepository.JavnoNadmetanjeExists(JavnoNadmetanjeID))
                return NotFound();

            if (!ModelState.IsValid) return BadRequest(ModelState);

            var jnadmetanjeMap = _mapper.Map<JavnoNadmetanje>(updatedJavnoNametanje);

            if (!_javnoNadmetanjeRepository.UpdateJavnoNadmetanje(jnadmetanjeMap))
            {
                ModelState.AddModelError("", "Nesto je otislo po zlu pri Update-ovanju");
                return StatusCode(500, ModelState);
            }

            return NoContent();

        }
        /// <summary>
        /// Brise zadato JavnoNadmetnaje
        /// </summary>
        /// <response code="204">Predsednik uspesno obrisan</response>
        /// <response code="400">Poslat neispravan zahtev</response>
        /// <response code="404">Nije pronadjen predsednik za brisanje</response>
        [HttpDelete("{JavnoNadmetanjeID}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult DeleteJavnoNadmetanje(int JavnoNadmetanjeID)
        {
            if (!_javnoNadmetanjeRepository.JavnoNadmetanjeExists(JavnoNadmetanjeID))
            {
                return NotFound();
            }

            var jnadmetanjeToDelte = _javnoNadmetanjeRepository.GetJavnaNadmetanje(JavnoNadmetanjeID);


            if (!ModelState.IsValid)
                return BadRequest(ModelState);


            if (!_javnoNadmetanjeRepository.DeleteJavnoNadmetanje(jnadmetanjeToDelte))
            {
                ModelState.AddModelError("", "Nesto je poslo po zlu pri Brisanju");
            }
            return NoContent();
        }

    }
}
