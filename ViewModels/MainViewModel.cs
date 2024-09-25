using MyToDo1.Common.Models;
using MyToDo1.Extentions;
using MyToDo1.Views;
using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Reflection.Metadata;
using System.Windows.Media.Imaging;

namespace MyToDo1.ViewModels
{
    internal class MainViewModel : BindableBase
    {
        private readonly IRegionManager regionManager;
        private IRegionNavigationJournal journal;

        public MainViewModel(IRegionManager regionManager)
        {
            LoadImage();
            menuBars = new ObservableCollection<MenuBar>();
            CreateMenuBar();
            NavigateCommand = new DelegateCommand<MenuBar>(Navigate);
            this.regionManager = regionManager;

            GoBackCommand = new DelegateCommand(() =>
            {
                if (journal != null && journal.CanGoBack)
                    journal.GoBack();
            });
            GoForwardCommand = new DelegateCommand(() =>
            {
                if (journal != null && journal.CanGoForward)
                    journal.GoForward();
            });
        }

        private void Navigate(MenuBar obj)
        {
            if (obj == null || string.IsNullOrWhiteSpace(obj.NameSpace))
                return;

            // 普通导航逻辑
            regionManager.Regions[PrismManager.MainViewRegionName].RequestNavigate(obj.NameSpace, back =>
            {
                journal = back.Context.NavigationService.Journal;
            });
        }

        private ObservableCollection<MenuBar> menuBars;
        private object _controller;
        private object _actionSource;

        public DelegateCommand<MenuBar> NavigateCommand { get; private set; }
        public DelegateCommand GoBackCommand { get; private set; }
        public DelegateCommand GoForwardCommand { get; private set; }

        public ObservableCollection<MenuBar> MenuBars
        {
            get { return menuBars; }
            set { menuBars = value; }
        }

        private string _imageSource;
        public string ImageSource
        {
            get => _imageSource;
            set
            {
                _imageSource = value;
            }
        }

        private void LoadImage()
        {
            // 获取当前exe文件所在目录
            string exeDirectory = AppDomain.CurrentDomain.BaseDirectory;

            // 构建相对路径指向Image文件夹
            string imagePath = exeDirectory + "Images\\UserImages\\" + "W-Logo_Purple_RGB.png";

            ImageSource = imagePath;
        }

        public event PropertyChangedEventHandler PropertyChanged;

       

        void CreateMenuBar()
        {
            MenuBars.Add(new MenuBar() { Icon = "Home", Title = "Index", NameSpace = "IndexView" });
            MenuBars.Add(new MenuBar() { Icon = "CameraOutline", Title = "Process", NameSpace = "ProcessView" });
            MenuBars.Add(new MenuBar() { Icon = "NotebookOutline", Title = "My Scans", NameSpace = "ToDoView" });
            MenuBars.Add(new MenuBar() { Icon = "Notebook", Title = "备忘录", NameSpace = "MemoView" });
            MenuBars.Add(new MenuBar() { Icon = "Cog", Title = "Settings", NameSpace = "SettingsView" });

        }
    }
}
