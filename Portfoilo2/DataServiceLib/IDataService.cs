using System.Collections.Generic;
using DataServiceLib.Domain;
using DataServiceLib.FuncDomain;

namespace DataServiceLib
{
    public interface IDataService
    {

        Actor GetActor(string aId);

        int NumberOfActors();

        IList<BestRatedActor> GetBestRatedActors(UrlParam urlParam);

    }
}