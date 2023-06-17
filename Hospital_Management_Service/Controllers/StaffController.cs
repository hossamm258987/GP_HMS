using Microsoft.AspNetCore.Mvc;
using Hospital_Management_Service.Repository.IRepository;
using Hospital_Management_Service.Models.DTOs;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Hospital_Management_Service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StaffController : ControllerBase
    {
        protected ResponseDTO _response;
        private IStaffRepository _staffRepository;

        public StaffController(IStaffRepository staffRepository)
        {
            this._response = new ResponseDTO();
            _staffRepository = staffRepository;
        }
        // GET: api/<StaffsController>
        [HttpGet]
        public async Task<object> Get()
        {
            try
            {
                IEnumerable<StaffDTO> StaffDTOs = await _staffRepository.Get_Staffs();
                _response.Result = StaffDTOs;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages
                     = new List<string>() { ex.ToString() };
            }
            return _response;
        }

        // GET api/<StaffsController>/5
        [HttpGet("{id}")]
        public async Task<object> Get(int id)
        {
            try
            {
                StaffDTO StaffDTO = await _staffRepository.Get_Staff_By_Id(id);
                _response.Result = StaffDTO;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages
                     = new List<string>() { ex.ToString() };
            }
            return _response;
        }

        // GET api/<StaffsController>/name/Staff
        [HttpGet("name/{name}")]
        public async Task<object> Get(string name)
        {
            try
            {
                IEnumerable<StaffDTO> StaffDTOs = await _staffRepository.Get_Staff_By_Name(name);
                _response.Result = StaffDTOs;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages
                     = new List<string>() { ex.ToString() };
            }
            return _response;
        }

        // GET api/<StaffsController>/ward/Staffs
        [HttpGet("ward/{wid}")]
        public async Task<object> Get_By_Ward(int wid)
        {
            try
            {
                IEnumerable<StaffDTO> StaffDTOs = await _staffRepository.Get_Staff_By_Ward(wid);
                _response.Result = StaffDTOs;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages
                     = new List<string>() { ex.ToString() };
            }
            return _response;
        }

        [HttpGet("sec/{sid}")]
        public async Task<object> Get_By_Section(int sid)
        {
            try
            {
                IEnumerable<StaffDTO> StaffDTOs = await _staffRepository.Get_Staff_By_Section(sid);
                _response.Result = StaffDTOs;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages
                     = new List<string>() { ex.ToString() };
            }
            return _response;
        }

        // POST api/<StaffsController>
        [HttpPost]
        public async Task<object> Post([FromBody] StaffDTO StaffDTO)
        {
            try
            {
                StaffDTO model = await _staffRepository.Create_Update_Staff(StaffDTO);
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

        // PUT api/<StaffsController>
        [HttpPut]
        public async Task<object> Put([FromBody] StaffDTO StaffDTO)
        {
            try
            {
                StaffDTO model = await _staffRepository.Create_Update_Staff(StaffDTO);
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

        // DELETE api/<StaffsController>/5
        [HttpDelete("{id}")]
        public async Task<object> Delete(int id)
        {
            try
            {
                bool isSuccess = await _staffRepository.Delete_Staff_By_Id(id);
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
