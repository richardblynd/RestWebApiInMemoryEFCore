using FluentAssertions;
using Newtonsoft.Json;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using WebApi.Model;
using Xunit;

namespace Test
{
    public class AwardsApiIntegrationTest
    {
        [Fact]
        public async Task TestGetMinMaxAwardInterval()
        {
            using (var client = new TestClientProvider("AwardsApiIntegrationTest").Client)
            {
                var response = await client.GetAsync("/awards/min_max_award_interval");

                response.EnsureSuccessStatusCode();

                response.StatusCode.Should().Be(HttpStatusCode.OK);

                var minMaxAwardInterval = JsonConvert.DeserializeObject<MinMaxAwardInterval>(await response.Content.ReadAsStringAsync());

                minMaxAwardInterval.Min.Count().Should().Equals(1);
                minMaxAwardInterval.Min.First().Producer.Should().Equals("Producer D");
                minMaxAwardInterval.Min.First().PreviousWin.Should().Equals(2006);
                minMaxAwardInterval.Min.First().FollowingWin.Should().Equals(2007);

                minMaxAwardInterval.Max.Count().Should().Equals(1);
                minMaxAwardInterval.Max.First().Producer.Should().Equals("Producer E");
                minMaxAwardInterval.Max.First().PreviousWin.Should().Equals(2006);
                minMaxAwardInterval.Max.First().FollowingWin.Should().Equals(2077);
            }
        }
    }
}
