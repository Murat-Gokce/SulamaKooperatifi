using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SulamaKoparatifi
{
    public partial class Girisi : Form
    {
        public Girisi()
        {
            InitializeComponent();
        }
        int baslagic;
    
        private void timer1_Tick(object sender, EventArgs e)
        {
            baslagic += 1;
            progressm.Value = baslagic;
            if (progressm.Value == 100)
            {
                progressm.Value = 0;
                timer1.Stop();
                this.Hide();
                Parola qwe = new Parola();
                qwe.Show();
            }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {

        }

        private void progressBar1_Click(object sender, EventArgs e)
        {

        }

        private void Girisi_Load(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
