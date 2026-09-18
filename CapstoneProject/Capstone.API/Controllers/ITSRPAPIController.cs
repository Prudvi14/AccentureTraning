using Capstone.DAL.Models;
using Capstone.DAL.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Capstone.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ITSRPAPIController : ControllerBase
    {
        private readonly IRepository _repository;

        public ITSRPAPIController(IRepository repository)
        {
            _repository = repository;
        }

        [HttpGet("Authenticate")]
        public IActionResult Authenticate(string userName, string password)
        {
            try
            {
                var loginUser = new User { UserName = userName, Password = password };
                var isValid = _repository.Authenticate(loginUser);

                if (!isValid)
                    return NotFound("Invalid username or password.");

                var user = _repository.GetUser(userName);
                return Ok(user);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred during authentication: {ex.Message}");
            }
        }

        [HttpGet("GetAllRequest")]
        public IActionResult GetAllRequest()
        {
            try
            {
                var requests = _repository.ViewRequests();
                if (requests == null || !requests.Any())
                    return NotFound("No service requests found.");

                return Ok(requests);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while retrieving requests: {ex.Message}");
            }
        }

        [HttpGet("GetRequestByuserName")]
        public IActionResult GetRequestByUN(string userName)
        {
            try
            {
                var requests = _repository.GetRequestBySP(userName);
                return Ok(requests);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while retrieving requests: {ex.Message}");
            }
        }

        [HttpPost("reopen")]
        public IActionResult ReOpenRequest(ServiceRequest request)
        {
            try
            {
                if (request == null || string.IsNullOrWhiteSpace(request.Justification))
                    return BadRequest("Justification is required to re-open a request.");

                request.Status = null;

                var success = _repository.ReOpenRequest(request);
                if (!success)
                    return NotFound("Request not found or could not be re-opened.");

                var updatedRequest = _repository.GetRequestById(request.RequestId);
                return Ok(updatedRequest);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while re-opening the request: {ex.Message}");
            }
        }

        [HttpPost("CreateNewSerRequest")]
        public IActionResult Post(ServiceRequest newRequest)
        {
            try
            {
                if (newRequest == null || !ModelState.IsValid)
                    return BadRequest(ModelState);

                newRequest.Status = null;

                var newId = _repository.RaiseRequest(newRequest);
                if (newId <= 0)
                    return BadRequest("Unable to create the service request.");

                return CreatedAtAction(nameof(GetRequestById), new { reqId = newId }, newRequest);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while creating the request: {ex.Message}");
            }
        }

        [HttpGet("GetRequestById")]
        public ServiceRequest? GetRequestById(int reqId)
        {
            return _repository.GetRequestById(reqId);
        }

        [HttpGet("GetUser")]
        public IActionResult GetUser(string userName)
        {
            try
            {
                var user = _repository.GetUser(userName);
                if (user == null)
                    return NotFound("User does not exist.");

                return Ok(user);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while retrieving the user: {ex.Message}");
            }
        }

        [HttpGet("CloseRequest")]
        public IActionResult CloseRequest(int id)
        {
            try
            {
                var success = _repository.CloseRequest(id);
                if (!success)
                    return NotFound("Request not found.");

                return Ok("Request closed successfully.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while closing the request: {ex.Message}");
            }
        }

        [HttpGet("Delete")]
        public IActionResult Delete(int id)
        {
            try
            {
                var success = _repository.DeleteRequest(id);
                if (!success)
                    return NotFound("Request not found or could not be deleted.");

                return Ok("Request deleted successfully.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while deleting the request: {ex.Message}");
            }
        }
    }
}