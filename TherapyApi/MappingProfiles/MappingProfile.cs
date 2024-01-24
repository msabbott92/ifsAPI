using AutoMapper;
using TherapyApi.Models;


public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Patient, PatientDTO>();
        CreateMap<PatientDTO, Patient>();
        CreateMap<Part, PartDTO>();
        CreateMap<PartDTO, Part>();
        CreateMap<CustomQuestion, CustomQuestionDTO>();
        CreateMap<CustomQuestionDTO, CustomQuestion>();
    }
}
