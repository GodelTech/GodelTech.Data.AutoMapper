using System.Diagnostics.CodeAnalysis;

namespace GodelTech.Data.AutoMapper.Tests.Fakes
{
    [ExcludeFromCodeCoverage]
    public class FakeSource
    {
        public int Id { get; set; }
        public string SourceName { get; set; }
    }
}