using AutoMapper;
using Dokument_Sergej.Data.DTO;
using Dokument_Sergej.Interfaces;
using Dokument_Sergej.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using RouteAttribute = Microsoft.AspNetCore.Mvc.RouteAttribute;

namespace Dokument_Sergej.Controllers
{
    /// <summary>
    /// Predstavlja kontroler dokumenta
    /// </summary>

    [Route("api/DokumentAPI")]
    [ApiController]
    public class DokumentController : Controller
    {
        private readonly IDokumentRepository _dokumentRepository;
        private readonly IMapper _mapper;

        public DokumentController(IDokumentRepository dokumentRepository, IMapper mapper)
        {
            _dokumentRepository= dokumentRepository; 
            _mapper = mapper;
        }

        /// <summary>
        /// Vraća sve dokumente
        /// </summary>
        /// <returns>Listu dokumenata</returns>

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Dokument>))]
        public IActionResult GetDokumenti()
        {
            var dokumenti = _mapper.Map<List<Dokument>>(_dokumentRepository.GetDokumenti());

            if (!ModelState.IsValid) 
                return BadRequest(ModelState);
            return Ok(dokumenti);   
        }

        /// <summary>
        /// Vraća dokument po zadatoj vrednosti id-a
        /// </summary>
        /// <param name="DokumentID"></param>
        /// <returns>Objekat dokumenta</returns>

        [HttpGet("{dokumentID:int}", Name ="getDokumentByID")]
        [ProducesResponseType(200,Type=typeof(IEnumerable<Dokument>))]
        [ProducesResponseType(400)]

        public async Task<IActionResult> GetDokument(int dokumentID)
        {
            if (!_dokumentRepository.DokumentExsists(dokumentID))
                return NotFound();

            var dokument = _mapper.Map<DokumentDTO>(_dokumentRepository.GetDokumentByID(dokumentID));


            var path = "https://localhost:7013/api/Licnost/" + dokument.LicnostID;

            var response = await HttpClient<Licnost>.GetAsync(path);

            dokument.Licnost = response;


            //var path1 = "https://localhost:7261/api/KorisniciSistema/" + dokument.KorisnikID;

            //var response1 = await HttpClient<KorisnikSistema>.GetAsync(path1);

            //dokument.KorisnikSistema = response1;

            if (!ModelState.IsValid) return BadRequest(ModelState);
            return Ok(dokument);
        }

        /// <summary>
        /// Kreira novi dokument
        /// </summary>
        /// <param name="dokument"></param>
        /// <returns>Potvrdu o kreiranom dokumentu</returns>
        /// <response code="204">Dokument uspesno obrisan</response>
        /// <response code="400">Poslat neispravan zahtev</response>
        /// <response code="404">Nije pronadjen dokument za brisanje</response>

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<Dokument> CreateDocument([FromBody] DokumentDTOCreate dokument1)
        {
            if (dokument1 == null)
            {
                return BadRequest(ModelState);
            }
            if (dokument1.DokumentID > 0)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
            var dokument = _dokumentRepository.GetDokumenti().Where(c => c.DokumentID == dokument1.DokumentID).FirstOrDefault();

            if (dokument != null)
            {
                ModelState.AddModelError("", "Dokument already exists");
                return StatusCode(422, ModelState);
            }

            if (!ModelState.IsValid)
                return BadRequest(ModelState);


            var dokumentMap = _mapper.Map<Models.Dokument>(dokument1);

            if (!_dokumentRepository.CreateDokument(dokumentMap))
            {
                ModelState.AddModelError("", "Something went wrong while saving");
                return StatusCode(500, ModelState);
            }

            return Ok("Successfully created");

        }

        /// <summary>
        /// Menja vrednosti postojećeg dokumenta
        /// </summary>
        /// <param name="Dokument"></param>
        /// <returns>Potvrdu o izmenjenom objektu</returns>

        [HttpPut("{dokumentID}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult UpdateDokument(int dokumentID, [FromBody] DokumentDTOUpdate updatedDokument)
        {
            if (updatedDokument == null) return BadRequest(ModelState);
            if (dokumentID != updatedDokument.DokumentID) return BadRequest(ModelState);
            if(!_dokumentRepository.DokumentExsists(dokumentID)) return NotFound();
            if (!ModelState.IsValid) return BadRequest();

            var dokumentMap = _mapper.Map<Dokument>(updatedDokument);

            if (!_dokumentRepository.UpdateDokument(dokumentMap))
            {
                ModelState.AddModelError("", "Nesto je otislo po zlu pri Update-ovanju");
                return StatusCode(500, ModelState);
            }
            return NoContent();
        }

        /// <summary>
        /// Briše dokument po zadatoj vrednosti id-a
        /// </summary>
        /// <param name="DokumentID"></param>
        
        [HttpDelete("{dokumentID}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult DeleteDokument(int dokumentID)
        {
            var dokumentToDelete = _dokumentRepository.GetDokumentByID(dokumentID);
            if (!ModelState.IsValid) return BadRequest(ModelState);
            if (_dokumentRepository.GetDokumentByID(dokumentID) == null) return StatusCode(500, ModelState);
            if (!_dokumentRepository.DeleteDokument(dokumentToDelete))
            {
                ModelState.AddModelError("", "Nesto je poslo po zlu pri Brisanju");
                return StatusCode(500, ModelState);
            }
            return NoContent();
        }
    }
    
}
