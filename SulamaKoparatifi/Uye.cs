using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace SulamaKoparatifi
{
    public partial class Uye : Form
    {
        public Uye()
        {
            InitializeComponent();
        }

        SqlConnection Con = new SqlConnection(@"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename=D:\Kodlar\Sulama kooparatifi\SulamaKoparatifi\SulamaKoparatifi\SULAMADB.mdf;Integrated Security = True; Connect Timeout = 30");
        private void Uye_Load(object sender, EventArgs e)
        {
            populate();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            Anasayfa u = new Anasayfa();
            u.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (uyesu.Text == "" ||aduye.Text == "" || uyebaba.Text == "" || uyetc.Text == "")
            {
                MessageBox.Show("Eksik Bilgi");
            }
            else
            {
                try
                {

                    Con.Open();
                    string ekle = "INSERT INTO UyeTbl values ('" + uyesu.Text + "','" + aduye.Text + "','" + uyebaba.Text + "','" + uyeanne.Text + "','" + uyetc.Text + "','" + uyetel.Text + "','" + uyetel.Text + "','" + uyeaciklama.Text+ "','" + uyealan.Text + "','" + uyeortakno.Text + "','" + uyeorpay.Text + "','" + uyeoden.Text + "','" + uyekalan.Text + "','" + uyegiris.Value.Date+ "','"  + uyekarar.Value.Date + "','" + uyekararno.Text + "','" + uyedevir.Text+"')";
                    SqlCommand kmt = new SqlCommand(ekle, Con);
                    kmt.ExecuteNonQuery();
                    MessageBox.Show("Kayıt Başarılı");
                    Con.Close();
                    populate();

                }
                catch (Exception hata)
                {
                    MessageBox.Show(hata.Message);
                }

            
            }
        }
        private void populate()
        {
            Con.Open();
            string ekle = "select * from UyeTbl";
            SqlDataAdapter sda = new SqlDataAdapter(ekle, Con);
            SqlCommandBuilder insa = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            Con.Close();
        }
        protected void Temizle()
        {
            uyesu.Text = "";
            aduye.Text = "";
            uyebaba.Text = "";
            uyeanne.Text = "";
            uyetc.Text = "";
            uyetel.Text = "";
            uyeadres.Text = "";
            uyeaciklama.Text = "";
            uyealan.Text = "";
            uyeortakno.Text = "";
            uyeorpay.Text = "";
            uyeoden.Text = "";
            uyekalan.Text = "";
            uyekarar.Text = "";
            uyedevir.Text = "";


        }
        private void button2_Click(object sender, EventArgs e)
        {
            Temizle();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (uyesu.Text == "")
            {
                MessageBox.Show("Lütfen Makbuz Numarası Giriniz!");
            }
            else
            {
                try
                {
                    Con.Open();
                    string sorgu = "DELETE from UyeTbl where odemak='" + uyesu.Text + "';";
                    SqlCommand kmt = new SqlCommand(sorgu, Con);
                    kmt.ExecuteNonQuery();
                    MessageBox.Show("Silme İşlemi Başarılı!");
                    Con.Close();
                    populate();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
    }
}
