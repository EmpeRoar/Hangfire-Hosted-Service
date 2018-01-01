using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HostedService.Services
{
    public interface IRand
    {
        string GetRandomString();
    }
}
