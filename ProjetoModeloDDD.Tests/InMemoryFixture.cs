using System;
using Xunit;

namespace ProjetoModeloDDD.Tests
{
    [CollectionDefinition(nameof(InMemoryFixture))]
    public class InMemoryFixture : ICollectionFixture<BaseFixture>
    {
        public InMemoryFixture()
        {

        }
    }
}
