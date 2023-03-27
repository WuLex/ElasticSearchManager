using Sunny.UI;

namespace ElasticSearchManager
{
    partial class AddDocumentForm:UIForm
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
        private UILabel lblId;
        private UILabel lblName;
        private UILabel lblDescription;
        private UITextBox txtId;
        private UITextBox txtName;
        private UITextBox txtDescription;
        private UIButton btnSave;
        private UIButton btnCancel;
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
            this.SuspendLayout();
            // 
            // lblId
            // 
            this.lblId.AutoSize = true;
            this.lblId.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblId.Location = new System.Drawing.Point(106, 98);
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
            this.lblName.Location = new System.Drawing.Point(83, 153);
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
            this.lblDescription.Location = new System.Drawing.Point(35, 222);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(120, 27);
            this.lblDescription.TabIndex = 2;
            this.lblDescription.Text = "Description";
            this.lblDescription.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtId
            // 
            this.txtId.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtId.Location = new System.Drawing.Point(159, 75);
            this.txtId.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtId.MinimumSize = new System.Drawing.Size(1, 16);
            this.txtId.Name = "txtId";
            this.txtId.ShowText = false;
            this.txtId.Size = new System.Drawing.Size(424, 50);
            this.txtId.TabIndex = 3;
            this.txtId.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.txtId.Watermark = "";
            // 
            // txtName
            // 
            this.txtName.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtName.Location = new System.Drawing.Point(159, 135);
            this.txtName.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtName.MinimumSize = new System.Drawing.Size(1, 16);
            this.txtName.Name = "txtName";
            this.txtName.ShowText = false;
            this.txtName.Size = new System.Drawing.Size(424, 45);
            this.txtName.TabIndex = 4;
            this.txtName.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.txtName.Watermark = "";
            // 
            // txtDescription
            // 
            this.txtDescription.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtDescription.Location = new System.Drawing.Point(162, 201);
            this.txtDescription.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtDescription.MinimumSize = new System.Drawing.Size(1, 16);
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.ShowText = false;
            this.txtDescription.Size = new System.Drawing.Size(424, 48);
            this.txtDescription.TabIndex = 5;
            this.txtDescription.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.txtDescription.Watermark = "";
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnSave.Location = new System.Drawing.Point(202, 280);
            this.btnSave.MinimumSize = new System.Drawing.Size(1, 1);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(113, 45);
            this.btnSave.TabIndex = 6;
            this.btnSave.Text = "Save";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnCancel.Location = new System.Drawing.Point(417, 280);
            this.btnCancel.MinimumSize = new System.Drawing.Size(1, 1);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(107, 45);
            this.btnCancel.TabIndex = 7;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // AddDocumentForm
            // 
            this.ClientSize = new System.Drawing.Size(653, 377);
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
            this.Name = "AddDocumentForm";
            this.Text = "Add Document";
            this.ZoomScaleRect = new System.Drawing.Rectangle(19, 19, 653, 377);
            this.ResumeLayout(false);
            this.PerformLayout();

        }


    }
}