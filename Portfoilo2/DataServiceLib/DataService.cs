using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using DataServiceLib.Domain;
using DataServiceLib.FuncDomain;

namespace DataServiceLib
{
    public class DataService : IDataService
    {
        public DataService() { }
        /*
         Actor Related Func
        */
        public Actor GetActor(string aId)
        {
            var ctx = new IMDbContext();
            var actor = ctx.Actors.Include(p => p.Professions).Include(p => p.Principals).FirstOrDefault(x => x.Id == aId);
            actor.PopularTitles = GetPopularTitle(aId);
            actor.CoActors = GetCoActors(aId);
            return actor;
        }

        public List<Actor> GetActors(string aId)
        {
            var ctx = new IMDbContext();
            return ctx.Actors.Where(x => x.Id == aId).ToList();
        }

        public int NumberOfActors()
        {
            var ctx = new IMDbContext();
            return ctx.BestRatedActors.Count();
        }

        public IList<PopularTitle> GetPopularTitle(string aId)
        {
            var ctx = new IMDbContext();
            var result = ctx.PopularTitles.FromSqlInterpolated($"SELECT * FROM popular_titles({aId})");
            return result.ToList();
        }

        public List<FindCoActor> GetCoActors(string aId)
        {
            var ctx = new IMDbContext();
            var result = ctx.FindCoActors.FromSqlInterpolated($"SELECT * FROM find_co_actors({aId})").ToList();
            return result;
        }


        public IList<BestRatedActor> GetBestRatedActors(UrlParam urlParam) 
        {
            var ctx = new IMDbContext();
            var result = ctx.BestRatedActors.FromSqlInterpolated($"SELECT * FROM best_rated_actors()").Skip(urlParam.Page * urlParam.PageSize).Take(urlParam.PageSize);
            return result.ToList();
        }

        /*
         Title Related Func
        */
        public Title GetTitle(string tId)
        {
            var ctx = new IMDbContext();
            var title = ctx.Titles.FirstOrDefault(x => x.Id == tId);
            return title;
        }

        public List<Title> GetTitles(string tId)
        {
            var ctx = new IMDbContext();
            return ctx.Titles.Where(x => x.Id == tId).ToList();
        }
        // BestRatedTitles Que pasa?
        public int NumberOfTitles()
        {
            var ctx = new IMDbContext();
            return ctx.Titles.Count();
        }

        public IList<BestRatedTitle> GetBestRatedTitles(UrlParam urlParam)
        {
            var ctx = new IMDbContext();
            var result = ctx.BestRatedTitles.FromSqlInterpolated($"SELECT * FROM best_rated_titles()").Skip(urlParam.Page * urlParam.PageSize).Take(urlParam.PageSize);
            return result.ToList();
        }

    }
}
