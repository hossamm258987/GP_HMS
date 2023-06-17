using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Hospital_Management_Service.Data;
using Hospital_Management_Service.Models;
using Hospital_Management_Service.Models.DTOs;
using Hospital_Management_Service.Repository.IRepository;

namespace Hospital_Management_Service.Repository
{
    public class AnalystRepository : IAnalystRepository
    {
        private readonly ApplicationDbContext _db;
        private IMapper _mapper;

        public AnalystRepository(ApplicationDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public async Task<List<AnalystDTO>> Get_Analysts()
        {
            List<Analyst> analysts = await _db.Analysts.ToListAsync();
            return _mapper.Map<List<AnalystDTO>>(analysts);
        }

        public async Task<AnalystDTO> Get_Analyst_By_Id(int id)
        {
            Analyst analyst = await _db.Analysts.FirstOrDefaultAsync(a => a.EmployeeId == id);
            return _mapper.Map<AnalystDTO>(analyst);
        }

        public async Task<List<AnalystDTO>> Get_Analyst_By_Name(string name)
        {
            List<Analyst> analysts = await _db.Analysts.Where(a => a.Name.Contains(name)).ToListAsync();
            return _mapper.Map<List<AnalystDTO>>(analysts);
        }

        public async Task<List<AnalystDTO>> Get_Analyst_By_Section(int secId)
        {
            List<Analyst> analysts = await _db.Analysts.Where(d => d.Section.Id == secId).ToListAsync();
            return _mapper.Map<List<AnalystDTO>>(analysts);
        }

        public async Task<AnalystDTO> Create_Update_Analyst(AnalystDTO analystDto)
        {
            Analyst analyst = _mapper.Map<AnalystDTO, Analyst>(analystDto);
            if (analyst.EmployeeId > 0)
            {
                _db.Analysts.Update(analyst);
            }
            else
            {
                _db.Analysts.Add(analyst);
            }
            await _db.SaveChangesAsync();
            return _mapper.Map<Analyst, AnalystDTO>(analyst);
        }

        public async Task<bool> Delete_Analyst_By_Id(int id)
        {
            try
            {
                Analyst analyst = await _db.Analysts.FirstOrDefaultAsync(a => a.EmployeeId == id);
                if (analyst == null)
                {
                    return false; ;
                }
                _db.Analysts.Remove(analyst);
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
