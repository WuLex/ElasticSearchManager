using Elasticsearch.Net;
using ElasticSearchManager.Models;
using ElasticSearchManager.utils;
using Nest;
using Nest.JsonNetSerializer;

namespace ElasticSearchManager.Services
{
    public class ElasticsearchService : IElasticsearchService
    {
        private static ElasticsearchService instance;
        private ElasticClient _client;

        //private readonly ElasticClient _client;
        private readonly Uri node;

        private ElasticsearchService(string url)
        {
            node = new Uri(url);
            Connect();
        }

        private void Connect()
        {
            // 使用 Newtonsoft.Json 序列化器
            var pool = new SingleNodeConnectionPool(node);
            var settings = new ConnectionSettings(pool, sourceSerializer: JsonNetSerializer.Default);
            //var settings = new ConnectionSettings(node);
            _client = new ElasticClient(settings);
        }

        public static ElasticsearchService GetInstance(string url)
        {
            if (instance == null)
            {
                instance = new ElasticsearchService(url);
            }
            return instance;
        }

        //public ElasticsearchService()
        //{
        //    _client = new ElasticClient();
        //}
        //public ElasticsearchService(string url)
        //{
        //    var settings = new ConnectionSettings(new Uri(url));
        //    _client = new ElasticClient(settings);
        //}
        //public async Task Connect(string url)
        //{
        //    var settings = new ConnectionSettings(new Uri(url));
        //    _client = new ElasticClient(settings);
        //}

        public async Task AddDocument(Document document)
        {
            var indexResponse = await _client.IndexAsync(document, idx => idx.Index("documents"));
            if (!indexResponse.IsValid)
            {
                throw new Exception(indexResponse.DebugInformation);
            }
        }

        public async Task DeleteDocument(string id)
        {
            var deleteResponse = await _client.DeleteAsync<Document>(id, idx => idx.Index("documents"));
            if (!deleteResponse.IsValid)
            {
                throw new Exception(deleteResponse.DebugInformation);
            }
        }

        public async Task<Document> GetDocumentById(string id)
        {
            var response = await _client.GetAsync<Document>(id, idx => idx.Index("documents"));
            if (!response.IsValid)
            {
                throw new Exception(response.DebugInformation);
            }
            return response.Source;
        }

        public async Task<IEnumerable<Document>> GetDocuments()
        {
            var searchResponse = await _client.SearchAsync<Document>(s => s.Index("documents"));
            if (!searchResponse.IsValid)
            {
                throw new Exception(searchResponse.DebugInformation);
            }
            return searchResponse.Documents.ToList();
        }

        public async Task UpdateDocument(string id, Document document)
        {
            var updateResponse = await _client.UpdateAsync<Document>(id, u => u.Index("documents").Doc(document));
            if (!updateResponse.IsValid)
            {
                throw new Exception(updateResponse.DebugInformation);
            }
        }


        /// <summary>
        /// 通过 NEST 公开的大部分 Elasticsearch API 都是强类型的，包括 .Search<T>(); 
        /// 使用此端点，“索引”和“类型”都将从 T 中推断出来，但有时您可能希望为推断出的值设置不同的值。 
        /// 在这些情况下，您可以在搜索流畅的 API（或搜索对象，如果使用对象初始化语法）上调用其他方法来覆盖推断值
        /// </summary>
        /// <param name="searchTerm"></param>
        /// <returns></returns>
        public async Task<IEnumerable<Document>> SearchDocuments(string searchTerm)
        {
            var searchResponse = await _client.SearchAsync<Document>(s => s.Index("mydoc")
                .Query(q => q
                    .Match(m => m
                        .Field(f => f.Title)
                        .Query(searchTerm)
                    ) || q
                    .Match(m => m
                        .Field(f => f.Content)
                        .Query(searchTerm)
                    )
                ));

            return searchResponse.Documents;
        }

        public async Task<bool> AddSampleDocuments(int count)
        {
            var documents = Enumerable.Range(1, count)
                .Select(i => new Document
                {
                    Id = Guid.NewGuid().ToString(),
                    Title = $"Doc {i}",
                    Content = LoremIpsum.Paragraphs(3),
                    CreatedDate = DateTime.Now.AddDays(-i),
                    Tags = new List<string> { "tag1", "tag2", "tag3" },
                    Author = new Author
                    {
                        Name = $"Author {i}",
                        Email = $"author{i}@example.com"
                    }
                })
                .ToList();

            // 创建多个 Document 对象，并设置属性
            var documenttwos = new List<Document>
                    {
                        new Document
                        {
                            Id = "1",
                            Title = "My First Document",
                            Content = LoremIpsum.Paragraphs(3),
                            CreatedDate = DateTime.Now,
                            Tags = new List<string> { "tag1", "tag2" },
                            Author = new Author { Name = "John Doe", Email = "john.doe@example.com" }
                        },
                        new Document
                        {
                            Id = "2",
                            Title = "My Second Document",
                            Content = LoremIpsum.Paragraphs(5),
                            CreatedDate = DateTime.Now.AddDays(-1),
                            Tags = new List<string> { "tag2", "tag3" },
                            Author = new Author { Name = "Jane Doe", Email = "jane.doe@example.com" }
                        }
                    };

            #region 批量

            var asyncBulkIndexResponse = await _client.BulkAsync(b => b
                .Index("mydoc")
                .IndexMany(documents)
            );
            return asyncBulkIndexResponse.IsValid;

            //// 创建一个 BulkRequest 对象，并将 BulkIndexOperation<Document> 对象添加到其中
            ////var bulkRequest = new BulkRequest
            ////{
            ////    Operations = new BulkOperationsCollection<IBulkOperation>(
            ////        documents.Select(d => new BulkIndexOperation<Document>(d)))
            ////};
            //var bulkRequest = new BulkRequest();

            //// 将每个文档对象转换为批量操作对象
            //var bulkOperations = documents
            //    .Select(d => new BulkIndexOperation<Document>(d))
            //    .ToList();

            //// 创建批量操作集合，并添加所有批量操作
            //var bulkOperationsCollection = new BulkOperationsCollection<IBulkOperation>(bulkOperations);

            //// 将批量操作集合添加到批量请求中
            //bulkRequest.Operations = bulkOperationsCollection;

            //// 发送批量请求
            //var bulkResponse = await _client.BulkAsync(bulkRequest);
            ////var response = _client.Bulk(bulkRequest);
            //return bulkResponse.IsValid;

            #endregion 批量
        }
    }
}