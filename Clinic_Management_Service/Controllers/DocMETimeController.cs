using Microsoft.AspNetCore.Mvc;
using Clinic_Management_Service.Repository.IRepository;
using Clinic_Management_Service.Models.DTOs;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Clinic_Management_Service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DocMETimeController : ControllerBase
    {
        protected ResponseDTO _response;
        private IDocMETimeRepository _docMETimeRepository;

        public DocMETimeController(IDocMETimeRepository docMETimeRepository)
        {
            this._response = new ResponseDTO();
            _docMETimeRepository = docMETimeRepository;
        }
        // GET: api/<DocMETimesController>
        [HttpGet]
        public async Task<object> Get()
        {
            try
            {
                IEnumerable<DocMETimeDTO> docMETimeDTOs = await _docMETimeRepository.Get_DocMETimes();
                _response.Result = docMETimeDTOs;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages
                     = new List<string>() { ex.ToString() };
            }
            return _response;
        }

        // GET api/<DocMETimesController>/5
        [HttpGet("{id}")]
        public async Task<object> Get(int id)
        {
            try
            {
                DocMETimeDTO docMETimeDTO = await _docMETimeRepository.Get_DocMETime_By_Id(id);
                _response.Result = docMETimeDTO;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages
                     = new List<string>() { ex.ToString() };
            }
            return _response;
        }

        // GET api/<DocMETimesController>/name/DocMETime
        [HttpGet("name/{name}")]
        public async Task<object> Get(string name)
        {
            try
            {
                IEnumerable<DocMETimeDTO> docMETimeDTOs = await _docMETimeRepository.Get_DocMETime_By_Name(name);
                _response.Result = docMETimeDTOs;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages
                     = new List<string>() { ex.ToString() };
            }
            return _response;
        }

        // GET api/<DocMETimesController>/dme/DocMETime
        [HttpGet("dme/{dmeid}")]
        public async Task<object> Get_By_DME(int dmeid)
        {
            try
            {
                IEnumerable<DocMETimeDTO> docMETimeDTOs = await _docMETimeRepository.Get_DocMETime_By_DocME(dmeid);
                _response.Result = docMETimeDTOs;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages
                     = new List<string>() { ex.ToString() };
            }
            return _response;
        }

        // GET api/<DocMETimesController>/doc/DocMETime
        [HttpGet("doc/{did}")]
        public async Task<object> Get_By_Doc(int did)
        {
            try
            {
                IEnumerable<DocMETimeDTO> docMETimeDTOs = await _docMETimeRepository.Get_DocMETime_By_Doctor(did);
                _response.Result = docMETimeDTOs;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages
                     = new List<string>() { ex.ToString() };
            }
            return _response;
        }

        // POST api/<DocMETimesController>
        [HttpPost]
        public async Task<object> Post([FromBody] DocMETimeDTO docMETimeDTO)
        {
            try
            {
                DocMETimeDTO model = await _docMETimeRepository.Create_Update_DocMETime(docMETimeDTO);
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

        // PUT api/<DocMETimesController>
        [HttpPut]
        public async Task<object> Put([FromBody] DocMETimeDTO docMETimeDTO)
        {
            try
            {
                DocMETimeDTO model = await _docMETimeRepository.Create_Update_DocMETime(docMETimeDTO);
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

        // DELETE api/<DocMETimesController>/5
        [HttpDelete("{id}")]
        public async Task<object> Delete(int id)
        {
            try
            {
                bool isSuccess = await _docMETimeRepository.Delete_DocMETime_By_Id(id);
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
