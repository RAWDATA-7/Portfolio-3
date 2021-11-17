using Microsoft.AspNetCore.Mvc;
using DataServiceLib;
using WebService.DTOs;

namespace WebService.Controllers
{
    [ApiController]
    [Route("api/AuthUser")]


    public class AuthUserController : ControllerBase
    {
        private readonly IDataService _dataService;
        private readonly IPasswordService _passwordService;
        private readonly IAuthService _authService;

        public AuthUserController(IDataService dataService, IPasswordService passwordService, IAuthService authService)
        {
            _dataService = dataService;
            _passwordService = passwordService;
            _authService = authService;
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
            //createUserDTO.password -> at first plainTxtPassword then becomes overwritten with (pwd+salt)+hash value...
            _passwordService.CreatePwdHash(createUserDTO.PlainTxtPwd, out pwdHash, out pwdSalt);

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
            if(!_passwordService.VerifyPwdHash(loginDTO.Password, dbPwdHash, dbSalt))
            {
                return BadRequest("Wrong Password...");
            }

            //Token stuff her
            string token = _authService.CreateToken(user);
            
            return Ok(new { loginDTO.Name, token});
        }
        

    }   
}
