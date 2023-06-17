using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Hospital_Management_Service.Data;
using Hospital_Management_Service.Models;
using Hospital_Management_Service.Models.DTOs;
using Hospital_Management_Service.Repository.IRepository;

namespace Hospital_Management_Service.Repository
{
    public class WardRepository : IWardRepository
    {
        private readonly ApplicationDbContext _db;
        private IMapper _mapper;

        public WardRepository(ApplicationDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public async Task<List<WardDTO>> Get_Wards()
        {
            List<Ward> wards = await _db.Wards.ToListAsync();
            return _mapper.Map<List<WardDTO>>(wards);
        }

        public async Task<WardDTO> Get_Ward_By_Id(int id)
        {
            Ward ward = await _db.Wards.FirstOrDefaultAsync(h => h.Id == id);
            return _mapper.Map<WardDTO>(ward);
        }

        public async Task<List<WardDTO>> Get_Ward_By_Name(string name)
        {
            List<Ward> wards = await _db.Wards.Where(h => h.Name.Contains(name)).ToListAsync();
            return _mapper.Map<List<WardDTO>>(wards);
        }

        public async Task<WardDTO> Create_Update_Ward(WardDTO wardDto)
        {
            Ward ward = _mapper.Map<WardDTO, Ward>(wardDto);
            if (ward.Id > 0)
            {
                _db.Wards.Update(ward);
            }
            else
            {
                _db.Wards.Add(ward);
            }
            await _db.SaveChangesAsync();
            return _mapper.Map<Ward, WardDTO>(ward);
        }

        public async Task<bool> Delete_Ward_By_Id(int id)
        {
            try
            {
                Ward ward = await _db.Wards.FirstOrDefaultAsync(h => h.Id == id);
                if (ward == null)
                {
                    return false; ;
                }
                _db.Wards.Remove(ward);
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
