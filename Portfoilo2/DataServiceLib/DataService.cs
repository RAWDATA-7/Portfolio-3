﻿using System;
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
//            var actorList = new List<FindCoActor>();
//            foreach (var c in result) 
//            {
//                c.Actor = GetActors(c.Id);
//                actorList.Add(c);
//            }
//            return actorList;
//
        }


        public IList<BestRatedActor> GetBestRatedActors(UrlParam urlParam) 
        {
            var ctx = new IMDbContext();
            var result = ctx.BestRatedActors.FromSqlInterpolated($"SELECT * FROM best_rated_actors()").Skip(urlParam.Page * urlParam.PageSize).Take(urlParam.PageSize);
            return result.ToList();
        }
    }
}
