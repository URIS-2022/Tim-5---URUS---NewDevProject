using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using NadmetanjeApp.Dto;
using NadmetanjeApp.Interfaces;
using NadmetanjeApp.Models;
using NadmetanjeApp.Repository;

namespace NadmetanjeApp.Controllers
{
    /// <summary>
    /// Predstavlja kontroler Otvaranja ponude
    /// </summary>
    [Route("api/OtvaranjePonudeAPI")]
    [ApiController]
    public class OtvaranjePonudeController : Controller
    {
        private readonly IOtvaranjePonudeRepository _otvaranjePonudeRepository;
        private readonly INadmetanjeRepository _nadmetanjeRpository;
        private readonly IMapper _mapper;

        public OtvaranjePonudeController(IOtvaranjePonudeRepository otvaranjePonudeRepository,
            INadmetanjeRepository nadmetanjeRepository,
            IMapper mapper)
        {
            _otvaranjePonudeRepository = otvaranjePonudeRepository;
            _nadmetanjeRpository = nadmetanjeRepository;
            _mapper = mapper;
        }
        /// <summary>
        /// Vraća otvaranje ponude
        /// </summary>
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<OtvaranjePonude>))]
        public IActionResult GetOtvaranjePonuda()
        {
            var otvaranjePonuda =_mapper.Map<List<OtvaranjePonude>>( _otvaranjePonudeRepository.GetOtvaranjePonuda());

            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(otvaranjePonuda);
        }

        /// <summary>
        /// Vraća otvaranje ponude po id-u
        /// </summary>
        [HttpGet("{OtvaranjePonudeID}")]
        [ProducesResponseType(200, Type = typeof(OtvaranjePonude))]
        [ProducesResponseType(400)]

        public async Task<IActionResult> GetOtvaranjePonude(int OtvaranjePonudeID)
        {
            if (!_otvaranjePonudeRepository.OtvaranjePonudeExists(OtvaranjePonudeID))
                return NotFound();

            var otvaranjePonude = _mapper.Map<OtvaranjePonudeDto>( _otvaranjePonudeRepository.GetOtvaranjePonude(OtvaranjePonudeID));

            var path = "https://localhost:7098/api/NadmetanjeAPI/" + otvaranjePonude.NadmetanjeID;

            var response = await HttpClient<NadmetanjeDto>.GetAsync(path);

            otvaranjePonude.NadmetanjeDto = response;


            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(otvaranjePonude);
        }

        /// <summary>
        /// Kreira novo otvaranje ponude
        /// </summary>
        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult CreateOtvaranjePonude([FromBody] OtvaranjePonudeCreateDTO otvaranjePonudeCreate)
        {
            if (otvaranjePonudeCreate == null)
                return BadRequest(ModelState);

            var otvaranjePonude = _otvaranjePonudeRepository.GetOtvaranjePonuda()
                .Where(a => a.OtvaranjePonudeID == otvaranjePonudeCreate.OtvaranjePonudeID).FirstOrDefault();

            if (otvaranjePonude != null)
            {
                ModelState.AddModelError("", "Otvaranje vec Postoji");
                return StatusCode(422, ModelState);
            }
            

            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var otvaranjeMap = _mapper.Map<OtvaranjePonude>(otvaranjePonudeCreate);



            if (!_otvaranjePonudeRepository.CreateOtvaranjePonude(otvaranjeMap))
            {
                ModelState.AddModelError("", "Nesto  je poslo po zlu pri cuvanju");
                return StatusCode(500, ModelState);
            }
            return Ok("Uspesno Kreirano");

        }
        /// <summary>
        /// Modifikuje otvaranje ponude
        /// </summary>
        [HttpPut("{OtvaranjePonudeID}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult UpdateOtvaranjePonude(int OtvaranjePonudeID, [FromBody] OtvaranjePonudeUpdateDTO updatedOtvaranjePonude)
        {
            if (updatedOtvaranjePonude == null)
                return BadRequest(ModelState);

            if (OtvaranjePonudeID != updatedOtvaranjePonude.OtvaranjePonudeID)
                return BadRequest(ModelState);
            if (!_otvaranjePonudeRepository.OtvaranjePonudeExists(OtvaranjePonudeID))
                return NotFound();

            if (!ModelState.IsValid) return BadRequest(ModelState);

            var otvaranjePonudeMap = _mapper.Map<OtvaranjePonude>(updatedOtvaranjePonude);

            if (!_otvaranjePonudeRepository.UpdateOtvaranjePonude(otvaranjePonudeMap))
            {
                ModelState.AddModelError("", "Nesto je otislo po zlu pri Update-ovanju");
                return StatusCode(500, ModelState);
            }

            return NoContent();

        }
        /// <summary>
        /// Brise otvaranje ponude po zadatom id-u
        /// </summary>
        [HttpDelete("{OtvaranjePonudeID}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult DeleteOtvaranjePonude(int OtvaranjePonudeID)
        {
            if(!_otvaranjePonudeRepository.OtvaranjePonudeExists(OtvaranjePonudeID))
            {
                return NotFound();
            }

            var nadmetanjeToDelte = _nadmetanjeRpository.GetNadmetanje(OtvaranjePonudeID);
            var otvaranjePOnudeDelete = _otvaranjePonudeRepository.GetOtvaranjePonude(OtvaranjePonudeID);


            if (!ModelState.IsValid)
                return BadRequest(ModelState);


            if (!_otvaranjePonudeRepository.DeleteOtvaranjePonude(otvaranjePOnudeDelete))
            {
                ModelState.AddModelError("", "Nesto je poslo po zlu pri Brisanju");
            }
            return NoContent();
        }
    }
}
