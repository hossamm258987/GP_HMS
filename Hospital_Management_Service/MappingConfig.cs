using AutoMapper;
using Hospital_Management_Service.Models;
using Hospital_Management_Service.Models.DTOs;

namespace Hospital_Management_Service
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(config =>
            {
                config.CreateMap<AnalystDTO, Analyst>().ReverseMap();
                config.CreateMap<DoctorDTO, Doctor>().ReverseMap();
                config.CreateMap<HospitalDTO, Hospital>().ReverseMap();
                config.CreateMap<NurseDTO, Nurse>().ReverseMap();
                config.CreateMap<PharmatistDTO, Pharmatist>().ReverseMap();
                config.CreateMap<ReceptionistDTO, Receptionist>().ReverseMap();
                config.CreateMap<SectionDTO, Section>().ReverseMap();
                config.CreateMap<SectionTypeDTO, SectionType>().ReverseMap();
                config.CreateMap<SpecializationDTO, Specialization>().ReverseMap();
                config.CreateMap<StaffDTO, Staff>().ReverseMap();
                config.CreateMap<WardDTO, Ward>().ReverseMap();
            });

            return mappingConfig;
        }
    }
}
