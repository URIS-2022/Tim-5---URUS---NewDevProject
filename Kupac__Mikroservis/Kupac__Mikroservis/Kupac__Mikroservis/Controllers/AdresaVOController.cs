using AutoMapper;
using Kupac__Mikroservis.Interfaces;
using Kupac__Mikroservis.Models;
using Kupac__Mikroservis.Models.DTO;
using Microsoft.AspNetCore.Mvc;

namespace Kupac__Mikroservis.Controllers
{

    /// <summary>
    /// Predstavlja kontroler adrese
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class AdresaVOController : Controller
    {
        private readonly IAdresaVORepository _adresaVORepository;
        private readonly IMapper _mapper;

        public AdresaVOController(IAdresaVORepository adresaVORepository, IMapper mapper)
        {
            _adresaVORepository = adresaVORepository;
            _mapper = mapper;
        }

        /// <summary>
        /// Vraća sve adrese 
        /// </summary>
        /// <returns>Listu adresa</returns>

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<AdresaVO>))]
        public IActionResult GetAdresaVOs()
        {
            var adresaVOs = _mapper.Map<List<AdresaVODTO>>(_adresaVORepository.GetAdresaVOs());

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(adresaVOs);
        }

        /// <summary>
        /// Vraća adresu po zadatoj vrednosti id-a
        /// </summary>
        /// <param name="AdresaID"></param>
        /// <returns>Objekat adrese</returns>

        [HttpGet("{id}")]
        [ProducesResponseType(200, Type = typeof(AdresaVO))]
        [ProducesResponseType(400, Type = typeof(AdresaVO))]
        public IActionResult GetAdresaVO(int id)
        {
            if (!_adresaVORepository.AdresaVOExist(id))
                return NotFound();

            var adresaVO = _mapper.Map<AdresaVODTO>(_adresaVORepository.GetAdresaVOById(id));

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(adresaVO);
        }

        /// <summary>
        /// Kreira novu adresu
        /// </summary>
        /// <param name="Adresa"></param>
        /// <returns>Potvrdu o kreiranoj adresi</returns>


        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]

        public IActionResult CreateAdresaVO([FromBody] AdresaVO adresaVOCreate)
        {
          


            try
            {
                AdresaVO adresaVO = _mapper.Map<AdresaVO>(adresaVOCreate);
                _adresaVORepository.CreateAdresaVO(adresaVO);
                _adresaVORepository.Save();
                return Ok("Successfully created");

            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Post error");
            }
        }

        /// <summary>
        /// Menja vrednosti postojeće adrese
        /// </summary>
        /// <param name="Adresa"></param>
        /// <returns>Potvrdu o izmenjenoj adresi</returns>

        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [HttpPut("{id}")]

        public IActionResult UpdateAdresaVO(int id, [FromBody] AdresaVO updateAdresaVO)
        {
            if (updateAdresaVO == null)
                return BadRequest(ModelState);

            if (id != updateAdresaVO.AdresaID)
                return BadRequest(ModelState);

            if (!_adresaVORepository.AdresaVOExist(id))
                return NotFound();

            if (!ModelState.IsValid)
                return BadRequest();


            if (!_adresaVORepository.UpdateAdresaVO(updateAdresaVO))
            {
                ModelState.AddModelError("", "Something went wrong while updating adresa");
                return StatusCode(500, ModelState);

            }

            return NoContent();
        }

        /// <summary>
        /// Briše adresu po zadatoj vrednosti id-a
        /// </summary>
        /// <param name="AdresaID"></param>

        [HttpDelete("{id}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult DeleteAdresaVO(int id)
        {
            var adresaVO = _adresaVORepository.GetAdresaVOById(id);
            if (!ModelState.IsValid) return BadRequest(ModelState);
            if (_adresaVORepository.GetAdresaVOById(id) == null)
                return StatusCode(500, ModelState);
            if (!_adresaVORepository.DeleteAdresaVO(adresaVO))
            {
                ModelState.AddModelError("", "Something went wrong while deleting adresa");
            }
            return NoContent();
        }

    }
}
