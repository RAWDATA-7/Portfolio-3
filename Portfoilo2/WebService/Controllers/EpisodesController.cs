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
    [Route("api/Episodes")]
    public class EpisodesController : ControllerBase
    {
        private readonly IDataService _dataService;
        private readonly LinkGenerator _linkGenerator;
        private readonly IMapper _mapper;

        public EpisodesController(IDataService dataservice, LinkGenerator linkGenerator, IMapper mapper)
        {
            _dataService = dataservice;
            _linkGenerator = linkGenerator;
            _mapper = mapper;
        }

        [HttpGet("{id}", Name = nameof(GetEpisodes))]
        public IActionResult GetEpisodes(string id, [FromQuery] UrlParam urlParam)
        {
            var episode = _dataService.GetEpisodes(urlParam, id).Where(x => x.TitleId == id).ToList();
            var total = _dataService.NumberOfEpisodes(id);
            var model = episode.Select(CreateEpisodesListViewModel);
            var result = EpisodesListResultModel(urlParam, total, model, id);
            return Ok(result);
        }

        private object EpisodesListResultModel(UrlParam urlParam, int total, IEnumerable<EpisodeListViewModel> model, string id)
        {
            return new
            {
                total,
                prev = CreatePrevPage(urlParam, id),
                current = CreateCurrentPage(urlParam, id),
                next = CreateNextPage(urlParam, total, id),
                items = model
            };
        }

        private string CreatePrevPage(UrlParam urlParam, string id)
        {
            return urlParam.Page <= 0 ? null : GetEpisodesUrl(urlParam.Page - 1, urlParam.PageSize, urlParam.OrderBy, id);
        }

        private string CreateCurrentPage(UrlParam urlParam, string id)
        {
            return GetEpisodesUrl(urlParam.Page, urlParam.PageSize, urlParam.OrderBy, id);
        }

        private string CreateNextPage(UrlParam urlParam, int total, string id)
        {
            var lastPage = GetLastPage(urlParam.PageSize, total);
            return urlParam.Page >= lastPage ? null : GetEpisodesUrl(urlParam.Page + 1, urlParam.PageSize, urlParam.OrderBy, id);
        }

        private int GetLastPage(int pageSize, int total)
        {
            return (int)Math.Ceiling(total / (double)pageSize) - 1;
        }

        private string GetEpisodesUrl(int page, int pageSize, string orderBy, string id)
        {
             
            var result = _linkGenerator.GetUriByName(HttpContext, nameof(GetEpisodes), new { page, pageSize, orderBy, Id = id });
            return result;
        }

        public string GetUrl(Episode episode)
        {
            return _linkGenerator.GetUriByName(HttpContext, nameof(EpisodeController.GetEpisode), new { episode.Id });
        }

        private EpisodeListViewModel CreateEpisodesListViewModel(Episode episode)
        {
            var model = _mapper.Map<EpisodeListViewModel>(episode);
            model.Url = GetUrl(episode);
            return model;
        }
    }
}
