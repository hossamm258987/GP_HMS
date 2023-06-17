using Hospital_Management_Gateway.Models;

namespace Hospital_Management_Gateway.Repository.IRepository
{
    public interface IDocMExaminationRepository
    {
        Task<T> Get_DocMExaminations<T>();
        Task<T> Get_DocMExamination_By_Id<T>(int id);
        Task<T> Get_DocMExamination_By_Doctor<T>(int did);
        Task<T> Get_MExamination_By_Section<T>(int sid, int meid);
        Task<T> Get_DocMExamination_By_MExamination<T>(int meid);
        Task<T> Create_DocMExamination<T>(DocMExaminationDTO docMExaminationDto);
        Task<T> Update_DocMExamination<T>(DocMExaminationDTO docMExaminationDto);
        Task<T> Delete_DocMExamination_By_Id<T>(int id);
    }
}
