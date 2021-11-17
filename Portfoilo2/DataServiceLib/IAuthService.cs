using DataServiceLib.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataServiceLib
{
    public interface IAuthService
    {
        string CreateToken(User user);
    }
}
