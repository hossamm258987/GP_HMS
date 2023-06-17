using Clinic_Management_Service.Models.DTOs;

namespace Clinic_Management_Service.Repository.IRepository
{
    public interface IMExaminationRepository
    {
        Task<List<MExaminationDTO>> Get_MExaminations();
        Task<MExaminationDTO> Get_MExamination_By_Id(int id);
        Task<List<MExaminationDTO>> Get_MExamination_By_Name(string name);
        Task<MExaminationDTO> Create_Update_MExamination(MExaminationDTO mExaminationDto);
        Task<bool> Delete_MExamination_By_Id(int id);
    }
}
