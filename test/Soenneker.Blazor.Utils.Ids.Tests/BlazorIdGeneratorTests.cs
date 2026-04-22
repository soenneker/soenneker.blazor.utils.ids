using Soenneker.Tests.HostedUnit;

namespace Soenneker.Blazor.Utils.Ids.Tests;

[ClassDataSource<Host>(Shared = SharedType.PerTestSession)]
public sealed class BlazorIdGeneratorTests : HostedUnitTest
{
    public BlazorIdGeneratorTests(Host host) : base(host)
    {

    }

    [Test]
    public void Default()
    {

    }
}
