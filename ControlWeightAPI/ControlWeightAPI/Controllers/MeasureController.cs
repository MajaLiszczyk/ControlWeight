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

        /// <summary>
        /// HttpGet method. 
        /// </summary>
        /// <returns>Returns all measures from history</returns>
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

        /// <summary>
        /// HttpGet method
        /// </summary>
        /// <param name="id">Requested measure Id</param>
        /// <returns>Returns requested measure</returns>
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

        /// <summary>
        /// HttpPost method. Create new measure
        /// </summary>
        /// <param name="dto">New measure (dto - without Is - user can not set measure Id)</param>
        /// <returns>Returns OperationResult (if there is success after action, list of errors and messages for user)</returns>
        [HttpPost]
        public OperationResult CreateMeasure([FromBody] CreateMeasureDto dto)
        {
            return _measureService.Create(dto);
        }

        /// <summary>
        /// HttpDeleteMeasure
        /// </summary>
        /// <param name="id">Requested measure Id</param>
        /// <returns>Returns OperationResult (if there is success after action, list of errors and messages for user)</returns>
        [HttpDelete("{id}")]
        public OperationResult Delete([FromRoute]int id)
        {
            return _measureService.Delete(id);
        }

        /// <summary>
        /// HttpPut method. Updates measure 
        /// </summary>
        /// <param name="dto">Updated measure values(dto - without Date - user can not edit measure date)
        /// </param>
        /// <returns>Returns OperationResult (if there is success after action, list of errors and messages for user)</returns>
        [HttpPut]
        public OperationResult Update([FromBody] UpdateMeasureDto dto)
        {
            return _measureService.Update(dto);
        }
    }
}
