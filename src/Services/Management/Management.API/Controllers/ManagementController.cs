using Management.Data.Repositories;
using Management.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Management.API.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class ManagementController : ControllerBase
    {
        public readonly IPartRepository _repository;
        public readonly ILogger<ManagementController> _logger;

        public ManagementController(IPartRepository repository, ILogger<ManagementController> logger)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        //method http
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<Part>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<Part>>> GetParts()
        {
            var parts = await _repository.GetParts();
            return Ok(parts);
        }

        [HttpGet("{id:length(24)}", Name = "GetPart")]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(Part), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<Part>> GetPartById(string id)
        {
            var part = await _repository.GetPart(id);
            if (part == null)
            {
                _logger.LogError($"Peca com id: {id}, nao encontrado!");
                return NotFound();
            }
            return Ok(part);
        }

        [Route("[action]/{category}", Name = "GetPartByCategory")]
        [HttpGet]
        [ProducesResponseType(typeof(Part), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<Part>>> GetPartByCategory(string category)
        {
            var parts = await _repository.GetPartByCategory(category);
            return Ok(parts);
        }

        [HttpPost]
        [ProducesResponseType(typeof(Part), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<Part>> CreatePart([FromBody] Part part)
        {
            await _repository.CreatePart(part);
            return CreatedAtRoute("GetPart", new { id = part.Id }, part);
        }

        [HttpPut]
        [ProducesResponseType(typeof(Part), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> UpdatePart([FromBody] Part part)
        {
            return Ok(await _repository.UpdatePart(part));
        }

        [HttpDelete("{id:length(24)}", Name = "DeleteProduct")]
        [ProducesResponseType(typeof(Part), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> DeletePartById(string id)
        {
            return Ok(await _repository.DeletePart(id));
        }


    }

}