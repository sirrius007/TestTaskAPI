using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TestTaskApi.Business.Services.Interfaces;
using System;

namespace TestTaskAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly IPersonManager _personManager;

        public PersonController(IPersonManager personManager)
        {
            _personManager = personManager;
        }

        [HttpGet]
        public async Task<ActionResult<string>> GetAll(string input)
        {
            try
            {
                var result = await _personManager.GetAllAsync(input);
                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult<long>> Save(string input)
        {
            try
            {
                var id = await _personManager.UpsertAsync(input);
                return Ok(id);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
