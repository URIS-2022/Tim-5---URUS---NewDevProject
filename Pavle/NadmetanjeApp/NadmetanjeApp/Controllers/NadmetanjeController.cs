using AutoMapper;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using NadmetanjeApp.Dto;
using NadmetanjeApp.Interfaces;
using NadmetanjeApp.Models;
using NadmetanjeApp.Repository;

namespace NadmetanjeApp.Controllers
{
    /// <summary>
    /// Predstavlja kontroler Nadmetanja
    /// </summary>
    [Microsoft.AspNetCore.Mvc.Route("api/NadmetanjeAPI")]
    [ApiController]
    public class NadmetanjeController : Controller
    {
        private readonly INadmetanjeRepository _nadmetanjeRepository;
        private readonly IMapper _mapper;

        public NadmetanjeController(INadmetanjeRepository nadmetanjeRepository, IMapper mapper)
        {
            _nadmetanjeRepository = nadmetanjeRepository;
            _mapper = mapper;
        }
        /// <summary>
        /// Vraća sva Nadmetanja
        /// </summary>
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Nadmetanje>))]
        public IActionResult GetNadmetanja()
        {
            var nadmetanja = _nadmetanjeRepository.GetNadmetanja();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(nadmetanja);
        }

        /// <summary>
        /// Vraća Nadmetanja preko zaatog id-a 
        /// </summary>
        [HttpGet("{NadmetanjeID}")]
        [ProducesResponseType(200, Type = typeof(Nadmetanje))]
        [ProducesResponseType(400)]

        public IActionResult GetNadmetanje(int NadmetanjeID)
        {
            if (!_nadmetanjeRepository.NadmetanjeExists(NadmetanjeID))
                return NotFound();

            var nadmetanje = _nadmetanjeRepository.GetNadmetanje(NadmetanjeID);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(nadmetanje);
        }

        /// <summary>
        /// Kreira novo nadmetanje 
        /// </summary>
        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult CreateNadmetanje([FromBody] Nadmetanje nadmetanjeCreate)
        {
            if (nadmetanjeCreate == null)
                return BadRequest(ModelState);

            var nadmetanje = _nadmetanjeRepository.GetNadmetanja()
                .Where(a => a.NadmetanjeID == nadmetanjeCreate.NadmetanjeID).FirstOrDefault();

            if (nadmetanje != null)
            {
                ModelState.AddModelError("", "Nadmetanje vec Postoji");
                return StatusCode(422, ModelState);
            }
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var nadmetanjeMap = _mapper.Map<Nadmetanje>(nadmetanjeCreate);

            if (!_nadmetanjeRepository.CreateNadmetanje(nadmetanjeMap))
            {
                ModelState.AddModelError("", "Nesto  je poslo po zlu pri cuvanju");
                return StatusCode(500, ModelState);
            }
            return Ok("Uspesno Kreirano");

        }
        /// <summary>
        /// Modifikuje nadmetanje zadato preko id-a
        /// </summary>
        /// <response code="204">Predsednik uspesno obrisan</response>
        /// <response code="400">Poslat neispravan zahtev</response>
        /// <response code="404">Nije pronadjen predsednik za brisanje</response>
        [HttpPut("{NadmetanjeID}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult UpdateNadmetanje(int NadmetanjeID, [FromBody]Nadmetanje updatedNametanje)
        {
            if (updatedNametanje == null)
                return BadRequest(ModelState);

            if(NadmetanjeID != updatedNametanje.NadmetanjeID)
                return BadRequest(ModelState);
            if (!_nadmetanjeRepository.NadmetanjeExists(NadmetanjeID))
                return NotFound();

            if(!ModelState.IsValid) return BadRequest(ModelState);

            var nadmetanjeMap = _mapper.Map<Nadmetanje>(updatedNametanje); 

            if(!_nadmetanjeRepository.UpdateNadmetanje(nadmetanjeMap))
            {
                ModelState.AddModelError("", "Nesto je otislo po zlu pri Update-ovanju");
                return StatusCode(500, ModelState);
            }

            return NoContent();

        }
        /// <summary>
        /// Brise zadato nadmetnaje
        /// </summary>
        /// <response code="204">Predsednik uspesno obrisan</response>
        /// <response code="400">Poslat neispravan zahtev</response>
        /// <response code="404">Nije pronadjen predsednik za brisanje</response>

        [HttpDelete("{NadmetanjeID}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult DeleteNadmetanje(int NadmetanjeID)
        {
            if (!_nadmetanjeRepository.NadmetanjeExists(NadmetanjeID))
            {
                return NotFound();
            }

            var nadmetanjeToDelte = _nadmetanjeRepository.GetNadmetanje(NadmetanjeID);
           

            if (!ModelState.IsValid)
                return BadRequest(ModelState);


            if (!_nadmetanjeRepository.DeleteNadmetanje(nadmetanjeToDelte))
            {
                ModelState.AddModelError("", "Nesto je poslo po zlu pri Brisanju");
            }
            return NoContent();
        }


    }
}
