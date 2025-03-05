using BusinessLayer.Interface;
using BusinessLayer.Service;
using Microsoft.AspNetCore.Mvc;
using ModelLayer.Model;
using NLog;
using RepositoryLayer.Entity;
using RepositoryLayer.Service;

namespace HelloGreetingApplication.Controllers
{
    /// <summary>
    ///  Class providing API for HelloGreeting
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class HelloGreetingController : ControllerBase
    {
        private static readonly Logger _logger = LogManager.GetCurrentClassLogger();
        private readonly IGreetingBL _greetingBL;
        private readonly UsernameRequestModel _usernameRequestModel;

        public HelloGreetingController(IGreetingBL greetingBL) // Use the interface
        {
            _greetingBL = greetingBL;
        }

        /// <summary>
        /// Get greeting message
        /// </summary>
        [HttpGet("greet")]
        public string get()
        {
            _logger.Info("GET /greet method executed");
            return _greetingBL.getGreetMessage();
        }

        /// <summary>
        /// Creates a personalized greeting based on provided user attributes
        /// </summary>
        /// <param name="request"> The RequestModel containing optional first Name and Last Name</param>
        /// <returns> A ResponseModel with a personalized greeting and creation timsestam</returns>
        [HttpPost("UC3/PostUserName")]
        public IActionResult PostUserName(UsernameRequestModel request)
        {
            _logger.Info("POST /GetUserName method executed");
            var result= _greetingBL.GetGreetingMessage(request);
            var response = new ResponseModel<object>
            {
                Success = true,
                Message = "Greeting created",
                Data = result
            };
            return Ok(response);
        }

        /// <summary>
        /// Handles the creation of a new greeting message.
        /// </summary>
        /// <param name="requestModel">The request containing the greeting message.</param>
        /// <returns>Returns a success response if the greeting is saved, or an error response if the input is invalid.</returns>
        [HttpPost("UC4")]
        public IActionResult SendGreeting(PostGreetingRequest postgreetingrequest)
        {
            _logger.Info("SendGreeting method started."); // Method start log

            ResponseModel<string> responseModel = new ResponseModel<string>();

            try
            {
                if (postgreetingrequest == null || string.IsNullOrWhiteSpace(postgreetingrequest.Message))
                {
                    _logger.Warn("Invalid input received: Message is empty or null.");
                    return BadRequest(new { Success = false, Message = "Invalid input. Message cannot be empty." });
                }

                var greeting = new Greeting { Message = postgreetingrequest.Message };
                var savedGreeting = _greetingBL.AddGreeting(greeting);

                responseModel.Success = true;
                responseModel.Message = "Greeting saved successfully.";
                responseModel.Data = savedGreeting.Message;

                _logger.Info("Greeting saved successfully: " + savedGreeting.Message);
                _logger.Info("SendGreeting method executed successfully.");

                return Ok(responseModel);
            }
            catch (Exception ex)
            {
                _logger.Error("Error occurred in SendGreeting method: " + ex.Message, ex);
                return StatusCode(500, new { Success = false, Message = "An unexpected error occurred." });
            }
        }


        //UC5
        /// <summary>
        /// Retrieves a greeting message by its unique identifier.
        /// </summary>
        /// <param name = "id" > The unique identifier of the greeting message.</param>
        /// <returns>
        /// Returns an HTTP 200 response with the greeting message if found.
        /// Returns an HTTP 404 response if no greeting message is found.
        /// </returns>
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            _logger.Info($"GetGreetingById called with id: {id}");

            ResponseModel<Greeting?> responseModel = new ResponseModel<Greeting?>();

            var greeting = _greetingBL.GetGreetingById(id);

            if (greeting == null)
            {
                responseModel.Success = false;
                responseModel.Message = "Greeting not found";
                responseModel.Data = null;
                _logger.Warn($"Greeting not found for id: {id}");
                return NotFound(responseModel);
            }

            responseModel.Success = true;
            responseModel.Message = "Greeting found successfully.";
            responseModel.Data = greeting;
            _logger.Info($"Greeting found: {greeting.Message}");

            return Ok(responseModel);
        }

        //UC6

        /// <summary>
        /// Retrieves a list of all greeting messages.
        /// </summary>
        /// <returns>A list of all stored greetings.</returns>
        [HttpGet("All")]
        public IActionResult GetAllGreetings()
        {
            _logger.Info("GetAllGreetings method called.");

            var greetings = _greetingBL.GetAllGreetings();

            if (greetings == null || greetings.Count == 0)
            {
                _logger.Warn("No greetings found in the database.");
                return NotFound(new { Success = false, Message = "No greetings found." });
            }

            _logger.Info("All greetings retrieved successfully.");
            return Ok(new { Success = true, Data = greetings });
        }


        /// <summary>
        /// Get a welcome message
        /// </summary>
        [HttpGet]
        [Route("GreetGet")]
        public IActionResult Get()
        {
            _logger.Info("GET /GreetGet method executed");
            ResponseModel<string> responseModel = new ResponseModel<string>();

            responseModel.Success = true;
            responseModel.Message = "Hello to Greeting App API Endpoint";
            responseModel.Data = "Hello, World";
            return Ok(responseModel);
        }

        /// <summary>
        /// Post a greeting message
        /// </summary>
        [HttpPost]
        [Route("GreetPost")]
        public IActionResult Post(RequestModel requestModel)
        {
            _logger.Info("POST /GreetPost method executed");
            ResponseModel<string> responseModel = new ResponseModel<string>();

            responseModel.Success = true;
            responseModel.Message = "Request received successfully";
            responseModel.Data = $"Key: {requestModel.Key}, Value: {requestModel.Value}";
            return Ok(responseModel);
        }

        /// <summary>
        /// Update greeting message
        /// </summary>
        [HttpPut]
        [Route("GreetPut")]
        public IActionResult Put(RequestModel requestModel)
        {
            _logger.Info("PUT /GreetPut method executed");
            ResponseModel<String> responseModel = new ResponseModel<string>();

            responseModel.Success = true;
            responseModel.Message = "Data put Successfully";
            responseModel.Data = $"Key: {requestModel.Key} , Value : {requestModel.Value} ";
            return Ok(responseModel);
        }

        /// <summary>
        /// Partially update greeting message
        /// </summary>
        [HttpPatch]
        [Route("GreetPatch")]
        public IActionResult Patch(RequestModel requestModel)
        {
            _logger.Info("PATCH /GreetPatch method executed");
            ResponseModel<String> responseModel = new ResponseModel<string>();

            responseModel.Success = true;
            responseModel.Message = "Data patch successfully";
            responseModel.Data = $"Key: {requestModel.Key} , Value : {requestModel.Value} ";
            return Ok(responseModel);
        }

        /// <summary>
        /// Delete greeting message
        /// </summary>
        [HttpDelete]
        [Route("GreetDelete")]
        public IActionResult Delete(RequestModel requestModel)
        {
            _logger.Info("DELETE /GreetDelete method executed");
            ResponseModel<String> responseModel = new ResponseModel<string>();

            responseModel.Success = true;
            responseModel.Message = "Data deleted Successfully";
            responseModel.Data = $"Deleted key: {requestModel.Key}";
            return Ok(responseModel);
        }
    }
}
