using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Parcela_MikroservisiProjekat.Interface;
using Parcela_MikroservisiProjekat.Models;
using Parcela_MikroservisiProjekat.Models.ModelsDto;

namespace Parcela_MikroservisiProjekat.Controllers
{
    /// <summary>
    /// Predstavlja kontroler parcele
    /// </summary>

    [Route("api/ParcelaAPIController")]
    [ApiController]
    public class ParcelaAPIController : ControllerBase
    {
        private readonly IParcelaRepository _parcelaRepository;
        //  private readonly ApplicationContext _db;
        private readonly IMapper _mapper;


        public ParcelaAPIController(IParcelaRepository parcelaRepository,/*ApplicationContext db*/ IMapper mapper)
        {
            _parcelaRepository = parcelaRepository;
            // _db = db;
            _mapper = mapper;
        }


        //--------->GET PARCELE

        /// <summary>
        /// Vraća sve parcele 
        /// </summary>
        /// <returns>Listu oglasa</returns>

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Parcela>))]

        public IActionResult getAllParcela()
        {
            var katOpst = _mapper.Map<List<ParcelaDto>>(_parcelaRepository.getAllParcela());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(katOpst);
        }



        //--------------> GET PO ID PARCELE
        /// <summary>
        /// Vraća parcelu po zadatoj vrednosti id-a
        /// </summary>
        /// <param name="parcela"></param>
        /// <returns>Objekat parcele</returns>


        [HttpGet("{id:int}", Name = "getParcelaID")]
        [ProducesResponseType(200, Type = typeof(Parcela))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]


        public async Task<IActionResult> getParcelaByID(int id)
        {
            if (!_parcelaRepository.parcelaExsists(id))
                return NotFound();

            var parcela = _mapper.Map<ParcelaDto>(_parcelaRepository.getParcelaByID(id));

            var path = "https://localhost:7182/api/KatastarskaOpstinaAPIController/" + parcela.katastarskaOpstinaId;

            var response = await HttpClient<KatastarskaOpstinaVO>.GetAsync(path);

            parcela.katastarskaOpstina = response;

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(parcela);
        }


        //--------------> POST PARCELA
        /// <summary>
        /// Kreira novu parcelu
        /// </summary>
        /// <param name="parcelaDto"></param>
        /// <returns>Potvrdu o kreiranoj parceli</returns>
        /// <response code="204">Parcela uspesno kreirana</response>
        /// <response code="400">Poslat neispravan zahtev</response>
        /// <response code="404">Nije pronadjena parcela</response>


        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<ParcelaDtoCreate> postParcela([FromBody] ParcelaDtoCreate parcelaDto)
        {/*
            if(ModelState.IsValid)
            {
                return BadRequest(ModelState);
            } */
            if (parcelaDto == null)
            {
                return BadRequest(parcelaDto);
            }
            if (parcelaDto.parcelaId > 0)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
            var parc = _parcelaRepository.getAllParcela().Where(c => c.parcelaId == parcelaDto.parcelaId).FirstOrDefault();

            if (parc != null)
            {
                ModelState.AddModelError("", "Parcela already exists");
                return StatusCode(422, ModelState);
            }

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var parcelaMap = _mapper.Map<Parcela>(parcelaDto);

            if (!_parcelaRepository.postParcela(parcelaMap))
            {
                ModelState.AddModelError("", "Something went wrong while saving");
                return StatusCode(500, ModelState);
            }

            return Ok("Successfully created");

        }





        //----------> DELETE PARCELA
        /// <summary>
        /// Briše parcelu po zadatoj vrednosti id-a
        /// </summary>
        /// <param name="parcela"></param>


        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpDelete("{id:int}", Name = "deleteParcela")]

        public IActionResult deleteParcela(int id)
        {
            var parcela = _parcelaRepository.getParcelaByID(id);
            if (!ModelState.IsValid) return BadRequest(ModelState);
            if (_parcelaRepository.getParcelaByID(id) == null) return StatusCode(500, ModelState);
            if (!_parcelaRepository.deleteParcela(parcela))
            {
                ModelState.AddModelError("", "Something went wrong while deleting parcela");
            }
            return NoContent();

        }



        //------------> PUT PARCELA
        /// <summary>
        /// Menja vrednosti postojeće parcele
        /// </summary>
        /// <param name="updatedParcela"></param>
        /// <returns>Potvrdu o izmenjenom objektu</returns>


        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPut("{id:int}", Name = "updateParcela")]
        public IActionResult updateParcela(int id, [FromBody] ParcelaDtoUpdate updatedParcela)
        {
            if (updatedParcela == null || id != updatedParcela.parcelaId)
            {
                return BadRequest();
            }

            if (!_parcelaRepository.parcelaExsists(id))
                return NotFound();

            if (!ModelState.IsValid)
                return BadRequest();

            var parcelaMap = _mapper.Map<Parcela>(updatedParcela);

            if (!_parcelaRepository.updateParcela(parcelaMap))
            {
                ModelState.AddModelError("", "Something went wrong updating parcela");
                return StatusCode(500, ModelState);
            }

            return NoContent();

        }





    }
}
