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
    public partial class Sulama : Form
    {
        public Sulama()
        {
            InitializeComponent();
        }
        public string ad1;
        SqlConnection Con = new SqlConnection(@"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename=D:\Kodlar\Sulama kooparatifi\SulamaKoparatifi\SulamaKoparatifi\SULAMADB.mdf;Integrated Security = True; Connect Timeout = 30");

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Anasayfa sula = new Anasayfa();
            sula.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Sezon sezo = new Sezon();
            sezo.Show();
            this.Hide();

        }
        private void gorev()
        {
            Con.Open();
            SqlCommand mkt = new SqlCommand("select *from GorTbl", Con);
            SqlDataReader okuma = mkt.ExecuteReader();
            while (okuma.Read())
            {
                Gorevli.Items.Add(okuma["gorad"]);
            }
            Con.Close();
        }
        private void popm()
        {

            Con.Open();
            SqlCommand mkk = new SqlCommand("select *from PompaTbl", Con);
            SqlDataReader okutma = mkk.ExecuteReader();
            while (okutma.Read())
            {
                sumev.Items.Add(okutma["pompais"]);
            }
            Con.Close();
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void olus()
        {
            dataGridView1.Columns[0].HeaderCell.Value = "Üye Numarası";
            dataGridView1.Columns[1].HeaderCell.Value = "Ad Soyad";
            dataGridView1.Columns[2].HeaderCell.Value = "Tc Numarası";
            dataGridView1.Columns[3].HeaderCell.Value = "Tel Numarası";
        }
        private void Sulama_Load(object sender, EventArgs e)
        {
           
            getir();
            pupolatt();
            gorev();
            popm();
            olus();

        }

        private void button3_Click(object sender, EventArgs e)
        {
           
            if (suye.Text == "" || suad.Text == "" || sutc.Text == "" || sufis.Text == "" || saatoplam.Text == "" || suc.Text == "")
            {
                MessageBox.Show("Eksik Bilgi");
            }
            else
            {
                try
                {

                    Con.Open();

                   
                    string ekle = "INSERT INTO SuTbl values ('" + suye.Text + "','" + sutc.Text + "','" + suad.Text + "','" + sufis.Text + "','" + suac.Value.Date + "','" + sukap.Value.Date + "','" + sumev.SelectedItem.ToString()+"','"+susezon.SelectedItem.ToString() + "','" + Gorevli.SelectedItem.ToString() + "','" + suc.Text + "','" + saatoplam.Text  +"','"+sutop.Text+ "')";
                    SqlCommand kmtt = new SqlCommand(ekle, Con);
                    kmtt.ExecuteNonQuery();
                    MessageBox.Show("Kayıt Başarılı");
                    Con.Close();
                    pupolatt();

                }
                catch (Exception hata)
                {
                    MessageBox.Show(hata.Message);
                }

            }

        }
        private void pupolatt()
        {
            Con.Open();
            string eklesu = "select * from SuTbl";
            SqlDataAdapter sa = new SqlDataAdapter(eklesu, Con);
            SqlCommandBuilder insa = new SqlCommandBuilder(sa);
            var dss = new DataSet();
            sa.Fill(dss);
            Con.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
           


        }

        private void verigetir()
        {
            Con.Open();
            string sorgu = " select* from Uyetbl where idu ='" + suara.Text + "'";
            SqlCommand kmt = new SqlCommand(sorgu, Con);
            DataTable dt = new DataTable();
            SqlDataAdapter sud = new SqlDataAdapter(kmt);
            sud.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                suye.Text = dr["idu"].ToString();
                sutc.Text = dr["tcu"].ToString();
                suad.Text = dr["adu"].ToString();
                suye.Visible = true;
                sutc.Visible = true;
                suad.Visible = true;


            }
            Con.Close();



        }

        private void button5_Click(object sender, EventArgs e)
        {
            DateTime asaat = Convert.ToDateTime(suacs.Text);
            DateTime atarih = Convert.ToDateTime(suac.Text);
            DateTime ksaat = Convert.ToDateTime(sukapk.Text);
            DateTime ktarih = Convert.ToDateTime(sukap.Text);

            if (atarih == ktarih)
            {
                if (suc.Text == "")
                {
                    MessageBox.Show("Lütfen Ücret Giriniz!");
                }
                else
                {

                    try
                    {
                        string sattoplam;
                        double saatt,yuvar ;
                        TimeSpan sonuc = ksaat - asaat;
                        sattoplam = sonuc.TotalHours.ToString();
                        saatt = Convert.ToDouble(sattoplam);
                        var timeSpan = TimeSpan.FromHours(saatt);
                        int hh = timeSpan.Hours;
                        int mm = timeSpan.Minutes;
                        saatoplam.Text = hh + "\t" + "s" + "\t" + mm + "\t" + "d";
                        double toplam, sayi1, sayi2;
                        sayi1 = Convert.ToDouble(sattoplam);
                        sayi2 = Convert.ToDouble(suc.Text);
                        toplam = sayi1 * sayi2;
                        yuvar = Math.Round(toplam);
                        sutop.Text = yuvar.ToString();
                    }
                    catch (Exception hata)
                    {
                        MessageBox.Show(hata.Message);
                    }
                }

            }
            else
            {
                MessageBox.Show("kayıt Başarılı");
            }



        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
        private void getir()
        {
            Con.Open();
            string sorgu = " select idu,adu,tcu,telu from UyeTbl ";
            SqlCommand kmt = new SqlCommand(sorgu, Con);
            DataTable ds = new DataTable();
            SqlDataAdapter sud = new SqlDataAdapter(kmt);
            sud.Fill(ds);
            dataGridView1.DataSource = ds;
            Con.Close();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            Temizle();
        }
        protected void Temizle()
        {
            suara.Text = "";
            suye.Text = "";
            sutc.Text = "";
            suad.Text = "";
            sufis.Text = "";
            sumev.Text = "";
            susezon.Text = "";
            suc.Text = "";
            saatoplam.Text = "";
            sutop.Text = "";

        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (sufis.Text == "")
            {
                MessageBox.Show("Lütfen Fiş Numarası Giriniz!");
            }
            else
            {
                try
                {
                    Con.Open();
                    string sorgu = "DELETE from SuTbl where fisu='" + sufis.Text + "';";
                    SqlCommand kmt = new SqlCommand(sorgu, Con);
                    kmt.ExecuteNonQuery();
                    MessageBox.Show("Silme İşlemi Başarılı!");
                    Con.Close();
                    pupolatt();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void sumev_SelectedIndexChanged(object sender, EventArgs e)
        {
            Con.Open();
            string sorgu = " select* from PompaTbl where pompais ='" + sumev.SelectedItem.ToString() + "'";
            SqlCommand kmt = new SqlCommand(sorgu, Con);
            DataTable dq = new DataTable();
            SqlDataAdapter sud = new SqlDataAdapter(kmt);
            sud.Fill(dq);
            foreach (DataRow dd in dq.Rows)
            {
                suc.Text = dd["pompauc"].ToString();

                suc.Visible = true;


            }
            Con.Close();
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void pictureBox2_Click_1(object sender, EventArgs e)
        {
            Anasayfa sula = new Anasayfa();
            sula.Show();
            this.Hide();
        }
        
        private void suara_TextChanged(object sender, EventArgs e)
        {

            Con.Open();
            string sorgu = "select idu,adu,tcu,telu from UyeTbl where adu like  '%" + suara.Text + "%'";
            SqlCommand kmt = new SqlCommand(sorgu, Con);
            SqlDataAdapter asd = new SqlDataAdapter();
            DataTable veri = new DataTable();
            asd.SelectCommand = kmt;
            veri.Clear();
            asd.Fill(veri);
            dataGridView1.DataSource = veri;
            Con.Close();

        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            suye.Text = this.dataGridView1.CurrentRow.Cells[0].Value.ToString();
            sutc.Text = this.dataGridView1.CurrentRow.Cells[1].Value.ToString();
            suad.Text = this.dataGridView1.CurrentRow.Cells[2].Value.ToString();
            
        }

        private void sutop_TextChanged(object sender, EventArgs e)
        {
           
        }
    }
}
