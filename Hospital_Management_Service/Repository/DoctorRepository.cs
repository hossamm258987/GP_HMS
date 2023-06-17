using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Hospital_Management_Service.Data;
using Hospital_Management_Service.Models;
using Hospital_Management_Service.Models.DTOs;
using Hospital_Management_Service.Repository.IRepository;

namespace Hospital_Management_Service.Repository
{
    public class DoctorRepository : IDoctorRepository
    {
        private readonly ApplicationDbContext _db;
        private IMapper _mapper;

        public DoctorRepository(ApplicationDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public async Task<List<DoctorDTO>> Get_Doctors()
        {
            List<Doctor> doctors = await _db.Doctors.ToListAsync();
            return _mapper.Map<List<DoctorDTO>>(doctors);
        }

        public async Task<DoctorDTO> Get_Doctor_By_Id(int id)
        {
            Doctor doctor = await _db.Doctors.FirstOrDefaultAsync(d => d.EmployeeId == id);
            return _mapper.Map<DoctorDTO>(doctor);
        }

        public async Task<List<DoctorDTO>> Get_Doctor_By_Name(string name)
        {
            List<Doctor> doctors = await _db.Doctors.Where(d => d.Name.Contains(name)).ToListAsync();
            return _mapper.Map<List<DoctorDTO>>(doctors);
        }

        public async Task<List<DoctorDTO>> Get_Doctor_By_Specialization(int specId)
        {
            List<Doctor> doctors = await _db.Doctors.Where(d => d.Specialization.Id == specId).ToListAsync();
            return _mapper.Map<List<DoctorDTO>>(doctors);
        }

        public async Task<DoctorDTO> Create_Update_Doctor(DoctorDTO doctorDto)
        {
            Doctor doctor = _mapper.Map<DoctorDTO, Doctor>(doctorDto);
            if (doctor.EmployeeId > 0)
            {
                _db.Doctors.Update(doctor);
            }
            else
            {
                _db.Doctors.Add(doctor);
            }
            await _db.SaveChangesAsync();
            return _mapper.Map<Doctor, DoctorDTO>(doctor);
        }

        public async Task<bool> Delete_Doctor_By_Id(int id)
        {
            try
            {
                Doctor doctor = await _db.Doctors.FirstOrDefaultAsync(d => d.EmployeeId == id);
                if (doctor == null)
                {
                    return false; ;
                }
                _db.Doctors.Remove(doctor);
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
