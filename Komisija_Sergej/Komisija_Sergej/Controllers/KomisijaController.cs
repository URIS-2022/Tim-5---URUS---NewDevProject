using AutoMapper;
using Komisija_Sergej.Data.DTO;
using Komisija_Sergej.Interfaces;
using Komisija_Sergej.Models;
using Microsoft.AspNetCore.Mvc;


namespace Komisija_Sergej.Controllers
{
    /// <summary>
    /// Predstavlja kontroler komisije
    /// </summary>
    
    [Route("api/KomisijaAPI")]
    [ApiController]
    public class KomisijaController : Controller
    {
        private readonly IKomisijaRepository _komisijaRepository;
        private readonly IMapper _mapper;

        public KomisijaController(IKomisijaRepository komisijaRepository, IMapper mapper)
        {
            _komisijaRepository = komisijaRepository;
            _mapper = mapper;
        }

        /// <summary>
        /// Vraća sve iz komisije 
        /// </summary>
        /// <returns>Lista komisije</returns>
        
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Komisija>))]
        public IActionResult GetKomisije()
        {
            var komisije = _mapper.Map<List<Komisija>>(_komisijaRepository.GetKomisijas());

            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            return Ok(komisije);
        }
        /// <summary>
        /// Vraća komisiju po zadatoj vrednosti id-a
        /// </summary>
        /// <param name="komisijaId"></param>
        /// <returns>Objekat komisije</returns>

        [HttpGet("{komisijaID:int}", Name = "getKomisijaByID")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Komisija>))]
        [ProducesResponseType(400)]

        public IActionResult GetKomisija(int komisijaID)
        {
            if (!_komisijaRepository.KomisijaExsists(komisijaID))
                return NotFound();
            var komisija = _mapper.Map<KomisijaDTO>(_komisijaRepository.GetKomisijaByID(komisijaID));
            if (!ModelState.IsValid) return BadRequest(ModelState);
            return Ok(komisija);
        }
        /// <summary>
        /// Kreira novu komisiju
        /// </summary>
        /// <param name="komisija"></param>
        /// <returns>Potvrdu o kreiranoj komisiji</returns>
        /// <response code="204">Komisija uspesno obrisana</response>
        /// <response code="400">Poslat neispravan zahtev</response>
        /// <response code="404">Nije pronadjena komisija za brisanje</response>

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<Komisija> CreateKomisija([FromBody] Komisija komisijaCreate)
        {

            try
            {
                Komisija komisija = _mapper.Map<Komisija>(komisijaCreate);
                _komisijaRepository.CreateKomisija(komisija);
                _komisijaRepository.Save();
                return Ok("Successfully created");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Post error");
            }
        }

        /// <summary>
        /// Menja vrednosti postojeće komisije
        /// </summary>
        /// <param name="Komisija"></param>
        /// <returns>Potvrdu o izmenjenom objektu</returns>

        [HttpPut("{komisijaID}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult UpdateKomisija(int komisijaID, [FromBody] Komisija updatedKomisija)
        {
            if (updatedKomisija == null) return BadRequest(ModelState);
            if (komisijaID != updatedKomisija.KomisijaID) return BadRequest(ModelState);
            if (!_komisijaRepository.KomisijaExsists(komisijaID)) return NotFound();
            if (!ModelState.IsValid) return BadRequest();

            if (!_komisijaRepository.UpdateKomisija(updatedKomisija))
            {
                ModelState.AddModelError("", "Nesto je otislo po zlu pri Update-ovanju");
                return StatusCode(500, ModelState);
            }
            return NoContent();
        }

        /// <summary>
        /// Briše komisiju po zadatoj vrednosti id-a
        /// </summary>
        /// <param name="komisijaId"></param>
        
        [HttpDelete("{komisijaID}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult DeleteKomisija(int komisijaID)
        {
            var komisijaToDelete = _komisijaRepository.GetKomisijaByID(komisijaID);
            if (!ModelState.IsValid) return BadRequest(ModelState);
            if (_komisijaRepository.GetKomisijaByID(komisijaID) == null) return StatusCode(500, ModelState);
            if (!_komisijaRepository.DeleteKomisija(komisijaToDelete))
            {
                ModelState.AddModelError("", "Nesto je poslo po zlu pri Brisanju");
                return StatusCode(500, ModelState);
            }
            return NoContent();
        }
    }   
}
