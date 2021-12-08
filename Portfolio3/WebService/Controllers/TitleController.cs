using Microsoft.AspNetCore.Mvc;
using System.Linq;
using AutoMapper;
using DataServiceLib;
using Microsoft.AspNetCore.Routing;
using WebService.ViewModels;
using DataServiceLib.Domain;

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
        public IActionResult GetTitle(string id)
        {

                var title = _dataService.GetTitle(id);
                if (title == null)
                {
                    return NotFound("Title not found...");
                }

                var model = CreateTitleViewModel(title);
                return Ok(model);      
        }

        public string GetUrl(Title title)
        {
            return _linkGenerator.GetUriByName(HttpContext, nameof(GetTitle), new { title.Id });
        }

        private TitleViewModel CreateTitleViewModel(Title title)
        {
            var model = _mapper.Map<TitleViewModel>(title);
            model.Url = GetUrl(title); 
            model.Genres = title.Genres.Select(x => x.Name).ToList();
            model.Rating = _dataService.GetRating(title.Id).AvgRating;
            model.NumVotes = _dataService.GetRating(title.Id).NumVotes;
            model.AkaUrl = _linkGenerator.GetUriByName(HttpContext, nameof(AkaController.GetAkas), new { title.Id });
            model.PopularActors = title.PopularActors.Select(x => x.ActorId).ToList();
            int count = model.PopularActors.Count();
            foreach (var c in title.PopularActors)
            {
                c.ActorId = "https://localhost:5001/api/Actor/" + c.ActorId;
                model.PopularActors.Add(c.ActorId);
            }
            model.PopularActors.RemoveRange(0, count);
            if (model.Type == "tvSeries" || model.Type == "tvMiniSeries")
            {
                model.EpisodesUrl = _linkGenerator.GetUriByName(HttpContext, nameof(EpisodesController.GetEpisodes), new { title.Id });
            }
            if (model.Type == "tvEpisode")
            {
                model.ParentUrl = "https://localhost:5001/api/Title/" + _dataService.GetEpisode(title.Id).TitleId.ToString();
            }
            return model;
        }

    }
}
