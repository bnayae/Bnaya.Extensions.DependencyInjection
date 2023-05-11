using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bnaya.Extensions.DependencyInjection.Tests
{
    public class Foo : IInfo
    {
        public string Info { get; } = "I'm Foo";
    }
}
