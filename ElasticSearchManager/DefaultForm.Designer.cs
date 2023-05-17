namespace ElasticSearchManager
{
    partial class DefaultForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnValidate = new Sunny.UI.UIButton();
            this.btnConnect = new Sunny.UI.UIButton();
            this.txtUri = new Sunny.UI.UITextBox();
            this.lblId = new Sunny.UI.UILabel();
            this.btnExport = new Sunny.UI.UIButton();
            this.uiPanel1 = new Sunny.UI.UIPanel();
            this.uiGroupBox1 = new Sunny.UI.UIGroupBox();
            this.txtQuery = new Sunny.UI.UIRichTextBox();
            this.uiGroupBox2 = new Sunny.UI.UIGroupBox();
            this.txtOutput = new Sunny.UI.UIRichTextBox();
            this.loadProgressBar = new Sunny.UI.UIProcessBar();
            this.uiPanel1.SuspendLayout();
            this.uiGroupBox1.SuspendLayout();
            this.uiGroupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnValidate
            // 
            this.btnValidate.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnValidate.Location = new System.Drawing.Point(783, 373);
            this.btnValidate.MinimumSize = new System.Drawing.Size(1, 1);
            this.btnValidate.Name = "btnValidate";
            this.btnValidate.Size = new System.Drawing.Size(247, 56);
            this.btnValidate.TabIndex = 15;
            this.btnValidate.Text = "验证(Validate)";
            this.btnValidate.Click += new System.EventHandler(this.btnValidate_Click);
            // 
            // btnConnect
            // 
            this.btnConnect.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnConnect.Location = new System.Drawing.Point(783, 287);
            this.btnConnect.MinimumSize = new System.Drawing.Size(1, 1);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(247, 56);
            this.btnConnect.TabIndex = 14;
            this.btnConnect.Text = "连接(Connect)";
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // txtUri
            // 
            this.txtUri.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtUri.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtUri.Location = new System.Drawing.Point(67, 25);
            this.txtUri.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtUri.MinimumSize = new System.Drawing.Size(1, 1);
            this.txtUri.Name = "txtUri";
            this.txtUri.Padding = new System.Windows.Forms.Padding(5);
            this.txtUri.ShowText = false;
            this.txtUri.Size = new System.Drawing.Size(666, 44);
            this.txtUri.TabIndex = 12;
            this.txtUri.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.txtUri.Watermark = "";
            // 
            // lblId
            // 
            this.lblId.AutoSize = true;
            this.lblId.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblId.Location = new System.Drawing.Point(15, 42);
            this.lblId.Name = "lblId";
            this.lblId.Size = new System.Drawing.Size(45, 27);
            this.lblId.TabIndex = 8;
            this.lblId.Text = "Url:";
            this.lblId.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnExport
            // 
            this.btnExport.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnExport.Location = new System.Drawing.Point(783, 462);
            this.btnExport.MinimumSize = new System.Drawing.Size(1, 1);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(247, 56);
            this.btnExport.TabIndex = 16;
            this.btnExport.Text = "导出CSV(Export CSV)";
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // uiPanel1
            // 
            this.uiPanel1.Controls.Add(this.txtUri);
            this.uiPanel1.Controls.Add(this.lblId);
            this.uiPanel1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.uiPanel1.Location = new System.Drawing.Point(9, 56);
            this.uiPanel1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uiPanel1.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiPanel1.Name = "uiPanel1";
            this.uiPanel1.Size = new System.Drawing.Size(748, 103);
            this.uiPanel1.TabIndex = 17;
            this.uiPanel1.Text = null;
            this.uiPanel1.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // uiGroupBox1
            // 
            this.uiGroupBox1.Controls.Add(this.txtQuery);
            this.uiGroupBox1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.uiGroupBox1.Location = new System.Drawing.Point(9, 169);
            this.uiGroupBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uiGroupBox1.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiGroupBox1.Name = "uiGroupBox1";
            this.uiGroupBox1.Padding = new System.Windows.Forms.Padding(0, 32, 0, 0);
            this.uiGroupBox1.Size = new System.Drawing.Size(748, 227);
            this.uiGroupBox1.TabIndex = 18;
            this.uiGroupBox1.Text = "Query:";
            this.uiGroupBox1.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtQuery
            // 
            this.txtQuery.FillColor = System.Drawing.Color.White;
            this.txtQuery.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtQuery.Location = new System.Drawing.Point(15, 37);
            this.txtQuery.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtQuery.MinimumSize = new System.Drawing.Size(1, 1);
            this.txtQuery.Name = "txtQuery";
            this.txtQuery.Padding = new System.Windows.Forms.Padding(2);
            this.txtQuery.ShowText = false;
            this.txtQuery.Size = new System.Drawing.Size(718, 170);
            this.txtQuery.TabIndex = 12;
            this.txtQuery.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // uiGroupBox2
            // 
            this.uiGroupBox2.Controls.Add(this.txtOutput);
            this.uiGroupBox2.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.uiGroupBox2.Location = new System.Drawing.Point(9, 406);
            this.uiGroupBox2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uiGroupBox2.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiGroupBox2.Name = "uiGroupBox2";
            this.uiGroupBox2.Padding = new System.Windows.Forms.Padding(0, 32, 0, 0);
            this.uiGroupBox2.Size = new System.Drawing.Size(748, 337);
            this.uiGroupBox2.TabIndex = 19;
            this.uiGroupBox2.Text = "Output:";
            this.uiGroupBox2.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtOutput
            // 
            this.txtOutput.FillColor = System.Drawing.Color.White;
            this.txtOutput.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtOutput.Location = new System.Drawing.Point(15, 37);
            this.txtOutput.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtOutput.MinimumSize = new System.Drawing.Size(1, 1);
            this.txtOutput.Name = "txtOutput";
            this.txtOutput.Padding = new System.Windows.Forms.Padding(2);
            this.txtOutput.ShowText = false;
            this.txtOutput.Size = new System.Drawing.Size(718, 282);
            this.txtOutput.TabIndex = 12;
            this.txtOutput.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // loadProgressBar
            // 
            this.loadProgressBar.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.loadProgressBar.Location = new System.Drawing.Point(3, 751);
            this.loadProgressBar.MinimumSize = new System.Drawing.Size(70, 3);
            this.loadProgressBar.Name = "loadProgressBar";
            this.loadProgressBar.Size = new System.Drawing.Size(1053, 40);
            this.loadProgressBar.TabIndex = 20;
            this.loadProgressBar.Text = "uiProcessBar1";
            // 
            // DefaultForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1059, 805);
            this.Controls.Add(this.loadProgressBar);
            this.Controls.Add(this.uiGroupBox2);
            this.Controls.Add(this.uiGroupBox1);
            this.Controls.Add(this.uiPanel1);
            this.Controls.Add(this.btnExport);
            this.Controls.Add(this.btnValidate);
            this.Controls.Add(this.btnConnect);
            this.Name = "DefaultForm";
            this.Text = "DefaultForm";
            this.ZoomScaleRect = new System.Drawing.Rectangle(19, 19, 800, 450);
            this.uiPanel1.ResumeLayout(false);
            this.uiPanel1.PerformLayout();
            this.uiGroupBox1.ResumeLayout(false);
            this.uiGroupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Sunny.UI.UIButton btnValidate;
        private Sunny.UI.UIButton btnConnect;
        private Sunny.UI.UITextBox txtUri;
        private Sunny.UI.UILabel lblId;
        private Sunny.UI.UIButton btnExport;
        private Sunny.UI.UIPanel uiPanel1;
        private Sunny.UI.UIGroupBox uiGroupBox1;
        private Sunny.UI.UIRichTextBox txtQuery;
        private Sunny.UI.UIGroupBox uiGroupBox2;
        private Sunny.UI.UIRichTextBox txtOutput;
        private Sunny.UI.UIProcessBar loadProgressBar;
    }
}