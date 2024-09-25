using MaterialDesignThemes.Wpf;
using Microsoft.WindowsAPICodePack.Dialogs;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace MyToDo1.Views
{
    /// <summary>
    /// ProcessView.xaml 的交互逻辑
    /// </summary>
    public partial class ProcessView : UserControl
    {
        string outputDir;
        string currentDirectory;
        string processedImageFolderPath;
        public ProcessView()
        {
            InitializeComponent();
            // 获取当前的 outputDirTextBox.Text 中的路径
            currentDirectory = Directory.GetCurrentDirectory();
            processedImageFolderPath = System.IO.Path.Combine(currentDirectory, "Processed_Image");

            // 如果文件夹不存在则创建
            if (!Directory.Exists(processedImageFolderPath))
            {
                Directory.CreateDirectory(processedImageFolderPath);
            }
            outputDirTextBox.Text = processedImageFolderPath;
            currentDirectory = processedImageFolderPath;
            selectOutputDirButton.IsEnabled = false;
            outputDirTextBox.IsEnabled = false;
            materialComboBox.SelectedIndex = 0;
            channelComboBox.SelectedIndex = 0; 
        }
        private async void startPythonBtn_Click(object sender, RoutedEventArgs e)
        {
            CreateNewFolderWithTimestamp();
            string folderPath = folderPathTextBox.Text;
            CopyDataJson(folderPath, outputDir);
            // outputDir = processedImageFolderPath;
            int lowThreshold = (int)lowThresholdNumericUD.Value;
            int highThreshold = (int)highThresholdNumericUD.Value;
            int n = numberNumericUD.Value;
            string channel = channelComboBox.Text;
            double cropRatio = cropRatioSlider.Value;

            CreateParameterJson();



            string pythonScriptPath = GetPythonScriptPath();
            string pythonExePath = @"C:\Users\Jeff\anaconda3\python.exe";

            ProcessStartInfo start = new ProcessStartInfo
            {
                FileName = pythonExePath,
                Arguments = $"{pythonScriptPath} \"{folderPath}\" \"{outputDir}\" {lowThreshold} {highThreshold} {n} {channel} {cropRatio}",
                UseShellExecute = false,
                RedirectStandardError = true,
                CreateNoWindow = true
            };

            try
            {
                using (Process process = Process.Start(start))
                {
                    await process.WaitForExitAsync();  // 等待脚本执行完毕的异步操作

                    if (process.ExitCode == 0)
                    {
                        MessageBox.Show("Python script executed successfully.");
                    }
                    else
                    {
                        using (StreamReader errorReader = process.StandardError)
                        {
                            string error = await errorReader.ReadToEndAsync();
                            MessageBox.Show($"Python script error: {error}");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }



        private void selectFolderPathBtn_Click(object sender, RoutedEventArgs e)
        {
            var folderDialog = new CommonOpenFileDialog
            {
                IsFolderPicker = true,
                Title = "Select the folder where you want to save your photos"
            };

            // 显示对话框并获取用户的选择结果
            if (folderDialog.ShowDialog() == CommonFileDialogResult.Ok && !string.IsNullOrWhiteSpace(folderDialog.FileName))
            {
                // 设置当前工作目录为用户选择的路径
                Directory.SetCurrentDirectory(folderDialog.FileName);

                // 保存选择的路径到控制器的模型（可选）
                // _controller.GetModel().SaveDirectory = folderDialog.FileName;

                // 提示用户选择的路径
                MessageBox.Show("Selected Folder: " + folderDialog.FileName, "Folder Selected", MessageBoxButton.OK, MessageBoxImage.Information);

                // 设置设计器中的Label文本为选择的路径
                folderPathTextBox.Text = folderDialog.FileName;
            }
            else
            {
                MessageBox.Show("No folder selected. The default save location will be used.", "No Folder Selected", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void selectOutputDirButton_Click(object sender, RoutedEventArgs e)
        {
            // 获取当前运行目录
            string defaultDirectory = System.IO.Path.Combine(Directory.GetCurrentDirectory(), "Processed_Image");

            // 如果当前目录下没有 "Processed_Image" 文件夹，创建它
            if (!Directory.Exists(defaultDirectory))
            {
                Directory.CreateDirectory(defaultDirectory);
            }

            // 初始化文件夹选择对话框
            var folderDialog = new CommonOpenFileDialog
            {
                IsFolderPicker = true,
                Title = "Select the folder where you want to save your photos"
            };

            // 显示对话框并获取用户的选择结果
            if (folderDialog.ShowDialog() == CommonFileDialogResult.Ok && !string.IsNullOrWhiteSpace(folderDialog.FileName))
            {
                // 设置当前工作目录为用户选择的路径
                Directory.SetCurrentDirectory(folderDialog.FileName);

                // 保存选择的路径到控制器的模型（可选）
                // _controller.GetModel().SaveDirectory = folderDialog.FileName;

                // 提示用户选择的路径
                MessageBox.Show("Selected Folder: " + folderDialog.FileName, "Folder Selected", MessageBoxButton.OK, MessageBoxImage.Information);

                // 设置设计器中的Label文本为选择的路径
                outputDirTextBox.Text = folderDialog.FileName;
            }
            else
            {
                // 用户未选择文件夹时，使用默认文件夹
                MessageBox.Show("No folder selected. Using default folder: " + defaultDirectory, "No Folder Selected", MessageBoxButton.OK, MessageBoxImage.Information);

                // 设置当前工作目录为默认路径
                Directory.SetCurrentDirectory(defaultDirectory);

                // 更新UI中的输出目录路径
                outputDirTextBox.Text = defaultDirectory;
            }
        }
        private void CreateNewFolderWithTimestamp()
        {

            // 获取当前的日期和时间，并将其转换为文件夹名字的格式
            string timestamp = DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss");
            string name = materialComboBox.Text + "-" + timestamp;

            // 创建一个新的文件夹路径
            string newFolderPath = System.IO.Path.Combine(currentDirectory, name);

            // 创建新的文件夹
            if (!Directory.Exists(newFolderPath))
            {
                Directory.CreateDirectory(newFolderPath);
            }

            // 将 outputDirTextBox.Text 更新为新建的文件夹路径
            outputDir = newFolderPath;

            // 提示用户已创建新文件夹
            MessageBox.Show("New folder created: " + newFolderPath, "Folder Created", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void CopyDataJson(string folderPath, string outputDir)
        {
            string sourceFilePath = System.IO.Path.Combine(folderPath, "data.json");
            string destinationFilePath = System.IO.Path.Combine(outputDir, "data.json");

            if (File.Exists(sourceFilePath))
            {
                File.Copy(sourceFilePath, destinationFilePath, overwrite: true);
            }
            else
            {
                // 处理文件不存在的情况
                throw new FileNotFoundException($"The file {sourceFilePath} does not exist.");
            }
        }

        private void CreateParameterJson()
        {
            var parameters = new
            {
                InputFolder = folderPathTextBox.Text,
                OutputFolder = outputDir,
                LowThreshold = lowThresholdNumericUD.Value,
                HighThreshold = highThresholdNumericUD.Value,
                Number = numberNumericUD.Value,
                Channel=channelComboBox.Text,
                CropRatio = cropRatioSlider.Value,
                Material=materialComboBox.Text,
            };

            // 将对象序列化为 JSON 字符串
            var jsonOptions = new JsonSerializerOptions { WriteIndented = true };
            string json = JsonSerializer.Serialize(parameters, jsonOptions);

            // 指定文件路径
            string filePath = System.IO.Path.Combine(outputDir, "parameters.json");

            // 将 JSON 字符串保存到文件中
            File.WriteAllText(filePath, json);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            // 要复制的邮箱地址
            string folderPath = outputDirTextBox.Text;

            // 将邮箱地址复制到剪贴板
            Clipboard.SetText(folderPath);

            // 显示提示信息
            //PopupText.Visibility = Visibility.Visible;

            // 设置定时器，在1.5秒后隐藏提示信息
            //DispatcherTimer timer = new DispatcherTimer();
            //timer.Interval = TimeSpan.FromSeconds(1.5);
            //timer.Tick += (s, args) =>
            //{
            //    PopupText.Visibility = Visibility.Collapsed;
            //    timer.Stop();  // 停止定时器
            //};
            //timer.Start();

        }

        public static string GetPythonScriptPath()
        {
            // 获取当前 exe 文件所在的文件夹路径
            string exeDirectory = AppDomain.CurrentDomain.BaseDirectory;

            // 构造 PythonScripts 文件夹中的 ImageProcess.py 文件的完整路径
            string scriptPath = System.IO.Path.Combine(exeDirectory, "PythonScripts", "ImageProcess.py");

            // 检测文件是否存在
            if (File.Exists(scriptPath))
            {
                return scriptPath;
            }
            else
            {
                return "ImageProcess.py 文件未找到";
            }
        }


    }
}
