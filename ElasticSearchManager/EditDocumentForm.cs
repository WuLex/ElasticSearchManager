using ElasticSearchManager.Models;
using ElasticSearchManager.utils;
using Sunny.UI;

namespace ElasticSearchManager
{
    public partial class EditDocumentForm : UIForm
    {
        public Document Document { get; private set; }
        //public Document _document { get; private set; }
        private readonly IDocumentFactory _documentFactory;

        public EditDocumentForm(Document document, IDocumentFactory documentFactory)
        {
            InitializeComponent();

            Document = document;
            _documentFactory = documentFactory;

            // 显示原始文档的属性值
            txtId.Text = document.Id.ToString();
            txtName.Text = document.Title;
            txtDescription.Text = document.Description;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            // 更新文档属性值
            #region UpdateDocument
            //Document.Id = int.Parse(txtId.Text);
            //Document.Name = txtName.Text;
            Document = _documentFactory.CreateDocument();
            Document.Id = txtId.Text;
            Document.Title = txtName.Text;
            Document.Description = txtDescription.Text;

            #endregion UpdateDocument

            // 将更新后的文档返回给 MainForm
            DialogResult = DialogResult.OK;
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}