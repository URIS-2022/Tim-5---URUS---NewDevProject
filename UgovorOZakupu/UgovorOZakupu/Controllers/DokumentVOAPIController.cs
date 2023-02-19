using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;
using UgovorOZakupu.Interfaces;
using UgovorOZakupu.Models;
using UgovorOZakupu.Models.DTOs;

namespace UgovorOZakupu.Controllers
{

    /// <summary>
    /// Predstavlja kontroler dokumenta
    /// </summary>

    //[Route("api/[controller]")]
    [Route("api/DokumentAPIController")]
    [ApiController]
    public class DokumentVOAPIController : ControllerBase
    {
        
        
            private readonly IDokumentRepository _dokumentRepository;
            private readonly IMapper _mapper;
            public DokumentVOAPIController(IDokumentRepository dokumentRepository,IMapper mapper)
            {
            _dokumentRepository = dokumentRepository;
                // _db = db;
                _mapper = mapper;
            }
        /// <summary>
        /// Vraća sva dokumenta 
        /// </summary>
        /// <returns>Listu dokumenata</returns>

        [HttpGet]
            [ProducesResponseType(200, Type = typeof(IEnumerable<DokumentVO>))]
         
            public IActionResult GetDokumenta()
            {
                var dokumenti = _mapper.Map<List<DokumentVO>>(_dokumentRepository.GetDokumenti());

                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                return Ok(dokumenti);
            }

        /// <summary>
        /// Vraća dokument po zadatoj vrednosti id-a
        /// </summary>
        /// <param name="DokumentID"></param>
        /// <returns>Objekat dokumenta</returns>

        [HttpGet("{id:int}", Name = "GetDokumentaByID")]
            [ProducesResponseType(200, Type = typeof(DokumentVOdto))]
            [ProducesResponseType(StatusCodes.Status404NotFound)]
            [ProducesResponseType(StatusCodes.Status400BadRequest)]
        

            public IActionResult GetDokument(int id)
            {
                if (!_dokumentRepository.DokumentExsists(id))
                    return NotFound();
                var dokument = _mapper.Map<DokumentVOdto>(_dokumentRepository.GetJDokumentByID(id));

                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                return Ok(dokument);
            }


        /// <summary>
        /// Kreira novi dokument
        /// </summary>
        /// <param name="dokumentVO"></param>
        /// <returns>Potvrdu o kreiranom dokumentu</returns>
        /// <response code="204">Dokument uspesno kreiran</response>
        /// <response code="400">Poslat neispravan zahtev</response>
        /// <response code="404">Nije pronadjena vrednost</response>


        [HttpPost]
            [ProducesResponseType(StatusCodes.Status201Created)]
            [ProducesResponseType(StatusCodes.Status404NotFound)]
            [ProducesResponseType(StatusCodes.Status400BadRequest)]
            public ActionResult<DokumentVO> CreateDocument([FromBody] DokumentVO dokumentVO)
            {

            try
            {
                DokumentVO dokument = _mapper.Map<DokumentVO>(dokumentVO);
                _dokumentRepository.CreateDokument(dokument);
                _dokumentRepository.Save();
                return Ok("Successfully created");
            }
            catch(Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Post error");
            }


            /*
                if (dokumentVO == null)
                {
                    return BadRequest(dokumentVO);
                }
                if (dokumentVO.DokumentID > 0)
                {
                    return StatusCode(StatusCodes.Status500InternalServerError);
                }
                var dokument = _dokumentRepository.GetDokumenti().Where(c => c.DokumentID == dokumentVO.DokumentID).FirstOrDefault();

                if (dokument != null)
                {
                    ModelState.AddModelError("", "Dokument already exists");
                    return StatusCode(422, ModelState);
                }

                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var dokumentMap = _mapper.Map<DokumentVO>(dokumentVO);

                if (!_dokumentRepository.CreateDokument(dokumentMap))
                {
                    ModelState.AddModelError("", "Something went wrong while saving");
                    return StatusCode(500, ModelState);
                }

                return Ok("Successfully created");
            */
            }

        /// <summary>
        /// Briše dokument po zadatoj vrednosti id-a
        /// </summary>
        /// <param name="id"></param>
        [ProducesResponseType(StatusCodes.Status204NoContent)]
            [ProducesResponseType(StatusCodes.Status404NotFound)]
            [ProducesResponseType(StatusCodes.Status400BadRequest)]
            [HttpDelete("{id:int}", Name = "DeleteDokument")]

            public IActionResult DeleteDokument(int id)
            {
            /*
              if (_dokumentRepository.DokumentExsists(id))
              {
                  return NotFound();
              }

              var dokumentToDelete = _dokumentRepository.GetJDokumentByID(id);

              if (!ModelState.IsValid)
                  return BadRequest(ModelState);

              if (!_dokumentRepository.DeleteDokument(dokumentToDelete))
              {
                  ModelState.AddModelError("", "Something went wrong deleting dokument");
              }

              _dokumentRepository.DeleteDokument(dokumentToDelete);
              return NoContent();*/
            var dokument = _dokumentRepository.GetJDokumentByID(id);
            if (!ModelState.IsValid) return BadRequest(ModelState);
            if (_dokumentRepository.GetJDokumentByID(id) == null) return StatusCode(500, ModelState);
            if (!_dokumentRepository.DeleteDokument(dokument))
            {
                ModelState.AddModelError("", "Something went wrong while deleting dokument");
            }
            return NoContent();
        }

        /// <summary>
        /// Menja vrednosti postojećeg dokumenta
        /// </summary>
        /// <param name="updatedDokumentVO"></param>
        /// <returns>Potvrdu o izmenjenom objektu</returns>

        [ProducesResponseType(StatusCodes.Status204NoContent)]
            [ProducesResponseType(StatusCodes.Status404NotFound)]
            [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Produces("application/json")]
        [HttpPut("{id:int}", Name = "UpdateDokument")]
            public IActionResult UpdateDokument(int id, [FromBody] DokumentVOdto updatedDokumentVO)
            {



            
                if (updatedDokumentVO == null) 
                {
                    return BadRequest(ModelState);
                }
                if(id != updatedDokumentVO.DokumentID)
                  {
                    return BadRequest(ModelState);

                }

            if (!_dokumentRepository.DokumentExsists(id))
                    return NotFound();

                if (!ModelState.IsValid)
                    return BadRequest();

                var dokumentMap = _mapper.Map<DokumentVO>(updatedDokumentVO);

                if (!_dokumentRepository.UpdateDokumentv(dokumentMap))
                {
                    ModelState.AddModelError("", "Something went wrong updating dokument");
                    return StatusCode(500, ModelState);
                }

                return NoContent();

        }
        }
    }

