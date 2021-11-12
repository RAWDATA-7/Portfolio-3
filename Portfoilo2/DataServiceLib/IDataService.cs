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

        IList<Genre> GetGenres(string tId);

        Rating GetRating(string tId);

        IList<Aka> GetAkas(string tId);

        Episode GetEpisode(string eId);

        IList<Episode> GetEpisodes(UrlParam urlParam, string tId);

        int NumberOfEpisodes(string tId);
    }
}   