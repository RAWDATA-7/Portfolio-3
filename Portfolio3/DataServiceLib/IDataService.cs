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

        User GetUserFromId(int uId);

        User GetUserFromUsername(string username);

        void CreateUser(string name,
            string firstName,
            string lastName,
            string email,
            string sex,
            byte[] password,
            byte[] salt);

        void updateBookmarks(int uId, string tId);

        void updateSearchHistory(int uId, string searchString, string field);

        void updateUserRating(int uId, string tId, int rating);

        IList<BestMatch> GetBestMatches(int uId, string searchString, string field, UrlParam urlParam);

    }
}   