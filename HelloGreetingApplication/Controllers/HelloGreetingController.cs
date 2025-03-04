using BusinessLayer.Interface;
using BusinessLayer.Service;
using Microsoft.AspNetCore.Mvc;
using ModelLayer.Model;
using NLog;

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
