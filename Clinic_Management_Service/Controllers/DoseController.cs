using Microsoft.AspNetCore.Mvc;
using Clinic_Management_Service.Repository.IRepository;
using Clinic_Management_Service.Models.DTOs;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Clinic_Management_Service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoseController : ControllerBase
    {
        protected ResponseDTO _response;
        private IDoseRepository _doseRepository;

        public DoseController(IDoseRepository doseRepository)
        {
            this._response = new ResponseDTO();
            _doseRepository = doseRepository;
        }
        // GET: api/<DosesController>
        [HttpGet]
        public async Task<object> Get()
        {
            try
            {
                IEnumerable<DoseDTO> doseDTOs = await _doseRepository.Get_Doses();
                _response.Result = doseDTOs;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages
                     = new List<string>() { ex.ToString() };
            }
            return _response;
        }

        // GET api/<DosesController>/5
        [HttpGet("{id}")]
        public async Task<object> Get(int id)
        {
            try
            {
                DoseDTO doseDTO = await _doseRepository.Get_Dose_By_Id(id);
                _response.Result = doseDTO;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages
                     = new List<string>() { ex.ToString() };
            }
            return _response;
        }

        // GET api/<DosesController>/name/Dose
        [HttpGet("name/{name}")]
        public async Task<object> Get(string name)
        {
            try
            {
                IEnumerable<DoseDTO> doseDTOs = await _doseRepository.Get_Dose_By_Name(name);
                _response.Result = doseDTOs;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages
                     = new List<string>() { ex.ToString() };
            }
            return _response;
        }

        // POST api/<DosesController>
        [HttpPost]
        public async Task<object> Post([FromBody] DoseDTO doseDTO)
        {
            try
            {
                DoseDTO model = await _doseRepository.Create_Update_Dose(doseDTO);
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

        // PUT api/<DosesController>
        [HttpPut]
        public async Task<object> Put([FromBody] DoseDTO doseDTO)
        {
            try
            {
                DoseDTO model = await _doseRepository.Create_Update_Dose(doseDTO);
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

        // DELETE api/<DosesController>/5
        [HttpDelete("{id}")]
        public async Task<object> Delete(int id)
        {
            try
            {
                bool isSuccess = await _doseRepository.Delete_Dose_By_Id(id);
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
