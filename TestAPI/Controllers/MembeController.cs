using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TestAPI.Interface;
using TestAPI.Model;
using TestAPI.Repository;

namespace TestAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MembeController : ControllerBase
    {
        private readonly IMembers _members;

        public MembeController(IMembers members)
        {
            _members = members;
        }


        [HttpGet("GetAllMembers")]
        public IActionResult GetAllMembers()
        {
            return Ok(_members.GetAllMember());
        }
        [HttpGet]
        public IActionResult GetHello()
        {
            return Ok("Hello");
        }
        [HttpGet("GetMemberById/{id}")]
        public IActionResult GetMemberById(int id)
        {
            var member = _members.GetMember(id);

            if (member == null)
                return NotFound();

            return Ok(member);
        }
        [HttpPost("SaveDetails")]
        public IActionResult SaveDetails([FromBody] Members obj)
        {
            if (obj == null)
                return BadRequest("Invalid data");

            try
            {
                int result = _members.SaveDetails(obj);

                if (result > 0)
                    return Ok(new { message = "Member saved successfully" });

                return StatusCode(500, "Failed to save member");
            }
            catch (Exception ex)
            {
                // TODO: log ex using ILogger
                return StatusCode(500, ex.Message);
            }
        }
        [HttpPost("SaveEnqueryDetails")]
        public IActionResult SaveEnqueryDetails([FromBody] Enquery obj)
        {
            if (obj == null)
                return BadRequest("Invalid data");

            try
            {
                int result = _members.SaveEnqueryDetails(obj);

                if (result > 0)
                    return Ok(new { message = "Enquery saved successfully" });

                return StatusCode(500, "Failed to save member");
            }
            catch (Exception ex)
            {
                // TODO: log ex using ILogger
                return StatusCode(500, ex.Message);
            }
        }

    }
}
