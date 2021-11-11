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

        
        private string GetUrl(Actor actor)
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
            foreach(var c in actor.CoActors)
            {
                c.Id = "https://localhost:5001/api/Actor/"+c.Id;
                model.CoActors.Add(c.Id);
            }
            model.CoActors.RemoveRange(0, count);
            return model;
        }

    }
}