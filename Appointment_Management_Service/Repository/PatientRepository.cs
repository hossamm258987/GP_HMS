using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Appointment_Management_Service.Models;
using Appointment_Management_Service.Data;
using Appointment_Management_Service.Models.DTOs;
using Appointment_Management_Service.Repository.IRepository;

namespace Appointment_Management_Service.Repository
{
    public class PatientRepository : IPatientRepository
    {
        private readonly ApplicationDbContext _db;
        private IMapper _mapper;

        public PatientRepository(ApplicationDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public async Task<List<PatientDTO>> Get_Patients()
        {
            List<Patient> Patients = await _db.Patients.ToListAsync();
            return _mapper.Map<List<PatientDTO>>(Patients);
        }

        public async Task<PatientDTO> Get_Patient_By_Id(int id)
        {
            Patient Patient = await _db.Patients.FirstOrDefaultAsync(h => h.Id == id);
            return _mapper.Map<PatientDTO>(Patient);
        }

        public async Task<List<PatientDTO>> Get_Patient_By_Name(string name)
        {
            List<Patient> Patients = await _db.Patients.Where(h => h.Name.Contains(name)).ToListAsync();
            return _mapper.Map<List<PatientDTO>>(Patients);
        }

        public async Task<PatientDTO> Create_Update_Patient(PatientDTO PatientDto)
        {
            Patient Patient = _mapper.Map<PatientDTO, Patient>(PatientDto);
            if (Patient.Id > 0)
            {
                _db.Patients.Update(Patient);
            }
            else
            {
                _db.Patients.Add(Patient);
            }
            await _db.SaveChangesAsync();
            return _mapper.Map<Patient, PatientDTO>(Patient);
        }

        public async Task<bool> Delete_Patient_By_Id(int id)
        {
            try
            {
                Patient Patient = await _db.Patients.FirstOrDefaultAsync(h => h.Id == id);
                if (Patient == null)
                {
                    return false; ;
                }
                _db.Patients.Remove(Patient);
                await _db.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
