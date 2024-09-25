using MyToDo1.Common.Models;
using MyToDo1.Extentions;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Prism.Navigation.Regions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Media3D;
using static Microsoft.WindowsAPICodePack.Shell.PropertySystem.SystemProperties.System;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;

namespace MyToDo1.ViewModels
{
    internal class DetailViewModel : NavigationViewModel
    {
        Object material = new Object();
        Object time = new Object();
        string folderPath;
        int lowThreshold;
        int highThreshold;
        int number;
        string imageType;
        DetailBar defaultDetailBar;
        public DelegateCommand<DetailBar> ViewCommand { get; private set; }
        public DelegateCommand LikeCommand { get; private set; }
        public DetailViewModel(IContainerProvider provider) : base(provider)
        {
            folderPath = "";
            originalImagePath = "";
            contourImagePath = "";
            thresholdImagePath = "";
            imagePaths = new List<string>();
            DetailBars = new ObservableCollection<DetailBar>();
            ViewCommand = new DelegateCommand<DetailBar>(ViewDetails);
            LikeCommand = new DelegateCommand(Like);
            imageType = ".jpg";
            isLikedPara = false;
        }

        private void Like()
        {
            try
            {
                // 获取当前exe文件所在的目录
                string exeDirectory = AppDomain.CurrentDomain.BaseDirectory;

                // 创建目标文件夹路径 (LikedImages 文件夹)
                string likedImagesFolder = Path.Combine(exeDirectory, "LikedImages");

                // 如果文件夹不存在，则创建该文件夹
                if (!Directory.Exists(likedImagesFolder))
                {
                    Directory.CreateDirectory(likedImagesFolder);
                }

                // 获取源文件的文件名
                string imageFileName = Path.GetFileName(OriginalImagePath);

                // 生成目标文件路径
                string destinationPath = Path.Combine(likedImagesFolder, imageFileName);

                // 将原图复制到 LikedImages 文件夹中
                File.Copy(OriginalImagePath, destinationPath, overwrite: true);

                // 提示成功
                Console.WriteLine($"Image copied to: {destinationPath}");

                CurrentDetailBar.IsLiked = true;
            }
            catch (Exception ex)
            {
                // 处理可能出现的异常
                Console.WriteLine($"Error: {ex.Message}");
            }

        }

        private ObservableCollection<DetailBar> detailBars;
        public ObservableCollection<DetailBar> DetailBars
        {
            get { return detailBars; }
            set { detailBars = value; RaisePropertyChanged(); }
        }
        private string originalImagePath;
        private string contourImagePath;
        private string thresholdImagePath;
        private List<string> imagePaths;
        public string OriginalImagePath
        {
            get => originalImagePath;
            set { originalImagePath = value; RaisePropertyChanged(); }
        }

        public string ContourImagePath
        {
            get => contourImagePath;
            set { contourImagePath = value; RaisePropertyChanged(); }
        }

        public string ThresholdImagePath
        {
            get => thresholdImagePath;
            set { thresholdImagePath = value; RaisePropertyChanged(); }
        }
        public List<string> ImagePaths
        {
            get => imagePaths; set => imagePaths = value;
        }
        private ObservableCollection<int> thresholdsItemsource;
        public ObservableCollection<int> ThresholdsItemSource
        {
            get { return thresholdsItemsource; }
            set { thresholdsItemsource = value; RaisePropertyChanged(); }
        }

        private List<int> thresholds;
        public List<int> Thresholds
        {
            get { return thresholds; }
            set { thresholds = value; }
        }
        private int _selectedThreshold;
        public int SelectedThreshold
        {
            get => _selectedThreshold;
            set
            {
                SetProperty(ref _selectedThreshold, value);
                Updatedetails();
            }
        }
        private DetailBar currentDetailBar;
        public DetailBar CurrentDetailBar
        {
            get { return currentDetailBar; }
            set { currentDetailBar = value; RaisePropertyChanged(); }
        }

        private Boolean isLikedPara;
        public Boolean IsLikedPara
        {
            get { return isLikedPara; }
            set
            {
                if (isLikedPara != value)
                {
                    isLikedPara = value;
                    RaisePropertyChanged(nameof(IsLikedPara)); // 明确指定属性名
                }
            }
        }


        public bool IsNavigationTarget(NavigationContext navigationContext)
        {
            throw new NotImplementedException();
        }

        public void OnNavigatedFrom(NavigationContext navigationContext)
        {
            throw new NotImplementedException();
        }

        public override void OnNavigatedTo(NavigationContext navigationContext)
        {

            imagePaths.Clear();

            base.OnNavigatedTo(navigationContext);

            material = new Object();
            time = new Object();

            if (navigationContext.Parameters.ContainsKey("Material"))
            {
                material = navigationContext.Parameters["Material"];
            }

            if (navigationContext.Parameters.ContainsKey("Time"))
            {
                time = navigationContext.Parameters["Time"];
            }
            // 获取当前运行目录
            string exeDirectory = AppDomain.CurrentDomain.BaseDirectory; // 获取当前 exe 文件所在的目录
            string processedImagePath = Path.Combine(exeDirectory, "Processed_Image"); // 构建指向 "Processed_Image" 文件夹的路径
            folderPath = processedImagePath + "\\" + material.ToString() + "-" + time.ToString();

            string[] fileNames = Directory.GetFiles(folderPath);

            // 遍历所有文件名
            foreach (string path in fileNames)
            {
                string fileName = Path.GetFileName(path);  // 仅获取文件名部分

                // 检查文件名是否包含 "original"
                if (fileName.Contains("original"))
                {
                    // 分割字符串并获取 _original 之前的部分
                    string baseName = fileName.Split(new[] { "_original" }, StringSplitOptions.None)[0];
                    imagePaths.Add(baseName);
                }
            }
            // imagePaths.Reverse();
            CreateDetailBars();

            string dataFilePath = Path.Combine(folderPath, "data.json");

            if (File.Exists(dataFilePath))
            {
                string jsonContent = File.ReadAllText(dataFilePath);
                JObject jsonObj = JObject.Parse(jsonContent);
                var x1Value = jsonObj["x_1"]?.ToString();
                var x2Value = jsonObj["x_2"]?.ToString();
                var y1Value = jsonObj["y_1"]?.ToString();
                var y2Value = jsonObj["y_1"]?.ToString();
                var xStepLength = jsonObj["xStepLength"]?.ToString();
                var yStepLength = jsonObj["yStepLength"]?.ToString();

            }
            else
            {
                // 处理文件不存在的情况
            }

            string parametersFilePath = Path.Combine(folderPath, "parameters.json");

            if (File.Exists(parametersFilePath))
            {
                string jsonContent = File.ReadAllText(parametersFilePath);
                JObject jsonObj = JObject.Parse(jsonContent);
                lowThreshold = jsonObj["LowThreshold"] != null ? Convert.ToInt32(jsonObj["LowThreshold"]) : 100;
                highThreshold = jsonObj["HighThreshold"] != null ? Convert.ToInt32(jsonObj["HighThreshold"]) : 170;
                number = jsonObj["Number"] != null ? Convert.ToInt32(jsonObj["Number"]) : 5;

                thresholds = Linspace(lowThreshold, highThreshold, number);
                ThresholdsItemSource = new ObservableCollection<int>(thresholds);
                Debug.WriteLine(ThresholdsItemSource.ToList<int>());
            }
            else
            {
                // 处理文件不存在的情况
            }
            SelectedThreshold = ThresholdsItemSource[0];
            OriginalImagePath = folderPath + "\\" + defaultDetailBar.FileName + "_original" + imageType;
            ContourImagePath = folderPath + "\\" + defaultDetailBar.FileName + "_contours_" + SelectedThreshold.ToString() + imageType;
            ThresholdImagePath = folderPath + "\\" + defaultDetailBar.FileName + "_threshold_" + SelectedThreshold.ToString() + imageType;


        }

        private void ViewDetails(DetailBar obj)
        {
            string exeDirectory = AppDomain.CurrentDomain.BaseDirectory; // 获取当前 exe 文件所在的目录
            string processedImagePath = Path.Combine(exeDirectory, "Processed_Image"); // 构建指向 "Processed_Image" 文件夹的路径

            if (obj == null || string.IsNullOrWhiteSpace(obj.FileName))
                return;

            OriginalImagePath = folderPath + "\\" + obj.FileName + "_original" + imageType;
            ContourImagePath = folderPath + "\\" + obj.FileName + "_contours_" + SelectedThreshold.ToString() + imageType;
            ThresholdImagePath = folderPath + "\\" + obj.FileName + "_threshold_" + SelectedThreshold.ToString() + imageType;

            CurrentDetailBar = obj;
            isLikedPara = CurrentDetailBar.IsLiked;
        }

        private void Updatedetails()
        {
            ContourImagePath = Regex.Replace(ContourImagePath, @"\d+(?=\D*$)", SelectedThreshold.ToString());
            ThresholdImagePath = Regex.Replace(ThresholdImagePath, @"\d+(?=\D*$)", SelectedThreshold.ToString());
        }

        private void InitializeInformation()
        {

        }

        void CreateDetailBars()
        {
            DetailBars.Clear();
            foreach (string prefix in imagePaths)
            {
                DetailBars.Add(new DetailBar() { Title = prefix, FileName = prefix, NameSpace = "DetailView", IsLiked = false});
            }
            defaultDetailBar = DetailBars[0];
        }

        static List<int> Linspace(int t_min, int t_max, int n)
        {
            List<int> result = new List<int>();

            if (n < 2)
            {
                result.Add(t_min);  // 如果 n 小于 2，就只返回 t_min
                return result;
            }

            // 计算整数步长，并处理余数
            int step = (t_max - t_min) / (n - 1);
            int remainder = (t_max - t_min) % (n - 1); // 余数用于调整误差

            int current = t_min;
            int errorAccumulator = 0;

            for (int i = 0; i < n - 1; i++)
            {
                result.Add(current);
                current += step;

                // 处理余数以尽量保持精度
                errorAccumulator += remainder;
                if (errorAccumulator >= (n - 1))
                {
                    current++;
                    errorAccumulator -= (n - 1);
                }
            }

            // 确保最后一个值是 t_max
            result.Add(t_max);

            return result;
        }

        void CreateThresholdComboBox()
        {
            string exeDirectory = AppDomain.CurrentDomain.BaseDirectory; // 获取当前 exe 文件所在的目录
            string processedImagePath = Path.Combine(exeDirectory, "Processed_Image"); // 构建指向 "Processed_Image" 文件夹的路径
            folderPath = processedImagePath + "\\" + material.ToString() + "-" + time.ToString();

            string[] fileNames = Directory.GetFiles(folderPath);
            string parametersFilePath = Path.Combine(folderPath, "parameters.json");

            if (File.Exists(parametersFilePath))
            {
                string jsonContent = File.ReadAllText(parametersFilePath);
                JObject jsonObj = JObject.Parse(jsonContent);
                lowThreshold = jsonObj["LowThreshold"] != null ? Convert.ToInt32(jsonObj["LowThreshold"]) : 100;
                highThreshold = jsonObj["HighThreshold"] != null ? Convert.ToInt32(jsonObj["HighThreshold"]) : 170;
                number = jsonObj["Number"] != null ? Convert.ToInt32(jsonObj["Number"]) : 5;
                thresholds = Linspace(lowThreshold, highThreshold, number);
                ThresholdsItemSource = new ObservableCollection<int>(thresholds);
            }
            else
            {

            }
        }


    }
}
