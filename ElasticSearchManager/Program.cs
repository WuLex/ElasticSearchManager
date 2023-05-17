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
            #region NET自带依赖注入
            // 创建 DI 容器
            var services = new ServiceCollection();

            // 注册依赖关系
            services.AddSingleton<IDocumentFactory, DocumentFactory>();
            //// 注册 MainForm 类
            //services.AddSingleton<MainForm>();


            // 创建 ServiceProvider
            var serviceProvider = services.BuildServiceProvider();
            ServiceProvider= serviceProvider;

            //// 获取 IDocumentFactory 对象
            //var documentFactory = serviceProvider.GetService<IDocumentFactory>();
            // 获取 MainForm 对象
            //var mainForm = serviceProvider.GetRequiredService<MainForm>();

            //// 使用 IDocumentFactory 创建 Document 对象
            //var document = documentFactory.CreateDocument(); 
            #endregion

            #region Autofac依赖注入
            //var builder = new ContainerBuilder();

            //// 注册依赖关系
            //builder.RegisterType<DocumentFactory>().As<IDocumentFactory>().InstancePerLifetimeScope();

            //// 创建容器
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