using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BackgrounWorkerApp
{
    public partial class Form1 : Form
    {
        //디자인에 BackgroundWorker 추가안하고 코딩에 썼을경우 사용하는 방법
        //public BackgroundWorker BgwTest { get; set; }
        public Form1()
        {
            InitializeComponent();
            //BgwTest = new BackgroundWorker();
            //BgwTest.DoWork += BgwTest_DoWork;
            //BgwTest.ProgressChanged += BgwTest_ProgressChanged;
            //BgwTest.RunWorkerCompleted += BgwTest_RunWorkerCompleted;
        }

        private void BtnStart_Click(object sender, EventArgs e)
        {
            if(BgwTest.IsBusy != true)
            {
                BgwTest.RunWorkerAsync(); //BackgroundWorker실행
                LblResult.Text = "실행";
            }
        }

        private void BtnCancle_Click(object sender, EventArgs e)
        {
            if(BgwTest.WorkerSupportsCancellation)
            {
                BgwTest.CancelAsync(); //BackgroundWorker실행취소
                LblResult.Text = "실행취소";
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            BgwTest.WorkerReportsProgress = true;
            BgwTest.WorkerSupportsCancellation = true;
        }

        private void BgwTest_DoWork(object sender, DoWorkEventArgs e)
        {
            var worker = sender as BackgroundWorker;
            for (int i = 0; i < 100; i++)
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
            if(e.Cancelled)
            {
                LblResult.Text = "실행취소";
            }
            else if(e.Error!=null)
            {
                LblResult.Text = $"에러 : {e.Error.Message}";
            }
            else
            {
                LblResult.Text = "실행완료";
            }
        }
    }
}
