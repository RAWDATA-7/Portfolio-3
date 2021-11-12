using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using AutoMapper;
using DataServiceLib;
using Microsoft.AspNetCore.Routing;
using WebService.ViewModels;
using DataServiceLib.Domain;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System;

namespace WebService.Controllers
{
    [ApiController]
    [Route("api/Aka")]
    public class AkaController : ControllerBase
    {
        private readonly IDataService _dataService;
        private readonly LinkGenerator _linkGenerator;
        private readonly IMapper _mapper;

        public AkaController(IDataService dataservice, LinkGenerator linkGenerator, IMapper mapper)
        {
            _dataService = dataservice;
            _linkGenerator = linkGenerator;
            _mapper = mapper;
        }

        [HttpGet("{id}", Name = nameof(GetAkas))]
        public IActionResult GetAkas()
        {
            var aka = _dataService.GetAkas("tt0903747");
            var model = aka.Select(CreateAkaViewModel);
            var result = AkaResultModel(aka, model);
            return Ok(result);
        }

        private object AkaResultModel(IList<Aka> aka, IEnumerable<AkaViewModel> model)
        {
            return new
            {
           
                TitleUrl = GetTitleUrl(aka.FirstOrDefault(x=>x.TitleId == x.TitleId)),
                items = model
            };
        }

        private string GetTitleUrl(Aka aka)
        {
            return _linkGenerator.GetUriByName(HttpContext, nameof(TitleController.GetTitle), new { aka.TitleId});
        }

        private AkaViewModel CreateAkaViewModel(Aka aka)
        {
            var model = _mapper.Map<AkaViewModel>(aka);
            return model;
        }

    }
}
