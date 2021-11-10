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
using DataServiceLib.FuncDomain;
using System;

namespace WebService.Controllers
{
    [ApiController]
    [Route("api/BestRatedActor")]
    public class BestRatedActorController : ControllerBase
    {
        private readonly IDataService _dataService;
        private readonly LinkGenerator _linkGenerator;
        private readonly IMapper _mapper;

        public BestRatedActorController(IDataService dataservice, LinkGenerator linkGenerator, IMapper mapper)
        {
            _dataService = dataservice;
            _linkGenerator = linkGenerator;
            _mapper = mapper;
        }

        [HttpGet(Name = nameof(GetBestRatedActor))]
        public IActionResult GetBestRatedActor([FromQuery] UrlParam urlParam)
        {
            var actors = _dataService.GetBestRatedActors(urlParam);
            var model = actors.Select(CreateBestRatedActorListViewModel);
            var result = BestRatedActorResultModel(urlParam, _dataService.NumberOfActors(), model);
            return Ok(result);
        }
        private object BestRatedActorResultModel(UrlParam urlParam, int total, IEnumerable<BestRatedActorListViewModel> model)
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
            return urlParam.Page >= lastPage ? null : GetActorsUrl(urlParam.Page + 1, urlParam.PageSize, urlParam.OrderBy);
        }

        private int GetLastPage(int pageSize, int total)
        {
            return (int)Math.Ceiling(total / (double)pageSize) - 1;
        }

        private string GetActorsUrl(BestRatedActor bestRatedActor)
        {
            return _linkGenerator.GetUriByName(HttpContext, nameof(GetBestRatedActor), new { bestRatedActor.Id });
        }

        private string GetActorsUrl(int page, int pageSize, string orderBy)
        {
            return _linkGenerator.GetUriByName(HttpContext, nameof(GetBestRatedActor), new { page, pageSize, orderBy });
        }

        private BestRatedActorListViewModel CreateBestRatedActorListViewModel(BestRatedActor bestRatedActor)
        {
            var model = _mapper.Map<BestRatedActorListViewModel>(bestRatedActor);
            model.Url = GetActorsUrl(bestRatedActor);
            return model;
        }

    }
}
