﻿namespace TvDbSharper.Tests
{
    using System.Net;
    using System.Threading;

    using NSubstitute;
    using NSubstitute.ExceptionExtensions;

    using TvDbSharper.JsonApi.Search;
    using TvDbSharper.JsonApi.Search.Json;
    using TvDbSharper.JsonClient;
    using TvDbSharper.JsonClient.Exceptions;
    using TvDbSharper.RestClient.Json;

    using Xunit;

    public class SearchClientTest
    {
        [Fact]

        // ReSharper disable once InconsistentNaming
        public async void SearchSeriesAsync_Makes_The_Right_Request()
        {
            var jsonClient = Substitute.For<IJsonClient>();
            var client = new SearchClient(jsonClient);

            const SearchParameter ParameterKey = SearchParameter.Name;
            const string ParameterValue = "Doctor Who";

            const string Route = "/search/series?name=Doctor Who";

            var expectedData = new TvDbResponse<SeriesSearchResult[]>();

            jsonClient.GetJsonAsync<TvDbResponse<SeriesSearchResult[]>>(Route, CancellationToken.None).Returns(expectedData);

            var responseData = await client.SearchSeriesAsync(ParameterValue, ParameterKey, CancellationToken.None);

            await jsonClient.Received().GetJsonAsync<TvDbResponse<SeriesSearchResult[]>>(Route, CancellationToken.None);

            Assert.Equal(expectedData, responseData);
        }

        [Theory]
        [InlineData(401)]
        [InlineData(404)]

        // ReSharper disable once InconsistentNaming
        public async void SearchSeriesAsync_Throws_With_The_Correct_Message(int statusCode)
        {
            var jsonClient = Substitute.For<IJsonClient>();
            var client = new SearchClient(jsonClient);

            jsonClient.GetJsonAsync<TvDbResponse<SeriesSearchResult[]>>(null, CancellationToken.None)
                      .ThrowsForAnyArgs(info => new TvDbServerException(null, (HttpStatusCode)statusCode, null));

            var ex =
                await
                    Assert.ThrowsAsync<TvDbServerException>(
                        async () => await client.SearchSeriesAsync("Doctor Who", SearchParameter.Name, CancellationToken.None));

            Assert.Equal(ErrorMessages.Search.SearchSeriesAsync[statusCode], ex.Message);
        }

        [Fact]

        // ReSharper disable once InconsistentNaming
        public async void SearchSeriesByImdbIdAsync_Makes_The_Right_Request()
        {
            var jsonClient = Substitute.For<IJsonClient>();
            var client = new SearchClient(jsonClient);

            const string ImdbId = "tt0436992";

            const string Route = "/search/series?imdbId=tt0436992";

            var expectedData = new TvDbResponse<SeriesSearchResult[]>();

            jsonClient.GetJsonAsync<TvDbResponse<SeriesSearchResult[]>>(Route, CancellationToken.None).Returns(expectedData);

            var responseData = await client.SearchSeriesByImdbIdAsync(ImdbId, CancellationToken.None);

            await jsonClient.Received().GetJsonAsync<TvDbResponse<SeriesSearchResult[]>>(Route, CancellationToken.None);

            Assert.Equal(expectedData, responseData);
        }

        [Theory]
        [InlineData(401)]
        [InlineData(404)]

        // ReSharper disable once InconsistentNaming
        public async void SearchSeriesByImdbIdAsync_Throws_With_The_Correct_Message(int statusCode)
        {
            var jsonClient = Substitute.For<IJsonClient>();
            var client = new SearchClient(jsonClient);

            jsonClient.GetJsonAsync<TvDbResponse<SeriesSearchResult[]>>(null, CancellationToken.None)
                      .ThrowsForAnyArgs(info => new TvDbServerException(null, (HttpStatusCode)statusCode, null));

            var ex =
                await
                    Assert.ThrowsAsync<TvDbServerException>(
                        async () => await client.SearchSeriesByImdbIdAsync("tt0436992", CancellationToken.None));

            Assert.Equal(ErrorMessages.Search.SearchSeriesAsync[statusCode], ex.Message);
        }

        [Fact]

        // ReSharper disable once InconsistentNaming
        public async void SearchSeriesByNameAsync_Makes_The_Right_Request()
        {
            var jsonClient = Substitute.For<IJsonClient>();
            var client = new SearchClient(jsonClient);

            const string Name = "Doctor Who";

            const string Route = "/search/series?name=Doctor Who";

            var expectedData = new TvDbResponse<SeriesSearchResult[]>();

            jsonClient.GetJsonAsync<TvDbResponse<SeriesSearchResult[]>>(Route, CancellationToken.None).Returns(expectedData);

            var responseData = await client.SearchSeriesByNameAsync(Name, CancellationToken.None);

            await jsonClient.Received().GetJsonAsync<TvDbResponse<SeriesSearchResult[]>>(Route, CancellationToken.None);

            Assert.Equal(expectedData, responseData);
        }

        [Theory]
        [InlineData(401)]
        [InlineData(404)]

        // ReSharper disable once InconsistentNaming
        public async void SearchSeriesByNameAsync_Throws_With_The_Correct_Message(int statusCode)
        {
            var jsonClient = Substitute.For<IJsonClient>();
            var client = new SearchClient(jsonClient);

            jsonClient.GetJsonAsync<TvDbResponse<SeriesSearchResult[]>>(null, CancellationToken.None)
                      .ThrowsForAnyArgs(info => new TvDbServerException(null, (HttpStatusCode)statusCode, null));

            var ex =
                await
                    Assert.ThrowsAsync<TvDbServerException>(
                        async () => await client.SearchSeriesByNameAsync("Doctor Who", CancellationToken.None));

            Assert.Equal(ErrorMessages.Search.SearchSeriesAsync[statusCode], ex.Message);
        }

        [Fact]

        // ReSharper disable once InconsistentNaming
        public async void SearchSeriesByZap2itIdAsync_Makes_The_Right_Request()
        {
            var jsonClient = Substitute.For<IJsonClient>();
            var client = new SearchClient(jsonClient);

            const string Zap2ItId = "SH007501780000";

            const string Route = "/search/series?zap2itId=SH007501780000";

            var expectedData = new TvDbResponse<SeriesSearchResult[]>();

            jsonClient.GetJsonAsync<TvDbResponse<SeriesSearchResult[]>>(Route, CancellationToken.None).Returns(expectedData);

            var responseData = await client.SearchSeriesByZap2ItIdAsync(Zap2ItId, CancellationToken.None);

            await jsonClient.Received().GetJsonAsync<TvDbResponse<SeriesSearchResult[]>>(Route, CancellationToken.None);

            Assert.Equal(expectedData, responseData);
        }

        [Theory]
        [InlineData(401)]
        [InlineData(404)]

        // ReSharper disable once InconsistentNaming
        public async void SearchSeriesByZap2itIdAsync_Throws_With_The_Correct_Message(int statusCode)
        {
            var jsonClient = Substitute.For<IJsonClient>();
            var client = new SearchClient(jsonClient);

            jsonClient.GetJsonAsync<TvDbResponse<SeriesSearchResult[]>>(null, CancellationToken.None)
                      .ThrowsForAnyArgs(info => new TvDbServerException(null, (HttpStatusCode)statusCode, null));

            var ex =
                await
                    Assert.ThrowsAsync<TvDbServerException>(
                        async () => await client.SearchSeriesByZap2ItIdAsync("SH007501780000", CancellationToken.None));

            Assert.Equal(ErrorMessages.Search.SearchSeriesAsync[statusCode], ex.Message);
        }
    }
}