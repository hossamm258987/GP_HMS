using Microsoft.AspNetCore.Mvc;
using Hospital_Management_Service.Models.DTOs;
using Hospital_Management_Service.Repository.IRepository;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Hospital_Management_Service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReceptionistController : ControllerBase
    {
        protected ResponseDTO _response;
        private IReceptionistRepository _receptionistRepository;

        public ReceptionistController(IReceptionistRepository receptionistRepository)
        {
            this._response = new ResponseDTO();
            _receptionistRepository = receptionistRepository;
        }
        // GET: api/<ReceptionistController>
        [HttpGet]
        public async Task<object> Get()
        {
            try
            {
                IEnumerable<ReceptionistDTO> receptionistDTOs = await _receptionistRepository.Get_Receptionists();
                _response.Result = receptionistDTOs;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages
                     = new List<string>() { ex.ToString() };
            }
            return _response;
        }

        // GET api/<ReceptionistController>/5
        [HttpGet("{id}")]
        public async Task<object> Get(int id)
        {
            try
            {
                ReceptionistDTO receptionistDTO = await _receptionistRepository.Get_Receptionist_By_Id(id);
                _response.Result = receptionistDTO;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages
                     = new List<string>() { ex.ToString() };
            }
            return _response;
        }

        // GET api/<ReceptionistController>/name/Receptionist
        [HttpGet("name/{name}")]
        public async Task<object> Get(string Name)
        {
            try
            {
                List<ReceptionistDTO> receptionistDTO = await _receptionistRepository.Get_Receptionist_By_Name(Name);
                _response.Result = receptionistDTO;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages
                     = new List<string>() { ex.ToString() };
            }
            return _response;
        }

        // GET api/<ReceptionistController>/sec/Id
        [HttpGet("sec/{sid}")]
        public async Task<object> Get_By_Sec(int sid)
        {
            try
            {
                List<ReceptionistDTO> receptionistDTO = await _receptionistRepository.Get_Receptionist_By_Section(sid);
                _response.Result = receptionistDTO;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages
                     = new List<string>() { ex.ToString() };
            }
            return _response;
        }

        // POST api/<ReceptionistController>
        [HttpPost]
        public async Task<object> Post([FromBody] ReceptionistDTO receptionistDTO)
        {
            try
            {
                ReceptionistDTO model = await _receptionistRepository.Create_Update_Receptionist(receptionistDTO);
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

        // PUT api/<ReceptionistController>/5
        [HttpPut("{id}")]
        public async Task<object> Put([FromBody] ReceptionistDTO receptionistDTO)
        {
            try
            {
                ReceptionistDTO model = await _receptionistRepository.Create_Update_Receptionist(receptionistDTO);
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

        // DELETE api/<ReceptionistController>/5
        [HttpDelete("{id}")]
        public async Task<object> Delete(int id)
        {
            try
            {
                bool isSuccess = await _receptionistRepository.Delete_Receptionist_By_Id(id);
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
