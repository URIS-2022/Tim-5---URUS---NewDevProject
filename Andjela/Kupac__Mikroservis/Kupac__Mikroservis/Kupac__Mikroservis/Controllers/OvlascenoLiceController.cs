using AutoMapper;
using Kupac__Mikroservis.Interfaces;
using Kupac__Mikroservis.Models;
using Kupac__Mikroservis.Models.DTO;
using Kupac__Mikroservis.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Kupac__Mikroservis.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OvlascenoLiceController : Controller
    {
        /// <summary>
        /// Predstavlja kontroler ovlascenog lica
        /// </summary>
        private readonly IOvlascenoLiceRepository _ovlascenoLiceRepository;
        private readonly IMapper _mapper;
        public OvlascenoLiceController(IOvlascenoLiceRepository ovlascenoLiceRepository, IMapper mapper)
        {
            _ovlascenoLiceRepository = ovlascenoLiceRepository;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<OvlascenoLice>))]
        public IActionResult GetOvlascenoLices()
        {
            var ovlascenoLices = _mapper.Map<List<OvlascenoLiceDTO>>(_ovlascenoLiceRepository.GetOvlascenoLices());


            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(ovlascenoLices);
        }

        /// <summary>
        /// Vraća ovlasceno lice po zadatoj vrednosti id-a
        /// </summary>
        /// <param name="OvlascenoLiceID"></param>
        /// <returns>Objekat ovlascenog lica</returns>

        [HttpGet("{id}")]
        [ProducesResponseType(200, Type = typeof(OvlascenoLice))]
        [ProducesResponseType(400, Type = typeof(OvlascenoLice))]
        public async Task<IActionResult> GetOvlascenoLice(int id)
        {
            if (!_ovlascenoLiceRepository.OvlascenoLiceExist(id))
                return NotFound();

            var ovlascenoLice = _mapper.Map<OvlascenoLiceDTO>(_ovlascenoLiceRepository.GetOvlascenoLiceById(id));

            var path = "https://localhost:7013/api/Adresa/" + ovlascenoLice.AdresaID;

            var response = await HttpClient<AdresaVODTO>.GetAsync(path);

            ovlascenoLice.Adresa = response;


            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(ovlascenoLice);
        }

        /// <summary>
        /// Kreira novo ovlasceno lice
        /// </summary>
        /// <param name="ovlascenoLice"></param>
        /// <returns>Potvrdu o kreiranom ovlascenom licu</returns>


        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]

        public ActionResult<OvlascenoLice> CreateOvlascenoLice([FromBody] OvlascenoLiceDTOCreate ovlascenoLiceCreate)
        {
      
            if (ovlascenoLiceCreate == null)
            {
                return BadRequest(ovlascenoLiceCreate);
            }
            if (ovlascenoLiceCreate.OvlascenoLiceID > 0)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
            var ovlascenoLice = _ovlascenoLiceRepository.GetOvlascenoLices().Where(c => c.OvlascenoLiceID == ovlascenoLiceCreate.OvlascenoLiceID).FirstOrDefault();

            if (ovlascenoLice != null)
            {
                ModelState.AddModelError("", "zalba already exists");
                return StatusCode(422, ModelState);
            }

            if (!ModelState.IsValid)
                return BadRequest(ModelState);


            var ovlascenoLiceMap = _mapper.Map<OvlascenoLice>(ovlascenoLiceCreate);

            if (!_ovlascenoLiceRepository.CreateOvlascenoLice(ovlascenoLiceMap))
            {
                ModelState.AddModelError("", "Something went wrong while saving");
                return StatusCode(500, ModelState);
            }

            return Ok("Successfully created");

        }

        /// <summary>
        /// Menja vrednosti postojećeg ovlascenog lica
        /// </summary>
        /// <param name="OvlascenoLice"></param>
        /// <returns>Potvrdu o izmenjenom objektu</returns>

        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [HttpPut("{id:int}")]
        public IActionResult UpdateOvlascenoLice(int id, [FromBody] OvlascenoLiceDTOUpdate updateOvlascenoLice)
        {
            if (updateOvlascenoLice == null)
                return BadRequest(ModelState);

            if (id != updateOvlascenoLice.OvlascenoLiceID)
                return BadRequest(ModelState);

            if (!_ovlascenoLiceRepository.OvlascenoLiceExist(id))
                return NotFound();

            if (!ModelState.IsValid)
                return BadRequest();

            var ovlascenoLiceMap = _mapper.Map<OvlascenoLice>(updateOvlascenoLice);

            if (!_ovlascenoLiceRepository.UpdateOvlascenoLice(ovlascenoLiceMap))
            {
                ModelState.AddModelError("", "Something went wrong while updating ovlasceno lice");
                return StatusCode(500, ModelState);

            }

            return NoContent();
        }

        /// <summary>
        /// Briše ovlasceno lice po zadatoj vrednosti id-a
        /// </summary>
        /// <param name="OvlascenoLiceID"></param>

        [HttpDelete("{id}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult DeleteOvlascenoLice(int id)
        {
            var ovlascenoLice = _ovlascenoLiceRepository.GetOvlascenoLiceById(id);
            if (!ModelState.IsValid) return BadRequest(ModelState);
            if (_ovlascenoLiceRepository.GetOvlascenoLiceById(id) == null)
                return StatusCode(500, ModelState);
            if (!_ovlascenoLiceRepository.DeleteOvlascenoLice(ovlascenoLice))
            {
                ModelState.AddModelError("", "Something went wrong while deleting ovlasceno lice");
            }
            return NoContent();
        }

    }
}
