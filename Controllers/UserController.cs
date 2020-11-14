using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApplication1.Controllers
{
    [Authorize]
    [EnableCors("MyPolicy")]
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        IUserDataService userDataService;
        public UserController(IUserDataService userData)
        {
            userDataService = userData;
        }


        // GET: api/<controller>
        [HttpGet]
        [Route("getValues")]
        // public ActionResult<IEnumerable<string>> Get()
        // {
        //     return Ok(new string[] { "value1", "value2" }); //especifico devolver Ok200
        // }
        public ActionResult<IEnumerable<string>> Get([FromServices]IUserDataService userData)
        {
            return userDataService.GetValues().Union(userData.GetValues()).ToList();
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]//requiered parameter
        public ActionResult<string> Get(int id)
        {
            if (id > 0)
            {

                return "value: " + id;
            }
            else if (id < 0)
            {
                return BadRequest();
            }
            else
            {
                return NotFound();
            }
        }

        // POST api/<controller>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
