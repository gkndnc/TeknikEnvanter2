using System;
using System.ComponentModel;
using System.Threading;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
       private EventConsumer consumer = new EventConsumer();
        public Form1()
        {
            InitializeComponent();
            initializeBase();
        }

        private void initializeBase()
        {
            backgroundWorker1.WorkerReportsProgress = true;
            backgroundWorker1.WorkerSupportsCancellation = true;

            backgroundWorker2.WorkerReportsProgress = true;
            backgroundWorker2.WorkerSupportsCancellation = true;
            backgroundWorker2.DoWork += BackgroundWorker2_DoWork;
            backgroundWorker2.ProgressChanged += BackgroundWorker2_ProgressChanged;
            backgroundWorker2.RunWorkerCompleted += BackgroundWorker2_RunWorkerCompleted;
        }


        # region Events
        private void BackgroundWorker2_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
        }

        private void BackgroundWorker2_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar2.Value = e.ProgressPercentage;

        }

        private void BackgroundWorker2_DoWork(object sender, DoWorkEventArgs e)
        {
            while (true)
            {
                Thread.Sleep(1000);
                backgroundWorker2.ReportProgress(consumer.completedCount);
                if (consumer.completedCount >= 400)
                    break;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            progressBar1.Maximum = 400;
            progressBar2.Maximum = 400;
            backgroundWorker1.RunWorkerAsync();
            backgroundWorker2.RunWorkerAsync();
            button1.Enabled = false;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
           
            EventProducer producer = new EventProducer(consumer);
            producer.Produce();
            
            while (true)
            {
                Thread.Sleep(1000);
                backgroundWorker1.ReportProgress(producer.EventCount);
                if (producer.EventCount >= 400)
                    break;
            }
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage;
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
             button1.Enabled = true;
        }

        private void backgroundWorker2_DoWork(object sender, DoWorkEventArgs e)
        {

        }
 #endregion
    }
}
