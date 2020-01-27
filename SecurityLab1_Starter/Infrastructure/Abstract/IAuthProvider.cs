using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SecurityLab1_Starter.Infrastructure.Abstract
{
    public interface IAuthProvider
    {
       bool Authenticate(string username, string password);
    }
}