using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Task1.Repository;

namespace Task1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PeopleController : ControllerBase
    {
        private readonly ILogger<PeopleController> _logger;
        private readonly IRepository _repository;

        public PeopleController(ILogger<PeopleController> logger, IRepository repository)
        {
            _logger = logger;
            _repository = repository;
        }

        [HttpPost]
        public async Task<ActionResult> AddPerson([FromForm] Person person)
        {
            await _repository.AddAsync(person);
            return Ok();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Person>> GetPerson(int id)
        {
            var response = await _repository.GetAsync(id);
            return new OkObjectResult(response);
        }

        [HttpPut]
        public async Task<ActionResult> UpdatePerson([FromForm] Person person)
        {
            await _repository.UpdateAsync(person);
            return Ok();
        }

        [HttpDelete]
        public async Task<ActionResult> DeletePerson(int id)
        {
            await _repository.DeleteAsync(id);
            return Ok();
        }
    }
}