using ElasticSearchManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElasticSearchManager.Services
{
    public interface IElasticsearchService
    {
        Task<IEnumerable<Document>> GetDocuments();
        Task<Document> GetDocumentById(string id);
        Task AddDocument(Document document);
        Task UpdateDocument(string id, Document document);
        Task DeleteDocument(string id);
        Task<IEnumerable<Document>> SearchDocuments(string searchTerm);

        //添加临时测试数据
        Task<bool> AddSampleDocuments(int count);
        //Task Connect(string url);
    }
}
