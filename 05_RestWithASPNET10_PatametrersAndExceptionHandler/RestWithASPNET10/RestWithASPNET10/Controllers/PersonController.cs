using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestWithASPNET10.Model;
using RestWithASPNET10.Services;

namespace RestWithASPNET10.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PersonController : ControllerBase
    {
        private IPersonServices _personServices;
        private readonly ILogger<PersonController> _logger;

        public PersonController(IPersonServices personServices, ILogger<PersonController> logger)
        {
            _personServices = personServices;
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Get()
        {
            _logger.LogInformation("Fetching all persons");
            return Ok(_personServices.FindAll());
        }

        [HttpGet("{id}")]
        public IActionResult Get(long id)
        {
            _logger.LogInformation("Fetching person with ID {id}", id);
            var person = _personServices.FindById(id);
            if (person == null) {
                _logger.LogWarning("Person with ID {id} not found", id);
                return NotFound(); 
            }
            return Ok(person);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Person person)
        {
            _logger.LogInformation("Create new person: {firstName}", person.FirstName);
            var createdPerson = _personServices.Create(person);
            if (person == null) {
                _logger.LogError("Failed to create person with name: {firstName}", person.FirstName);
                return BadRequest(); 
            }
            return Ok(createdPerson);
        }

        [HttpPut]
        public IActionResult Put([FromBody] Person person)
        {
            _logger.LogInformation("Update person ID {id}", person.Id);
            var updatedPerson = _personServices.Update(person);
            if (person == null) {
                _logger.LogError("Failed to update person with ID: {id}", person.Id);
                return BadRequest();
            }
            _logger.LogDebug("Person ID {id} updated successfully", person.Id);
            return Ok(updatedPerson);
        }

        [HttpDelete("{id}")]

        public IActionResult Delete(long id)
        {
            _logger.LogInformation("Delete person ID {id}", id);
            _personServices.Delete(id);
            _logger.LogDebug("Person ID {id} deleted successfully", id);
            return NoContent();
        }
    }
}
