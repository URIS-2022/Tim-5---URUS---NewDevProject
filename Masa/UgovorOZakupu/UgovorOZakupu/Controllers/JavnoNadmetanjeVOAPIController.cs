using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using UgovorOZakupu.Interfaces;
using UgovorOZakupu.Models.DTOs;
using UgovorOZakupu.Models;
using UgovorOZakupu.Repository;

namespace UgovorOZakupu.Controllers
{

    /// <summary>
    /// Predstavlja kontroler javnog nadmetanja
    /// </summary>

    //[Route("api/[controller]")]
    [Route("api/JavnoNadmetanjeAPIController")]
    [ApiController]
    public class JavnoNadmetanjeVOAPIController : ControllerBase
    { 
        private readonly IJavnoNadmetanjeRepository _javnoNadmetanjeRepository;
        private readonly IMapper _mapper;
        public JavnoNadmetanjeVOAPIController(IJavnoNadmetanjeRepository javnonadmetanjeRepository, IMapper mapper)
        {
            _javnoNadmetanjeRepository = javnonadmetanjeRepository;
            _mapper = mapper;
        }
        /// <summary>
        /// Vraća sva javna nadmetanja 
        /// </summary>
        /// <returns>Listu javnih nadmetanja</returns>
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<JavnoNadmetanjeVO>))]

        public IActionResult GetJavnaNadmetanja()
        {
            var javnaNadmetanja = _mapper.Map<List<JavnoNadmetanjeVOdto>>(_javnoNadmetanjeRepository.GetJavnaNadmetanja());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(javnaNadmetanja);
        }

        /// <summary>
        /// Vraća javno nadmetanje po zadatoj vrednosti id-a
        /// </summary>
        /// <param name="JavnoNadmetanjeID"></param>
        /// <returns>Objekat javnog nadmetanja</returns>

        [HttpGet("{id:int}", Name = "GetJavnoNadmetanjeByID")]
        [ProducesResponseType(200, Type = typeof(JavnoNadmetanjeVO))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]


        public IActionResult GetJavnoNadmetanje(int id)
        {
            if (!_javnoNadmetanjeRepository.JavnoNadmetanjeExsists(id))
                return NotFound();
            var javnoNadmetanje = _mapper.Map<JavnoNadmetanjeVOdto>(_javnoNadmetanjeRepository.GetJavnoNadmetanjeByID(id));

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(javnoNadmetanje);
        }


        /// <summary>
        /// Kreira novo javno nadmetanje
        /// </summary>
        /// <param name="javnoNadmetanjeVO"></param>
        /// <returns>Potvrdu o kreiranom javnom nadmetanju</returns>
        /// <response code="204">Javno nadmetanje uspesno kreirano</response>
        /// <response code="400">Poslat neispravan zahtev</response>
        /// <response code="404">Nije pronadjen</response>


        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<JavnoNadmetanjeVO> CreateJavnoNadmetanje([FromBody] JavnoNadmetanjeVO javnoNadmetanjeVO)
        {/*
            if (javnoNadmetanjeDTO == null)
            {
                return BadRequest(javnoNadmetanjeDTO);
            }
            if (javnoNadmetanjeDTO.JavnoNadmetanjeID > 0)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
            var javnoNadmetanje = _javnoNadmetanjeRepository.GetJavnaNadmetanja().Where(c => c.JavnoNadmetanjeID == javnoNadmetanjeDTO.JavnoNadmetanjeID).FirstOrDefault();

            if (javnoNadmetanjeDTO != null)
            {
                ModelState.AddModelError("", "Javno nadmetanje already exists");
                return StatusCode(422, ModelState);
            }

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var javnoNadmetanjeMap = _mapper.Map<JavnoNadmetanjeVO>(javnoNadmetanjeDTO);

            if (!_javnoNadmetanjeRepository.CreateJavnoNadmetanje(javnoNadmetanjeMap))
            {
                ModelState.AddModelError("", "Something went wrong while saving");
                return StatusCode(500, ModelState);
            }

            return Ok("Successfully created");
            */
            try
            {
                JavnoNadmetanjeVO javnoNadmetanje = _mapper.Map<JavnoNadmetanjeVO>(javnoNadmetanjeVO);
                _javnoNadmetanjeRepository.CreateJavnoNadmetanje(javnoNadmetanje);
                _javnoNadmetanjeRepository.Save();
                return Ok("Successfully created");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Post error");
            }

        }


        /// <summary>
        /// Briše javno nadmetanje po zadatoj vrednosti id-a
        /// </summary>
        /// <param name="id"></param>
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpDelete("{id:int}", Name = "DeleteJavnoNadmetanje")]

        public IActionResult DeleteJavnoNadmetanje(int id)
        {

            var javnoNadmetanje = _javnoNadmetanjeRepository.GetJavnoNadmetanjeByID(id);
            if (!ModelState.IsValid) return BadRequest(ModelState);
            if (_javnoNadmetanjeRepository.GetJavnoNadmetanjeByID(id) == null) return StatusCode(500, ModelState);
            if (!_javnoNadmetanjeRepository.DeleteJavnoNadmetanje(javnoNadmetanje))
            {
                ModelState.AddModelError("", "Something went wrong while deleting javno nadmetanje");
            }
            return NoContent();
            /*
            if (_javnoNadmetanjeRepository.JavnoNadmetanjeExsists(id))
            {
                return NotFound();
            }

            var javnoNadmetanjeToDelete = _javnoNadmetanjeRepository.GetJavnoNadmetanjeByID(id);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (!_javnoNadmetanjeRepository.DeleteJavnoNadmetanje(javnoNadmetanjeToDelete))
            {
                ModelState.AddModelError("", "Something went wrong deleting javno nadmetanje");
            }

            _javnoNadmetanjeRepository.DeleteJavnoNadmetanje(javnoNadmetanjeToDelete);
            return NoContent(); */
        }

        /// <summary>
        /// Menja vrednosti postojećeg javnog nadmetanja
        /// </summary>
        /// <param name="updatedJavnoNadmetanje"></param>
        /// <returns>Potvrdu o izmenjenom objektu</returns>
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPut("{id:int}", Name = "UpdateJavnoNadmetanje")]
        public IActionResult UpdateJavnoNadmetanje(int id, [FromBody] JavnoNadmetanjeVOdto updatedJavnoNadmetanje)
        {
            if (updatedJavnoNadmetanje == null || id != updatedJavnoNadmetanje.JavnoNadmetanjeID)
            {
                return BadRequest();
            }

            if (!_javnoNadmetanjeRepository.JavnoNadmetanjeExsists(id))
                return NotFound();

            if (!ModelState.IsValid)
                return BadRequest();

            var javnoNadmetanjeMap = _mapper.Map<JavnoNadmetanjeVO>(updatedJavnoNadmetanje);

            if (!_javnoNadmetanjeRepository.UpdateJavnoNadmetanje(javnoNadmetanjeMap))
            {
                ModelState.AddModelError("", "Something went wrong updating javno nadmetanjes");
                return StatusCode(500, ModelState);
            }

            return NoContent();

        }
    }
}
