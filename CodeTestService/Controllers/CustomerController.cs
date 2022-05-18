using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CodeTest.Infrastructure.Dispatcher;  
using CodeTest.Domain.Contract.Request;
using CodeTest.Domain.Queries;
using CodeTest.Domain.Commands;
using System.Net.Http;
using System.IO;
using System.Net;
using Microsoft.AspNetCore.Http;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CodeTestService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomerController : ControllerBase
    {
        public CustomerController()
        {
        }

        [Route("CustomerInfo")] 
        [HttpGet]
        public async Task<IActionResult> GetCustomerInfo(string socialNumber)
        {
            var query = new GetCustomerQuery(socialNumber);
            var result = await MediatorDispatcher.ExecuteMediatorAsync(query);
            if (result.Result == null) 
            {
                var message = new HttpResponseMessage(HttpStatusCode.NoContent) { ReasonPhrase = "No Data Found" };
                throw new InvalidDataException(message.ToString());
            }
            return Ok(result);
        }    


        [HttpPost]
        [Route("AddCustomerInfo")]
        public async Task<IActionResult> AddCustomerInfo([FromBody] AddCustomerInfoRequest user)
        {
            var command = new AddCustomerInfoCommand(user);
            if (string.IsNullOrEmpty(user.SocialNumber))
            {
                var message = new HttpResponseMessage(HttpStatusCode.BadRequest) { ReasonPhrase = "Invalid Input" };
                throw new InvalidDataException(message.ToString());
            }
            var result = await MediatorDispatcher.ExecuteMediatorAsync(command);
            return Ok(result);
        }

        [HttpPut]
        [Route("ModifyCustomerInfo")]
        public async Task<IActionResult> ModifyCustomerInfo([FromBody] AddCustomerInfoRequest user)
        {
            var command = new AddCustomerInfoCommand(user);
            if (string.IsNullOrEmpty(user.SocialNumber))
            {
                var message = new HttpResponseMessage(HttpStatusCode.BadRequest) { ReasonPhrase = "Invalid Input" };
                throw new InvalidDataException(message.ToString());
            }
            var result = await MediatorDispatcher.ExecuteMediatorAsync(command);
            return Ok(result);
        }

        [HttpDelete("delete/{id}")]
        public IActionResult Delete(string socialNumber)
        {
            try
            {

                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}

