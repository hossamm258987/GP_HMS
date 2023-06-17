using Hospital_Management_Gateway.Models;

namespace Hospital_Management_Gateway.Repository.IRepository
{
    public interface IPatientRepository
    {
        Task<T> Get_Patients<T>();
        Task<T> Get_Patient_By_Id<T>(int id);
        Task<T> Get_Patient_By_Name<T>(string name);
        Task<T> Create_Patient<T>(PatientDTO patientDto);
        Task<T> Update_Patient<T>(PatientDTO patientDto);
        Task<T> Delete_Patient_By_Id<T>(int id);
    }
}
