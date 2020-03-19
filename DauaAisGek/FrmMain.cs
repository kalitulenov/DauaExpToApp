#region Using

using System;
using System.Windows.Forms;

using System.Security;
using System.Security.Policy;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Net;
using System.Net.Security;
using System.IO;

using System.Data;



#endregion

#region Copyright

// Пример к статье: http://www.softez.pp.ua/2015/04/27/mouse-events-emulation-geckofx/
// Автор: dredei

#endregion

namespace DauaAisGek
{
    public partial class FrmMain : Form
    {
        int I=0;

        //string Interval="10000";
        //int timerCounter = 0; //счётчик для таймера
        //System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();

        public FrmMain()
        {
            this.InitializeComponent();

            //timer.Interval = Convert.ToInt32(Interval); // 5000;
            //timer.Tick += new EventHandler(timer_Tick); //подписываемся на события Tick
            //timer.Start();
        //    while (Console.Read() != 'q') ;
        }


        private void btnStart_Click(object sender, EventArgs e)
        {
            if (I == 0)
            {
                I++;
                // создаем экземпляр класса EmulMouseEvents
                var clickClass = new EmulMouseEvents();
                clickClass.Start();
            }
        }

        //обработчик события Tick
        void timer_Tick(object sender, EventArgs e)
        {
            int i = 0;
            DateTime dt = new DateTime(2019, 1, 1);

            var clickClass = new EmulMouseEvents();
            clickClass.Start();

            //В текстбокс выводим значение timerCounter увеличенное на 1
            // this.textBox1.Text = (++timerCounter).ToString();

            //timer.Stop();
            //timer.Start();
        }

        //обработчик события Tick
        public void MsgShow(string MsgTxt)
        {
            listBox1.Items.Add(MsgTxt);
            listBox1.TopIndex = listBox1.Items.Count-1;
        }

        private void Button1_Click(object sender, EventArgs e)
        {
         //   this.Close();
        //    Application.Exit();
            Environment.Exit(0);
        }
    }
}