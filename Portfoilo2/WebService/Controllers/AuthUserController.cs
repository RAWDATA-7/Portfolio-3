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
            PasswordService.CreatePwdHash(createUserDTO.PlainTxtPwd, out pwdHash, out pwdSalt);

            createUserDTO.Password = pwdHash;
            createUserDTO.Salt = pwdSalt;

            _dataService.CreateUser(createUserDTO.Name,
                createUserDTO.FirstName,
                createUserDTO.LastName,
                createUserDTO.Email,
                createUserDTO.Sex,
                createUserDTO.Password,
                createUserDTO.Salt);

            return CreatedAtRoute(null, new { createUserDTO.Name});
        }

        [HttpPost("UserLogin")]
        public IActionResult UserLogin(LoginDTO loginDTO)
        {
            var user = _dataService.GetUserFromUsername(loginDTO.Name);

            if(user == null)
            {
                return BadRequest("Username not found...");
               
            }

            byte[] dbPwdHash = user.Password;
            byte[] dbSalt = user.Salt;
            if(!PasswordService.VerifyPwdHash(loginDTO.Password, dbPwdHash, dbSalt))
            {
                return BadRequest("Wrong Password...");
            }

            //Token stuff her
            return Ok("Logged in...");
        }
        

    }   
}
