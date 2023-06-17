using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Appointment_Management_Service.Models;
using Appointment_Management_Service.Data;
using Appointment_Management_Service.Models.DTOs;
using Appointment_Management_Service.Repository.IRepository;

namespace Appointment_Management_Service.Repository
{
    public class AppointmentRepository : IAppointmentRepository
    {
        private readonly ApplicationDbContext _db;
        private IMapper _mapper;

        public AppointmentRepository(ApplicationDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public async Task<List<AppointmentDTO>> Get_Appointments()
        {
            List<Appointment> Appointments = await _db.Appointments.ToListAsync();
            return _mapper.Map<List<AppointmentDTO>>(Appointments);
        }

        public async Task<AppointmentDTO> Get_Appointment_By_Id(int id)
        {
            Appointment Appointment = await _db.Appointments.FirstOrDefaultAsync(h => h.Id == id);
            return _mapper.Map<AppointmentDTO>(Appointment);
        }

        public async Task<List<AppointmentDTO>> Get_Appointment_By_Name(string name)
        {
            List<Appointment> Appointments = await _db.Appointments.Where(h => h.Name.Contains(name)).ToListAsync();
            return _mapper.Map<List<AppointmentDTO>>(Appointments);
        }
        public async Task<List<AppointmentDTO>> Get_Appointment_By_Patient(int pid)
        {
            List<Appointment> Appointments = await _db.Appointments.Where(h => h.Patient.Id == pid).ToListAsync();
            return _mapper.Map<List<AppointmentDTO>>(Appointments);
        }

        public async Task<List<AppointmentDTO>> Get_Appointment_By_Number(int number, DateTime time)
        {
            List<Appointment> Appointments = await _db.Appointments.Where(h => h.Number == number && time.Year == h.AppointTime.Year 
                && time.Month == h.AppointTime.Month && time.Day == h.AppointTime.Day).ToListAsync();
            return _mapper.Map<List<AppointmentDTO>>(Appointments);
        }

        public async Task<List<AppointmentDTO>> Get_Appointment_By_Section(int sid, DateTime time)
        {
            List<Appointment> Appointments = await _db.Appointments.Where(h => h.DocMETime.DocMExamination.Doctor.Section.Id == sid && time.Year == h.AppointTime.Year
                && time.Month == h.AppointTime.Month && time.Day == h.AppointTime.Day).ToListAsync();
            return _mapper.Map<List<AppointmentDTO>>(Appointments);
        }

        public async Task<List<AppointmentDTO>> Get_Appointment_By_Section(int sid)
        {
            List<Appointment> Appointments = await _db.Appointments.Where(h => h.DocMETime.DocMExamination.Doctor.Section.Id == sid).ToListAsync();
            return _mapper.Map<List<AppointmentDTO>>(Appointments);
        }

        public async Task<AppointmentDTO> Create_Update_Appointment(AppointmentDTO AppointmentDto)
        {
            Appointment Appointment = _mapper.Map<AppointmentDTO, Appointment>(AppointmentDto);
            if (Appointment.Id > 0)
            {
                _db.Appointments.Update(Appointment);
            }
            else
            {
                _db.Appointments.Add(Appointment);
            }
            await _db.SaveChangesAsync();
            return _mapper.Map<Appointment, AppointmentDTO>(Appointment);
        }

        public async Task<bool> Delete_Appointment_By_Id(int id)
        {
            try
            {
                Appointment Appointment = await _db.Appointments.FirstOrDefaultAsync(h => h.Id == id);
                if (Appointment == null)
                {
                    return false; ;
                }
                _db.Appointments.Remove(Appointment);
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
