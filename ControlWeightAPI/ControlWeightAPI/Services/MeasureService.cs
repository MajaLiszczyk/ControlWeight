using AutoMapper;
using ControlWeightAPI.Dtos;
using ControlWeightAPI.Entities;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace ControlWeightAPI.Services
{
    //zby instancje tego serwisu wstrzyknac do kontrolera, trzeba wydzielic interfejs, a nastepnie zarejestrowac go w kontenerze zaleznosci w Program.cs
    public class MeasureService : IMeasureService
    {
        private readonly ControlWeightDbContext _dbContext;
        private readonly IMapper _mapper;
        public MeasureService(ControlWeightDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public ReturnMeasureDto GetById(int id)
        {
            var measure = _dbContext
               .Measures.
               FirstOrDefault(m => m.Id == id);
            if (measure == null)
            {*
                return null;
            }
            var result = _mapper.Map<ReturnMeasureDto>(measure);
            return result;
        }


        public List<ReturnMeasureDto> GetAll()
        {
            var measures = _dbContext
               .Measures.OrderByDescending(x => x.MeasureDate)
               .ToList();
            var measuresDto = _mapper.Map<List<ReturnMeasureDto>>(measures);
            return measuresDto;
        }

        //public int Create(CreateMeasureDto dto)
        public OperationResult Create(CreateMeasureDto dto)
        {
            var measure = _mapper.Map<Measure>(dto);
            var result = new OperationResult();
            if(dto.Hips>500 || dto.Hips < 10)
            {
                result.Errors.Add("Hips value should be between 10 and 500");
            }
            //ify dla kazdego wymiaru. Sprawdzic alidacje z frontem
            //if dla daty, czy unikalna itp
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
        
        // bool informuje czy zasob zostal usuniety, czy nie istnieje i nie zostal usuniety
       // public bool Delete(int id)
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

        public OperationResult Update(UpdateMeasureDto dto)
        {
            var result = new OperationResult();
            //ponizej walidacja merytoryczna (czy ma sens dla Kowlaskiego).Zasady biznesowe
            if(dto.Hips>500 || dto.Hips<10)
            {
                result.Errors.Add("Hips value should be between 10 and 500"); 
            }
            //ify dla kazdego wymiaru
            //if dla daty czy unikalna itp

            result.IsSuccess = result.Errors.Count == 0; //jesli nie ma zadnych messages, to sukces
            if(!result.IsSuccess)
            {
                result.UserMessage = "The form contains incorrect values: ";
                return result;
            }
            //ponizej walidacja techniczna. Lapanie bledów technicznych, informatycznych
            var measure = _dbContext
             .Measures.
             FirstOrDefault(m => m.Id == dto.Id);
            if (measure == null)
            {
                result.IsSuccess=false;
                result.UserMessage = "Measure can not be updated";
                 // jak bede robic logi , to tu loguje dla technika 
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
                //jak beda logi, to podac tresc exception:  $"Error during update measure id:{measure.Id}: {ex.Message}"
            }
           
            return result;
        }
    }
}
