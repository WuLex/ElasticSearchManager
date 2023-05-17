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

            // ��ʼ�� Elasticsearch �ͻ���
            //var uri = new Uri("http://localhost:9200"); // Elasticsearch �������ĵ�ַ
            //var settings = new ConnectionSettings(uri);
            //_client = new ElasticClient(settings);
        }

        //public MainForm(IContainer container)
        //{
        //    InitializeComponent();
        //    // �� Autofac �����н��� IDocumentFactory ����
        //    _documentFactory = container.Resolve<IDocumentFactory>();
        //}

        private async void MainForm_Load(object sender, EventArgs e)
        {
            // ���������ĵ�
            //await LoadDocuments();
        }

        //private void LoadDocuments()
        //{
        //    // �� Elasticsearch �����л�ȡ�����ĵ�
        //    var searchResponse = _client.Search<MyDocument>(s => s
        //        .Index("my_index")
        //    );

        //    // ���ĵ��б���ʾ�� DataGridView ��
        //    var documents = searchResponse.Documents.ToList();
        //    dataGridView1.DataSource = documents;
        //}

        //private void btnAdd_Click(object sender, EventArgs e)
        //{
        //    // ��ʾ����ĵ��ĶԻ���
        //    var addDocumentForm = new AddDocumentForm();
        //    var result = addDocumentForm.ShowDialog(this);

        //    if (result == DialogResult.OK)
        //    {
        //        // �����ĵ���ӵ� Elasticsearch ������
        //        var document = addDocumentForm.Document;
        //        var indexResponse = _client.IndexDocument(document);

        //        // ˢ�� DataGridView ��ʾ�����ĵ�
        //        LoadDocuments();
        //    }
        //}

        //private void btnEdit_Click(object sender, EventArgs e)
        //{
        //    // ��ȡѡ�����ĵ�
        //    var selectedRows = dataGridView1.SelectedRows;
        //    if (selectedRows.Count != 1)
        //    {
        //        MessageBox.Show("��ѡ��һ��Ҫ�༭���ĵ���", "��ʾ");
        //        return;
        //    }

        //    var selectedRow = selectedRows[0];
        //    var document = selectedRow.DataBoundItem as MyDocument;

        //    // ��ʾ�༭�ĵ��ĶԻ���
        //    var editDocumentForm = new EditDocumentForm(document);
        //    var result = editDocumentForm.ShowDialog(this);

        //    if (result == DialogResult.OK)
        //    {
        //        // ���� Elasticsearch �����е��ĵ�
        //        document = editDocumentForm.Document;
        //        var updateResponse = _client.Update<MyDocument, object>(document.Id, u => u
        //            .Index("my_index")
        //            .Doc(document)
        //        );

        //        // ˢ�� DataGridView ��ʾ�����ĵ�
        //        LoadDocuments();
        //    }
        //}

        //private void btnDelete_Click(object sender, EventArgs e)
        //{
        //    // ��ȡѡ�����ĵ�
        //    var selectedRows = dataGridView1.SelectedRows;
        //    if (selectedRows.Count != 1)
        //    {
        //        MessageBox.Show("��ѡ��һ��Ҫɾ�����ĵ���", "��ʾ");
        //        return;
        //    }

        //    var selectedRow = selectedRows[0];
        //    var document = selectedRow.DataBoundItem as MyDocument;

        //    // ȷ��ɾ������
        //    var confirmResult = MessageBox.Show($"ȷ��Ҫɾ���ĵ� {document.Id} ��", "ȷ��", MessageBoxButtons.YesNo);
        //    if (confirmResult == DialogResult.Yes)
        //    {
        //        // �� Elasticsearch ������ɾ���ĵ�
        //        var deleteResponse = _client.Delete<MyDocument>(document.Id, d => d
        //       .Index("my_index")
        //   );

        //        // ˢ�� DataGridView ��ʾ�����ĵ�
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

                //�����ؼ�
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

        #region ��Ӳ�������

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

        #endregion ��Ӳ�������

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
                
                #region ���°�ListBox
                bs.DataSource = documents;
                lstDocuments.DataSource = bs;

                //�б��δ��⵽��������DataSource.��ֻ����Datasource�����仯ʱˢ�£�����DataSource������Ϊ�գ�
                //lstDocuments.DataSource = null;
                //lstDocuments.DataSource = data;
                //�������������Ŀ��Ȼ���ٴ���������Դ��
                //lstDocuments.Items.Clear();
                //lstDocuments.DataSource = data; 
                #endregion

                #region ���°�GridView
                //// �������Դ��
                //dataGridView1.DataSource = null;
                //// ���°�����Դ
                //dataGridView1.DataSource = documents;
                //// ˢ�� DataGridView
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