using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Zalba_Mikroservis.Interfaces;
using Zalba_Mikroservis.Models;
using Zalba_Mikroservis.Models.DTO;
using Zalba_Mikroservis.Repository;

namespace Zalba_Mikroservis.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ZalbaController : Controller
    {
        private readonly IZalbaRepository _zalbaRepository;
        private readonly IMapper _mapper;
        public ZalbaController(IZalbaRepository zalbaRepository, IMapper mapper)
        {
            _zalbaRepository = zalbaRepository;
            _mapper = mapper;
        }


        /// <summary>
        /// Vraća sve zalbe 
        /// </summary>
        /// <returns>Listu zalbi</returns>


        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Zalba>))]
        public IActionResult GetZalbas()
        {
            var zalbas = _mapper.Map<List<ZalbaDTO>>(_zalbaRepository.GetZalbas());



            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(zalbas);
        }


        /// <summary>
        /// Vraća zalbu po zadatoj vrednosti id-a
        /// </summary>
        /// <param name="ZalbaID"></param>
        /// <returns>Objekat zalbe</returns>

        [HttpGet("{id}")]
        [ProducesResponseType(200, Type = typeof(Zalba))]
        [ProducesResponseType(400, Type = typeof(Zalba))]
        public async Task<IActionResult> GetZalba(int id)
        {
            if (!_zalbaRepository.ZalbaExist(id))
                return NotFound();

            var zalba = _mapper.Map<ZalbaDTO>(_zalbaRepository.GetZalbaById(id));

            var path = "https://localhost:7099/api/Kupac/" + zalba.KupacID;

            var response = await HttpClient<KupacVODTO>.GetAsync(path);

            zalba.Kupac = response;

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(zalba);
        }

        /// <summary>
        /// Kreira novu zalbu
        /// </summary>
        /// <param name="Zalba"></param>
        /// <returns>Potvrdu o kreiranoj zalbi</returns>

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<Zalba> CreateZalba([FromBody] ZalbaDTOCreate zalbaCreate)
        {
            if(zalbaCreate == null)
            {
                return BadRequest(zalbaCreate);
            }
            if (zalbaCreate.ZalbaID > 0)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
            var zalba = _zalbaRepository.GetZalbas().Where(c => c.ZalbaID == zalbaCreate.ZalbaID).FirstOrDefault();

            if (zalba != null)
            {
                ModelState.AddModelError("", "zalba already exists");
                return StatusCode(422, ModelState);
            }

            if (!ModelState.IsValid)
                return BadRequest(ModelState);


            var zalbaMap = _mapper.Map<Zalba>(zalbaCreate);

            if (!_zalbaRepository.CreateZalba(zalbaMap))
            {
                ModelState.AddModelError("", "Something went wrong while saving");
                return StatusCode(500, ModelState);
            }

            return Ok("Successfully created");
            

            
        }

        /// <summary>
        /// Menja vrednosti postojeće zalbe
        /// </summary>
        /// <param name="Zalba"></param>
        /// <returns>Potvrdu o izmenjenom objektu</returns>

        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [HttpPut("{id:int}", Name = "UpdateZalba")]
        public IActionResult UpdateZalba(int id, [FromBody] ZalbaDTOUpdate updateZalba)
        {
            if (updateZalba == null)
                return BadRequest(ModelState);

            if (id != updateZalba.ZalbaID)
                return BadRequest(ModelState);

            if (!_zalbaRepository.ZalbaExist(id))
                return NotFound();

            if (!ModelState.IsValid)
                return BadRequest();

            var zalbaMap = _mapper.Map<Zalba>(updateZalba);
            if (!_zalbaRepository.UpdateZalba(zalbaMap))
            {
                ModelState.AddModelError("", "Something went wrong while updating zalba");
                return StatusCode(500, ModelState);

            }

            return NoContent();
        }

        /// <summary>
        /// Briše zalbu po zadatoj vrednosti id-a
        /// </summary>
        /// <param name="ZalbaID"></param>

        [HttpDelete("{id}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult DeleteZalba(int id)
        {
            var zalba = _zalbaRepository.GetZalbaById(id);
            if (!ModelState.IsValid) return BadRequest(ModelState);
            if (_zalbaRepository.GetZalbaById(id) == null)
                return StatusCode(500, ModelState);
            if (!_zalbaRepository.DeleteZalba(zalba))
            {
                ModelState.AddModelError("", "Something went wrong while deleting zalba");
            }
            return NoContent();
        }
    }
}




