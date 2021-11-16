using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataServiceLib;
using Microsoft.AspNetCore.Mvc;

namespace WebService.Controllers
{
    [ApiController]
    [Route("api/User")]
    public class UserController : ControllerBase
    {
        private readonly IDataService _dataService;

        public UserController(IDataService dataService)
        {
            _dataService = dataService;
        }

        [HttpGet("{id}", Name = nameof(GetUser))]
        public IActionResult GetUser(int id)
        {
            var user = _dataService.GetUser(id);

            if(user == null)
            {
                return NotFound();
            }
            return Ok();
        }
    }
}
