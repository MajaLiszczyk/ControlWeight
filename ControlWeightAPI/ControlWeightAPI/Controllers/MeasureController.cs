using AutoMapper;
using ControlWeightAPI.Dtos;
using ControlWeightAPI.Entities;
using ControlWeightAPI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace ControlWeightAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    public class MeasureController : ControllerBase
    {
        private readonly IMeasureService _measureService;
        public MeasureController(IMeasureService measureService)
        {
            _measureService = measureService;
        }

        [HttpGet]
        public ActionResult<List<ReturnMeasureDto>> GetAll()
        {
            var measuresDtos = _measureService.GetAll();

            if (measuresDtos == null)
            {
                return new ForbidResult();
            }
            return Ok(measuresDtos);
        }

        [HttpGet("{id}")]
        public ActionResult<ReturnMeasureDto> Get([FromRoute] int id)
        {
            var measureDto = _measureService.GetById(id);
            if (measureDto == null)
            {
                return new ForbidResult();
            }
            return Ok(measureDto);
        }

        [HttpPost]
        public OperationResult CreateMeasure([FromBody] CreateMeasureDto dto)
        {
            return _measureService.Create(dto);
        }

        [HttpDelete("{id}")]
        public OperationResult Delete([FromRoute]int id)
        {
            return _measureService.Delete(id);
        }

        [HttpPut]
        public OperationResult Update([FromBody] UpdateMeasureDto dto)
        {
            return _measureService.Update(dto);
        }
    }
}
