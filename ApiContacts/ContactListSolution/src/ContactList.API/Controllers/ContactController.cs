using ContactList.BLL.Services.Contracts;
using ContactList.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ContactList.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly IContactsService _contactsService;

        public ContactController(IContactsService contactsService)
        {
            _contactsService = contactsService;
        }

        [HttpGet("List/{search?}")]
        public async Task<IActionResult> List(string search = "NA")
        {
            var response = new ResponseDTO<List<ContactDTOs>>();
            try
            {
                if (search == "NA")
                {
                    search = "";
                }
                response.IsOk = true;
                response.Result = await _contactsService.ListFilterByAdressAndName(search);

            }
            catch (Exception ex)
            {

                response.IsOk = false;
                response.Message = ex.Message;
            }

            return Ok(response);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> Get(int id)
        {
            var response = new ResponseDTO<ContactDTOs>();
            try
            {

                response.IsOk = true;
                response.Result = await _contactsService.FindById(id);

            }
            catch (Exception ex)
            {

                response.IsOk = false;
                response.Message = ex.Message;
            }

            return Ok(response);
        }

        [HttpGet("FindByRangeOfAge")]

        public async Task<IActionResult> FindByRangeOfAge(int ageinit, int agefinal)
        {
            var response = new ResponseDTO<List<ContactDTOs>>();



            try
            {
                response.IsOk = true;
                response.Result = await _contactsService.FindRangeAge(ageinit, agefinal);
            }
            catch (Exception ex)
            {
                response.IsOk = false;
                response.Message = ex.Message;
            }

            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ContactDTOs modelo)
        {
            var response = new ResponseDTO<ContactDTOs>();
            try
            {

                response.IsOk  = true;
                response.Result = await _contactsService.Create(modelo);

            }
            catch (Exception ex)
            {

                response.IsOk = false;
                response.Message = ex.Message;
            }

            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] ContactDTOs modelo)
        {
            var response = new ResponseDTO<bool>();
            try
            {

                response.IsOk = true;
                response.Result = await _contactsService.Update(modelo);

            }
            catch (Exception ex)
            {

                response.IsOk = false;
                response.Message = ex.Message;
            }

            return Ok(response);
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var response = new ResponseDTO<bool>();
            try
            {

                response.IsOk = true;
                response.Result = await _contactsService.Delete(id);

            }
            catch (Exception ex)
            {

                response.IsOk = false;
                response.Message = ex.Message;
            }

            return Ok(response);
        }


    }
}
