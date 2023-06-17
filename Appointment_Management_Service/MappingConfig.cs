using AutoMapper;
using Appointment_Management_Service.Models;
using Appointment_Management_Service.Models.DTOs;

namespace Appointment_Management_Service
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(config =>
            {
                config.CreateMap<AppointmentDTO, Appointment>().ReverseMap();
                config.CreateMap<DocMETimeDTO, DocMETime>().ReverseMap();
                config.CreateMap<DocMExaminationDTO, DocMExamination>().ReverseMap();
                config.CreateMap<DoctorDTO, Doctor>().ReverseMap();
                config.CreateMap<HospitalDTO, Hospital>().ReverseMap();
                config.CreateMap<MExaminationDTO, MExamination>().ReverseMap();
                config.CreateMap<PatientDTO, Patient>().ReverseMap();
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
