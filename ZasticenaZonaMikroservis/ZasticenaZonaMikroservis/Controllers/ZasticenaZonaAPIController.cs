using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Diagnostics.Metrics;
using ZasticenaZonaMikroservis.Data;
using ZasticenaZonaMikroservis.DataContext;
using ZasticenaZonaMikroservis.Interface;
using ZasticenaZonaMikroservis.Models;
using ZasticenaZonaMikroservis.Models.DTO;

namespace ZasticenaZonaMikroservis.Controllers
{
    /// <summary>
    /// Predstavlja kontroler zasticene zone
    /// </summary>

    //[Route("api/[controller]")]
    [Route("api/ZasticenaZonaAPIController")]
    [ApiController]
    public class ZasticenaZonaAPIController : ControllerBase
    {
        private readonly IZasticenaZonaRepository _zastZonaRepository;
      //  private readonly ApplicationContext _db;
        private readonly IMapper _mapper;
        public ZasticenaZonaAPIController(IZasticenaZonaRepository zastZonaRepository ,/*ApplicationContext db*/ IMapper mapper)
        {
            _zastZonaRepository = zastZonaRepository;
            // _db = db;
            _mapper = mapper;
        }

        /// <summary>
        /// Vraća sve zasticene zone 
        /// </summary>
        /// <returns>Listu zasticenih zona</returns>

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<ZasticenaZona>))]
        /*
        public ActionResult<IEnumerable<ZasticenaZonaDTO>> GetZasticeneZone()
        {
            // return Ok (ZasticenaZonaStore.ZasticenaZonaList);
            return Ok(_db.ZasticeneZone.ToList());
        } ovo je bilo dok nije postojao Repository
        */
        public IActionResult GetZasticeneZone()
        {
            var zastZone = _mapper.Map<List<ZasticenaZonaDTO>>(_zastZonaRepository.GetZasticeneZone());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(zastZone);
        }

        /// <summary>
        /// Vraća zasticenu zonu po zadatoj vrednosti id-a
        /// </summary>
        /// <param name="ZasticenaZonaID"></param>
        /// <returns>Objekat zasticena zona</returns>


        [HttpGet("{id:int}", Name = "GetZasticenaZona")]
        [ProducesResponseType(200, Type = typeof(ZasticenaZona))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        /*
        public ActionResult<ZasticenaZonaDTO> GetZasticenaZona(int id)
        {
            if ( id == 0)
            {
                return BadRequest();
            }
            //  var ZasticenaZona = ZasticenaZonaStore.ZasticenaZonaList.FirstOrDefault(u => u.ZasticenaZonaID == id);
            var ZasticenaZona = _db.ZasticeneZone.FirstOrDefault(u => u.ZasticenaZonaID == id);
            if (ZasticenaZona == null)
            {
                return NotFound();
            }
            return Ok(ZasticenaZona);

        }*/

        public IActionResult GetZasticenaZona(int id)
        {
            if (!_zastZonaRepository.ZasticenaZonaExsists(id))
                return NotFound();
            var zasticenaZona = _mapper.Map<ZasticenaZonaDTO>(_zastZonaRepository.GetZasticenaZona(id));

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(zasticenaZona);
        }


        /// <summary>
        /// Kreira novu zasticenu zonu
        /// </summary>
        /// <param name="zasticenaZonaDTO"></param>
        /// <returns>Potvrdu o kreiranoj zasticenoj zoni</returns>

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<ZasticenaZonaDTO> CreateZasticenaZona([FromBody] ZasticenaZonaDTO zasticenaZonaDTO)
        {/*
            if(ModelState.IsValid)
            {
                return BadRequest(ModelState);
            } */
            if (zasticenaZonaDTO == null)
            {
                return BadRequest(zasticenaZonaDTO);
            }
            if (zasticenaZonaDTO.ZasticenaZonaID > 0)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
            var zastZone = _zastZonaRepository.GetZasticeneZone().Where(c => c.ZasticenaZonaID == zasticenaZonaDTO.ZasticenaZonaID).FirstOrDefault();

            if (zastZone != null)
            {
                ModelState.AddModelError("", "Zasticena zona already exists");
                return StatusCode(422, ModelState);
            }

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var zasticenaZonaMap = _mapper.Map<ZasticenaZona>(zasticenaZonaDTO);

            if (!_zastZonaRepository.CreateZasticenaZona(zasticenaZonaMap))
            {
                ModelState.AddModelError("", "Something went wrong while saving");
                return StatusCode(500, ModelState);
            }

            return Ok("Successfully created");

            //   zasticenaZonaDTO.ZasticenaZonaID = ZasticenaZonaStore.ZasticenaZonaList.OrderByDescending(u => u.ZasticenaZonaID).FirstOrDefault().ZasticenaZonaID + 1;
            /*
            ZasticenaZona model = new()
            {
                ZasticenaZonaID = zasticenaZonaDTO.ZasticenaZonaID,
                DozvoljeniRadovi = zasticenaZonaDTO.DozvoljeniRadovi,
                StepenZastite = zasticenaZonaDTO.StepenZastite,
                VrstaZasticenogPodrucja = zasticenaZonaDTO.VrstaZasticenogPodrucja
               };
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            /*
            _db.ZasticeneZone.Add(model);
            _db.SaveChanges();*/

            /*ZasticenaZonaStore.ZasticenaZonaList.Add(zasticenaZonaDTO);
            return Ok(zasticenaZonaDTO); */

            // return CreatedAtRoute("GetZasticenaZona",new {id=zasticenaZonaDTO.ZasticenaZonaID},zasticenaZonaDTO);
        }

        /// <summary>
        /// Briše zasticenu zonu po zadatoj vrednosti id-a
        /// </summary>
        /// <param name="ZasticenaZonaID"></param>


        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpDelete("{id:int}", Name = "DeleteZasticenaZona")]

        public IActionResult DeleteZasticenaZona (int id)
        {
            /*
            if (id == 0)
            {
                return BadRequest();
            }*/
           /* ovo if(_zastZonaRepository.ZasticenaZonaExsists(id))
            {
                return NotFound();
            } */
            //var zasticenazona = ZasticenaZonaStore.ZasticenaZonaList.FirstOrDefault(u => u.ZasticenaZonaID == id);
            // var zasticenazona = _db.ZasticeneZone.FirstOrDefault(u => u.ZasticenaZonaID == id);
         // ovo   var zasticenaZonaToDelete = _zastZonaRepository.GetZasticenaZona(id);
            /*
            if (zasticenazona == null)
            {
                return NotFound();
            }*/
            /* ovo
            if (!ModelState.IsValid)
                return BadRequest(ModelState); */
            //ZasticenaZonaStore.ZasticenaZonaList.Remove(zasticenazona);
            /*.ZasticeneZone.Remove(zasticenazona);
            _db.SaveChanges();*/
            //
            /* ovo
            if (!_zastZonaRepository.DeleteZasticenaZona(zasticenaZonaToDelete))
            {
                ModelState.AddModelError("", "Something went wrong deleting zasticena zona");
            }*/

          /*  ovo _zastZonaRepository.DeleteZasticenaZona(zasticenaZonaToDelete);
            return NoContent();
          */
            var zasticenaZona = _zastZonaRepository.GetZasticenaZona(id);
            if (!ModelState.IsValid) return BadRequest(ModelState);
            if (_zastZonaRepository.GetZasticenaZona(id) == null) return StatusCode(500, ModelState);
            if (!_zastZonaRepository.DeleteZasticenaZona(zasticenaZona))
            {
                ModelState.AddModelError("", "Something went wrong while deleting zasticena zona");
            }
            return NoContent();
        }
        /// <summary>
        /// Menja vrednosti postojeće zasticene zone
        /// </summary>
        /// <param name="Zasticena zona"></param>
        /// <returns>Potvrdu o izmenjenom objektu</returns>

        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPut("{id:int}", Name = "UpdateZasticenaZona")]
        public IActionResult UpdateZasticenaZona(int id, [FromBody] ZasticenaZonaDTO updatedZasticenaZona)
        {
            if (updatedZasticenaZona == null || id != updatedZasticenaZona.ZasticenaZonaID)
            {
                return BadRequest();
            }
            /* var zasticenazona = ZasticenaZonaStore.ZasticenaZonaList.FirstOrDefault(u => u.ZasticenaZonaID == id);
            zasticenazona.DozvoljeniRadovi = zasticenaZonaDTO.DozvoljeniRadovi;
            zasticenazona.StepenZastite = zasticenaZonaDTO.StepenZastite;
            zasticenazona.VrstaZasticenogPodrucja = zasticenaZonaDTO.VrstaZasticenogPodrucja; */
            /*
            ZasticenaZona model = new()
            {
                ZasticenaZonaID = zasticenaZonaDTO.ZasticenaZonaID,
                DozvoljeniRadovi = zasticenaZonaDTO.DozvoljeniRadovi,
                StepenZastite = zasticenaZonaDTO.StepenZastite,
                VrstaZasticenogPodrucja = zasticenaZonaDTO.VrstaZasticenogPodrucja
            };

            _db.ZasticeneZone.Update(model);
            _db.SaveChanges();
            */
           if (!_zastZonaRepository.ZasticenaZonaExsists(id))
                return NotFound();

            if (!ModelState.IsValid)
                return BadRequest();

            var zasticenaZonaMap = _mapper.Map<ZasticenaZona>(updatedZasticenaZona);

            if (!_zastZonaRepository.UpdateZasticenaZona(zasticenaZonaMap))
            {
                ModelState.AddModelError("", "Something went wrong updating zasticena zona");
                return StatusCode(500, ModelState);
            }

            return NoContent();

        }
    }
}
