using Autofac;
using ElasticSearchManager.Models;
using ElasticSearchManager.Services;
using ElasticSearchManager.utils;
using Microsoft.Extensions.DependencyInjection;
using Nest;
using Sunny.UI;
using System.ComponentModel;
using System.Windows.Forms;
using System.Xml.Linq;

namespace ElasticSearchManager
{
    public partial class MainForm : UIForm
    {
        private ElasticClient _client;
        private IElasticsearchService _elasticsearchService;
        private List<Document> _documents;
        private BindingList<Document> _documentdatas = new BindingList<Document>();
        private BindingSource bs = new BindingSource();
        private readonly IDocumentFactory _documentFactory;

        public MainForm()
        {
            InitializeComponent();
            _documents = new List<Document>();
            //_elasticsearchService = new ElasticsearchService("http://localhost:9200");

            // 初始化 Elasticsearch 客户端
            //var uri = new Uri("http://localhost:9200"); // Elasticsearch 服务器的地址
            //var settings = new ConnectionSettings(uri);
            //_client = new ElasticClient(settings);
        }

        //public MainForm(IContainer container)
        //{
        //    InitializeComponent();
        //    // 从 Autofac 容器中解析 IDocumentFactory 对象
        //    _documentFactory = container.Resolve<IDocumentFactory>();
        //}

        private async void MainForm_Load(object sender, EventArgs e)
        {
            // 加载所有文档
            //await LoadDocuments();
        }

        //private void LoadDocuments()
        //{
        //    // 从 Elasticsearch 索引中获取所有文档
        //    var searchResponse = _client.Search<MyDocument>(s => s
        //        .Index("my_index")
        //    );

        //    // 将文档列表显示在 DataGridView 中
        //    var documents = searchResponse.Documents.ToList();
        //    dataGridView1.DataSource = documents;
        //}

        //private void btnAdd_Click(object sender, EventArgs e)
        //{
        //    // 显示添加文档的对话框
        //    var addDocumentForm = new AddDocumentForm();
        //    var result = addDocumentForm.ShowDialog(this);

        //    if (result == DialogResult.OK)
        //    {
        //        // 将新文档添加到 Elasticsearch 索引中
        //        var document = addDocumentForm.Document;
        //        var indexResponse = _client.IndexDocument(document);

        //        // 刷新 DataGridView 显示最新文档
        //        LoadDocuments();
        //    }
        //}

        //private void btnEdit_Click(object sender, EventArgs e)
        //{
        //    // 获取选定的文档
        //    var selectedRows = dataGridView1.SelectedRows;
        //    if (selectedRows.Count != 1)
        //    {
        //        MessageBox.Show("请选中一行要编辑的文档。", "提示");
        //        return;
        //    }

        //    var selectedRow = selectedRows[0];
        //    var document = selectedRow.DataBoundItem as MyDocument;

        //    // 显示编辑文档的对话框
        //    var editDocumentForm = new EditDocumentForm(document);
        //    var result = editDocumentForm.ShowDialog(this);

        //    if (result == DialogResult.OK)
        //    {
        //        // 更新 Elasticsearch 索引中的文档
        //        document = editDocumentForm.Document;
        //        var updateResponse = _client.Update<MyDocument, object>(document.Id, u => u
        //            .Index("my_index")
        //            .Doc(document)
        //        );

        //        // 刷新 DataGridView 显示最新文档
        //        LoadDocuments();
        //    }
        //}

        //private void btnDelete_Click(object sender, EventArgs e)
        //{
        //    // 获取选定的文档
        //    var selectedRows = dataGridView1.SelectedRows;
        //    if (selectedRows.Count != 1)
        //    {
        //        MessageBox.Show("请选中一行要删除的文档。", "提示");
        //        return;
        //    }

        //    var selectedRow = selectedRows[0];
        //    var document = selectedRow.DataBoundItem as MyDocument;

        //    // 确认删除操作
        //    var confirmResult = MessageBox.Show($"确定要删除文档 {document.Id} 吗？", "确认", MessageBoxButtons.YesNo);
        //    if (confirmResult == DialogResult.Yes)
        //    {
        //        // 从 Elasticsearch 索引中删除文档
        //        var deleteResponse = _client.Delete<MyDocument>(document.Id, d => d
        //       .Index("my_index")
        //   );

        //        // 刷新 DataGridView 显示最新文档
        //        LoadDocuments();
        //    }
        //}

        private async Task LoadDocuments()
        {
            // Clear list box
            _documents.Clear();
            lstDocuments.Items.Clear();

            try
            {
                // Get documents from Elasticsearch
                var documents = await _elasticsearchService.GetDocuments();
                _documents = documents.ToList();

                // Add documents to list box
                foreach (var document in _documents)
                {
                    lstDocuments.Items.Add(document);
                }

                lblStatus.Text = "Documents loaded successfully";
                lblStatus.ForeColor = System.Drawing.Color.Green;
            }
            catch (Exception ex)
            {
                lblStatus.Text = "Error loading documents";
                lblStatus.ForeColor = System.Drawing.Color.Red;
                MessageBox.Show(ex.Message);
            }
        }

        private async void btnConnect_Click(object sender, EventArgs e)
        {
            try
            {
                // Connect to Elasticsearch server
                _elasticsearchService = ElasticsearchService.GetInstance(txtServerUrl.Text);
                lblStatus.Text = "Connected to Elasticsearch server";
                lblStatus.ForeColor = System.Drawing.Color.Green;

                // Load documents
                await LoadDocuments();

                //开启控件
                grpDocuments.Enabled = true;
                grpSearch.Enabled = true;
            }
            catch (Exception ex)
            {
                lblStatus.Text = "Error connecting to Elasticsearch server";
                lblStatus.ForeColor = System.Drawing.Color.Red;
                MessageBox.Show(ex.Message);
            }
        }

        private async void btnAdd_Click(object sender, EventArgs e)
        {
            var addDocumentForm = new AddDocumentForm();
            if (addDocumentForm.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    // Add document to Elasticsearch
                    var document = addDocumentForm.Document;
                    await _elasticsearchService.AddDocument(document);
                    lblStatus.Text = "Document added successfully";
                    lblStatus.ForeColor = System.Drawing.Color.Green;

                    // Add document to list box
                    _documents.Add(document);
                    lstDocuments.Items.Add(document);
                }
                catch (Exception ex)
                {
                    lblStatus.Text = "Error adding document";
                    lblStatus.ForeColor = System.Drawing.Color.Red;
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private async void btnEdit_Click(object sender, EventArgs e)
        {
            var document = lstDocuments.SelectedItem as Document;
            if (document == null)
            {
                MessageBox.Show("Please select a document to edit");
                return;
            }

            using var scope = Program.ServiceProvider.CreateScope();
            var documentFactory = scope.ServiceProvider.GetRequiredService<IDocumentFactory>();
            var editDocumentForm = new EditDocumentForm(document, documentFactory);
            //var editDocumentForm = new EditDocumentForm(document);
            if (editDocumentForm.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    // Update document in Elasticsearch
                    var updatedDocument = editDocumentForm.Document;
                    await _elasticsearchService.UpdateDocument(updatedDocument.Id, updatedDocument);
                    lblStatus.Text = "Document updated successfully";
                    lblStatus.ForeColor = System.Drawing.Color.Green;

                    // Update document in list box
                    var index = _documents.IndexOf(document);
                    _documents[index] = updatedDocument;
                    lstDocuments.Items[index] = updatedDocument;
                }
                catch (Exception ex)
                {
                    lblStatus.Text = "Error updating document";
                    lblStatus.ForeColor = System.Drawing.Color.Red;
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private async void btnDelete_Click(object sender, EventArgs e)
        {
            var document = lstDocuments.SelectedItem as Document;
            if (document == null)
            {
                MessageBox.Show("Please select a document to delete");
                return;
            }

            if (MessageBox.Show($"Are you sure you want to delete the document with ID {document.Id}?", "Confirm Deletion", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                try
                {
                    // Delete document from Elasticsearch
                    await _elasticsearchService.DeleteDocument(document.Id);
                    lblStatus.Text = "Document deleted successfully";
                    lblStatus.ForeColor = System.Drawing.Color.Green;

                    // Remove document from list box
                    _documents.Remove(document);
                    lstDocuments.Items.Remove(document);
                }
                catch (Exception ex)
                {
                    lblStatus.Text = "Error deleting document";
                    lblStatus.ForeColor = System.Drawing.Color.Red;
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private async void btnRefresh_Click(object sender, EventArgs e)
        {
            await LoadDocuments();
        }

        #region 添加测试数据

        private async void btnAddSampleDocuments_Click(object sender, EventArgs e)
        {
            int count = 100;
            try
            {
                bool result = await _elasticsearchService.AddSampleDocuments(count);
                MessageBox.Show($"Added {count} documents to Elasticsearch.");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to add sample documents to Elasticsearch. {ex.Message}");
            }
        }

        #endregion 添加测试数据

        //private void btnSearch_Click(object sender, EventArgs e)
        //{
        //    var searchResponse = _elasticsearchService.Search<Document>(s => s
        //        .Index("myindex")
        //        .Query(q => q
        //            .Match(m => m
        //                .Field(f => f.Content)
        //                .Query(txtSearch.Text)
        //            )
        //        )
        //    );

        //    //var documents = searchResponse.Documents.ToList();
        //    //dataGridView1.DataSource = ToDataTable(documents);
        //}
        private async void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                var searchTerm = txtSearch.Text.Trim();
                var documents = await _elasticsearchService.SearchDocuments(searchTerm);
                
                #region 重新绑定ListBox
                bs.DataSource = documents;
                lstDocuments.DataSource = bs;

                //列表框未检测到您更改了DataSource.它只会在Datasource发生变化时刷新，所以DataSource先设置为空：
                //lstDocuments.DataSource = null;
                //lstDocuments.DataSource = data;
                //您还可以清除项目，然后再次设置数据源：
                //lstDocuments.Items.Clear();
                //lstDocuments.DataSource = data; 
                #endregion

                #region 重新绑定GridView
                //// 解除数据源绑定
                //dataGridView1.DataSource = null;
                //// 重新绑定数据源
                //dataGridView1.DataSource = documents;
                //// 刷新 DataGridView
                //dataGridView1.Refresh(); 
                #endregion
               
                //if (documents.Any())
                //{
                //    dataGridView1.Columns["Id"].Visible = false;
                //    dataGridView1.Columns["CreatedDate"].Visible = false;
                //    dataGridView1.Columns["ModifiedDate"].Visible = false;
                //}
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}