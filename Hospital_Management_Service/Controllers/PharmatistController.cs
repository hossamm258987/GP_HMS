using Microsoft.AspNetCore.Mvc;
using Hospital_Management_Service.Models.DTOs;
using Hospital_Management_Service.Repository.IRepository;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Hospital_Management_Service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PharmatistController : ControllerBase
    {
        protected ResponseDTO _response;
        private IPharmatistRepository _pharmatistRepository;

        public PharmatistController(IPharmatistRepository pharmatistRepository)
        {
            this._response = new ResponseDTO();
            _pharmatistRepository = pharmatistRepository;
        }
        // GET: api/<PharmatistController>
        [HttpGet]
        public async Task<object> Get()
        {
            try
            {
                IEnumerable<PharmatistDTO> pharmatistDTOs = await _pharmatistRepository.Get_Pharmatists();
                _response.Result = pharmatistDTOs;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages
                     = new List<string>() { ex.ToString() };
            }
            return _response;
        }

        // GET api/<PharmatistController>/5
        [HttpGet("{id}")]
        public async Task<object> Get(int id)
        {
            try
            {
                PharmatistDTO pharmatistDTO = await _pharmatistRepository.Get_Pharmatist_By_Id(id);
                _response.Result = pharmatistDTO;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages
                     = new List<string>() { ex.ToString() };
            }
            return _response;
        }

        // GET api/<PharmatistController>/name/Pharmatist
        [HttpGet("name/{name}")]
        public async Task<object> Get(string Name)
        {
            try
            {
                List<PharmatistDTO> pharmatistDTO = await _pharmatistRepository.Get_Pharmatist_By_Name(Name);
                _response.Result = pharmatistDTO;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages
                     = new List<string>() { ex.ToString() };
            }
            return _response;
        }

        // GET api/<PharmatistController>/sec/Id
        [HttpGet("sec/{sid}")]
        public async Task<object> Get_By_Sec(int sid)
        {
            try
            {
                List<PharmatistDTO> pharmatistDTO = await _pharmatistRepository.Get_Pharmatist_By_Section(sid);
                _response.Result = pharmatistDTO;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages
                     = new List<string>() { ex.ToString() };
            }
            return _response;
        }

        
        // POST api/<PharmatistController>
        [HttpPost]
        public async Task<object> Post([FromBody] PharmatistDTO pharmatistDTO)
        {
            try
            {
                PharmatistDTO model = await _pharmatistRepository.Create_Update_Pharmatist(pharmatistDTO);
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

        // PUT api/<PharmatistController>/5
        [HttpPut("{id}")]
        public async Task<object> Put([FromBody] PharmatistDTO pharmatistDTO)
        {
            try
            {
                PharmatistDTO model = await _pharmatistRepository.Create_Update_Pharmatist(pharmatistDTO);
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

        // DELETE api/<PharmatistController>/5
        [HttpDelete("{id}")]
        public async Task<object> Delete(int id)
        {
            try
            {
                bool isSuccess = await _pharmatistRepository.Delete_Pharmatist_By_Id(id);
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
