using System;
using System.Collections.Generic;
using System.Net;
using RestSharp;

namespace SearchTap
{
    public class SearchTapClient
    {
        private readonly string _collectionName;
        private readonly string _key;
        private readonly RestClient _client;

        private int _page = 1;
        private int _offset = 0;
        private int _typoCount = 1;

        private static readonly string _authHeader = "X-Auth-Token";
        private static readonly string _contentHeader = "content-type";
        private static readonly string _contentJson = "application/json";
        private static readonly string _apiVersion = "v1";


        public SearchTapClient(string collectionName, string key, string projectId = null)
        {
            _collectionName = collectionName;
            _key = key;

            var url = projectId == null ? "https://api.searchtap.net" : $"https://{projectId}-api.searchtap.net";

            _client = new RestClient(url);
            _client.AddDefaultHeader(_authHeader, _key);
            _client.AddDefaultHeader(_contentHeader, _contentJson);
        }

        public void Index(IEnumerable<object> entities)
        {

            var request = new RestRequest($"/{_apiVersion}/collections/{_collectionName}", Method.POST);
            request.AddJsonBody(entities);

            var response = _client.Execute(request);

            if (response.StatusCode == HttpStatusCode.Created || response.StatusCode == HttpStatusCode.OK)
                return;

            throw new Exception(response.ErrorMessage);
        }

        public void Index(object entity)
        {
            this.Index(new[] {entity});
        }

        public void Delete(IEnumerable<object> ids)
        {
            throw new NotImplementedException();
        }

        public void Delete(object id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<object> Search(string query)
        {
            throw new NotImplementedException();
        }

        public SearchTapClient Page(int page)
        {
            _page = 1;
            return this;
        }

        public SearchTapClient Offset(int offset)
        {
            _offset = offset;
            return this;
        }

        public SearchTapClient TypoTolerance(int typoCount)
        {
            _typoCount = typoCount;
            return this;
        }
    }
}