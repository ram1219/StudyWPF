using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
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

namespace WpfBackgroundWorkerApp
{
    /// <summary>
    /// MainWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MainWindow : Window
    {
        public BackgroundWorker BgwTest { get; set; }
        public MainWindow()
        {
            InitializeComponent();
            BgwTest = new BackgroundWorker();
            BgwTest.DoWork += BgwTest_DoWork;
            BgwTest.ProgressChanged += BgwTest_ProgressChanged;
            BgwTest.RunWorkerCompleted += BgwTest_RunWorkerCompleted;

            BgwTest.WorkerReportsProgress = true;
            BgwTest.WorkerSupportsCancellation = true;
        }
        private void BtnStart_Click(object sender, EventArgs e)
        {
            if (BgwTest.IsBusy != true)
            {
                BgwTest.RunWorkerAsync(); //BackgroundWorker실행
                LblResult.Content = "실행";
            }
        }

        private void BtnCancle_Click(object sender, EventArgs e)
        {
            if (BgwTest.WorkerSupportsCancellation)
            {
                BgwTest.CancelAsync(); //BackgroundWorker실행취소
                LblResult.Content = "실행취소";
            }
        }

        private void BgwTest_DoWork(object sender, DoWorkEventArgs e)
        {
            var worker = sender as BackgroundWorker;
            for (int i = 0; i <= 100; i++)
            {
                if (worker.CancellationPending)
                {
                    e.Cancel = true;
                    break;
                }
                else
                {
                    Thread.Sleep(20);
                    worker.ReportProgress(i);
                }
            }
        }

        private void BgwTest_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            //LblResult.Text = $"{e.ProgressPercentage} %";
            PgbTest.Value = e.ProgressPercentage;

        }

        private void BgwTest_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled)
            {
                LblResult.Content = "실행취소";
            }
            else if (e.Error != null)
            {
                LblResult.Content = $"에러 : {e.Error.Message}";
            }
            else
            {
                LblResult.Content = "실행완료";
            }
        }

    
    }
}

