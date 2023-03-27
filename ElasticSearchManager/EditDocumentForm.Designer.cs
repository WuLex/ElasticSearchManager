namespace ElasticSearchManager
{
    partial class EditDocumentForm
    {
        private System.ComponentModel.IContainer components = null;
        //private System.Windows.Forms.Label lblId;
        //private System.Windows.Forms.Label lblName;
        //private System.Windows.Forms.Label lblDescription;
        //private System.Windows.Forms.TextBox txtId;
        //private System.Windows.Forms.TextBox txtName;
        //private System.Windows.Forms.TextBox txtDescription;
        //private System.Windows.Forms.Button btnSave;
        //private System.Windows.Forms.Button btnCancel;

        private Sunny.UI.UILabel lblId;
        private Sunny.UI.UILabel lblName;
        private Sunny.UI.UILabel lblDescription;
        private Sunny.UI.UITextBox txtId;
        private Sunny.UI.UITextBox txtName;
        private Sunny.UI.UITextBox txtDescription;
        private Sunny.UI.UIButton btnSave;
        private Sunny.UI.UIButton btnCancel;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lblId = new Sunny.UI.UILabel();
            this.lblName = new Sunny.UI.UILabel();
            this.lblDescription = new Sunny.UI.UILabel();
            this.txtId = new Sunny.UI.UITextBox();
            this.txtName = new Sunny.UI.UITextBox();
            this.txtDescription = new Sunny.UI.UITextBox();
            this.btnSave = new Sunny.UI.UIButton();
            this.btnCancel = new Sunny.UI.UIButton();
            this.uiLabel1 = new Sunny.UI.UILabel();
            this.SuspendLayout();
            // 
            // lblId
            // 
            this.lblId.AutoSize = true;
            this.lblId.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblId.Location = new System.Drawing.Point(166, 88);
            this.lblId.Name = "lblId";
            this.lblId.Size = new System.Drawing.Size(33, 27);
            this.lblId.TabIndex = 0;
            this.lblId.Text = "ID";
            this.lblId.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblName.Location = new System.Drawing.Point(130, 161);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(69, 27);
            this.lblName.TabIndex = 1;
            this.lblName.Text = "Name";
            this.lblName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblDescription.Location = new System.Drawing.Point(79, 223);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(120, 27);
            this.lblDescription.TabIndex = 2;
            this.lblDescription.Text = "Description";
            this.lblDescription.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtId
            // 
            this.txtId.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtId.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtId.Location = new System.Drawing.Point(254, 71);
            this.txtId.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtId.MinimumSize = new System.Drawing.Size(1, 1);
            this.txtId.Name = "txtId";
            this.txtId.Padding = new System.Windows.Forms.Padding(5);
            this.txtId.ShowText = false;
            this.txtId.Size = new System.Drawing.Size(361, 55);
            this.txtId.TabIndex = 3;
            this.txtId.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.txtId.Watermark = "";
            // 
            // txtName
            // 
            this.txtName.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtName.Location = new System.Drawing.Point(254, 138);
            this.txtName.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtName.MaxLength = 50;
            this.txtName.MinimumSize = new System.Drawing.Size(1, 16);
            this.txtName.Name = "txtName";
            this.txtName.ShowText = false;
            this.txtName.Size = new System.Drawing.Size(361, 50);
            this.txtName.TabIndex = 3;
            this.txtName.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.txtName.Watermark = "";
            // 
            // txtDescription
            // 
            this.txtDescription.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtDescription.Location = new System.Drawing.Point(254, 198);
            this.txtDescription.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtDescription.MaxLength = 500;
            this.txtDescription.MinimumSize = new System.Drawing.Size(1, 16);
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.ShowText = false;
            this.txtDescription.Size = new System.Drawing.Size(361, 52);
            this.txtDescription.TabIndex = 4;
            this.txtDescription.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.txtDescription.Watermark = "";
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnSave.Location = new System.Drawing.Point(152, 287);
            this.btnSave.MinimumSize = new System.Drawing.Size(1, 1);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(197, 56);
            this.btnSave.TabIndex = 6;
            this.btnSave.Text = "Save";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnCancel.Location = new System.Drawing.Point(406, 287);
            this.btnCancel.MinimumSize = new System.Drawing.Size(1, 1);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(209, 56);
            this.btnCancel.TabIndex = 7;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // uiLabel1
            // 
            this.uiLabel1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.uiLabel1.Location = new System.Drawing.Point(0, 35);
            this.uiLabel1.Name = "uiLabel1";
            this.uiLabel1.Size = new System.Drawing.Size(100, 23);
            this.uiLabel1.TabIndex = 0;
            this.uiLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // EditDocumentForm
            // 
            this.ClientSize = new System.Drawing.Size(745, 407);
            this.Controls.Add(this.uiLabel1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.txtId);
            this.Controls.Add(this.lblDescription);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.lblId);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "EditDocumentForm";
            this.Text = "Edit Document";
            this.ZoomScaleRect = new System.Drawing.Rectangle(19, 19, 745, 407);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private Sunny.UI.UILabel uiLabel1;
    }
}