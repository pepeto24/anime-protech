using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimesProtech.Tests
{
    public abstract class TestBase
    {
        protected readonly IServiceProvider Escopo;

        public TestBase()
        {
            Escopo = RegistrarServicos(new ServiceCollection()).BuildServiceProvider().CreateScope().ServiceProvider;
        }

        protected virtual ServiceCollection RegistrarServicos(ServiceCollection servicos)
        {
            return servicos;
        }
    }
}
