using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Examples.Charge.Application.Interfaces;
using Examples.Charge.Application.Messages.Request;
using Examples.Charge.Application.Messages.Response;
using System.Threading.Tasks;
using Examples.Charge.Application.Dtos;
using Examples.Charge.Domain.Aggregates.PersonAggregate;

namespace Examples.Charge.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExampleController : BaseController
    {
        private readonly IPersonFacade _personFacade;

        public ExampleController(IPersonFacade personFacade)
        {
            _personFacade = personFacade;
        }

        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            return Response(null);
        }
        

        [HttpPost]
        public async Task<IActionResult> Post(PersonPhoneDto personPhone)
        {
            var result = await _personFacade.InsertPersonPhone(personPhone);
            return Ok(new {success = result});
        }
        
        [HttpPost]
        public async Task<IActionResult> Update(PersonPhoneDto personPhone)
        {
            var result = await _personFacade.Update(personPhone);
            return Ok(new {success = result});
        }
        
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _personFacade.Delete(id);
            return Ok(new {success = result});
        }
    }
}
