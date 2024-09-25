using MyToDo1.ViewModels;
using MyToDo1.Views;
using Prism.DryIoc;
using Prism.Ioc;
using System;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Windows;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace MyToDo1
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : PrismApplication
    {
        protected override Window CreateShell()
        {
            return Container.Resolve<MainView>();
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<DetailView, DetailViewModel>();
            containerRegistry.RegisterForNavigation<AboutView>();
            containerRegistry.RegisterForNavigation<ProcessView, ProcessViewModel>();
            containerRegistry.RegisterForNavigation<SkinView, SkinViewModel>();
            containerRegistry.RegisterForNavigation<IndexView, IndexViewModel>();
            containerRegistry.RegisterForNavigation<MemoView, MemoViewModel>();
            containerRegistry.RegisterForNavigation<SettingsView, SettingsViewModel>();
            containerRegistry.RegisterForNavigation<ToDoView, ToDoViewModel>();
            

        }
    }

}
