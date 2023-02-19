using AutoMapper;
using LicnostProjekat.Data.DTO;
using LicnostProjekat.Interfaces;
using LicnostProjekat.Models;
using LicnostProjekat.Repository;
using Microsoft.AspNetCore.Mvc;

namespace LicnostProjekat.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class KontaktOsobaController : Controller
    {
        private readonly IKontaktOsobaRepository _kontaktOsoba;
        private readonly IMapper _mapper;

        public KontaktOsobaController(IKontaktOsobaRepository kontaktOsoba, IMapper mapper)
        {
            _kontaktOsoba = kontaktOsoba;
            _mapper = mapper;
        }
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<KontaktOsoba>))]
        public IActionResult getKontaktOsobas()
        {
            var kontaktOsobas = _mapper.Map<List<KontaktOsobaDTO>>(_kontaktOsoba.GetKontaktOsobas());
            if (!ModelState.IsValid) { return BadRequest(ModelState); }
            return Ok(kontaktOsobas);
        }
        /// <summary>
        /// Vraća sve Kontakt Osobe 
        /// </summary>
        /// <returns>Listu Kontakt Osoba</returns>
        [HttpGet("{kontaktOsobaID}")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<KontaktOsoba>))]
        [ProducesResponseType(400)]
        public IActionResult getKontaktOsoba(int kontaktOsobaID)
        {
            var kontaktOsoba = _mapper.Map<KontaktOsobaDTO>(_kontaktOsoba.getKontaktOsobaByID(kontaktOsobaID));
            if (!ModelState.IsValid) return BadRequest(ModelState);
            return Ok(kontaktOsoba);
        }
        /// <summary>
        /// Vraća Kontakt Osobu po zadatoj vrednosti id-a
        /// </summary>
        /// <param name="kontaktOsobaID"></param>
        /// <returns>Objekat KontaktOsobe</returns>
        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult CreateKontaktOsoba([FromBody] KontaktOsobaDTO kontaktOsobaCreate)
        {
            if (kontaktOsobaCreate == null) return BadRequest(ModelState);

            var adresa = _kontaktOsoba.GetKontaktOsobas().Where(c => c.Telefon.Trim().ToUpper() == kontaktOsobaCreate.Telefon.TrimEnd().ToUpper()).FirstOrDefault();
            if (adresa != null)
            {
                ModelState.AddModelError("", "Kontakt Osoba vec Postoji");
                return StatusCode(422, ModelState);
            }
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var kontaktOsobaMap = _mapper.Map<KontaktOsoba>(kontaktOsobaCreate);

            if (!_kontaktOsoba.CreateKontaktOsoba(kontaktOsobaMap))
            {
                ModelState.AddModelError("", "Nesto  je poslo po zlu pri cuvanju");
                return StatusCode(500, ModelState);
            }
            return Ok("Uspesno Kreirano");
        }
        /// <summary>
        /// Kreira novu Kontakt Osobu
        /// </summary>
        /// <param name="KontaktOsoba"></param>
        /// <returns>Potvrdu o kreiranom oglasu</returns>
        /// <response code="204">Kontakt Osoba kreirana</response>
        /// <response code="400">Poslat neispravan zahtev</response>

        [HttpPut("{kontaktOsobaID}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult UpdateKontaktOsoba(int kontaktOsobaID, [FromBody] KontaktOsobaDTO updatedKontaktOsoba)
        {
            if (updatedKontaktOsoba == null) return BadRequest(ModelState);
            if (kontaktOsobaID != updatedKontaktOsoba.KontaktOsobaID) return BadRequest(ModelState);
            if (!ModelState.IsValid) return BadRequest();

            var kontaktOsobaMap = _mapper.Map<KontaktOsoba>(updatedKontaktOsoba);
            if (!_kontaktOsoba.UpdateKontaktOsoba(kontaktOsobaMap))
            {
                ModelState.AddModelError("", "Nesto je otislo po zlu pri Update-ovanju");
                return StatusCode(500, ModelState);
            }
            return NoContent();
        }
        /// <summary>
        /// Menja vrednosti postojeće Kontakt Osobe
        /// </summary>
        /// <param name="updatedKontaktOsoba"></param>
        /// <returns>Potvrdu o izmenjenom objektu</returns>

        [HttpDelete("{kontaktOsobaID}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult DeleteKontatkOsoba(int kontaktOsobaID)
        {
            var KontaktOsobaToDelete = _kontaktOsoba.getKontaktOsobaByID(kontaktOsobaID);
            if (!ModelState.IsValid) return BadRequest(ModelState);
            if (_kontaktOsoba.getKontaktOsobaByID(kontaktOsobaID) == null) return StatusCode(500, ModelState);
            if (!_kontaktOsoba.DeleteKontaktOsoba(KontaktOsobaToDelete))
            {
                ModelState.AddModelError("", "Nesto je poslo po zlu pri Brisanju");
            }
            return NoContent();
        }
        /// <summary>
        /// Briše KOntakt Osoba po zadatoj vrednosti id-a
        /// </summary>
        /// <param name="kontaktOsobaID"></param>
    }
}
