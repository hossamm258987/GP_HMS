using Microsoft.AspNetCore.Mvc;
using Clinic_Management_Service.Repository.IRepository;
using Clinic_Management_Service.Models.DTOs;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Clinic_Management_Service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DocMExaminationController : ControllerBase
    {
        protected ResponseDTO _response;
        private IDocMExaminationRepository _docMExaminationRepository;

        public DocMExaminationController(IDocMExaminationRepository docMExaminationRepository)
        {
            this._response = new ResponseDTO();
            _docMExaminationRepository = docMExaminationRepository;
        }
        // GET: api/<DocMExaminationsController>
        [HttpGet]
        public async Task<object> Get()
        {
            try
            {
                IEnumerable<DocMExaminationDTO> docMExaminationDTOs = await _docMExaminationRepository.Get_DocMExaminations();
                _response.Result = docMExaminationDTOs;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages
                     = new List<string>() { ex.ToString() };
            }
            return _response;
        }

        // GET api/<DocMExaminationsController>/5
        [HttpGet("{id}")]
        public async Task<object> Get(int id)
        {
            try
            {
                DocMExaminationDTO DocMExaminationDTO = await _docMExaminationRepository.Get_DocMExamination_By_Id(id);
                _response.Result = DocMExaminationDTO;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages
                     = new List<string>() { ex.ToString() };
            }
            return _response;
        }

        // GET api/<DocMExaminationsController>/name/DocMExamination
        [HttpGet("doc/{did}")]
        public async Task<object> Get_By_DocId(int did)
        {
            try
            {
                IEnumerable<DocMExaminationDTO> docMExaminationDTOs = await _docMExaminationRepository.Get_DocMExamination_By_Doctor(did);
                _response.Result = docMExaminationDTOs;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages
                     = new List<string>() { ex.ToString() };
            }
            return _response;
        }

        // GET api/<DocMExaminationsController>/name/DocMExamination
        [HttpGet("sme/sid/{meid}")]
        public async Task<object> Get_By_ME(int sid, int meid)
        {
            try
            {
                IEnumerable<DocMExaminationDTO> docMExaminationDTOs = await _docMExaminationRepository.Get_MExamination_By_Section(sid, meid);
                _response.Result = docMExaminationDTOs;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages
                     = new List<string>() { ex.ToString() };
            }
            return _response;
        }

        // GET api/<DocMExaminationsController>/name/DocMExamination
        [HttpGet("me/{meid}")]
        public async Task<object> Get_By_ME(int meid)
        {
            try
            {
                IEnumerable<DocMExaminationDTO> docMExaminationDTOs = await _docMExaminationRepository.Get_DocMExamination_By_MExamination(meid);
                _response.Result = docMExaminationDTOs;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages
                     = new List<string>() { ex.ToString() };
            }
            return _response;
        }

        // POST api/<DocMExaminationsController>
        [HttpPost]
        public async Task<object> Post([FromBody] DocMExaminationDTO docMExaminationDTO)
        {
            try
            {
                DocMExaminationDTO model = await _docMExaminationRepository.Create_Update_DocMExamination(docMExaminationDTO);
                _response.Result = model;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages
                     = new List<string>() { ex.ToString() };
            }
            return _response;
        }

        // PUT api/<DocMExaminationsController>
        [HttpPut]
        public async Task<object> Put([FromBody] DocMExaminationDTO docMExaminationDTO)
        {
            try
            {
                DocMExaminationDTO model = await _docMExaminationRepository.Create_Update_DocMExamination(docMExaminationDTO);
                _response.Result = model;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages
                     = new List<string>() { ex.ToString() };
            }
            return _response;
        }

        // DELETE api/<DocMExaminationsController>/5
        [HttpDelete("{id}")]
        public async Task<object> Delete(int id)
        {
            try
            {
                bool isSuccess = await _docMExaminationRepository.Delete_DocMExamination_By_Id(id);
                _response.Result = isSuccess;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages
                     = new List<string>() { ex.ToString() };
            }
            return _response;
        }
    }
}
