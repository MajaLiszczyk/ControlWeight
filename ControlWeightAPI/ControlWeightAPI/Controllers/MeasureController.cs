using AutoMapper;
using ControlWeightAPI.Dtos;
using ControlWeightAPI.Entities;
using ControlWeightAPI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace ControlWeightAPI.Controllers
{
    // klasa ControllerBase udostepnia dostep do kontekstu zapytania i odpowiedzi
    [Route("api/[controller]/[action]")]
    public class MeasureController : ControllerBase
    {

        private readonly IMeasureService _measureService;
        public MeasureController(IMeasureService measureService)
        {
            _measureService = measureService;
        }
        // nie oznaczylismy metody typu get, ale domyslnie zostala zmapowana do takiej. Dobra praktyka jest oznaczyc: [HttpGet]
        
        public ActionResult<List<ReturnMeasureDto>> GetAll()
        {
            var measuresDtos = _measureService.GetAll();
            

            return Ok(measuresDtos);
        }

        [HttpGet("{id}")]
        public ActionResult<ReturnMeasureDto> Get([FromRoute] int id)
        {
            var measureDto = _measureService.GetById(id);
            if (measureDto == null)
            {
                return NotFound();
            }
            return Ok(measureDto);
        }

        [HttpPost]
        public OperationResult CreateMeasure([FromBody] CreateMeasureDto dto)
        {
            //gdybym mila wymagania co do kolumny np. max ilosc znakow itp
            /* if (!ModelState.IsValid)
             {
                 return BadRequest(ModelState);
             }*/

            //var id = _measureService.Create(dto);
            return _measureService.Create(dto);

            //drugi parametr - opcjonalnie cialo odpowiedzi .Tutaj null
            //return Created($"/api/measure/{id}", null);
        }

        [HttpDelete("{id}")]
        public OperationResult Delete([FromRoute]int id)
        {

            /*OperationResult result = _measureService.Delete(id);
            if(result.IsSuccess)
            {
                //return NoContent();
                return result;
            }
            return result;*/
            return _measureService.Delete(id);

        }

        [HttpPut]
        public OperationResult Update([FromBody] UpdateMeasureDto dto)
        {
            /* if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }*/
            return _measureService.Update(dto);

            /*var isUpdated = _measureService.Update(id, dto);
            if (!isUpdated)
            {
                return NotFound();
            }

            return Ok(); */

        }

    }
}
