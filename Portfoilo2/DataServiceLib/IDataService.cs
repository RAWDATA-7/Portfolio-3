using System.Collections.Generic;
using DataServiceLib.Domain;
using DataServiceLib.FuncDomain;

namespace DataServiceLib
{
    public interface IDataService
    {

        Actor GetActor(string aId);

        Title GetTitle(string tId);

        int NumberOfActors();

        IList<BestRatedActor> GetBestRatedActors(UrlParam urlParam);

        IList<BestRatedTitle> GetBestRatedTitles(UrlParam urlParam);

        int NumberOfTitles();

    }
}   