using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Zalba_Mikroservis.Interfaces;
using Zalba_Mikroservis.Models;
using Zalba_Mikroservis.Models.DTO;
using Zalba_Mikroservis.Repository;

namespace Zalba_Mikroservis.Controllers
{

    /// <summary>
    /// Predstavlja kontroler kupca
    /// </summary>

    [Route("api/[controller]")]
    [ApiController]
    public class KupacVOController : Controller
    {
        private readonly IKupacVORepository _kupacVORepository;
        private readonly IMapper _mapper;

        public KupacVOController(IKupacVORepository kupacVORepository, IMapper mapper)
        {
            _kupacVORepository = kupacVORepository;
            _mapper = mapper;
        }

        /// <summary>
        /// Vraća sve kupce 
        /// </summary>
        /// <returns>Listu kupaca</returns>

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<KupacVO>))]
        public IActionResult GetKupacVOs()
        {
            var kupacVOs = _mapper.Map<List<KupacVODTO>>(_kupacVORepository.GetKupacVOs());

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(kupacVOs);
        }


        /// <summary>
        /// Vraća kupca po zadatoj vrednosti id-a
        /// </summary>
        /// <param name="KupacID"></param>
        /// <returns>Objekat kupca</returns>

        [HttpGet("{id}")]
        [ProducesResponseType(200, Type = typeof(KupacVO))]
        [ProducesResponseType(400, Type = typeof(KupacVO))]
        public IActionResult GetKupacVO(int id)
        {
            if (!_kupacVORepository.KupacVOExist(id))
                return NotFound();

            var kupacVO = _mapper.Map<KupacVODTO>(_kupacVORepository.GetKupacVOById(id));

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
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult CreateKupacVO([FromBody] KupacVO kupacVOCreate)
        {
            try
            {
                KupacVO kupacVO = _mapper.Map<KupacVO>(kupacVOCreate);
                _kupacVORepository.CreateKupacVO(kupacVO);
                _kupacVORepository.Save();
                return Ok("Successfully created");

            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Post error");
            }
        }

        /// <summary>
        /// Menja vrednosti postojećeg kupca
        /// </summary>
        /// <param name="Kupac"></param>
        /// <returns>Potvrdu o izmenjenom objektu</returns>

        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [HttpPut("{id}")]

        public IActionResult UpdateKupacVO(int id, [FromBody] KupacVO updateKupacVO)
        {
            if (updateKupacVO == null)
                return BadRequest(ModelState);

            if (id != updateKupacVO.KupacID)
                return BadRequest(ModelState);

            if (!_kupacVORepository.KupacVOExist(id))
                return NotFound();

            if (!ModelState.IsValid)
                return BadRequest();


            if (!_kupacVORepository.UpdateKupacVO(updateKupacVO))
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
        public IActionResult DeleteKupacVO(int id)
        {
            var kupacVO = _kupacVORepository.GetKupacVOById(id);
            if (!ModelState.IsValid) return BadRequest(ModelState);
            if (_kupacVORepository.GetKupacVOById(id) == null)
                return StatusCode(500, ModelState);
            if (!_kupacVORepository.DeleteKupacVO(kupacVO))
            {
                ModelState.AddModelError("", "Something went wrong while deleting kupac");
            }
            return NoContent();
        }
    }


}


