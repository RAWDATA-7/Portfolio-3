using Microsoft.AspNetCore.Mvc;
using System.Linq;
using AutoMapper;
using DataServiceLib;
using Microsoft.AspNetCore.Routing;
using WebService.ViewModels;
using System.Collections.Generic;
using System;
using DataServiceLib.FuncDomain;

namespace WebService.Controllers
{
    [ApiController]
    [Route("api/BestRatedTitles")]
    public class BestRatedTitleController : ControllerBase
    {
        private readonly IDataService _dataService;
        private readonly LinkGenerator _linkGenerator;
        private readonly IMapper _mapper;

        public BestRatedTitleController(IDataService dataservice, LinkGenerator linkGenerator, IMapper mapper)
        {
            _dataService = dataservice;
            _linkGenerator = linkGenerator;
            _mapper = mapper;
        }
        [HttpGet(Name = nameof(GetBestRatedTitle))]
        public IActionResult GetBestRatedTitle([FromQuery] UrlParam urlParam)
        {
            var titles = _dataService.GetBestRatedTitles(urlParam);
            var model = titles.Select(CreateBestRatedTitleListViewModel);
            var result = BestRatedTitleResultModel(urlParam, _dataService.NumberOfTitles(), model);
            return Ok(result);
        }
        private object BestRatedTitleResultModel(UrlParam urlParam, int total, IEnumerable<BestRatedTitleListViewModel> model)
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
            return urlParam.Page <= 0 ? null : GetTitlesUrl(urlParam.Page - 1, urlParam.PageSize, urlParam.OrderBy);
        }

        private string CreateCurrentPage(UrlParam urlParam)
        {
            return GetTitlesUrl(urlParam.Page, urlParam.PageSize, urlParam.OrderBy);
        }

        private string CreateNextPage(UrlParam urlParam, int total)
        {
            var lastPage = GetLastPage(urlParam.PageSize, total);
            return urlParam.Page >= lastPage ? null : GetTitlesUrl(urlParam.Page + 1, urlParam.PageSize, urlParam.OrderBy);
        }

        private int GetLastPage(int pageSize, int total)
        {
            return (int)Math.Ceiling(total / (double)pageSize) - 1;
        }

        private string GetTitlesUrl(int page, int pageSize, string orderBy)
        {
            return _linkGenerator.GetUriByName(HttpContext, nameof(GetBestRatedTitle), new { page, pageSize, orderBy });
        }
        private string GetTitleUrl(BestRatedTitle bestRatedTitle)
        {
            return _linkGenerator.GetUriByName(HttpContext, nameof(TitleController.GetTitle), new { bestRatedTitle.Id });
        }
        private BestRatedTitleListViewModel CreateBestRatedTitleListViewModel(BestRatedTitle bestRatedTitle)
        {
            var model = _mapper.Map<BestRatedTitleListViewModel>(bestRatedTitle);
            model.Url = GetTitleUrl(bestRatedTitle);
            return model;
        }
    }
}
