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
    public class AdresaController : Controller
    {
        private readonly IAdresaRepository _adresaRepository;
        private readonly IMapper _mapper;

        public AdresaController(IAdresaRepository adresaRepository, IMapper mapper)
        {
            _adresaRepository = adresaRepository;
            _mapper = mapper;
        }
        /// <summary>
        /// Predstavlja kontroler Adrese
        /// </summary>
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Adresa>))]
        public IActionResult getAdresas()
        {
            var adresas = _mapper.Map<List<AdresaDTO>>(_adresaRepository.GetAdresas());
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            return Ok(adresas);
        }
        /// <summary>
        /// Vraća sve Adrese 
        /// </summary>
        /// <returns>Listu Adresa</returns>
        /// 



        [HttpGet("{adresaID}")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Adresa>))]
        [ProducesResponseType(400)]
        public IActionResult GetAdresa(int adresaID)
        {
            var adresa = _mapper.Map<Adresa>(_adresaRepository.getAdresaByID(adresaID));
            if (!ModelState.IsValid) return BadRequest(ModelState);
            return Ok(adresa);
        }
        /// <summary>
        /// Vraća Adresu po zadatoj vrednosti id-a
        /// </summary>
        /// <param name="adresaID"></param>
        /// <returns>Objekat Adrese</returns>

        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult CreateAdresa([FromBody] AdresaDTO adresaCreate)
        {
            if (adresaCreate == null) return BadRequest(ModelState);

            var adresa = _adresaRepository.GetAdresas().Where(c => c.Ulica.Trim().ToUpper() == adresaCreate.Ulica.TrimEnd().ToUpper()).FirstOrDefault();
            if (adresa != null)
            {
                ModelState.AddModelError("", "Ulica vec Postoji");
                return StatusCode(422, ModelState);
            }
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var adresaMap = _mapper.Map<Adresa>(adresaCreate);

            if (!_adresaRepository.CreateAdresa(adresaMap))
            {
                ModelState.AddModelError("", "Nesto  je poslo po zlu pri cuvanju");
                return StatusCode(500, ModelState);
            }
            return Ok("Uspesno Kreirano");
        }
        /// <summary>
        /// Kreira novu Adresu
        /// </summary>
        /// <param name="adresaCreate"></param>
        /// <returns>Potvrdu o Kreiranoj  Adresi</returns>
        /// <response code="204">Adresa uspesno obrisan</response>
        /// <response code="400">Poslat neispravan zahtev</response>
        /// <response code="404">Nije pronadjena Adresa za brisanje</response>




        [HttpPut("{adresaID}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult UpdateAdresa(int adresaID, [FromBody] AdresaDTO updatedAdresa)
        {
            if (updatedAdresa == null) return BadRequest(ModelState);
            if (adresaID != updatedAdresa.AdresaID) return BadRequest(ModelState);
            if (!ModelState.IsValid) return BadRequest();

            var adresaMap = _mapper.Map<Adresa>(updatedAdresa);
            if (!_adresaRepository.UpdateAdresa(adresaMap))
            {
                ModelState.AddModelError("", "Nesto je otislo po zlu pri Update-ovanju");
                return StatusCode(500, ModelState);
            }
            return NoContent();
        }
        /// <summary>
        /// Menja vrednosti postojeće adrese
        /// </summary>
        /// <param name="updatedAdresa"></param>
        /// <returns>Potvrdu o izmenjenoj adresi</returns>




        [HttpDelete("{adresaID}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult DeleteAdresa(int adresaID)
        {
            var adresaToDelete = _adresaRepository.getAdresaByID(adresaID);
            if (!ModelState.IsValid) return BadRequest(ModelState);
            if(_adresaRepository.getAdresaByID(adresaID) == null) return StatusCode(500, ModelState);
            if (!_adresaRepository.DeleteAdresa(adresaToDelete))
            {
                ModelState.AddModelError("", "Nesto je poslo po zlu pri Brisanju");
                return StatusCode(500, ModelState);
            }
            return NoContent();
        }
        /// <summary>
        /// Briše Adresu po zadatoj vrednosti id-a
        /// </summary>
        /// <param name="adresaID"></param>
    }
}
