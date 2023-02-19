using AutoMapper;
using Kupac__Mikroservis.Interfaces;
using Kupac__Mikroservis.Models;
using Kupac__Mikroservis.Models.DTO;
using Kupac__Mikroservis.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Kupac__Mikroservis.Controllers
{
    /// <summary>
    /// Predstavlja kontroler kupca
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class KupacController : Controller
    {
        private readonly IKupacRepository _kupacRepository;
        private readonly IMapper _mapper;

        public KupacController(IKupacRepository kupacRepository, IMapper mapper)
        {
            _kupacRepository = kupacRepository;
            _mapper = mapper;
        }

        /// <summary>
        /// Vraća sve kupce 
        /// </summary>
        /// <returns>Listu oglasa</returns>

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Kupac>))]
        public IActionResult GetKupacs()
        {
            var kupacs = _mapper.Map<List<KupacDTO>>(_kupacRepository.GetKupacs());

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(kupacs);
        }

        /// <summary>
        /// Vraća kupca po zadatoj vrednosti id-a
        /// </summary>
        /// <param name="KupacID"></param>
        /// <returns>Objekat kupca</returns>

        [HttpGet("{id}")]
        [ProducesResponseType(200, Type = typeof(Kupac))]
        [ProducesResponseType(400, Type = typeof(Kupac))]
        public IActionResult GetKupac(int id)
        {
            if (!_kupacRepository.KupacExist(id))
                return NotFound();

            var kupacVO = _mapper.Map<KupacDTO>(_kupacRepository.GetKupacById(id));

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(kupacVO);
        }

        /// <summary>
        /// Kreira novog kupca
        /// </summary>
        /// <param name="Kupac"></param>
        /// <returns>Potvrdu o kreiranom kupcu</returns>


        [HttpPost]
                [ProducesResponseType(201)]
                [ProducesResponseType(400)]
                [ProducesResponseType(404)]

        public ActionResult<Kupac> CreateKupac([FromBody] KupacDTOCreate kupacCreate)
                {
           
            if (kupacCreate == null)
            {
                return BadRequest(kupacCreate);
            }
            if (kupacCreate.KupacID > 0)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
            var kupac = _kupacRepository.GetKupacs().Where(c => c.KupacID == kupacCreate.KupacID).FirstOrDefault();

            if (kupac != null)
            {
                ModelState.AddModelError("", "zalba already exists");
                return StatusCode(422, ModelState);
            }

            if (!ModelState.IsValid)
                return BadRequest(ModelState);


            var kupacMap = _mapper.Map<Kupac>(kupacCreate);

            if (!_kupacRepository.CreateKupac(kupacMap))
            {
                ModelState.AddModelError("", "Something went wrong while saving");
                return StatusCode(500, ModelState);
            }

            return Ok("Successfully created");
        }

        /// <summary>
        /// Menja vrednosti postojećeg kupca
        /// </summary>
        /// <param name="Kupac"></param>
        /// <returns>Potvrdu o izmenjenom kupcu</returns>

        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [HttpPut("{id}")]

        public IActionResult UpdateKupacVO(int id, [FromBody] KupacDTOUpdate updateKupac)
        {
            if (updateKupac == null)
                return BadRequest(ModelState);

            if (id != updateKupac.KupacID)
                return BadRequest(ModelState);

            if (!_kupacRepository.KupacExist(id))
                return NotFound();

            if (!ModelState.IsValid)
                return BadRequest();

            var kupacMap = _mapper.Map<Kupac>(updateKupac);


            if (!_kupacRepository.UpdateKupac(kupacMap))
            {
                ModelState.AddModelError("", "Something went wrong while updating kupac");
                return StatusCode(500, ModelState);

            }

            return NoContent();
        }

        /// <summary>
        /// Briše kupca po zadatoj vrednosti id-a
        /// </summary>
        /// <param name="KupacID"></param>

        [HttpDelete("{id}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult DeleteKupac(int id)
        {
            var kupac = _kupacRepository.GetKupacById(id);
            if (!ModelState.IsValid) return BadRequest(ModelState);
            if (_kupacRepository.GetKupacById(id) == null)
                return StatusCode(500, ModelState);
            if (!_kupacRepository.DeleteKupac(kupac))
            {
                ModelState.AddModelError("", "Something went wrong while deleting kupac");
            }
            return NoContent();
        }

    }
}
