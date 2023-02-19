using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Parcela_MikroservisiProjekat.Interface;
using Parcela_MikroservisiProjekat.Models;
using Parcela_MikroservisiProjekat.Models.ModelsDto;

namespace Parcela_MikroservisiProjekat.Controllers
{
    /// <summary>
    /// Predstavlja kontroler katastarske opstine 
    /// </summary>
    [Route("api/KatastarskaOpstinaVOAPIController")]
    [ApiController]
    public class KatastarskaOpstinaVOAPIController : ControllerBase
    {
        private readonly IKatastarskaOpstinaVORepository _katastarskaOpstVORepository;
        //  private readonly ApplicationContext _db;
        private readonly IMapper _mapper;


        public KatastarskaOpstinaVOAPIController(IKatastarskaOpstinaVORepository katastarskaOpstVORepository,/*ApplicationContext db*/ IMapper mapper)
        {
            _katastarskaOpstVORepository = katastarskaOpstVORepository;
            // _db = db;
            _mapper = mapper;
        }

        //--------->GET KATASTARSKE OPSTINE VO

        /// <summary>
        /// Vraća sve katastarske opstine 
        /// </summary>
        /// <returns>Listu katastarskih opstina</returns>

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<KatastarskaOpstinaVO>))]

        public IActionResult getAllKatastarskaOpstinaVO()
        {
            var katOpstVO = _mapper.Map<List<KatastarskaOpstinaVODto>>(_katastarskaOpstVORepository.getAllKatastarskaOpstinaVO());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(katOpstVO);
        }





        //--------------> GET PO ID KATASTARSKE OPSTINE VO

        /// <summary>
        /// Vraća katastarsku opstinu po zadatoj vrednosti id-a
        /// </summary>
        /// <param name="katastarskaOpstinaVO"></param>
        /// <returns>Objekat katastarske opstine</returns>

        [HttpGet("{id:int}", Name = "getKatastarskaOpstinaVOId")]
        [ProducesResponseType(200, Type = typeof(KatastarskaOpstinaVO))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]


        public IActionResult getKatastarskaOpstinaVOByID(int id)
        {
            if (!_katastarskaOpstVORepository.katastarskaOpstinaVOExsists(id))
                return NotFound();
            var katastarskaOpstinaVO = _mapper.Map<KatastarskaOpstinaVODto>(_katastarskaOpstVORepository.getKatastarskaOpstinaVOByID(id));

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(katastarskaOpstinaVO);
        }





        //--------------> POST KATASTARSKA OPSTINA VO

        /// <summary>
        /// Kreira novu katastarsku opstinu
        /// </summary>
        /// <param name="katastarskaOpstinaVODto"></param>
        /// <returns>Potvrdu o kreiranom oglasu</returns>
        /// <response code="204">katastarska opstina uspesno kreirana</response>
        /// <response code="400">Poslat neispravan zahtev</response>
        /// <response code="404">Nije pronadjena katastarska opstina</response>

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<KatastarskaOpstinaVODto> postKatastarskaOpstinaVO([FromBody] KatastarskaOpstinaVODto katastarskaOpstinaVODto)
        {/*
            if(ModelState.IsValid)
            {
                return BadRequest(ModelState);
            } */
            if (katastarskaOpstinaVODto == null)
            {
                return BadRequest(katastarskaOpstinaVODto);
            }
            if (katastarskaOpstinaVODto.katastarskaOpstinaId > 0)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
            var katOpstVO = _katastarskaOpstVORepository.getAllKatastarskaOpstinaVO().Where(c => c.katastarskaOpstinaId == katastarskaOpstinaVODto.katastarskaOpstinaId).FirstOrDefault();

            if (katOpstVO != null)
            {
                ModelState.AddModelError("", "Katastarska opstina VO already exists");
                return StatusCode(422, ModelState);
            }

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var katastarskaOpstinaVOMap = _mapper.Map<KatastarskaOpstinaVO>(katastarskaOpstinaVODto);

            if (!_katastarskaOpstVORepository.postKatastarskaOpstinaVO(katastarskaOpstinaVOMap))
            {
                ModelState.AddModelError("", "Something went wrong while saving");
                return StatusCode(500, ModelState);
            }

            return Ok("Successfully created");

        }





        //----------> DELETE KATASTARSKA OPSTINA

        /// <summary>
        /// Briše katastarsku opstinu po zadatoj vrednosti id-a
        /// </summary>
        /// <param name="katOpstinaVO"></param>

        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpDelete("{id:int}", Name = "deleteKatastarskaOpstinaVO")]

        public IActionResult deleteKatastarskaOpstinaVO(int id)
        {
            var katOpstinaVO = _katastarskaOpstVORepository.getKatastarskaOpstinaVOByID(id);
            if (!ModelState.IsValid) return BadRequest(ModelState);
            if(_katastarskaOpstVORepository.getKatastarskaOpstinaVOByID(id) == null) return StatusCode(500, ModelState);
            if (!_katastarskaOpstVORepository.deleteKatastarskaOpstinaVO(katOpstinaVO))
            {
                ModelState.AddModelError("", "Something went wrong while deleting katastarska opstina VO");
            }
            return NoContent();

        }






        //------------> PUT KATASTARSKA OPSTINA VO

        /// <summary>
        /// Menja vrednosti postojeće katastarske opstine
        /// </summary>
        /// <param name="updatedKatastarskaOpstinaVO"></param>
        /// <returns>Potvrdu o izmenjenom objektu</returns>

        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPut("{id:int}", Name = "updateKatastarskaOpstinaVO")]
        public IActionResult updateKatastarskaOpstinaVO(int id, [FromBody] KatastarskaOpstinaVODto updatedKatastarskaOpstinaVO)
        {
            if (updatedKatastarskaOpstinaVO == null || id != updatedKatastarskaOpstinaVO.katastarskaOpstinaId)
            {
                return BadRequest();
            }

            if (!_katastarskaOpstVORepository.katastarskaOpstinaVOExsists(id))
                return NotFound();

            if (!ModelState.IsValid)
                return BadRequest();

            var katastarkaOpstinaVOMap = _mapper.Map<KatastarskaOpstinaVO>(updatedKatastarskaOpstinaVO);

            if (!_katastarskaOpstVORepository.updateKatastarskaOpstinaVO(katastarkaOpstinaVOMap))
            {
                ModelState.AddModelError("", "Something went wrong updating katastarska opstina");
                return StatusCode(500, ModelState);
            }

            return NoContent();

        }



    }
}
