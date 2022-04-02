using Domain;
using IBusinessLogic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace DAO2Obligatorio.WebApi.Controllers
{
    [ApiController]
    [Route("users")]
    public class UserController : Controller
    {
        private readonly IUserService usersService;

        public UserController(IUserService usersService)
        {
            this.usersService = usersService;
        }

        // GET /user?userName=Pepe
        [HttpGet]
        public IActionResult GetMovies([FromQuery] User userFilter)
        {
            try
            {
                return Ok(usersService.GetUsers(userFilter));
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Algo salió mal." + ex.Message);
            }
        }

        [HttpPost]
        public IActionResult PostMovie([FromBody] User user)
        {
            try
            {
                return Ok(usersService.InsertUser(user));
            }
            catch (ArgumentException exception)
            {
                return BadRequest(exception.Message);
            }
            catch (Exception exception)
            {
                return StatusCode(500, "Algo salió mal."+ exception.Message);
            }
        }
        
        [HttpPut("{id}")]
        public IActionResult PutMovie([FromRoute] int id, [FromBody] User user)
        {
            try
            {
                user.Id = id;
                return Ok(usersService.UpdateUser(user, user.Password));
            }
            catch (ArgumentException exception)
            {
                return BadRequest(exception.Message);
            }
            catch (NullReferenceException exception)
            {
                return NotFound(exception.Message);
            }
            catch (Exception)
            {
                return StatusCode(500, "Algo salió mal.");
            }

        }

        [HttpDelete("{id}")]
        public IActionResult DeleteMovie([FromRoute] int id)
        {
            try
            {
                usersService.DeleteUser(id);
                return Ok();
            }
            catch (ArgumentException exception)
            {
                return BadRequest(exception.Message);
            }
            catch (NullReferenceException exception)
            {
                return NotFound(exception.Message);
            }
            catch (Exception)
            {
                return StatusCode(500, "Algo salió mal.");
            }
        }
    }
}
