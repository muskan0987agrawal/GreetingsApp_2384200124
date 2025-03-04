using BusinessLayer.Interface;
using BusinessLayer.Service;
using Microsoft.AspNetCore.Mvc;
using ModelLayer.Model;
using NLog;
using RepositoryLayer.Entity;

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
        public IActionResult SendGreeting(RequestModel requestModel)
        {
            ResponseModel<String> responseModel = new ResponseModel<string>();

            if (requestModel == null || string.IsNullOrWhiteSpace(requestModel.Value))
            {
                return BadRequest(new { Success = false, Message = "Invalid input. Message cannot be empty." });
            }

            var greeting = new Greeting { Message = requestModel.Value };
            var savedGreeting = _greetingBL.AddGreeting(greeting);


            responseModel.Success = true;
            responseModel.Message = "Greeting saved successfully.";
            responseModel.Data = savedGreeting.Message;
            _logger.Info("SendGreeting Method Executed Successfully");
            return Ok(responseModel);
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
