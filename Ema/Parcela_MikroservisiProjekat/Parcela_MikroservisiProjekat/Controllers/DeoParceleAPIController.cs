using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Parcela_MikroservisiProjekat.Interface;
using Parcela_MikroservisiProjekat.Models;
using Parcela_MikroservisiProjekat.Models.ModelsDto;

namespace Parcela_MikroservisiProjekat.Controllers
{
    /// <summary>
    /// Predstavlja kontroler dela parcele
    /// </summary>
    [Route("api/DeoParceleAPIController")]
    [ApiController]
    public class DeoParceleAPIController : ControllerBase
    {
        private readonly IDeoParceleRepository _deoParcRepository;
        //  private readonly ApplicationContext _db;
        private readonly IMapper _mapper;


        public DeoParceleAPIController(IDeoParceleRepository deoParceleRepository,/*ApplicationContext db*/ IMapper mapper)
        {
            _deoParcRepository = deoParceleRepository;
            // _db = db;
            _mapper = mapper;
        }


        //--------->GET DEO PARCELE
        /// <summary>
        /// Vraća sve delove parcele 
        /// </summary>
        /// <returns>Listu delova parcele</returns>
        /// 
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<DeoParcele>))]

        public IActionResult getAllDeoParcele()
        {
            var statOpst = _mapper.Map<List<DeoParceleDto>>(_deoParcRepository.getAllDeoParcele());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(statOpst);
        }



        //--------------> GET PO ID DEO PARCELE

        /// <summary>
        /// Vraća deo parcele po zadatoj vrednosti id-a
        /// </summary>
        /// <param name="deoParcele"></param>
        /// <returns>Objekat dela parcele</returns>

        [HttpGet("{id:int}", Name = "getDeoParceleID")]
        [ProducesResponseType(200, Type = typeof(DeoParcele))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]


        public IActionResult getDeoParceleByID(int id)
        {
            if (!_deoParcRepository.deoParceleExsists(id))
                return NotFound();
            var deoParcele = _mapper.Map<DeoParceleDto>(_deoParcRepository.getDeoParceleByID(id));

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(deoParcele);
        }

        //--------------> POST DEO PARCELE

        /// <summary>
        /// Kreira novi deo parcele
        /// </summary>
        /// <param name="deoParceleDto"></param>
        /// <returns>Potvrdu o kreiranom delu parcele</returns>
        /// <response code="204">Deo parcele uspesno kreiran</response>
        /// <response code="400">Poslat neispravan zahtev</response>
        /// <response code="404">Nije pronadjen deo parcele</response>

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<DeoParceleDto> postDeoParcele([FromBody] DeoParceleDto deoParceleDto)
        {/*
            if(ModelState.IsValid)
            {
                return BadRequest(ModelState);
            } */
            if (deoParceleDto == null)
            {
                return BadRequest(deoParceleDto);
            }
            if (deoParceleDto.deoParceleId > 0)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
            var deoParc = _deoParcRepository.getAllDeoParcele().Where(c => c.deoParceleId == deoParceleDto.deoParceleId).FirstOrDefault();

            if (deoParc != null)
            {
                ModelState.AddModelError("", "Deo parcele already exists");
                return StatusCode(422, ModelState);
            }

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var deoParceleMap = _mapper.Map<DeoParcele>(deoParceleDto);

            if (!_deoParcRepository.postDeoParcele(deoParceleMap))
            {
                ModelState.AddModelError("", "Something went wrong while saving");
                return StatusCode(500, ModelState);
            }

            return Ok("Successfully created");

        }




        //----------> DELETE DEO PARCELE

        /// <summary>
        /// Briše deo parcele po zadatoj vrednosti id-a
        /// </summary>
        /// <param name="deoparc"></param>

        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpDelete("{id:int}", Name = "deleteDeoParcele")]

        public IActionResult deleteDeoParcele(int id)
        {
            var deoparc = _deoParcRepository.getDeoParceleByID(id);
            if (!ModelState.IsValid) return BadRequest(ModelState);
            if (_deoParcRepository.getDeoParceleByID(id) == null) return StatusCode(500, ModelState);
            if (!_deoParcRepository.deleteDeoParcele(deoparc))
            {
                ModelState.AddModelError("", "Something went wrong while deleting deo parcele");
            }
            return NoContent();

        }





        //------------> PUT DEO PARCELE

        /// <summary>
        /// Menja vrednosti postojećeg dela parcele
        /// </summary>
        /// <param name="updatedDeoParcele"></param>
        /// <returns>Potvrdu o izmenjenom objektu</returns>

        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPut("{id:int}", Name = "updateDeoParcele")]
        public IActionResult updateDeoParcele(int id, [FromBody] DeoParceleDto updatedDeoParcele)
        {
            if (updatedDeoParcele == null || id != updatedDeoParcele.deoParceleId)
            {
                return BadRequest();
            }

            if (!_deoParcRepository.deoParceleExsists(id))
                return NotFound();

            if (!ModelState.IsValid)
                return BadRequest();

            var deoParceleMap = _mapper.Map<DeoParcele>(updatedDeoParcele);

            if (!_deoParcRepository.updateDeoParcele(deoParceleMap))
            {
                ModelState.AddModelError("", "Something went wrong updating deo parcele");
                return StatusCode(500, ModelState);
            }

            return NoContent();

        }

    }
}
