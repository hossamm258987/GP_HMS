using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Hospital_Management_Service.Data;
using Hospital_Management_Service.Models;
using Hospital_Management_Service.Models.DTOs;
using Hospital_Management_Service.Repository.IRepository;

namespace Hospital_Management_Service.Repository
{
    public class PharmatistRepository : IPharmatistRepository
    {
        private readonly ApplicationDbContext _db;
        private IMapper _mapper;

        public PharmatistRepository(ApplicationDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public async Task<List<PharmatistDTO>> Get_Pharmatists()
        {
            List<Pharmatist> pharmatists = await _db.Pharmatists.ToListAsync();
            return _mapper.Map<List<PharmatistDTO>>(pharmatists);
        }

        public async Task<PharmatistDTO> Get_Pharmatist_By_Id(int id)
        {
            Pharmatist pharmatist = await _db.Pharmatists.FirstOrDefaultAsync(d => d.EmployeeId == id);
            return _mapper.Map<PharmatistDTO>(pharmatist);
        }

        public async Task<List<PharmatistDTO>> Get_Pharmatist_By_Name(string name)
        {
            List<Pharmatist> pharmatists = await _db.Pharmatists.Where(d => d.Name.Contains(name)).ToListAsync();
            return _mapper.Map<List<PharmatistDTO>>(pharmatists);
        }

        public async Task<List<PharmatistDTO>> Get_Pharmatist_By_Section(int secId)
        {
            List<Pharmatist> pharmatists = await _db.Pharmatists.Where(d => d.Section.Id == secId).ToListAsync();
            return _mapper.Map<List<PharmatistDTO>>(pharmatists);
        }

        public async Task<PharmatistDTO> Create_Update_Pharmatist(PharmatistDTO pharmatistDto)
        {
            Pharmatist pharmatist = _mapper.Map<PharmatistDTO, Pharmatist>(pharmatistDto);
            if (pharmatist.EmployeeId > 0)
            {
                _db.Pharmatists.Update(pharmatist);
            }
            else
            {
                _db.Pharmatists.Add(pharmatist);
            }
            await _db.SaveChangesAsync();
            return _mapper.Map<Pharmatist, PharmatistDTO>(pharmatist);
        }

        public async Task<bool> Delete_Pharmatist_By_Id(int id)
        {
            try
            {
                Pharmatist pharmatist = await _db.Pharmatists.FirstOrDefaultAsync(d => d.EmployeeId == id);
                if (pharmatist == null)
                {
                    return false; ;
                }
                _db.Pharmatists.Remove(pharmatist);
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
