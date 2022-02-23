using Elasticsearch.Net;
using Nest;
using System;

namespace Blog.Connector
{
    public class ConnectionToEs
    {
        public ElasticClient esClient()
        {
            var nodes = new Uri[]
            {
                new Uri("http://localhost:9200/")
            };
            var connectionPool = new StaticConnectionPool(nodes);
            var connectionSettings = new ConnectionSettings(connectionPool).DisableDirectStreaming();
            var elasticClient = new ElasticClient(connectionSettings);
            return elasticClient;
        }
    }
}
