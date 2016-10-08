﻿namespace TvDbSharper.JsonApi.Search
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;

    using TvDbSharper.JsonApi.Search.Json;
    using TvDbSharper.JsonClient;
    using TvDbSharper.JsonClient.Exceptions;
    using TvDbSharper.RestClient.Json;

    public class SearchClient : BaseClient, ISearchClient
    {
        public SearchClient(IJsonClient jsonClient)
            : base(jsonClient)
        {
        }

        public async Task<TvDbResponse<SeriesSearchResult[]>> SearchSeriesAsync(
            string value,
            SearchParameter parameter,
            CancellationToken cancellationToken)
        {
            try
            {
                string requestUri = $"/search/series?{UrlHelpers.PascalCase(parameter.ToString())}={value}";

                return await this.GetAsync<SeriesSearchResult[]>(requestUri, cancellationToken);
            }
            catch (TvDbServerException ex)
            {
                string message = this.GetMessage(ex.StatusCode, ErrorMessages.Search.SearchSeriesAsync);

                if (message == null)
                {
                    throw;
                }

                throw new TvDbServerException(message, ex.StatusCode, ex);
            }
        }

        public async Task<TvDbResponse<SeriesSearchResult[]>> SearchSeriesByImdbIdAsync(string imdbId, CancellationToken cancellationToken)
        {
            return await this.SearchSeriesAsync(imdbId, SearchParameter.ImdbId, cancellationToken);
        }

        public async Task<TvDbResponse<SeriesSearchResult[]>> SearchSeriesByNameAsync(string name, CancellationToken cancellationToken)
        {
            return await this.SearchSeriesAsync(name, SearchParameter.Name, cancellationToken);
        }

        public async Task<TvDbResponse<SeriesSearchResult[]>> SearchSeriesByZap2ItIdAsync(
            string zap2ItId,
            CancellationToken cancellationToken)
        {
            return await this.SearchSeriesAsync(zap2ItId, SearchParameter.Zap2itId, cancellationToken);
        }
    }
}