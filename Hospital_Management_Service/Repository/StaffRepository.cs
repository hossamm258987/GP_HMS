using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Hospital_Management_Service.Data;
using Hospital_Management_Service.Models;
using Hospital_Management_Service.Models.DTOs;
using Hospital_Management_Service.Repository.IRepository;

namespace Hospital_Management_Service.Repository
{
    public class StaffRepository : IStaffRepository
    {
        private readonly ApplicationDbContext _db;
        private IMapper _mapper;

        public StaffRepository(ApplicationDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public async Task<List<StaffDTO>> Get_Staffs()
        {
            List<Staff> staffs = await _db.Staffs.ToListAsync();
            return _mapper.Map<List<StaffDTO>>(staffs);
        }

        public async Task<StaffDTO> Get_Staff_By_Id(int id)
        {
            Staff staff = await _db.Staffs.FirstOrDefaultAsync(h => h.EmployeeId == id);
            return _mapper.Map<StaffDTO>(staff);
        }

        public async Task<List<StaffDTO>> Get_Staff_By_Name(string name)
        {
            List<Staff> staffs = await _db.Staffs.Where(h => h.Name.Contains(name)).ToListAsync();
            return _mapper.Map<List<StaffDTO>>(staffs);
        }

        public async Task<List<StaffDTO>> Get_Staff_By_Ward(int wid)
        {
            List<Staff> staffs = await _db.Staffs.Where(h => h.Ward.Id == wid).ToListAsync();
            return _mapper.Map<List<StaffDTO>>(staffs);
        }
        public async Task<List<StaffDTO>> Get_Staff_By_Section(int sid)
        {
            List<Staff> staffs = await _db.Staffs.Where(h => h.Section.Id == sid).ToListAsync();
            return _mapper.Map<List<StaffDTO>>(staffs);
        }

        public async Task<StaffDTO> Create_Update_Staff(StaffDTO staffDto)
        {
            Staff staff = _mapper.Map<StaffDTO, Staff>(staffDto);
            if (staff.EmployeeId > 0)
            {
                _db.Staffs.Update(staff);
            }
            else
            {
                _db.Staffs.Add(staff);
            }
            await _db.SaveChangesAsync();
            return _mapper.Map<Staff, StaffDTO>(staff);
        }

        public async Task<bool> Delete_Staff_By_Id(int id)
        {
            try
            {
                Staff staff = await _db.Staffs.FirstOrDefaultAsync(h => h.EmployeeId == id);
                if (staff == null)
                {
                    return false; ;
                }
                _db.Staffs.Remove(staff);
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
