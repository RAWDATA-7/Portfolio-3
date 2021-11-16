using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DataServiceLib;
using WebService.DTOs;
using System.Text;

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
        public IActionResult CreateUser(CreateUserDTO createUserDTO)
        {

            CreateUserDTO userDto = new CreateUserDTO();

            if(_dataService.GetUserFromUsername(createUserDTO.Name) != null)
            {
                return BadRequest("Username taken...");
            }


            byte[] pwdHash;
            byte[] pwdSalt;
            //createUserDTO.password -> at first plainTxtPassword then later overwritten with a hashed+salted value...
            PasswordService.CreatePwdHash(createUserDTO.Password, out pwdHash, out pwdSalt);

            createUserDTO.Password = Encoding.UTF8.GetString(pwdHash);
            createUserDTO.Salt = Encoding.UTF8.GetString(pwdSalt);


            //tilføj til DB
            //savechanges();
            _dataService.CreateUser(createUserDTO.Name,
                createUserDTO.FirstName,
                createUserDTO.LastName,
                createUserDTO.Email,
                createUserDTO.Sex,
                createUserDTO.Password,
                createUserDTO.Salt);

            return CreatedAtRoute(null, new { createUserDTO.Name});
        }

        //public IActionResult UserLogin(UserLoginDTO userLoginDTO)
        //{
        //    return Ok();
        //}
    }   
}
