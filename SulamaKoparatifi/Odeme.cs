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
    public partial class Odeme : Form
    {
        public Odeme()
        {
            InitializeComponent();
        }
        SqlConnection Con = new SqlConnection(@"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename=D:\Kodlar\Sulama kooparatifi\SulamaKoparatifi\SulamaKoparatifi\SULAMADB.mdf;Integrated Security = True; Connect Timeout = 30");
        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
       
        private void button4_Click(object sender, EventArgs e)
        {
            Faiz faizgec = new Faiz();
            faizgec.Show();
            this.Hide();


        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Anasayfa o = new Anasayfa();
            o.Show();
            this.Hide();
        }
        private void pupol()
        {
            Con.Open();
            string eklesu = "select * from SuTbl";
            SqlDataAdapter sa = new SqlDataAdapter(eklesu, Con);
            SqlCommandBuilder insa = new SqlCommandBuilder(sa);
            var dss = new DataSet();
            sa.Fill(dss);
            Con.Close();
        }
        private void olus()
        {
            dataGridView1.Columns[0].HeaderCell.Value = "Üye Numarası";
            dataGridView1.Columns[1].HeaderCell.Value = "Ad Soyad";
            dataGridView1.Columns[2].HeaderCell.Value = "Tc Numarası";
            dataGridView1.Columns[3].HeaderCell.Value = "Sezon İsmi";
            dataGridView1.Columns[4].HeaderCell.Value = "Toplam Tutar";
        }
        private void getir1()
        {

            Con.Open();
            string sorgu = " select uyesu,tcsu,adsu,susez,sum(sutoplam) as sutoplam from SuTbl group by uyesu,tcsu,adsu,susez ";
            SqlCommand kmt = new SqlCommand(sorgu, Con);
            DataTable ds = new DataTable();
            SqlDataAdapter sud = new SqlDataAdapter(kmt);
            sud.Fill(ds);
            dataGridView1.DataSource = ds;
            Con.Close();

        }
        private void getir2()
        {
            Con.Open();
            string sorgu = " select odeuye,odetc,odead,odesez,odekalan from OdeTbl  ";
            SqlCommand kmt = new SqlCommand(sorgu, Con);
            DataTable ds = new DataTable();
            SqlDataAdapter sud = new SqlDataAdapter(kmt);
            sud.Fill(ds);
            dataGridView2.DataSource = ds;
            Con.Close();

        }
        private void olus1()
        {
            dataGridView2.Columns[0].HeaderCell.Value = "Üye Numarası";
            dataGridView2.Columns[1].HeaderCell.Value = "Ad Soyad";
            dataGridView2.Columns[2].HeaderCell.Value = "Tc Numarası";
            dataGridView2.Columns[3].HeaderCell.Value = "Sezon İsmi";
            dataGridView2.Columns[4].HeaderCell.Value = "Kalan Tutar";
        }

        private void Odeme_Load(object sender, EventArgs e)
        {
            getir1();
           
            olus();
            getir2();
            olus1();
          
           
           
            
        
        }
      

        private void button1_Click(object sender, EventArgs e)
        {
           
            
            
        }
        

       
       
        
        private void toplamm()
        {
            Con.Open();
            string sorg = "select uyesu,tcsu, sum(sutoplam) as sutoplam from SuTbl where uyesu ='" + odara.Text + "'  group by uyesu,tcsu";
            SqlCommand sor = new SqlCommand(sorg, Con);
            DataTable dtm = new DataTable();
            SqlDataAdapter oku = new SqlDataAdapter(sor);
            oku.Fill(dtm);
            foreach (DataRow dy in dtm.Rows)
            {
                odborc.Text = dy["sutoplam"].ToString();
                odborc.Visible = true;


            }


            Con.Close();
        }


        private void button3_Click(object sender, EventArgs e)
        {
            double sayi1, sayi2, sonuc;
            sayi1 = Convert.ToDouble(odborc.Text);
            sayi2 = Convert.ToDouble(odmik.Text);
            sonuc = sayi1 - sayi2;
            odkal.Text = Convert.ToString(sonuc);
        }
        protected void Temizle()
        {
            odara.Text = "";
            oduye.Text = "";
            odtc.Text = "";
            odad.Text = "";
            odsezon.Text = "";
            odmak.Text = "";
            odborc.Text = "";
            odmik.Text = "";
            odkal.Text = "";
            

        }
        private void button2_Click(object sender, EventArgs e)
        {
            Temizle();
        }

        private void button5_Click(object sender, EventArgs e)
        {

            if (oduye.Text == "" || odad.Text == "" || odtc.Text == "" || odtar.Text == "" || odsezon.Text == "" || odmak.Text == "" || odborc.Text == "" || odmik.Text == "" || odkal.Text == "" || odeturu.Text == "")
            {
                MessageBox.Show("Eksik Bilgi");
            }
            else
            {
                try
                {

                    Con.Open();
                    string ekle = "INSERT INTO OdeTbl values ('" + oduye.Text + "','" + odtc.Text + "','" + odad.Text + "','"+ odtar.Value.Date+"','"+ odsezon.Text + "','" + odmak.Text + "','" + odborc.Text + "','" + odmik.Text + "','" + odkal.Text + "','" + odeturu.SelectedItem.ToString()  + "')";
                    SqlCommand kmtt = new SqlCommand(ekle, Con);
                    kmtt.ExecuteNonQuery();
                    MessageBox.Show("Kayıt Başarılı");
                    Con.Close();
                    pupol();

                }
                catch (Exception hata)
                {
                    MessageBox.Show(hata.Message);
                }

            }
           
        }

        private void button6_Click(object sender, EventArgs e)
        {
           
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (odmak.Text == "")
            {
                MessageBox.Show("Lütfen Makbuz Numarası Giriniz!");
            }
            else
            {
                try
                {
                    Con.Open();
                    string sorgu = "DELETE from OdeTbl where odemak='" + odmak.Text + "';";
                    SqlCommand kmt = new SqlCommand(sorgu, Con);
                    kmt.ExecuteNonQuery();
                    MessageBox.Show("Silme İşlemi Başarılı!");
                    Con.Close();
                    pupol();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void odara_TextChanged(object sender, EventArgs e)
        {
            Con.Open();
            string sorgu = "select uyesu,tcsu,adsu,susez,sum(sutoplam) as sutoplam from SuTbl where tcsu like  '%" + odara.Text + "%'or uyesu like  '%" + odara.Text + "%' group by uyesu,tcsu, adsu,susez";
            SqlCommand kmt = new SqlCommand(sorgu, Con);
            SqlDataAdapter asd = new SqlDataAdapter();
            DataTable veri = new DataTable();
            asd.SelectCommand = kmt;
            veri.Clear();
            asd.Fill(veri);
            dataGridView1.DataSource = veri;
            Con.Close();

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            oduye.Text = this.dataGridView1.CurrentRow.Cells[0].Value.ToString();
            odad.Text = this.dataGridView1.CurrentRow.Cells[1].Value.ToString();
            odtc.Text = this.dataGridView1.CurrentRow.Cells[2].Value.ToString();
            odsezon.Text = this.dataGridView1.CurrentRow.Cells[3].Value.ToString();
            odborc.Text = this.dataGridView1.CurrentRow.Cells[4].Value.ToString();
        }
      

      
        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

            Con.Open();
            string sorgu = "select odeuye,odetc,odead,odesez,odekalan from OdeTbl where odetc like  '%" + toplamara.Text + "%'";
            SqlCommand kmt = new SqlCommand(sorgu, Con);
            SqlDataAdapter asd = new SqlDataAdapter();
            DataTable veri = new DataTable();
            asd.SelectCommand = kmt;
            veri.Clear();
            asd.Fill(veri);
            dataGridView2.DataSource = veri;
            Con.Close();
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            oduye.Text = this.dataGridView2.CurrentRow.Cells[0].Value.ToString();
            odad.Text = this.dataGridView2.CurrentRow.Cells[1].Value.ToString();
            odtc.Text = this.dataGridView2.CurrentRow.Cells[2].Value.ToString();
            odsezon.Text = this.dataGridView2.CurrentRow.Cells[3].Value.ToString();
            odborc.Text = this.dataGridView2.CurrentRow.Cells[4].Value.ToString();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
         
        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_2(object sender, EventArgs e)
        {
            if (oduye.Text == "" || odad.Text == "" || odtc.Text == "" || odtar.Text == "" || odsezon.Text == "" || odmak.Text == "" || odborc.Text == "" || odmik.Text == "" || odkal.Text == "" || odeturu.Text == "")
            {
                MessageBox.Show("Eksik Bilgi.");

            }
            else
            {
                try
                {
                    Con.Open();
                    string sorgu = "update OdeTbl set odekalan='" + odkal.Text  + "'where odeuye='" + oduye.Text + "';";
                    SqlCommand kmt = new SqlCommand(sorgu, Con);
                    kmt.ExecuteNonQuery();
                    MessageBox.Show("Ödeme Başarılı.");
                    Con.Close();
                    pupol();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
    }
}
     
