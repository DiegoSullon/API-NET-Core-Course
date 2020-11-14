using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApiRoutesResponses.Context;
using WebApiRoutesResponses.Models;
using WebApiRoutesResponses.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApplication1.Controllers
{
    [Authorize]
    [EnableCors("MyPolicy")]
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        ApiAppContext apiContext;
        public UserController(ApiAppContext context)
        {
            apiContext = context;
            apiContext.Database.EnsureCreated();
        }


        // GET: api/<controller>
        [HttpGet]
        [ResponseCache(Duration=60)]
        public ActionResult<IEnumerable<User>> Get()
        {
            return apiContext.users.Include(p=>p.userRole).ToList();
        }
        [HttpGet]
        [Route("GetRoles")]
        public ActionResult<IEnumerable<UserRole>> GetRoles()
        {
            return apiContext.userRoles.Include(p => p.user).ToList();
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]//requiered parameter
        public ActionResult<string> Get(string id)
        {

            Guid.TryParse(id, out var userId);
            if (userId != Guid.Empty)
            {
                var userFound = apiContext.users.FirstOrDefault(p => p.userId == userId);

                if (userFound != null)
                {
                    return Ok(userFound);
                }
                else
                {
                    return NotFound();
                }
            }
            else
            {
                return BadRequest();
            }
        }

        // POST api/<controller>
        [HttpPost]
        public async Task Post([FromBody] User value)
        {
            apiContext.users.Add(value);
            await apiContext.SaveChangesAsync();

        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public async Task Put(string id, [FromBody] User value)
        {
            Guid.TryParse(id, out var userId);
            if (userId != Guid.Empty)
            {
                var userFound = apiContext.users.FirstOrDefault(p=>p.userId==userId);
                if (userFound != null)
                {
                    userFound.name = value.name;
                    userFound.lastName=value.lastName;
                    userFound.active = value.active;
                    await apiContext.SaveChangesAsync();

                }
            }
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public async Task Delete(string id)
        {
            Guid.TryParse(id, out var userId);
            if (userId != Guid.Empty)
            {
                var userFound = apiContext.users.FirstOrDefault(p=>p.userId==userId);
                apiContext.users.Remove(userFound);
                await apiContext.SaveChangesAsync();
            }
        }
    }
}
