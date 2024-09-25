using MyToDo1.Common.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyToDo1.ViewModels
{
    public class IndexViewModel : BindableBase
    {

        public IndexViewModel()
        {
            TaskBars = new ObservableCollection<TaskBar>();
            CreateTaskBars();
            CreateTestData();
        }
        //----------------------
        private ObservableCollection<TaskBar> taskBars;
        public ObservableCollection<TaskBar> TaskBars
        {
            get { return taskBars; }
            set { taskBars = value; RaisePropertyChanged(); }
        }
        //----------------------
        private ObservableCollection<ToDoDto> toDoDtos;
        public ObservableCollection<ToDoDto> ToDoDtos
        {
            get { return toDoDtos; }
            set { toDoDtos = value; RaisePropertyChanged(); }
        }
        //-----------------------
        private ObservableCollection<MemoDto> memoDtos;
        public ObservableCollection<MemoDto> MemoDtos
        {
            get { return memoDtos; }
            set { memoDtos = value; RaisePropertyChanged(); }
        }

        void CreateTaskBars()
        {
            TaskBars.Add(new TaskBar() { Icon = "ClockFast", Title = "Total", Content = "9", Color = "#b7a57a", Target = "" });
            TaskBars.Add(new TaskBar() { Icon = "ClockCheckOutLine", Title = "Viewed", Content = "9", Color = "#4b2e83", Target = "" });
            TaskBars.Add(new TaskBar() { Icon = "ChartLineVarient", Title = "Liked", Content = "100%", Color = "#85754d", Target = "" });
            TaskBars.Add(new TaskBar() { Icon = "PlaylistStar", Title = "Memo", Content = "19", Color = "#c5b4e3", Target = "" });

        }

        void CreateTestData()
        {
            ToDoDtos = new ObservableCollection<ToDoDto>();
            MemoDtos = new ObservableCollection<MemoDto>();

            for (int i = 0; i < 10; i++)
            {
                ToDoDtos.Add(new ToDoDto() { Title = "待办" + i, Content = "正在处理中" + i });
                MemoDtos.Add(new MemoDto() { Title = "备忘" + i, Content = "我的密码" + i });
            }
        }
    }
}
