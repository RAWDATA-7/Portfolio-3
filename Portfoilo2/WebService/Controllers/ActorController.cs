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

        [HttpGet]
        public IActionResult GetActors() 
        {
            var actors = _dataService.GetActors();
            var model = actors.Select(CreateActorViewModel);
            return Ok(model); 
        }
        private ActorViewModel CreateActorViewModel(Actor actor)
        {
            var model = _mapper.Map<ActorViewModel>(actor);
            model.Url = GetUrl(actor);
            return model;
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

        private string GetUrl(Actor actor)
        {
            return _linkGenerator.GetUriByName(HttpContext, nameof(GetActor), new { actor.Id });
        }


        /*
         * Helper stuff
         */


        private object ActorResultModel(UrlParam urlParam, int total, IEnumerable<ActorViewModel> model)
        {
            return new
            {
                total,
                prev = CreatePrevPage(urlParam),
                current = CreateCurrentPage(urlParam),
                next = CreateNextPage(urlParam, total),
                items = model
            };
        }

        private string CreatePrevPage(UrlParam urlParam)
        {
            return urlParam.Page <= 0 ? null : GetActorsUrl(urlParam.Page - 1, urlParam.PageSize, urlParam.OrderBy);
        }

        private string CreateCurrentPage(UrlParam urlParam)
        {
            return GetActorsUrl(urlParam.Page, urlParam.PageSize, urlParam.OrderBy);
        }

        private string CreateNextPage(UrlParam urlParam, int total)
        {
            var lastPage = GetLastPage(urlParam.PageSize, total);
            return urlParam.Page >= lastPage ? null : GetActorsUrl(urlParam.Page+1, urlParam.PageSize, urlParam.OrderBy);
        }

        private int GetLastPage(int pageSize, int total)
        {
            return (int)Math.Ceiling(total / (double)pageSize) - 1;
        }

        private string GetActorsUrl(int page, int pageSize, string orderBy)
        {
            return _linkGenerator.GetUriByName(HttpContext, nameof(GetActors), new { page, pageSize, orderBy });
        }
    }
}