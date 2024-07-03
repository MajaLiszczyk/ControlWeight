using ControlWeightAPI.Dtos;
using ControlWeightAPI.Entities;

namespace ControlWeightAPI.Services
{
    public interface IMeasureService
    {
        //int Create(CreateMeasureDto dto);
        OperationResult Create(CreateMeasureDto dto);
        List<ReturnMeasureDto> GetAll();
        ReturnMeasureDto GetById(int id);
        //public bool Delete(int id);
        OperationResult Delete(int id);
        OperationResult Update(UpdateMeasureDto dto);
    }
}