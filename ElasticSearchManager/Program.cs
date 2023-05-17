using Autofac;
using ElasticSearchManager.utils;
using Microsoft.Extensions.DependencyInjection;

namespace ElasticSearchManager
{
    internal static class Program
    {

        private static IContainer _container;

        public static IServiceProvider ServiceProvider;
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            #region NET�Դ�����ע��
            // ���� DI ����
            var services = new ServiceCollection();

            // ע��������ϵ
            services.AddSingleton<IDocumentFactory, DocumentFactory>();
            //// ע�� MainForm ��
            //services.AddSingleton<MainForm>();


            // ���� ServiceProvider
            var serviceProvider = services.BuildServiceProvider();
            ServiceProvider= serviceProvider;

            //// ��ȡ IDocumentFactory ����
            //var documentFactory = serviceProvider.GetService<IDocumentFactory>();
            // ��ȡ MainForm ����
            //var mainForm = serviceProvider.GetRequiredService<MainForm>();

            //// ʹ�� IDocumentFactory ���� Document ����
            //var document = documentFactory.CreateDocument(); 
            #endregion

            #region Autofac����ע��
            //var builder = new ContainerBuilder();

            //// ע��������ϵ
            //builder.RegisterType<DocumentFactory>().As<IDocumentFactory>().InstancePerLifetimeScope();

            //// ��������
            //_container = builder.Build();
            #endregion


            ApplicationConfiguration.Initialize();
            //Application.Run(mainForm);
            //Application.Run(new MainForm(_container));
            //Application.Run(new MainForm());
            Application.Run(new DefaultForm());



        }
    }
}