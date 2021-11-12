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
    [Route("api/Episode")]
    public class EpisodeController : ControllerBase
    {
        private readonly IDataService _dataService;
        private readonly LinkGenerator _linkGenerator;
        private readonly IMapper _mapper;

        public EpisodeController(IDataService dataservice, LinkGenerator linkGenerator, IMapper mapper)
        {
            _dataService = dataservice;
            _linkGenerator = linkGenerator;
            _mapper = mapper;
        }
        [HttpGet("{id}", Name = nameof(GetEpisode))]
        public IActionResult GetEpisode(string id)
        {
            var episode = _dataService.GetEpisode(id);

            if (episode == null)
            {
                return NotFound();
            }

            var model = CreateEpisodeViewModel(episode);

            return Ok(model);
        }

        public string GetUrl(Episode episode)
        {
            return _linkGenerator.GetUriByName(HttpContext, nameof(GetEpisode), new { episode.TitleId });
        }


        private EpisodeViewModel CreateEpisodeViewModel(Episode episode)
        {
            var model = _mapper.Map<EpisodeViewModel>(episode);
            return model;
        }
    }
}