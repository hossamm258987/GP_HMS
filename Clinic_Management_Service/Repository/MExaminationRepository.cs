using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Clinic_Management_Service.Data;
using Clinic_Management_Service.Models;
using Clinic_Management_Service.Models.DTOs;
using Clinic_Management_Service.Repository.IRepository;

namespace Clinic_Management_Service.Repository
{
    public class MExaminationRepository : IMExaminationRepository
    {
        private readonly ApplicationDbContext _db;
        private IMapper _mapper;

        public MExaminationRepository(ApplicationDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public async Task<List<MExaminationDTO>> Get_MExaminations()
        {
            List<MExamination> mExaminations = await _db.MExaminations.ToListAsync();
            return _mapper.Map<List<MExaminationDTO>>(mExaminations);
        }

        public async Task<MExaminationDTO> Get_MExamination_By_Id(int id)
        {
            MExamination mExamination = await _db.MExaminations.FirstOrDefaultAsync(h => h.Id == id);
            return _mapper.Map<MExaminationDTO>(mExamination);
        }

        public async Task<List<MExaminationDTO>> Get_MExamination_By_Name(string name)
        {
            List<MExamination> mExaminations = await _db.MExaminations.Where(h => h.Name.Contains(name)).ToListAsync();
            return _mapper.Map<List<MExaminationDTO>>(mExaminations);
        }

        public async Task<MExaminationDTO> Create_Update_MExamination(MExaminationDTO mExaminationDto)
        {
            MExamination mExamination = _mapper.Map<MExaminationDTO, MExamination>(mExaminationDto);

            if (mExamination.Id > 0)
            {
                _db.MExaminations.Update(mExamination);
            }
            else
            {
                _db.MExaminations.Add(mExamination);
            }
            await _db.SaveChangesAsync();
            return _mapper.Map<MExamination, MExaminationDTO>(mExamination);
        }

        public async Task<bool> Delete_MExamination_By_Id(int id)
        {
            try
            {
                MExamination mExamination = await _db.MExaminations.FirstOrDefaultAsync(h => h.Id == id);
                if (mExamination == null)
                {
                    return false; ;
                }
                _db.MExaminations.Remove(mExamination);
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
