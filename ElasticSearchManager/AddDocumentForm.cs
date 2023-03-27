using ElasticSearchManager.Models;
using Sunny.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace ElasticSearchManager
{
    public partial class AddDocumentForm : UIForm
    {
        public Document Document { get; private set; }
       
        
        
        public AddDocumentForm()
        {
            InitializeComponent();
        }
        // 保存按钮事件处理函数
        private void btnSave_Click(object sender, EventArgs e)
        {
            // 创建新文档并设置属性值
            var document = new Document();
            #region MyDocument
            //document.Id = int.Parse(txtId.Text);
            //document.Name = txtName.Text; 
            #endregion
            document.Id = txtId.Text;
            document.Title = txtName.Text;
            document.Description = txtDescription.Text;

            // 将新文档返回给 MainForm
            Document = document;
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
