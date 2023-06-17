using Microsoft.AspNetCore.Mvc;
using Clinic_Management_Service.Repository.IRepository;
using Clinic_Management_Service.Models.DTOs;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Clinic_Management_Service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MExaminationController : ControllerBase
    {
        protected ResponseDTO _response;
        private IMExaminationRepository _mExaminationRepository;

        public MExaminationController(IMExaminationRepository mExaminationRepository)
        {
            this._response = new ResponseDTO();
            _mExaminationRepository = mExaminationRepository;
        }
        // GET: api/<MExaminationsController>
        [HttpGet]
        public async Task<object> Get()
        {
            try
            {
                IEnumerable<MExaminationDTO> mExaminationDTOs = await _mExaminationRepository.Get_MExaminations();
                _response.Result = mExaminationDTOs;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages
                     = new List<string>() { ex.ToString() };
            }
            return _response;
        }

        // GET api/<MExaminationsController>/5
        [HttpGet("{id}")]
        public async Task<object> Get(int id)
        {
            try
            {
                MExaminationDTO mExaminationDTO = await _mExaminationRepository.Get_MExamination_By_Id(id);
                _response.Result = mExaminationDTO;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages
                     = new List<string>() { ex.ToString() };
            }
            return _response;
        }

        // GET api/<MExaminationsController>/name/MExamination
        [HttpGet("name/{name}")]
        public async Task<object> Get(string name)
        {
            try
            {
                IEnumerable<MExaminationDTO> mExaminationDTOs = await _mExaminationRepository.Get_MExamination_By_Name(name);
                _response.Result = mExaminationDTOs;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages
                     = new List<string>() { ex.ToString() };
            }
            return _response;
        }

        //// GET api/<MExaminationsController>/sec/MExamination
        //[HttpGet("sec/{sid}")]
        //public async Task<object> Get_By_Sec(int sid)
        //{
        //    try
        //    {
        //        IEnumerable<MExaminationDTO> mExaminationDTOs = await _mExaminationRepository.Get_MExamination_By_Section(sid);
        //        _response.Result = mExaminationDTOs;
        //    }
        //    catch (Exception ex)
        //    {
        //        _response.IsSuccess = false;
        //        _response.ErrorMessages
        //             = new List<string>() { ex.ToString() };
        //    }
        //    return _response;
        //}

        // POST api/<MExaminationsController>
        [HttpPost]
        public async Task<object> Post([FromBody] MExaminationDTO mExaminationDTO)
        {
            try
            {
                MExaminationDTO model = await _mExaminationRepository.Create_Update_MExamination(mExaminationDTO);
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

        // PUT api/<MExaminationsController>
        [HttpPut]
        public async Task<object> Put([FromBody] MExaminationDTO mExaminationDTO)
        {
            try
            {
                MExaminationDTO model = await _mExaminationRepository.Create_Update_MExamination(mExaminationDTO);
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

        // DELETE api/<MExaminationsController>/5
        [HttpDelete("{id}")]
        public async Task<object> Delete(int id)
        {
            try
            {
                bool isSuccess = await _mExaminationRepository.Delete_MExamination_By_Id(id);
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
