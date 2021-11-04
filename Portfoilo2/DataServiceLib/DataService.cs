using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using DataServiceLib.Domain;

namespace DataServiceLib
{
    public class DataService : IDataService
    {

        public DataService(){}
        public IList<Actor> GetActors()
        {
            var ctx = new IMDbContext();
            return ctx.Actors.ToList();
        }

        public Actor GetActor(string aId)
        {
            return GetActors().FirstOrDefault(x => x.Id == aId);
        }
        
        
        
        
    }
}
