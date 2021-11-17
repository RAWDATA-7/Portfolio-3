using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using AutoMapper;
using DataServiceLib;
using Microsoft.AspNetCore.Routing;
using WebService.ViewModels;
using DataServiceLib.Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authorization;
using System.Collections.Generic;
using System;

namespace WebService.Controllers
{
    [ApiController]
    [Route("api/Title")]
    public class TitleController : ControllerBase
    {
        private readonly IDataService _dataService;
        private readonly LinkGenerator _linkGenerator;
        private readonly IMapper _mapper;

        public TitleController(IDataService dataservice, LinkGenerator linkGenerator, IMapper mapper)
        {
            _dataService = dataservice;
            _linkGenerator = linkGenerator;
            _mapper = mapper;
        }

        [HttpGet("{id}", Name = nameof(GetTitle))]
        [Authorize]//Authorization?? ingen ved det... Alle snakker om det, tror jeg - not sure tho
        public IActionResult GetTitle(string id)
        {
            try
            {
                //Pull user from HTTP header (måske dette kan bruges til bookmarking User.List<bookmark>.addbookmark(titleId) or sumtin)
                var user = Request.HttpContext.Items["User"] as User;
                Console.WriteLine($"Current user: {user.Name}");

                var title = _dataService.GetTitle(id);
                if (title == null)
                {
                    return NotFound("Title not found...");
                }
                var model = CreateTitleViewModel(title);
                return Ok(model);

            }
            catch (Exception)
            {
                return Unauthorized("User not authorized...");
            }
        }

        public string GetUrl(Title title)
        {
            return _linkGenerator.GetUriByName(HttpContext, nameof(GetTitle), new { title.Id });
        }

        private TitleViewModel CreateTitleViewModel(Title title)
        {
            var model = _mapper.Map<TitleViewModel>(title);
            model.Url = GetUrl(title);
            model.Genres = _dataService.GetGenres(title.Id).Select(x => x.Name).ToList();
            model.Rating = _dataService.GetRating(title.Id).AvgRating;
            model.NumVotes = _dataService.GetRating(title.Id).NumVotes;
            model.AkaUrl = _linkGenerator.GetUriByName(HttpContext, nameof(AkaController.GetAkas), new { title.Id });
            if (model.Type == "tvSeries")
            {
                model.EpisodesUrl = _linkGenerator.GetUriByName(HttpContext, nameof(EpisodesController.GetEpisodes), new { title.Id });
            }
            return model;
        }

    }
}
