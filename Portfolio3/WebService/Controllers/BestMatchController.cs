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
    [Route("api/BestMatch")]
    public class BestMatchController : ControllerBase
    {
        private readonly IDataService _dataService;
        private readonly LinkGenerator _linkGenerator;
        private readonly IMapper _mapper;

        public BestMatchController(IDataService dataservice, LinkGenerator linkGenerator, IMapper mapper)
        {
            _dataService = dataservice;
            _linkGenerator = linkGenerator;
            _mapper = mapper;
        }
        [HttpGet(Name = nameof(GetBestMatch))]
        public IActionResult GetBestMatch([FromQuery] UrlParam urlParam, [FromQuery]SearchParam searchParam)
        {
            var titles = _dataService.GetBestMatches(searchParam.uId, searchParam.searchString, searchParam.field, urlParam);
            var model = titles.Select(CreateBestMatchListViewModel);
            var result = BestMatchResultModel(urlParam, _dataService.NumberOfTitles(), model);
            return Ok(result);
        }
        private object BestMatchResultModel(UrlParam urlParam, int total, IEnumerable<BestMatchListViewModel> model)
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
            return _linkGenerator.GetUriByName(HttpContext, nameof(GetBestMatch), new { page, pageSize, orderBy });
        }

        private BestMatchListViewModel CreateBestMatchListViewModel(BestMatch bestMatch)
        {
            var model = _mapper.Map<BestMatchListViewModel>(bestMatch);
            model.Url = "https://localhost:5001/api/Title/" + bestMatch.TitleId;
            return model;
        }
    }
}
