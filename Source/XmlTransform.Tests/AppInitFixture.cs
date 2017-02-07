using Infrastructure.Extensibility;
using Infrastructure.Services;
using Xunit;

namespace XmlToHtmlTransform.Tests
{
    public class AppInitFixture
    {
        [Fact]
        public void VerifyAppInit()
        {
            AppBootStrapper appBootStrapper = new AppBootStrapper();
            appBootStrapper.Run();

            // test every component is composed.
            Assert.NotNull(AppContext.Instance);
            Assert.NotNull(AppContext.Instance.Host);
            Assert.NotNull(AppContext.Instance.Host.Queue);
        }
    }
}
