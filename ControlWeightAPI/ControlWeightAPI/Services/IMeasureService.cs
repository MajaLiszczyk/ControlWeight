using ControlWeightAPI.Dtos;
using ControlWeightAPI.Entities;

namespace ControlWeightAPI.Services
{
    public interface IMeasureService
    {
        OperationResult Create(CreateMeasureDto dto);
        List<ReturnMeasureDto> GetAll();
        ReturnMeasureDto GetById(int id);
        OperationResult Delete(int id);
        OperationResult Update(UpdateMeasureDto dto);
    }
}