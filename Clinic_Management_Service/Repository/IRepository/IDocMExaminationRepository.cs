using Clinic_Management_Service.Models.DTOs;

namespace Clinic_Management_Service.Repository.IRepository
{
    public interface IDocMExaminationRepository
    {
        Task<List<DocMExaminationDTO>> Get_DocMExaminations();
        Task<DocMExaminationDTO> Get_DocMExamination_By_Id(int id);
        Task<List<DocMExaminationDTO>> Get_DocMExamination_By_Doctor(int did);
        Task<List<DocMExaminationDTO>> Get_MExamination_By_Section(int sid, int meid);
        Task<List<DocMExaminationDTO>> Get_DocMExamination_By_MExamination(int meid);
        Task<DocMExaminationDTO> Create_Update_DocMExamination(DocMExaminationDTO docMExaminationDto);
        Task<bool> Delete_DocMExamination_By_Id(int id);
    }
}
