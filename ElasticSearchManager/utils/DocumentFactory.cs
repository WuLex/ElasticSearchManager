using ElasticSearchManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElasticSearchManager.utils
{
    public class DocumentFactory : IDocumentFactory
    {
        public Document CreateDocument()
        {
            return new Document();
        }
    }
}
