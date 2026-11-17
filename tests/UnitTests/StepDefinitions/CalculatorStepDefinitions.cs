using Reqnroll.Amp;
using Xunit;

namespace UnitTests.StepDefinitions
{
    [Binding]
    public sealed partial class CalculatorStepDefinitions
    {
        private Dictionary<string, WebApiProfile>? _webApiProfiles;
        private WebApiProfile? _webApiProfile;

        [Given("WebApi profile is defined in reqnroll.ampsettings.json")]
        public void GivenWebApiProfileIsDefinedInReqnroll_Ampsettings_Json()
        {
            _webApiProfiles = new Dictionary<string, WebApiProfile>
            {
                { "first", new WebApiProfile { Url = "https://localhost:5001" } },
            };
        }

        [When("no name is provided")]
        public void WhenNoNameIsProvided()
        {
            _webApiProfile = HttpClientDriverFake.GetProfile(_webApiProfiles, null);
        }

        [Then("the profile should be selected")]
        public void ThenTheProfileShouldBeSelected()
        {
            Assert.Equal("https://localhost:5001", _webApiProfile?.Url);
        }

    }
}
