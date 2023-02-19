using AutoMapper;
using LicnostProjekat.Data.DTO;
using LicnostProjekat.Interfaces;
using LicnostProjekat.Models;
using LicnostProjekat.Repository;
using Microsoft.AspNetCore.Mvc;

namespace LicnostProjekat.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KupacController : Controller
    {
        private readonly IKupacRepository _kupacRepository;
        private readonly IMapper _mapper;

        public KupacController(IKupacRepository kupacRepository, IMapper mapper)
        {
            _kupacRepository = kupacRepository;
            _mapper = mapper;
        }


        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Kupac>))]
        public IActionResult getKupci()
        {
            var kupci = _mapper.Map<List<KupacDTO>>(_kupacRepository.GetKupci());
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            return Ok(kupci);
        }
        /// <summary>
        /// Vraća sve Kupce 
        /// </summary>
        /// <returns>Listu kupaca</returns>


        [HttpGet("{kupacID}")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Kupac>))]
        [ProducesResponseType(400)]
        public IActionResult GetKupac(int kupacID)
        {
            var kupac = _mapper.Map<KupacDTO>(_kupacRepository.GetKupacByID(kupacID));
            if (!ModelState.IsValid) return BadRequest(ModelState);
            return Ok(kupac);
        }
        /// <summary>
        /// Vraća Kupca po zadatoj vrednosti id-a
        /// </summary>
        /// <param name="kupacID"></param>
        /// <returns>Objekat Kupca</returns>

        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult CreateAdresa([FromBody] KupacDTO kupacCreate)
        {
            if (kupacCreate == null) return BadRequest(ModelState);

            var kupac = _kupacRepository.GetKupci().Where(c => c.Lice.Trim().ToUpper() == kupacCreate.Lice.TrimEnd().ToUpper()).FirstOrDefault();
            if (kupac != null)
            {
                ModelState.AddModelError("", "Kupac vec Postoji");
                return StatusCode(422, ModelState);
            }
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var kupacMap = _mapper.Map<Kupac>(kupacCreate);

            if (!_kupacRepository.CreateKupac(kupacMap))
            {
                ModelState.AddModelError("", "Nesto  je poslo po zlu pri cuvanju");
                return StatusCode(500, ModelState);
            }
            return Ok("Uspesno Kreirano");
        }
        /// <summary>
        /// Kreira novog Kupca
        /// </summary>
        /// <param name="kupacCreate"></param>
        /// <returns>Potvrdu o kreiranom Kupcu</returns>
        /// <response code="204">Predsednik uspesno kreiran</response>
        /// <response code="400">Poslat neispravan zahtev</response>

        [HttpPut("{kupacID}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult UpdateKupac(int kupacID, [FromBody] KupacDTO updatedKupac)
        {
            if (updatedKupac == null) return BadRequest(ModelState);
            if (kupacID != updatedKupac.KupacID) return BadRequest(ModelState);
            if (!ModelState.IsValid) return BadRequest();

            var kupacMap = _mapper.Map<Kupac>(updatedKupac);
            if (!_kupacRepository.UpdateKupac(kupacMap))
            {
                ModelState.AddModelError("", "Nesto je otislo po zlu pri Update-ovanju");
                return StatusCode(500, ModelState);
            }
            return NoContent();
        }
        /// <summary>
        /// Menja vrednosti postojećeg kupca
        /// </summary>
        /// <param name="updatedKupac"></param>
        /// <returns>Potvrdu o izmenjenom kupcu</returns>

        [HttpDelete("{kupacID}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult DeleteKupac(int kupacID)
        {
            var kupacToDelete = _kupacRepository.GetKupacByID(kupacID);
            if (!ModelState.IsValid) return BadRequest(ModelState);
            if (!_kupacRepository.DeleteKupac(kupacToDelete))
            {
                ModelState.AddModelError("", "Nesto je poslo po zlu pri Brisanju");
            }
            return NoContent();
        }
        /// <summary>
        /// Briše kupca po zadatoj vrednosti id-a
        /// </summary>
        /// <param name="kupacID"></param>
    }
}