using AutoMapper;
using ControlWeightAPI.Dtos;
using ControlWeightAPI.Entities;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace ControlWeightAPI.Services
{
    public class MeasureService : IMeasureService
    {
        private readonly ControlWeightDbContext _dbContext;
        private readonly IMapper _mapper;

        public MeasureService(ControlWeightDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        /// <summary>
        /// Get measure by Id
        /// </summary>
        /// <param name="id">Requested measure Id</param>
        /// <returns>Returns requested measure</returns>
        public ReturnMeasureDto? GetById(int id)
        {
            var meassureDto = new ReturnMeasureDto();
            try
            {
                var result = new OperationResult();

                var measure = _dbContext
                   .Measures.
                   FirstOrDefault(m => m.Id == id);
                meassureDto = _mapper.Map<ReturnMeasureDto>(measure);
            }
            catch(Exception ex)
            {
                return null;
            }
            return meassureDto;
        }

        /// <summary>
        /// Get all measures
        /// </summary>
        /// <returns>List of measures</returns>
        public List<ReturnMeasureDto>? GetAll()
        {
            var measuresDto = new List<ReturnMeasureDto>();
            try
            {
                var measures = _dbContext
               .Measures.OrderByDescending(x => x.MeasureDate)
               .ToList();
                measuresDto = _mapper.Map<List<ReturnMeasureDto>>(measures);
            }
            catch(Exception ex)
            {
                return null;
            }
            return measuresDto;
        }

        /// <summary>
        /// Create new measure
        /// </summary>
        /// <param name="dto">New measure (dto - without Is - user can not set measure Id)</param>
        /// <returns>Returns OperationResult (if there is success after action, list of errors and messages for user)</returns>
        public OperationResult Create(CreateMeasureDto dto)
        {
            var measure = _mapper.Map<Measure>(dto);
            var result = new OperationResult();
            if(dto.Weight>500 || dto.Weight < 10)
            {
                result.Errors.Add("Weight value should be between 10 and 500");
            }
            if (dto.Waist > 500 || dto.Waist < 10)
            {
                result.Errors.Add("Waist value should be between 10 and 500");
            }
            if (dto.Hips > 500 || dto.Hips < 10)
            {
                result.Errors.Add("Hips value should be between 10 and 500");
            }
            if (dto.Thigh > 500 || dto.Thigh < 10)
            {
                result.Errors.Add("Thigh value should be between 10 and 500");
            }
            if (dto.Arm > 500 || dto.Arm < 10)
            {
                result.Errors.Add("Arm value should be between 10 and 500");
            }
            if (dto.Chest > 500 || dto.Chest < 10)
            {
                result.Errors.Add("Chest value should be between 10 and 500");
            }

            List<ReturnMeasureDto> history = GetAll();
            var measuresSameDate = _dbContext.Measures.Where(y => y.MeasureDate == measure.MeasureDate);
            if (measuresSameDate.Count() > 0)
            {
                 result.Errors.Add("This date already exists in the history");
            }

            result.IsSuccess = result.Errors.Count == 0;
            if(!result.IsSuccess)
            {
                result.UserMessage = "The form contains incorrect values: ";
                return result;
            }

            try
            {
               
                _dbContext.Measures.Add(measure);
                _dbContext.SaveChanges();

                result.IsSuccess = true;
                result.UserMessage = "Insert success";
            }
            catch(Exception ex)
            {
                result.IsSuccess = false;
                result.UserMessage = "Error occured during inserting";
            }
            return result;
        }

        /// <summary>
        /// Delete measure
        /// </summary>
        /// <param name="id">Requested measure Id</param>
        /// <returns>Returns OperationResult (if there is success after action, list of errors and messages for user)</returns>
        public OperationResult Delete(int id)
        {
            var result = new OperationResult();

            try
            {
                var measure = _dbContext
                              .Measures
                              .FirstOrDefault(m => m.Id == id);
                
                _dbContext.Measures.Remove(measure);
                _dbContext.SaveChanges();
                result.IsSuccess = true;
                result.UserMessage = "Delete success";
            }
            catch(Exception ex)
            {
                result.UserMessage = "Error occured during deleting";
                result.IsSuccess = false;
            }
            return result;
        }

        /// <summary>
        /// Update measure
        /// </summary>
        /// <param name="dto">Updated measure values(dto - without Date - user can not edit measure date)</param>
        /// <returns>Returns OperationResult (if there is success after action, list of errors and messages for user)</returns>
        public OperationResult Update(UpdateMeasureDto dto)
        {
            var result = new OperationResult();
            if (dto.Weight > 500 || dto.Weight < 10)
            {
                result.Errors.Add("Weight value should be between 10 and 500");
            }
            if (dto.Waist > 500 || dto.Waist < 10)
            {
                result.Errors.Add("Waist value should be between 10 and 500");
            }
            if (dto.Hips > 500 || dto.Hips < 10)
            {
                result.Errors.Add("Hips value should be between 10 and 500");
            }
            if (dto.Thigh > 500 || dto.Thigh < 10)
            {
                result.Errors.Add("Thigh value should be between 10 and 500");
            }
            if (dto.Arm > 500 || dto.Arm < 10)
            {
                result.Errors.Add("Arm value should be between 10 and 500");
            }
            if (dto.Chest > 500 || dto.Chest < 10)
            {
                result.Errors.Add("Chest value should be between 10 and 500");
            }

            result.IsSuccess = result.Errors.Count == 0;
            if(!result.IsSuccess)
            {
                result.UserMessage = "The form contains incorrect values: ";
                return result;
            }

            var measure = _dbContext
             .Measures.
             FirstOrDefault(m => m.Id == dto.Id);
            if (measure == null)
            {
                result.IsSuccess=false;
                result.UserMessage = "Measure can not be updated";
                return result;
            }
            try
            {
                measure.Weight = dto.Weight;
                measure.Chest = dto.Chest;
                measure.Arm = dto.Arm;
                measure.Waist = dto.Waist;
                measure.Thigh = dto.Thigh;
                measure.Hips = dto.Hips;
                _dbContext.SaveChanges();

                result.IsSuccess = true;
                result.UserMessage = "Update success!";
            }
            catch (Exception ex)
            {
                result.IsSuccess = false;
                result.UserMessage = "Error occured";
            }
            return result;
        }
    }
}
