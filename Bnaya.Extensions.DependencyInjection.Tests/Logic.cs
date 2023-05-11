using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Extensions.DependencyInjection;

namespace Bnaya.Extensions.DependencyInjection.Tests
{
    internal class Logic
    {
        private readonly IKeyed<IInfo> _infos;

        public Logic(IKeyed<IInfo> infos)
        {
            _infos = infos;
        }

        public string? GetInfo(string key)
        {
            return _infos[key]?.Info;
        }

        public string? TryGetInfo(string key)
        {
            if(_infos.TryGet(key, out IInfo val))
                return val.Info;
            return null;
        }
    }
}
