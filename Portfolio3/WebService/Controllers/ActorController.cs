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
    [Route("api/Actor")]
    
    public class ActorController : ControllerBase
    {
        private readonly IDataService _dataService;
        private readonly LinkGenerator _linkGenerator;
        private readonly IMapper _mapper;

        public ActorController(IDataService dataservice, LinkGenerator linkGenerator, IMapper mapper)
        {
            _dataService = dataservice;
            _linkGenerator = linkGenerator;
            _mapper = mapper;
        }

        [HttpGet("{id}", Name = nameof(GetActor))]
        public IActionResult GetActor(string id)
        {
            var actor = _dataService.GetActor(id);
            
            if (actor == null)
            {
                return NotFound();
            }

            var model = CreateActorViewModel(actor);

            return Ok(model);
        }


        /*
         * Helper stuff
         */

        public string GetUrl(Actor actor)
        {
            return _linkGenerator.GetUriByName(HttpContext, nameof(GetActor), new { actor.Id });
        }

        private string GetUrlCo(string actor)
        {
            return _linkGenerator.GetUriByName(HttpContext, nameof(GetActor), new { actor });
        }

        private ActorViewModel CreateActorViewModel(Actor actor)
        {
            var model = _mapper.Map<ActorViewModel>(actor);
            model.Url = GetUrl(actor);
            model.Professions = actor.Professions.Select(x => x.Name).ToList();
            model.Principals = actor.Principals.Select(x=>x.ToString()).ToList();
            model.PopularTitles = actor.PopularTitles.Select(x=> x.Id).ToList();
            model.CoActors = actor.CoActors.Select(x => x.Id).ToList();
            int count = model.CoActors.Count();
            int count1 = model.PopularTitles.Count();
            foreach (var c in actor.CoActors)
            {
                c.Id = "https://localhost:5001/api/Actor/"+c.Id;
                model.CoActors.Add(c.Id);
            }
            model.CoActors.RemoveRange(0, count);
            foreach (var t in actor.PopularTitles)
            {
                t.Id = "https://localhost:5001/api/Title/" + t.Id;
                model.PopularTitles.Add(t.Id);
            }
            model.PopularTitles.RemoveRange(0, count1);
            return model;
        }

    }
}