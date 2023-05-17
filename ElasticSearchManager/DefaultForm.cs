using ElasticSearchManager.Data;
using Sunny.UI;

namespace ElasticSearchManager
{
    public partial class DefaultForm : UIForm
    {
        private string url = "http://192.168.59.1:9200";

        private string user = "none";

        private string query = "SELECT author,content,language FROM music";

        private string output;

        private bool isValid;

        private bool hasConnection;

        private ElasticRepository elasticRepository;

        public DefaultForm()
        {
            InitializeComponent();
            this.txtUri.Text = url;
            this.txtQuery.Text = query;
        }

        /// <summary>
        /// WinForms中的控件只能在UI线程上访问和更新。
        /// 在 Task.Run 中的异步操作可能在不同的线程上执行，因此在访问或更新控件时需要确保线程安全。
        /// 可以使用 Control.Invoke 或 Control.BeginInvoke 方法将操作发送到UI线程上执行。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void btnConnect_Click(object sender, EventArgs e)
        {
            this.loadProgressBar.Visible = true;
            try
            {
                await Task.Run(async () =>
                {
                    try
                    {
                        this.elasticRepository = new ElasticRepository(this.txtUri.Text, "admin", "123");
                        await this.elasticRepository.PingElastic();
                        this.txtOutput.Invoke((Action)(() =>
                        {
                            this.txtOutput.Text = "连接有效";
                        }));
                        this.hasConnection = true;
                    }
                    catch (Exception exception)
                    {
                        this.txtOutput.Invoke((Action)(() =>
                        {
                            this.txtOutput.Text = exception.ToString();
                        }));
                    }
                });
            }
            finally
            {
                this.loadProgressBar.Invoke((Action)(() =>
                {
                    this.loadProgressBar.Visible = false;
                }));
            }
        }

        /// <summary>
        /// 异步方法写法二
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void btnValidate_Click(object sender, EventArgs e)
        {
            this.loadProgressBar.Visible = true;
            try
            {
                var result = await this.elasticRepository.RunSingleQuery(this.txtQuery.Text);
                this.txtOutput.Text = $"有效请求,返回第一行: {result}";
                this.isValid = true;
            }
            catch (Exception exception)
            {
                this.txtOutput.Text = exception.ToString();
            }
            finally
            {
                this.loadProgressBar.Visible = false;
            }
        }

        private async void btnExport_Click(object sender, EventArgs e)
        {
            this.loadProgressBar.Visible = true;
            try
            {
                var saveFileDialog = new SaveFileDialog();
                saveFileDialog.FileName = $"{DateTime.Now.ToFileTimeUtc()}.csv";
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    var result = await this.elasticRepository.QueryComplete(this.txtQuery.Text);
                    await File.WriteAllTextAsync(saveFileDialog.FileName, result);
                    this.txtOutput.Text = $"导出文件 {saveFileDialog.FileName}";
                }
            }
            catch (Exception exception)
            {
                this.txtOutput.Text = exception.ToString();
            }
            finally
            {
                this.loadProgressBar.Visible = false;
            }
        }
    }
}