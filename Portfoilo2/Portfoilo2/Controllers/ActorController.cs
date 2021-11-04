using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using AutoMapper;
using DataServiceLib;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using WebService.ViewModels;


namespace WebService.Controllers
{
    [ApiController]
    [Route("api/Actor")]
    
    
    public class ActorController
    {
        private readonly IDataService _dataService;
        private readonly LinkGenerator _linkGenerator;
        private readonly IMapper _mapper;

    }
}