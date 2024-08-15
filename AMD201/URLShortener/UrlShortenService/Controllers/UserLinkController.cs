using Microsoft.AspNetCore.Mvc;
using UserLinkService.Models;
using UserLinkService.Repositories.Interfaces;

namespace UserLinkService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserLinkController : ControllerBase
    {
        private readonly IUserLinkRepository _userLinkRepository;

        public UserLinkController(IUserLinkRepository userLinkRepository)
        {
            _userLinkRepository = userLinkRepository;
        }

        [HttpGet("all")]
        public IActionResult Get()
        {
            return Ok(_userLinkRepository.GetAll());
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var userLink = _userLinkRepository.GetUserLink(id);
            if (userLink == null)
            {
                return NotFound();
            }
            return Ok(userLink);
        }

        [HttpGet("shortened/{newuserlink}")]
        public IActionResult GetByShortenedLink(string newuserlink)
        {
            var userLink = _userLinkRepository.GetUserLinkFromNewLink(newuserlink);
            if (userLink == null)
            {
                return NotFound();
            }
            return Ok(userLink);
        }

        [HttpPost("create")]
        public IActionResult Create([FromBody] UserLink userLink)
        {
            var baseUrl = $"{Request.Scheme}://{Request.Host}/api/userlink";
            if (_userLinkRepository.Create(userLink, baseUrl))
            {
                return Ok(userLink);
            }
            return BadRequest();
        }


        [HttpPost("generatelink")]
        public IActionResult GenerateNewLink([FromBody] UserLink userLink)
        {
            var baseUrl = $"{Request.Scheme}://{Request.Host}/api";
            if (_userLinkRepository.GenerateNewLink(userLink, baseUrl))
            {
                return Ok(userLink);
            }
            return BadRequest();
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] UserLink userLink)
        {
            if (_userLinkRepository.Update(id, userLink))
            {
                return Ok("Updated Successfully");
            }
            return BadRequest();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (_userLinkRepository.Delete(id))
            {
                return Ok("Deleted Successfully");
            }
            return BadRequest();
        }
    }
}
