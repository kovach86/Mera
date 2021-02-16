using Autofac;
using Core.DatabaseLayer;
using Repositories.Interfaces;
using Repositories.Repos;
using Services.TextReaders;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Services.Description;
using System.Windows;
using System.Windows.Markup;
using TextOperationServices;
using TextOperationServices.Interfaces;

namespace MainProgram
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            var containerBuilder = new ContainerBuilder();
            containerBuilder.RegisterType<SavedTextDbContext>().AsSelf().SingleInstance();
            containerBuilder.RegisterType<SavedTextRepository>().As<ISavedTextRepository>().InstancePerLifetimeScope();
            containerBuilder.RegisterType<TextService>().As<ITextService>().InstancePerLifetimeScope();

            var containerInjector = containerBuilder.Build();
            var main = new MainWindow(containerInjector.Resolve<ISavedTextRepository>());
            main.Show();
        }
    }
}
