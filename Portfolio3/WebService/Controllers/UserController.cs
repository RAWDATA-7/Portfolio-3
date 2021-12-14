using System;
using AutoMapper;
using DataServiceLib;
using DataServiceLib.Attributes;
using DataServiceLib.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using WebService.ViewModels;

namespace WebService.Controllers
{
    [ApiController]
    [Route("api/User")]
    [Authorization]
    public class UserController : ControllerBase
    {
        private readonly IDataService _dataService;
        private readonly LinkGenerator _linkGenerator;
        private readonly IMapper _mapper;

        public UserController(IDataService dataservice, LinkGenerator linkGenerator, IMapper mapper)
        {
            _dataService = dataservice;
            _linkGenerator = linkGenerator;
            _mapper = mapper;
        }

        [HttpGet("{name}", Name = nameof(GetUser))]
        public IActionResult GetUser(string name)
        {
            try
            {
                var authUser = Request.HttpContext.Items["User"] as User;
                Console.WriteLine($"Current user: {authUser}");
                
                var user = _dataService.GetUserFromUsername(name);
                
                if (user == null)
                {
                    return NotFound();
                }
                if (authUser.Id == user.Id)
                {
                    var model = CreateUserViewModel(user);

                    return Ok(model);
                }
                return Unauthorized("User not authorized...");
            }
            catch (Exception)
            {
                return Unauthorized("User not authorized...");
            }
        }

        public string GetUrl(User user)
        {
            return _linkGenerator.GetUriByName(HttpContext, nameof(GetUser), new { user.Id });
        }


        private UserViewModel CreateUserViewModel(User user)
        {
            var model = _mapper.Map<UserViewModel>(user);
            return model;
        }

    }
}
