using AutoMapper;
using ControlWeightAPI.Dtos;
using ControlWeightAPI.Entities;

namespace ControlWeightAPI
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Measure, ReturnMeasureDto>()
                .ForMember(m => m.Id, d => d.MapFrom(t => t.Id))
                .ForMember(m => m.Weight, d => d.MapFrom(t => t.Weight))
                .ForMember(m => m.Waist, d => d.MapFrom(t => t.Waist))
                .ForMember(m => m.Hips, d => d.MapFrom(t => t.Hips))
                .ForMember(m => m.Thigh, d => d.MapFrom(t => t.Thigh))
                .ForMember(m => m.Arm, d => d.MapFrom(t => t.Arm))
                .ForMember(m => m.Chest, d => d.MapFrom(t => t.Chest));

            CreateMap<CreateMeasureDto, Measure>()
                .ForMember(d => d.Weight, m => m.MapFrom(t => t.Weight))
                .ForMember(d => d.Waist, m => m.MapFrom(t => t.Waist))
                .ForMember(d => d.Hips, m => m.MapFrom(t => t.Hips))
                .ForMember(d => d.Thigh, m => m.MapFrom(t => t.Thigh))
                .ForMember(d => d.Arm, m => m.MapFrom(t => t.Arm))
                .ForMember(d => d.Chest, m => m.MapFrom(t => t.Chest));

            CreateMap<DateDto, DateTime>()
                .ForMember(d => d.Year, d => d.MapFrom(t => t.Year))
                .ForMember(d => d.Month, d => d.MapFrom(t => t.Month))
                .ForMember(d => d.Day, d => d.MapFrom(t => t.Day));

            CreateMap<DateTime, DateDto>()
                .ForMember(d => d.Year, d => d.MapFrom(t => t.Year))
                .ForMember(d => d.Month, d => d.MapFrom(t => t.Month))
                .ForMember(d => d.Day, d => d.MapFrom(t => t.Day));
        }
    }
}
