using AutoMapper;
using Licitacija_Project.Interface;
using Licitacija_Project.Models;
using Licitacija_Project.Models.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Net.WebSockets;

namespace Licitacija_Project.Controllers
{
    [Route("api/JavnoNadmetanjeVOController")]
    [ApiController]
    public class JavnoNadmetanjeVOController : Controller
    {
        private readonly IJavnoNadmetanjeVORepository _javnoNadmetanjeVORepository;
        private readonly IMapper _mapper;

        public  JavnoNadmetanjeVOController(IJavnoNadmetanjeVORepository javnoNadmetanjeVORepository, IMapper mapper)
        {
            _javnoNadmetanjeVORepository = javnoNadmetanjeVORepository;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<JavnoNadmetanjeVO>))]
        public IActionResult getJavnaNadmetanja()
        {
            var jNAd  = _mapper.Map<List<JavnoNadmetanjeVODTO>>(_javnoNadmetanjeVORepository.GetJavnoNadmetanjes());
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            return Ok(jNAd);
        }
        [HttpGet("{JavnoNadmetanjeID}")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<JavnoNadmetanjeVO>))]
        [ProducesResponseType(400)]
        public IActionResult GetAdresa(int JavnoNadmetanjeID)
        {
            var dokument = _mapper.Map<JavnoNadmetanjeVO>(_javnoNadmetanjeVORepository.GetJavnoNadmetanjeById(JavnoNadmetanjeID));
            if (!ModelState.IsValid) return BadRequest(ModelState);
            return Ok(dokument);
        }

        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult CreateJavnaNadmetanja([FromBody] JavnoNadmetanjeVODTO javnoNadmetanjeCreate)
        {
            if (javnoNadmetanjeCreate == null) return BadRequest(ModelState);

            var dokument = _javnoNadmetanjeVORepository.GetJavnoNadmetanjes().Where(c => c.JavnoNadmetanjeID == javnoNadmetanjeCreate.JavnoNadmetanjeID).FirstOrDefault();
            if (dokument != null)
            {
                ModelState.AddModelError("", "JavnoNadmetanje vec Postoji");
                return StatusCode(422, ModelState);
            }
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var dokumentMap = _mapper.Map<JavnoNadmetanjeVO>(javnoNadmetanjeCreate);

            if (!_javnoNadmetanjeVORepository.CreateJavnoNadmetanje(dokumentMap))
            {
                ModelState.AddModelError("", "Nesto  je poslo po zlu pri cuvanju");
                return StatusCode(500, ModelState);
            }
            return Ok("Uspesno Kreirano");
        }

        [HttpPut("{JavnoNadmetanjeID}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult UpdateJavnoNadmetanje(int JavnoNadmetanjeID, [FromBody] JavnoNadmetanjeVODTO updatedJavnoNadmetanje)
        {
            if (updatedJavnoNadmetanje == null) return BadRequest(ModelState);
            if (JavnoNadmetanjeID != updatedJavnoNadmetanje.JavnoNadmetanjeID) return BadRequest(ModelState);
            if (!ModelState.IsValid) return BadRequest();

            var dokumentMap = _mapper.Map<JavnoNadmetanjeVO>(updatedJavnoNadmetanje);
            if (!_javnoNadmetanjeVORepository.UpdateJavnoNadmetanje(dokumentMap))
            {
                ModelState.AddModelError("", "Nesto je otislo po zlu pri Update-ovanju");
                return StatusCode(500, ModelState);
            }
            return NoContent();
        }

        [HttpDelete("{JavnoNadmetanjeID}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult DeleteJavnoNadmetanje(int JavnoNadmetanjeID)
        {
            var dokumentToDelete = _javnoNadmetanjeVORepository.GetJavnoNadmetanjeById(JavnoNadmetanjeID);
            if (!ModelState.IsValid) return BadRequest(ModelState);
            if (_javnoNadmetanjeVORepository.GetJavnoNadmetanjeById(JavnoNadmetanjeID) == null) return StatusCode(500, ModelState);
            if (!_javnoNadmetanjeVORepository.DeleteJavnoNadmetanje(dokumentToDelete))
            {
                ModelState.AddModelError("", "Nesto je poslo po zlu pri Brisanju");
                return StatusCode(500, ModelState);
            }
            return NoContent();
        }
    }
}
