using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DauaAisGek
{
    public partial class FrmKlt : Form
    {
        public FrmKlt()
        {
            InitializeComponent();
            DatBeg.Format = DateTimePickerFormat.Custom;
            DatBeg.CustomFormat = "dd.MM.yyyy";
            DatEnd.Format = DateTimePickerFormat.Custom;
            DatEnd.CustomFormat = "dd.MM.yyyy";
        }

        private void ButWrt_Click(object sender, EventArgs e)
        {
            //  EmulMouseEvents. TxtIinBeg.Text;
            //            TxtPod.Text, TxtEml.Text, TxtRab.Text, TxtDlg.Text);
            Hide();

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void DatBeg_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
