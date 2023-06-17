using Appointment_Management_Service.Models.DTOs;

namespace Appointment_Management_Service.Repository.IRepository
{
    public interface IPatientRepository
    {
        Task<List<PatientDTO>> Get_Patients();
        Task<PatientDTO> Get_Patient_By_Id(int id);
        Task<List<PatientDTO>> Get_Patient_By_Name(string name);
        Task<PatientDTO> Create_Update_Patient(PatientDTO patientDto);
        Task<bool> Delete_Patient_By_Id(int id);
    }
}
