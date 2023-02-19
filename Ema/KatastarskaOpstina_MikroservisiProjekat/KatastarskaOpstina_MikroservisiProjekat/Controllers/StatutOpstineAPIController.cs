using AutoMapper;
using KatastarskaOpstina_MikroservisiProjekat.Interface;
using KatastarskaOpstina_MikroservisiProjekat.Models.ModelsDto;
using KatastarskaOpstina_MikroservisiProjekat.Models;
using Microsoft.AspNetCore.Mvc;

namespace KatastarskaOpstina_MikroservisiProjekat.Controllers
{

    /// <summary>
    /// Predstavlja kontroler statuta opstine
    /// </summary>
    [Route("api/StatutOpstineAPIController")]
    [ApiController]
    public class StatutOpstineAPIController : ControllerBase
    {
        private readonly IStatutOpstineRepository _statutOpstRepository;
        //  private readonly ApplicationContext _db;
        private readonly IMapper _mapper;


        public StatutOpstineAPIController(IStatutOpstineRepository statutOpstineRepository,/*ApplicationContext db*/ IMapper mapper)
        {
            _statutOpstRepository = statutOpstineRepository;
            // _db = db;
            _mapper = mapper;
        }


        //--------->GET STATUT OPSTINE
        /// <summary>
        /// Vraća sve statute opstine 
        /// </summary>
        /// <returns>Listu statuta opstine</returns>
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<StatutOpstine>))]

        public IActionResult getAllStatutOpstine()
        {
            var statOpst = _mapper.Map<List<StatutOpstineDto>>(_statutOpstRepository.getAllStatutOpstine());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(statOpst);
        }





        //--------------> GET PO ID STATUTA OPSTINE
        /// <summary>
        /// Vraća statut opstine po zadatoj vrednosti id-a
        /// </summary>
        /// <param name="statutOpstine"></param>
        /// <returns>Objekat statuta opstine</returns>
        
        [HttpGet("{id:int}", Name = "getStatutOpstineByID")]
        [ProducesResponseType(200, Type = typeof(StatutOpstine))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]


        public IActionResult getStatutOpstineByID(int id)
        {
            if (!_statutOpstRepository.statutOpstineExsists(id))
                return NotFound();
            var statutOpstine = _mapper.Map<StatutOpstineDto>(_statutOpstRepository.getStatutOpstineByID(id));

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(statutOpstine);
        }







        //--------------> POST STATUT OPSTINA
        /// <summary>
        /// Kreira novi statut opstine
        /// </summary>
        /// <param name="statutOpstineDto"></param>
        /// <returns>Potvrdu o kreiranom statutu opstine</returns>
        /// <response code="204">Statut opstine uspesno kreiran</response>
        /// <response code="400">Poslat neispravan zahtev</response>
        /// <response code="404">Nije pronadjen statut opstine za brisanje</response>

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<StatutOpstineDtoCreate> postStatutOpstine([FromBody] StatutOpstineDtoCreate statutOpstineDto)
        {/*
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            } */
            if (statutOpstineDto == null)
            {
                return BadRequest(statutOpstineDto);
            }
            if (statutOpstineDto.statutOpstineID > 0)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
            var statOpst = _statutOpstRepository.getAllStatutOpstine().Where(c => c.statutOpstineID == statutOpstineDto.statutOpstineID).FirstOrDefault();

            if (statOpst != null)
            {
                ModelState.AddModelError("", "Statut opstine already exists");
                return StatusCode(422, ModelState);
            }

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var statutOpstineMap = _mapper.Map<StatutOpstine>(statutOpstineDto);

            if (!_statutOpstRepository.postStatutOpstine(statutOpstineMap))
            {
                ModelState.AddModelError("", "Something went wrong while saving");
                return StatusCode(500, ModelState);
            }

            return Ok("Successfully created");

        }






        //----------> DELETE STATUT OPSTINA
        /// <summary>
        /// Briše statut opstine po zadatoj vrednosti id-a
        /// </summary>
        /// <param name="OglasId"></param>


        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpDelete("{id:int}", Name = "deleteStatutOpstine")]

        public IActionResult deleteStatutOpstine(int id)
        {
            var statutOpstine = _statutOpstRepository.getStatutOpstineByID(id);
            if (!ModelState.IsValid) return BadRequest(ModelState);
            if (_statutOpstRepository.getStatutOpstineByID(id) == null) return StatusCode(500, ModelState);
            if (!_statutOpstRepository.deleteStatutOpstine(statutOpstine))
            {
                ModelState.AddModelError("", "Something went wrong while deleting statut opstine");
            }
            return NoContent();

        }





        //------------> PUT statut OPSTINA

        /// <summary>
        /// Menja vrednosti postojećeg statuta opstine
        /// </summary>
        /// <param name="updatedStatutOpstine"></param>
        /// <returns>Potvrdu o izmenjenom objektu</returns>

        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPut("{id:int}", Name = "updateStatutOpstine")]
        public IActionResult updateStatutOpstine(int id, [FromBody] StatutOpstineDtoUpdate updatedStatutOpstine)
        {
            if (updatedStatutOpstine == null || id != updatedStatutOpstine.statutOpstineID)
            {
                return BadRequest();
            }

            if (!_statutOpstRepository.statutOpstineExsists(id))
                return NotFound();

            if (!ModelState.IsValid)
                return BadRequest();

            var statutOpstineMap = _mapper.Map<StatutOpstine>(updatedStatutOpstine);

            if (!_statutOpstRepository.updateStatutOpstine(statutOpstineMap))
            {
                ModelState.AddModelError("", "Something went wrong updating statut opstine");
                return StatusCode(500, ModelState);
            }

            return NoContent();

        }



    }
}
