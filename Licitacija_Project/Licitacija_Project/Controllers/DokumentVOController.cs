using AutoMapper;
using Licitacija_Project.Interface;
using Licitacija_Project.Models;
using Licitacija_Project.Models.DTO;
using Microsoft.AspNetCore.Mvc;
using System.Net.WebSockets;

namespace Licitacija_Project.Controllers
{
    [Route("api/DokumentVOController")]
    [ApiController]
    public class DokumentVOController : Controller
    {
        private readonly IDokumentVORepository _dokumentRepository;
        private readonly IMapper _mapper;

        public DokumentVOController(IDokumentVORepository dokumentVORepository, IMapper mapper)
        {
            _dokumentRepository = dokumentVORepository;
            _mapper = mapper;
        }
      
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<DokumentVO>))]
        public IActionResult getDokumenti()
        {
            var dokumenti = _mapper.Map<List<DokumentVODTO>>(_dokumentRepository.GetDokumentVOs());
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            return Ok(dokumenti);
        }
 


        [HttpGet("{dokumentID}")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<DokumentVO>))]
        [ProducesResponseType(400)]
        public IActionResult GetAdresa(int dokumentID)
        {
            var dokument = _mapper.Map<DokumentVO>(_dokumentRepository.GetDokumentVOById(dokumentID));
            if (!ModelState.IsValid) return BadRequest(ModelState);
            return Ok(dokument);
        }

        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult CreateAdresa([FromBody] DokumentVODTO dokumentCreate)
        {
            if (dokumentCreate == null) return BadRequest(ModelState);

            var dokument = _dokumentRepository.GetDokumentVOs().Where(c => c.DokumentID == dokumentCreate.DokumentID).FirstOrDefault();
            if (dokument != null)
            {
                ModelState.AddModelError("", "Dokument vec Postoji");
                return StatusCode(422, ModelState);
            }
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var dokumentMap = _mapper.Map<DokumentVO>(dokumentCreate);

            if (!_dokumentRepository.CreateDokumentVO(dokumentMap))
            {
                ModelState.AddModelError("", "Nesto  je poslo po zlu pri cuvanju");
                return StatusCode(500, ModelState);
            }
            return Ok("Uspesno Kreirano");
        }


        [HttpPut("{DokumentID}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult UpdateDokumentVO(int DokumentID, [FromBody] DokumentVODTO updatedDokument)
        {
            if(updatedDokument== null) return BadRequest(ModelState);
            if (DokumentID != updatedDokument.DokumentID) return BadRequest(ModelState);
            if(!ModelState.IsValid) return BadRequest();

            var dokumentMap = _mapper.Map<DokumentVO>(updatedDokument);
            if(!_dokumentRepository.UpdateDokumentVO(dokumentMap))
            {
                ModelState.AddModelError("", "Nesto je otislo po zlu pri Update-ovanju");
                return StatusCode(500, ModelState);
            }
            return NoContent();
        }
        




        [HttpDelete("{dokumentID}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult DeleteDokument(int dokumentID)
        {
            var dokumentToDelete = _dokumentRepository.GetDokumentVOById(dokumentID);
            if (!ModelState.IsValid) return BadRequest(ModelState);
            if (_dokumentRepository.GetDokumentVOById(dokumentID) == null) return StatusCode(500, ModelState);
            if (!_dokumentRepository.DeleteDokumentVO(dokumentToDelete))
            {
                ModelState.AddModelError("", "Nesto je poslo po zlu pri Brisanju");
                return StatusCode(500, ModelState);
            }
            return NoContent();
        }

    }
}
