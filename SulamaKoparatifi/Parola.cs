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
    public partial class Parola : Form
    {
        public Parola()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {

            if (girkul.Text == "" || girsifre.Text == "")
            {
                MessageBox.Show("Lütfen Bilgilerinizi Giriniz:");
            }
            else if (girkul.Text == "kocaksulama" || girsifre.Text == "kocaksulama")
            {
                this.Hide();
                Anasayfa afm = new Anasayfa();
                afm.Show();
            }
            else
            {
                MessageBox.Show("Yanlış Kullanıcı Adı Ve Şifre:");
            }
        }

        private void Parola_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

            DialogResult sonuc;
            sonuc = MessageBox.Show("Çıkmak İstediğinizden Emin misiniz ?", "Çıkış", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (sonuc == DialogResult.No)
            {
                //MessageBox.Show("");// hiçbir işlem yaptırmıyorum
            }
            if (sonuc == DialogResult.Yes)
            {
                this.Close();
                Application.Exit();
            }
        }
    }
}
