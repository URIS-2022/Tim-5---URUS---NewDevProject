using AutoMapper;
using LicnostProjekat.Data.DTO;
using LicnostProjekat.Interfaces;
using LicnostProjekat.Models;
using LicnostProjekat.Repository;
using Microsoft.AspNetCore.Mvc;


namespace LicnostProjekat.Controllers
{

    /// <summary>
    /// Predstavlja kontroler Fizickog Lica
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class FizickoLiceController : Controller
    {
        private readonly IFizickoLiceRepository _fizickoLice;
        private readonly IMapper _mapper;

        public FizickoLiceController(IFizickoLiceRepository fizickoLice, IMapper mapper)
        {
            _fizickoLice = fizickoLice;
            _mapper = mapper;
        }
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<FizickoLice>))]
        public IActionResult getFizickoLices()//izmena
        {
            var fizickaLica = _mapper.Map<List<FizickoLiceDTO>>(_fizickoLice.GetFizickoLices());
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            return Ok(fizickaLica);
        }
        /// <summary>
        /// Vraća sva Fizicka Lica 
        /// </summary>
        /// <returns>Listu Fizickoh lica</returns>



        [HttpGet("{fizickoLiceID}")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<FizickoLice>))]
        [ProducesResponseType(400)]
        public IActionResult getFizickoLice(int fizickoLiceID)
        {
            var fizickoLice = _mapper.Map<FizickoLiceDTO>(_fizickoLice.GetFizickoLice(fizickoLiceID));
            if (!ModelState.IsValid) return BadRequest(ModelState);
            return Ok(fizickoLice);

        }
        /// <summary>
        /// Vraća Fizicko Lice po zadatoj vrednosti id-a
        /// </summary>
        /// <param name="fizickoLiceID"></param>
        /// <returns>Objekat Fizickog Lica</returns>

        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult CreateFizickoLice([FromBody] FizickoLicePostDTO fizickoLiceCreate)
        {
            if (fizickoLiceCreate == null) return BadRequest(ModelState); //ovo je isto

            //ovo sam dodala
            if(fizickoLiceCreate.FizickoLiceID > 0)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }

            var fizickoLice = _fizickoLice.GetFizickoLices().Where(c => c.JMBG == fizickoLiceCreate.JMBG).FirstOrDefault();
            if (fizickoLice != null)
            {
                ModelState.AddModelError("", "Fizicko Lice vec Postoji");
                return StatusCode(422, ModelState);
            }
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var fizickoLiceMap = _mapper.Map<FizickoLice>(fizickoLiceCreate);

            if (!_fizickoLice.createFizickoLice(fizickoLiceMap))
            {
                ModelState.AddModelError("", "Nesto  je poslo po zlu pri cuvanju");
                return StatusCode(500, ModelState);
            }
            return Ok("Uspesno Kreirano");
        }
        /// <summary>
        /// Kreira novo Fizicko Lice
        /// </summary>
        /// <param name="fizickoLiceCreate"></param>
        /// <returns>Potvrdu o kreiranom Fizickom Licu</returns>
        /// <response code="204">Nema sadrzaja u odgovoru</response>
        /// <response code="400">Poslat neispravan zahtev</response>

        [HttpPut("{fizickoLiceID}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult UpdateFizickoLice(int fizickoLiceID, [FromBody] FizickoLiceUpdateDTO updatedFizickoLice)
        {
            if (updatedFizickoLice == null) return BadRequest(ModelState);
            if (fizickoLiceID != updatedFizickoLice.FizickoLiceID) return BadRequest(ModelState);
            if (!ModelState.IsValid) return BadRequest();

            var fizickoLiceMap = _mapper.Map<FizickoLice>(updatedFizickoLice);
            if (!_fizickoLice.updateFizickoLice(fizickoLiceMap))
            {
                ModelState.AddModelError("", "Nesto je otislo po zlu pri Update-ovanju");
                return StatusCode(500, ModelState);
            }
            return NoContent();
        }
        /// <summary>
        /// Menja vrednosti postojećeg Fizickog lIca
        /// </summary>
        /// <param name="fizickoLiceUpdate"></param>
        /// <returns>Potvrdu o izmenjenom objektu</returns>

        [HttpDelete("{fizickoLiceID}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult DeleteFizickoLice(int fizickoLiceID)
        {
            var fizickoLiceToDelete = _fizickoLice.GetFizickoLice(fizickoLiceID);
            if (!ModelState.IsValid) return BadRequest(ModelState);
            if (_fizickoLice.GetFizickoLice(fizickoLiceID) == null) return StatusCode(500, ModelState);

            if (!_fizickoLice.deleteFizickoLice(fizickoLiceToDelete))
            {
                ModelState.AddModelError("", "Nesto je poslo po zlu pri Brisanju");
            }
            return NoContent();
        }
        /// <summary>
        /// Briše fizicko lice po zadatoj vrednosti id-a
        /// </summary>
        /// <param name="fizickoLiceID"></param>
    }
}