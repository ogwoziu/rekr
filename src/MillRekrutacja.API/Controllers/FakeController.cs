using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MillRekrutacja.Core.Exceptions;
using MillRekrutacja.Core.Models;
using MillRekrutacja.Core.Services;
using System;
using System.Threading.Tasks;

namespace MillRekrutacja.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FakeController : ControllerBase
    {
        private readonly ILogger<FakeModel> _logger;
        private readonly IFakeService _fakeService;

        public FakeController(ILogger<FakeModel> logger, IFakeService fakeService)
        {
            _logger = logger;
            _fakeService = fakeService;
        }

        [HttpGet]
        [Route("/GetById/{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            FakeModel result;
            try
            {
                result = await _fakeService.GetFakeModelById(id);
            }
            catch (ArgumentNullException)
            {
                return BadRequest("Provide fake id");
            }
            catch (FakeModelNotFoundException ex)
            {
                _logger.LogError(ex.Message);
                return NotFound(ex.Message);
            }
            return Ok(result);

        }

        [HttpPost]
        [Route("/Create/")]
        public async Task<IActionResult> Create([FromBody] FakeModel model)
        {
            try
            {
                await _fakeService.AddFakeModel(model);
            }
            catch (FakeModelExistsException ex)
            {
                _logger.LogError(ex.Message);
                return BadRequest(ex.Message);
            }

            return Ok();
        }

        [HttpDelete]
        public ActionResult Delete(int id)
        {
            return StatusCode(200);
        }
    }
}
