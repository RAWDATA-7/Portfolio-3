using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DataServiceLib;

namespace WebService.Controllers
{
    [ApiController]
    [Route("api/AuthUser")]


    public class AuthUserController : ControllerBase
    {
        private readonly IDataService _dataService;

        public AuthUserController(IDataService dataService)
        {
            _dataService = dataService;
        }


        [HttpPost("CreateUser")]
        public IActionResult(CreateUserDTO createUserDTO)
        {
            //If getuser blabla
        }
    }
}
