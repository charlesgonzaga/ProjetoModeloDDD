using Microsoft.EntityFrameworkCore;
using ProjetoModeloDDD.Infra;
using System;

namespace ProjetoModeloDDD.Tests
{
    public class BaseFixture : IDisposable
    {
        public BaseFixture()
        {

        }

        public TContext GerarContexto<TContext>() where TContext : DbContext
        {
            DbContextOptions options = new DbContextOptionsBuilder<TContext>()
                    .UseInMemoryDatabase("BaseEmMemoria01")
                    .Options;

            return (TContext)Activator.CreateInstance(typeof(TContext), options);
        }

        public void Dispose()
        {

        }
    }
}
