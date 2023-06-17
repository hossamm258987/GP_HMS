using Hospital_Management_Gateway.Models;

namespace Hospital_Management_Gateway.Repository.IRepository
{
    public interface IMExaminationRepository
    {
        Task<T> Get_MExaminations<T>();
        Task<T> Get_MExamination_By_Id<T>(int id);
        Task<T> Get_MExamination_By_Name<T>(string name);
        Task<T> Create_MExamination<T>(MExaminationDTO mExaminationDto);
        Task<T> Update_MExamination<T>(MExaminationDTO mExaminationDto);
        Task<T> Delete_MExamination_By_Id<T>(int id);
    }
}
