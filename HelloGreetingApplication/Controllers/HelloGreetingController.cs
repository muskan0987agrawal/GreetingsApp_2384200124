using BusinessLayer.Interface;
using Microsoft.AspNetCore.Mvc;
using ModelLayer.Model;
using NLog;
using RepositoryLayer.Entity;

namespace HelloGreetingApplication.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HelloGreetingController : ControllerBase
    {
        private static readonly Logger _logger = LogManager.GetCurrentClassLogger();
        private readonly IGreetingBL _greetingBL;

        public HelloGreetingController(IGreetingBL greetingBL)
        {
            _greetingBL = greetingBL;
        }

        [HttpGet("greet")]
        public string get()
        {
            _logger.Info("GET /greet method executed");
            return _greetingBL.getGreetMessage();
        }

        [HttpPost("UC3/PostUserName")]
        public IActionResult PostUserName(UsernameRequestModel request)
        {
            _logger.Info("POST /GetUserName method executed");
            var result = _greetingBL.GetGreetingMessage(request);
            return Ok(new { Success = true, Message = "Greeting created", Data = result });
        }

        [HttpPost("save")]
        public IActionResult SendGreeting(RequestGreetingModel postgreetingrequest)
        {
            _logger.Info("SendGreeting method started.");
            if (postgreetingrequest == null || string.IsNullOrWhiteSpace(postgreetingrequest.Message))
            {
                return BadRequest(new { Success = false, Message = "Invalid input. Message cannot be empty." });
            }

            var greeting = new GreetingEntity { Message = postgreetingrequest.Message };
            var savedGreeting = _greetingBL.AddGreeting(greeting);
            return Ok(new { Success = true, Message = "Greeting saved successfully.", Data = savedGreeting.Message });
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            _logger.Info($"GetGreetingById called with id: {id}");
            var greeting = _greetingBL.GetGreetingById(id);

            if (greeting == null)
                return NotFound(new { Success = false, Message = "Greeting not found" });

            return Ok(new { Success = true, Message = "Greeting found successfully.", Data = greeting });
        }

        [HttpPatch("{id}")]
        public IActionResult PatchGreeting(int id, RequestGreetingModel updatedGreeting)
        {
            _logger.Info($"UpdateGreeting method called with id: {id}");
            var greeting = _greetingBL.UpdateGreeting(id, updatedGreeting.Message);
            if (greeting == null)
                return NotFound(new { Success = false, Message = "Greeting not found." });

            return Ok(new { Success = true, Data = greeting.Message });
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteById(int id)
        {
            _logger.Info($"DELETE request received: Delete Greeting ID={id}");
            var isDeleted = _greetingBL.DeleteGreeting(id);

            if (!isDeleted)
                return NotFound(new { Success = false, Message = "Greeting not found!" });

            return Ok(new { Success = true, Message = "Greeting deleted successfully!" });
        }
    }
}
