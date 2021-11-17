using AutoMapper;
using DataServiceLib;
using DataServiceLib.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using WebService.ViewModels;

namespace WebService.Controllers
{
    [ApiController]
    [Route("api/User")]
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

        [HttpGet("{id}", Name = nameof(GetUser))]
        public IActionResult GetUser(int id)
        {
            var user = _dataService.GetUserFromId(id);

            if(user == null)
            {
                return NotFound();
            }

            var model = CreateUserViewModel(user);

            return Ok(model);
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
