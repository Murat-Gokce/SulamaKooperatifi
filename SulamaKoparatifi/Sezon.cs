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
    public partial class Sezon : Form
    {
        public Sezon()
        {
            InitializeComponent();
        }
        SqlConnection Con = new SqlConnection(@"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename=D:\Kodlar\Sulama kooparatifi\SulamaKoparatifi\SulamaKoparatifi\SULAMADB.mdf;Integrated Security = True; Connect Timeout = 30");
        private void button2_Click(object sender, EventArgs e)
        {
            Sulama sezi = new Sulama();
            sezi.Show();
            this.Hide();
        }
        private void popul()
        {
            Con.Open();
            string ekleode = "select * from PompaTbl";
            SqlDataAdapter sa = new SqlDataAdapter(ekleode, Con);
            SqlCommandBuilder insa = new SqlCommandBuilder(sa);
            var dss = new DataSet();
            sa.Fill(dss);
            Con.Close();
        }
        private void popula()
        {
            Con.Open();
            string ekleode = "select * from GorTbl";
            SqlDataAdapter sa = new SqlDataAdapter(ekleode, Con);
            SqlCommandBuilder insa = new SqlCommandBuilder(sa);
            var dss = new DataSet();
            sa.Fill(dss);
            Con.Close();
        }
        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Sulama sez = new Sulama();
            sez.Show();
            this.Hide();
        }

        private void Sezon_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {


        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (popnu.Text == "" || popad.Text == "" || popuc.Text == "")
            {
                MessageBox.Show("Eksik Bilgi");
            }
            else
            {
                try
                {

                    Con.Open();

                    string eklesu = "INSERT INTO PompaTbl values ('" + popnu.Text + "','" + popad.Text + "','" + popuc.Text + "')";

                    SqlCommand kmtt = new SqlCommand(eklesu, Con);
                    kmtt.ExecuteNonQuery();
                    MessageBox.Show("Kayıt Başarılı");
                    Con.Close();
                    popul();

                }
                catch (Exception hata)
                {
                    MessageBox.Show(hata.Message);
                }

            }
        }
        private void getir()
        {
            if (popara.Text == "")
            {
                MessageBox.Show("Lütfen Pompa Numarası Giriniz.");
            }
            else
            {
                Con.Open();
                string sorgu = " select* from PompaTbl where pompanu ='" + popara.Text + "'";
                SqlCommand kmt = new SqlCommand(sorgu, Con);
                DataTable dq = new DataTable();
                SqlDataAdapter sud = new SqlDataAdapter(kmt);
                sud.Fill(dq);
                foreach (DataRow dd in dq.Rows)
                {
                    popnu.Text = dd["pompanu"].ToString();
                    popad.Text = dd["pompais"].ToString();
                 
                    popnu.Visible = true;
                    popad.Visible = true;
                    

                }
                Con.Close();
            }
          
        }


        private void button1_Click(object sender, EventArgs e)
        {
            getir();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (popnu.Text == "")
            {
                MessageBox.Show("Lütfen Pompa Numarası Giriniz!");
            }
            else
            {
                try
                {
                    Con.Open();
                    string sorgu = "DELETE from PompaTbl where pompanu='" + popnu.Text + "';";
                    SqlCommand kmt = new SqlCommand(sorgu, Con);
                    kmt.ExecuteNonQuery();
                    MessageBox.Show("Silme İşlemi Başarılı!");
                    Con.Close();
                    popul();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (goris.Text == "" )
            {
                MessageBox.Show("Eksik Bilgi");
            }
            else
            {
                try
                {

                    Con.Open();

                    string eklesu = "INSERT INTO GorTbl values ('" + gorno.Text  +"','" + goris.Text+ "')";

                    SqlCommand kmtt = new SqlCommand(eklesu, Con);
                    kmtt.ExecuteNonQuery();
                    MessageBox.Show("Kayıt Başarılı");
                    Con.Close();
                    popul();

                }
                catch (Exception hata)
                {
                    MessageBox.Show(hata.Message);
                }

            }
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            if (gorno.Text == "")
            {
                MessageBox.Show("Lütfen Görevli Numarası Giriniz!");
            }
            else
            {
                try
                {
                    Con.Open();
                    string sorgu = "DELETE from GorTbl where gornu='" + gorno.Text + "';";
                    SqlCommand kmt = new SqlCommand(sorgu, Con);
                    kmt.ExecuteNonQuery();
                    MessageBox.Show("Silme İşlemi Başarılı!");
                    Con.Close();
                    popula();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
        protected void Temizle()
        {
            popara.Text = "";
            popad.Text = "";
            popnu.Text = "";
            popuc.Text = "";
            goris.Text = "";
            gorno.Text = "";
          

        }
        private void button7_Click(object sender, EventArgs e)
        {
            Temizle();
        }
    }
}
