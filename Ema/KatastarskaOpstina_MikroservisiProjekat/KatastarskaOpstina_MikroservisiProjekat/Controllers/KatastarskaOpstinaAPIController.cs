using AutoMapper;
using KatastarskaOpstina_MikroservisiProjekat.Interface;
using KatastarskaOpstina_MikroservisiProjekat.Models;
using KatastarskaOpstina_MikroservisiProjekat.Models.ModelsDto;
using Microsoft.AspNetCore.Mvc;

namespace KatastarskaOpstina_MikroservisiProjekat.Controllers
{
    /// <summary>
    /// Predstavlja kontroler katastarske opstine
    /// </summary>

    [Route("api/KatastarskaOpstinaAPIController")]
    [ApiController]
    public class KatastarskaOpstinaAPIController : ControllerBase
    {
        private readonly IKatastarskaOpstinaRepository _katastarskaOpstRepository;
        //  private readonly ApplicationContext _db;
        private readonly IMapper _mapper;


        public KatastarskaOpstinaAPIController(IKatastarskaOpstinaRepository katastarskaOpstRepository,/*ApplicationContext db*/ IMapper mapper)
        {
            _katastarskaOpstRepository = katastarskaOpstRepository;
            // _db = db;
            _mapper = mapper;
        }




        //--------->GET KATASTARSKE OPSTINE


        /// <summary>
        /// Vraća sve katastarske opstine 
        /// </summary>
        /// <returns>Listu katastarskih opstina</returns>
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<KatastarskaOpstina>))]
       
        public IActionResult getAllKatastarskaOpstina()
        {
            var katOpst = _mapper.Map<List<KatastarskaOpstinaDto>>(_katastarskaOpstRepository.getAllKatastarskaOpstina());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(katOpst);
        }

        //--------------> GET PO ID KATASTARSKE OPSTINE


        /// <summary>
        /// Vraća katastarsku opstinu po zadatoj vrednosti id-a
        /// </summary>
        /// <param name="katastarskaOpstina"></param>
        /// <returns>Objekat katastarske opstine</returns>
        [HttpGet("{id:int}", Name = "getKatastarskaOpstinaID")]
        [ProducesResponseType(200, Type = typeof(KatastarskaOpstina))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        

        public IActionResult getKatastarskaOpstinaByID(int id)
        {
            if (!_katastarskaOpstRepository.katastarskaOpstinaExsists(id))
                return NotFound();
            var katastarskaOpstina = _mapper.Map<KatastarskaOpstinaDto>(_katastarskaOpstRepository.getKatastarskaOpstinaByID(id));

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(katastarskaOpstina);
        }

        //--------------> POST KATASTARSKA OPSTINA
        /// <summary>
        /// Kreira novu katastarsku opstinu
        /// </summary>
        /// <param name="katastarskaOpstinaDto"></param>
        /// <returns>Potvrdu o kreiranoj katastarskoj opstini</returns>
        /// <response code="204">Predsednik uspesno kreiran</response>
        /// <response code="400">Poslat neispravan zahtev</response>
        /// <response code="404">Nije pronadjena katastarska opstina</response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<KatastarskaOpstinaDto> postKatastarskaOpstina([FromBody] KatastarskaOpstinaDto katastarskaOpstinaDto)
        {/*
            if(ModelState.IsValid)
            {
                return BadRequest(ModelState);
            } */
            if (katastarskaOpstinaDto == null)
            {
                return BadRequest(katastarskaOpstinaDto);
            }
            if (katastarskaOpstinaDto.katastarskaOpstinaId > 0)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
            var katOpst = _katastarskaOpstRepository.getAllKatastarskaOpstina().Where(c => c.katastarskaOpstinaId == katastarskaOpstinaDto.katastarskaOpstinaId).FirstOrDefault();

            if (katOpst != null)
            {
                ModelState.AddModelError("", "Katastarska opstina already exists");
                return StatusCode(422, ModelState);
            }

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var katastarskaOpstinaMap = _mapper.Map<KatastarskaOpstina>(katastarskaOpstinaDto);

            if (!_katastarskaOpstRepository.postKatastarskaOpstina(katastarskaOpstinaMap))
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
        /// <param name="katastarskaOpstina"></param>

        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpDelete("{id:int}", Name = "deleteKatastarskaOpstina")]

        public IActionResult deleteKatastarskaOpstina(int id)
        {
            var katastarskaOpstina = _katastarskaOpstRepository.getKatastarskaOpstinaByID(id);
            if (!ModelState.IsValid) return BadRequest(ModelState);
            if (_katastarskaOpstRepository.getKatastarskaOpstinaByID(id) == null) return StatusCode(500, ModelState);
            if (!_katastarskaOpstRepository.deleteKatastarskaOpstina(katastarskaOpstina))
            {
                ModelState.AddModelError("", "Something went wrong while deleting katastarska opstina");
            }
            return NoContent();

        }







        //------------> PUT KATASTARSKA OPSTINA

        /// <summary>
        /// Menja vrednosti postojeće katastarske opstine
        /// </summary>
        /// <param name="updatedKatastarskaOpstina"></param>
        /// <returns>Potvrdu o izmenjenom objektu</returns>

        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPut("{id:int}", Name = "updateKatastarskaOpstina")]
        public IActionResult updateKatastarskaOpstina(int id, [FromBody] KatastarskaOpstinaDto updatedKatastarskaOpstina)
        {
            if (updatedKatastarskaOpstina == null || id != updatedKatastarskaOpstina.katastarskaOpstinaId)
            {
                return BadRequest();
            }
            
            if (!_katastarskaOpstRepository.katastarskaOpstinaExsists(id))
                return NotFound();

            if (!ModelState.IsValid)
                return BadRequest();

            var katastarkaOpstinaMap = _mapper.Map<KatastarskaOpstina>(updatedKatastarskaOpstina);

            if (!_katastarskaOpstRepository.updateKatastarskaOpstina(katastarkaOpstinaMap))
            {
                ModelState.AddModelError("", "Something went wrong updating katastarska opstina");
                return StatusCode(500, ModelState);
            }

            return NoContent();

        }
    



}
}
