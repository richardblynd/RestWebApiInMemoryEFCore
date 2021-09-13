using Entities;
using FluentAssertions;
using Newtonsoft.Json;
using System.Net;
using System.Threading.Tasks;
using Xunit;

namespace Test
{
    public class MoviesApiIntegrationTest
    {
        [Fact]
        public async Task TestGetAll()
        {
            using (var client = new TestClientProvider("MoviesApiIntegrationTest").Client)
            {
                var response = await client.GetAsync("/movies");

                response.EnsureSuccessStatusCode();

                response.StatusCode.Should().Be(HttpStatusCode.OK);

                var movies = JsonConvert.DeserializeObject<Movie[]>(await response.Content.ReadAsStringAsync());

                movies.Should().HaveCount(53);
            }
        }
    }
}
