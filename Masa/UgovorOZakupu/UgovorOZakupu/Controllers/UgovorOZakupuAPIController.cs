using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using UgovorOZakupu.Interfaces;
using UgovorOZakupu.Models.DTOs;
using UgovorOZakupu.Models;

namespace UgovorOZakupu.Controllers
{

    /// <summary>
    /// Predstavlja kontroler ugovora o zakupu
    /// </summary>

    //[Route("api/[controller]")]
    [Route("api/UgovorOZakupuAPIController")]
    [ApiController]
    public class UgovorOZakupuAPIController : ControllerBase
    {

        private readonly IUgovorOZakupuRepository _ugovorRepository;
        private readonly IMapper _mapper;
        public UgovorOZakupuAPIController(IUgovorOZakupuRepository ugovorRepository, IMapper mapper)
        {
            _ugovorRepository = ugovorRepository;
            
            _mapper = mapper;
        }

        /// <summary>
        /// Vraća sve ugovore o zakupu 
        /// </summary>
        /// <returns>Listu ugovora o zakupu</returns>
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Models.UgovorOZakupu>))]

        public IActionResult GetUgovori()
        {
            var ugovori = _mapper.Map<List<UgovorOZakupudto>>(_ugovorRepository.GetUgovoriOZakupu());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(ugovori);
        }


        /// <summary>
        /// Vraća ugovor o zakupu po zadatoj vrednosti id-a
        /// </summary>
        /// <param name="UgovorID"></param>
        /// <returns>Objekat ugovora o zakupu</returns>


        [HttpGet("{id:int}", Name = "GetUgovoriByID")]
        [ProducesResponseType(200, Type = typeof(UgovorOZakupudto))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]


        public async Task<IActionResult> GetUgovorOZakupu(int id)
        {
            if (!_ugovorRepository.UgovorOZakupuExsists(id))
                return NotFound();
            var ugovor = _mapper.Map<UgovorOZakupudto>(_ugovorRepository.GetUgovorOZakupuByID(id));

            var path = "https://localhost:7099/api/Kupac/" + ugovor.kupacID;

            var response = await HttpClient<KupacVO>.GetAsync(path);

            ugovor.kupac = response;



            var path1 = "https://localhost:7195/api/DokumentAPI/" + ugovor.dokumentID;

            var response1 = await HttpClient<DokumentVO>.GetAsync(path);

            ugovor.dokument = response1;



            var path2 = "https://localhost:7013/api/Licnost/" + ugovor.licnostID;

            var response2 = await HttpClient<LicnostVO>.GetAsync(path);

            ugovor.licnost = response2;


            var path3 = "https://localhost:7098/api/JavnoNadmetanjeAPI/" + ugovor.javnoNadmetanjeID;

            var response3 = await HttpClient<JavnoNadmetanjeVO>.GetAsync(path);

            ugovor.javnoNadmetanje = response3;


            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(ugovor);
        }


        /// <summary>
        /// Kreira novi ugovor
        /// </summary>
        /// <param name="ugovorDTO"></param>
        /// <returns>Potvrdu o kreiranom ugovoru</returns>
        /// <response code="204">ugovor uspesno kreiran</response>
        /// <response code="400">Poslat neispravan zahtev</response>
        /// <response code="404">Nije pronadjen </response>


        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<UgovorOZakupuDTOCreate> CreateUgovorOZakupu([FromBody] UgovorOZakupuDTOCreate ugovorDTO)
        {
            if (ugovorDTO == null)
            {
                return BadRequest(ugovorDTO);
            }
            if (ugovorDTO.UgovorID > 0)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
            var ugovor = _ugovorRepository.GetUgovoriOZakupu().Where(c => c.UgovorID == ugovorDTO.UgovorID).FirstOrDefault();

            if (ugovor != null)
            {
                ModelState.AddModelError("", "Ugovor already exists");
                return StatusCode(422, ModelState);
            }

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            
            var ugovorMap = _mapper.Map<Models.UgovorOZakupu>(ugovorDTO);

            if (!_ugovorRepository.CreateUgovorOZakupu(ugovorMap))
            {
                ModelState.AddModelError("", "Something went wrong while saving");

                return StatusCode(500, ModelState);
            }

            return Ok("Successfully created");

        }

        /// <summary>
        /// Briše ugovor po zadatoj vrednosti id-a
        /// </summary>
        /// <param name="id"></param>

        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpDelete("{id:int}", Name = "DeleteUgovor")]

        public IActionResult DeleteUgovor(int id)
        {


            var ugovor = _ugovorRepository.GetUgovorOZakupuByID(id);
            if (!ModelState.IsValid) return BadRequest(ModelState);
            if (_ugovorRepository.GetUgovorOZakupuByID(id) == null) return StatusCode(500, ModelState);
            if (!_ugovorRepository.DeleteUgovorOZakupu(ugovor))
            {
                ModelState.AddModelError("", "Something went wrong while deleting ugovor");
            }
            return NoContent();
        }

        /// <summary>
        /// Menja vrednosti postojećeg ugovora
        /// </summary>
        /// <param name="updatedUgovor"></param>
        /// <returns>Potvrdu o izmenjenom objektu</returns>
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPut("{id:int}", Name = "UpdateUgovor")]
        public IActionResult UpdateUgovor(int id, [FromBody] UgovorOZakupuDTOUpdate updatedUgovor)
        {
            if (updatedUgovor == null || id != updatedUgovor.UgovorID)
            {
                return BadRequest();
            }

            if (!_ugovorRepository.UgovorOZakupuExsists(id))
                return NotFound();

            if (!ModelState.IsValid)
                return BadRequest();

            var ugovorMap = _mapper.Map<Models.UgovorOZakupu>(updatedUgovor);

            if (!_ugovorRepository.UpdateUgovorOZakupu(ugovorMap))
            {
                ModelState.AddModelError("", "Something went wrong updating ugovor");
                return StatusCode(500, ModelState);
            }

            return NoContent();

        }
    }
}
