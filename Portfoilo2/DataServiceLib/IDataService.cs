using System.Collections.Generic;
using DataServiceLib.Domain;

namespace DataServiceLib
{
    public interface IDataService
    {
        IList<Actor> GetActors();

        Actor GetActor(string aId);
        
    }
}