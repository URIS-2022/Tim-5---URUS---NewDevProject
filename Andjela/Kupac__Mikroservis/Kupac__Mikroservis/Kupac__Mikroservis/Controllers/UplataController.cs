using AutoMapper;
using Kupac__Mikroservis.Interfaces;
using Kupac__Mikroservis.Models;
using Kupac__Mikroservis.Models.DTO;
using Kupac__Mikroservis.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Kupac__Mikroservis.Controllers
{
    /// <summary>
    /// Predstavlja kontroler uplate
    /// </summary>

    [Route("api/[controller]")]
    [ApiController]
    public class UplataController : Controller
    {
        private readonly IUplataRepository _uplataRepository;
        private readonly IMapper _mapper;
        public UplataController(IUplataRepository uplataRepository, IMapper mapper)
        {
            _uplataRepository = uplataRepository;
            _mapper = mapper;
        }

        /// <summary>
        /// Vraća sve uplate 
        /// </summary>
        /// <returns>Listu uplata</returns>

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Uplata>))]
        public IActionResult GetUplatas()
        {
            var uplatas = _mapper.Map<List<UplataDTO>>(_uplataRepository.GetUplatas());



            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(uplatas);
        }

        /// <summary>
        /// Vraća uplatu po zadatoj vrednosti id-a
        /// </summary>
        /// <param name="UplataID"></param>
        /// <returns>Objekat uplate</returns>

        [HttpGet("{id}")]
        [ProducesResponseType(200, Type = typeof(Uplata))]
        [ProducesResponseType(400, Type = typeof(Uplata))]
        public IActionResult GetuPLATA(int id)
        {
            if (!_uplataRepository.UplataExist(id))
                return NotFound();

            var uplata = _mapper.Map<Uplata>(_uplataRepository.GetUplataById(id));

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(uplata);
        }

        /// <summary>
        /// Kreira novu uplatu
        /// </summary>
        /// <param name="Uplata"></param>
        /// <returns>Potvrdu o kreiranoj uplati</returns>


        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]

        public ActionResult<Uplata> CreateUplata([FromBody] UplataDTOCreate uplataCreate)
        {
           
            if (uplataCreate == null)
            {
                return BadRequest(uplataCreate);
            }
            
            if (uplataCreate.UplataID > 0)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
            var uplata = _uplataRepository.GetUplatas().Where(c => c.UplataID == uplataCreate.UplataID).FirstOrDefault();

            if (uplata != null)
            {
                ModelState.AddModelError("", "zalba already exists");
                return StatusCode(422, ModelState);
            }

            if (!ModelState.IsValid)
                return BadRequest(ModelState);


            var uplataMap = _mapper.Map<Uplata>(uplataCreate);

            if (!_uplataRepository.CreateUplata(uplataMap))
            {
                ModelState.AddModelError("", "Something went wrong while saving");
                return StatusCode(500, ModelState);
            }

            return Ok("Successfully created");
        }

        /// <summary>
        /// Menja vrednosti postojeće uplate
        /// </summary>
        /// <param name="Uplata"></param>
        /// <returns>Potvrdu o izmenjenoj uplati</returns>


        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [HttpPut("{id:int}")]
        public IActionResult UpdateUplata(int id, [FromBody] UplataDTOUpdate updateUplata)
        {
            if (updateUplata == null)
                return BadRequest(ModelState);

            if (id != updateUplata.UplataID)
                return BadRequest(ModelState);

            if (!_uplataRepository.UplataExist(id))
                return NotFound();

            if (!ModelState.IsValid)
                return BadRequest();
            var uplataMap = _mapper.Map<Uplata>(updateUplata);


            if (!_uplataRepository.UpdateUplata(uplataMap))
            {
                ModelState.AddModelError("", "Something went wrong while updating uplata");
                return StatusCode(500, ModelState);

            }

            return NoContent();
        }

        /// <summary>
        /// Briše uplatu po zadatoj vrednosti id-a
        /// </summary>
        /// <param name="UplataID"></param>

        [HttpDelete("{id}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult DeleteUplata(int id)
        {
            var uplata = _uplataRepository.GetUplataById(id);
            if (!ModelState.IsValid) return BadRequest(ModelState);
            if (_uplataRepository.GetUplataById(id) == null)
                return StatusCode(500, ModelState);
            if (!_uplataRepository.DeleteUplata(uplata))
            {
                ModelState.AddModelError("", "Something went wrong while deleting uplata");
            }
            return NoContent();
        }
    }
}
