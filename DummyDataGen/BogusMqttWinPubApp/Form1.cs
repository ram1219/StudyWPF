﻿using Bogus;
using MetroFramework.Forms;
using Newtonsoft.Json;
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
using uPLibrary.Networking.M2Mqtt;

namespace BogusMqttWinPubApp
{
    public partial class MainForm : MetroForm
    {
        BackgroundWorker MqttWorker;
        public string MqttBrokerUrl { get; set; }
        public MqttClient BrokerClient { get; set; }
        private Thread MqttThread { get; set; }
        private Faker<SensorInfo> SensorFaker { get; set; }
        private static string CurrValue { get; set; }
        public MainForm()
        {
            InitializeComponent();
            InitializeAll(); //전체 초기화
        }

        private void InitializeAll()
        {
            MqttWorker = new BackgroundWorker();
            MqttWorker.DoWork += BgwTest_DoWork;
            MqttWorker.WorkerReportsProgress = false;
            MqttWorker.WorkerSupportsCancellation = true;

            MqttBrokerUrl = "localhost"; //또는 127.0.0.1 or IP주소 넣기

            string[] Rooms = new[] { "DiningRoom", "LivingRoom", "BathRoom", "BedRoom" };

            SensorFaker = new Faker<SensorInfo>()
                .RuleFor(s => s.Dev_Id, f => f.PickRandom(Rooms))
                .RuleFor(s => s.Curr_Time, f => f.Date.Past(0).ToString("yyyy-MM-dd HH:mm:ss.ff")) //0 현재 시분초 들어감
                .RuleFor(s => s.Temp, f => float.Parse(f.Random.Float(19.0f, 35.9f).ToString("0.00")))
                .RuleFor(s => s.Humid, f => float.Parse(f.Random.Float(40.0f, 63.9f).ToString("0.0")))
                .RuleFor(s => s.Press, f => float.Parse(f.Random.Float(800.0f, 999.0f).ToString("0.0")));
        }
        private void BgwTest_DoWork(object sender, DoWorkEventArgs e)
        {
            LoopPublish();
        }

        private void BtnConect_Click(object sender, EventArgs e)
        {
            ConnectMqttBroker(); //MQTT 브로커 접속
            //StartPublish(); //FAKE센싱 메세지 전송
            MqttWorker.RunWorkerAsync();
        }

        private void StartPublish()
        {
            MqttThread = new Thread(new ThreadStart(LoopPublish));
            //MqttThread = new Thread(() => LoopPublish);
            MqttThread.Start();
        }

        private void LoopPublish()
        {
            while (true)
            {
                SensorInfo value = SensorFaker.Generate();
                CurrValue = JsonConvert.SerializeObject(value, Formatting.Indented);
                BrokerClient.Publish("home/device/data/", Encoding.Default.GetBytes(CurrValue));
                //Console.WriteLine($"Published : {CurrValue}");
                this.Invoke(new Action(() =>
                {
                    RtbLog.AppendText($"Published : {CurrValue}\n");
                    RtbLog.ScrollToCaret();
                }));
                Thread.Sleep(1000); //1sec
            }
        }

        private void ConnectMqttBroker()
        {
            MqttBrokerUrl = TxtBrokerIp.Text;
            BrokerClient = new MqttClient(MqttBrokerUrl);
            BrokerClient.Connect("FakerDemon");
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(MqttWorker.IsBusy)
            {
                MqttWorker.CancelAsync();
                MqttWorker.Dispose();
            }
            Environment.Exit(0);
        }
    }
}
