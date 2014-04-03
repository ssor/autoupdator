using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace startCMD
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //startSupervisor();
            //Console.WriteLine(this.RunCmd("dir"));
        }
        private void startSupervisor()
        {
            Thread thread = new Thread(new ThreadStart(() =>
            {
                Console.WriteLine(this.RunCmd("supervisor C:\\program\\nodejs\\tekbox\\app"));
            }));
            thread.IsBackground = true;//设置为true，则当主线程结束后强迫结束子线程，否则主线程退出后子线程依旧运行
            thread.Start();
        }
        private string RunCmd(string _command)
        {
            Process p = new Process();
            p.StartInfo.FileName = "cmd.exe";
            p.StartInfo.Arguments = "/c " + _command;
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.RedirectStandardInput = true;
            p.StartInfo.RedirectStandardOutput = true;
            p.StartInfo.RedirectStandardError = true;
            p.StartInfo.CreateNoWindow = true;

            p.Start();

            return p.StandardOutput.ReadToEnd();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            KnightsWarriorAutoupdater.AutoUpdater updater = new KnightsWarriorAutoupdater.AutoUpdater();
            updater.Update();
        }

    }
}
