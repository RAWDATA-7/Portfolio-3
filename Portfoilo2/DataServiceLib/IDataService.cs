using System.Collections.Generic;
using DataServiceLib.Domain;

namespace DataServiceLib
{
    public interface IDataService
    {
        IList<Actor> GetActors(UrlParam urlParam);

        Actor GetActor(string aId);

        int NumberOfActors();
        
    }
}