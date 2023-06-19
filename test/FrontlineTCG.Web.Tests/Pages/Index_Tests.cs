using System.Threading.Tasks;
using Shouldly;
using Xunit;

namespace FrontlineTCG.Pages;

public class Index_Tests : FrontlineTCGWebTestBase
{
    [Fact]
    public async Task Welcome_Page()
    {
        var response = await GetResponseAsStringAsync("/");
        response.ShouldNotBeNull();
    }
}
