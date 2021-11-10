using System.Collections.Generic;
using DataServiceLib.Domain;
using DataServiceLib.FuncDomain;

namespace DataServiceLib
{
    public interface IDataService
    {
        IList<Actor> GetActors(UrlParam urlParam);

        Actor GetActor(string aId);

        int NumberOfActors();

        IList<BestRatedActor> GetBestRatedActors(UrlParam urlParam);
        
    }
}