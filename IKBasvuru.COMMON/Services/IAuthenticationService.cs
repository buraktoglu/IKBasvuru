using IKBasvuru.COMMON.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKBasvuru.COMMON.Services
{
    public interface IAuthenticationService
    {
        IAppUser Login(string username, string password);
    }
}
