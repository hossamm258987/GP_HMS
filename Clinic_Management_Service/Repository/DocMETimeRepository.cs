using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Clinic_Management_Service.Data;
using Clinic_Management_Service.Models;
using Clinic_Management_Service.Models.DTOs;
using Clinic_Management_Service.Repository.IRepository;

namespace Clinic_Management_Service.Repository
{
    public class DocMETimeRepository : IDocMETimeRepository
    {
        private readonly ApplicationDbContext _db;
        private IMapper _mapper;

        public DocMETimeRepository(ApplicationDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public async Task<List<DocMETimeDTO>> Get_DocMETimes()
        {
            List<DocMETime> docMETimes = await _db.DocMETimes.ToListAsync();
            return _mapper.Map<List<DocMETimeDTO>>(docMETimes);
        }

        public async Task<DocMETimeDTO> Get_DocMETime_By_Id(int id)
        {
            DocMETime docMETime = await _db.DocMETimes.FirstOrDefaultAsync(h => h.Id == id);
            return _mapper.Map<DocMETimeDTO>(docMETime);
        }

        public async Task<List<DocMETimeDTO>> Get_DocMETime_By_Name(string name)
        {
            List<DocMETime> docMETimes = await _db.DocMETimes.Where(h => h.DocMExamination.MExamination.Name.Contains(name)).ToListAsync();
            return _mapper.Map<List<DocMETimeDTO>>(docMETimes);
        }

        public async Task<List<DocMETimeDTO>> Get_DocMETime_By_DocME(int dmeid)
        {
            List<DocMETime> docMETimes = await _db.DocMETimes.Where(h => h.DocMExamination.Id == dmeid).ToListAsync();
            return _mapper.Map<List<DocMETimeDTO>>(docMETimes);
        }

        public async Task<List<DocMETimeDTO>> Get_DocMETime_By_Doctor(int did)
        {
            List<DocMETime> docMETimes = await _db.DocMETimes.Where(h => h.DocMExamination.Doctor.EmployeeId == did).ToListAsync();
            return _mapper.Map<List<DocMETimeDTO>>(docMETimes);
        }

        public async Task<DocMETimeDTO> Create_Update_DocMETime(DocMETimeDTO docMETimeDto)
        {
            DocMETime docMETime = _mapper.Map<DocMETimeDTO, DocMETime>(docMETimeDto);
            if (docMETime.Id > 0)
            {
                _db.DocMETimes.Update(docMETime);
            }
            else
            {
                _db.DocMETimes.Add(docMETime);
            }
            await _db.SaveChangesAsync();
            return _mapper.Map<DocMETime, DocMETimeDTO>(docMETime);
        }

        public async Task<bool> Delete_DocMETime_By_Id(int id)
        {
            try
            {
                DocMETime docMETime = await _db.DocMETimes.FirstOrDefaultAsync(h => h.Id == id);
                if (docMETime == null)
                {
                    return false; ;
                }
                _db.DocMETimes.Remove(docMETime);
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
