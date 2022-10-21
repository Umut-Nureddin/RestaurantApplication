using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HiPOS
{
    public partial class frmPreloader : Form
    {
        int saniye = 30;

        public frmPreloader()
        {
            InitializeComponent();
        }

        private void frmPreloader_Load(object sender, EventArgs e)
        {


            PreloaderTimer.Start();


        }

        private void PreloaderTimer_Tick(object sender, EventArgs e)
        {
            saniye--;

            if (saniye == 0)
            {

                frmAnaSayfa frmana = new frmAnaSayfa();
                this.Hide();
                frmana.Show();
            }
        }
    }
}
