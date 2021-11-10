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

        public IList<Actor> GetActors(UrlParam urlParam)
        {
            var ctx = new IMDbContext();
            var result = ctx.Actors.AsEnumerable().Skip(urlParam.Page * urlParam.PageSize).Take(urlParam.PageSize);
            return result.ToList();
        }

        public Actor GetActor(string aId)
        {
            var ctx = new IMDbContext();
            return ctx.Actors.FirstOrDefault(x => x.Id == aId);
        }

        public int NumberOfActors()
        {
            var ctx = new IMDbContext();
            return ctx.Actors.Count();
        }

        public IList<BestRatedActor> GetBestRatedActors(UrlParam urlParam) 
        {
            var ctx = new IMDbContext();
            var result = ctx.BestRatedActors.FromSqlInterpolated($"SELECT * FROM best_rated_actors()").Skip(urlParam.Page * urlParam.PageSize).Take(urlParam.PageSize);
            return result.ToList();
        }
    }
}
