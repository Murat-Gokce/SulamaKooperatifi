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
using Excel= Microsoft.Office.Interop.Excel;






namespace SulamaKoparatifi
{
    public partial class Bilgi : Form
    {
        public Bilgi()
        {
            InitializeComponent();
        }

        SqlConnection Con = new SqlConnection(@"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename=D:\Kodlar\Sulama kooparatifi\SulamaKoparatifi\SulamaKoparatifi\SULAMADB.mdf;Integrated Security = True; Connect Timeout = 30");
        DataTable tablo = new DataTable();
        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Anasayfa bi = new Anasayfa();
            bi.Show();
            this.Hide();
        }
        private void pupolattt()
        {
            Con.Open();
            string eklesu = "select * from OdeTbl";
            SqlDataAdapter sa = new SqlDataAdapter(eklesu, Con);
            SqlCommandBuilder insa = new SqlCommandBuilder(sa);
            var dss = new DataSet();
         
            sa.Fill(dss);
            Con.Close();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            verigetir();
            
        }
        private void verigetir()
        {
            Con.Open();
            string sorgu = " select* from OdeTbl where odeuye ='" + bilara.Text + "'";
            SqlCommand kmt = new SqlCommand(sorgu, Con);
            DataTable dt = new DataTable();
            SqlDataAdapter sud = new SqlDataAdapter(kmt);
            sud.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                bilad.Text = dr["odetc"].ToString();
                biles.Text = dr["odead"].ToString();
                biltop.Text = dr["odekalan"].ToString();
                bilad.Visible = true;
                biles.Visible = true;
                biltop.Visible = true;


            }
            Con.Close();
        }

        private void Bilgi_Load(object sender, EventArgs e)
        {
            
        }
        private void getir()
        {
            Con.Open();
            string sorgu = " select odeuye,odetc,odead,odekalan from OdeTbl";
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
            string sorgu = " select odeuye,odetc,odead,odekalan from OdeTbl where odetc like  '%" + bilad.Text + "%'";
            SqlCommand kmt = new SqlCommand(sorgu, Con);
            DataTable ds = new DataTable();
            SqlDataAdapter sud = new SqlDataAdapter(kmt);
            sud.Fill(ds);
            dataGridView1.DataSource = ds;
            Con.Close();



        }
        private void getir3()
        {
            Con.Open();
            string sorgu = " select* from UyeTbl";
            SqlCommand kmt = new SqlCommand(sorgu, Con);
            DataTable ds = new DataTable();
            SqlDataAdapter sud = new SqlDataAdapter(kmt);
            sud.Fill(ds);
            dataGridView1.DataSource = ds;
            Con.Close();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            int sutun = 1;
            int satir = 1;
            Microsoft.Office.Interop.Excel.Application uyg = new Microsoft.Office.Interop.Excel.Application();
            uyg.Visible = true;
            Microsoft.Office.Interop.Excel.Workbook kitap = uyg.Workbooks.Add(System.Reflection.Missing.Value);
            Microsoft.Office.Interop.Excel.Worksheet sheet1 = (Microsoft.Office.Interop.Excel.Worksheet)kitap.Sheets[1];
            for (int i = 0; i < dataGridView1.Columns.Count; i++)
            {
                uyg.Cells[satir, sutun + i].Value = dataGridView1.Columns[i].HeaderText;
                uyg.Cells[satir, sutun + i].Font.Color = System.Drawing.Color.Blue;
                uyg.Cells[satir, sutun + i].Font.Size = 12;
                uyg.Cells[satir, sutun + i].ColumnWidth = 20;
                uyg.Cells[satir, sutun + i].Font.Bold = true;
                uyg.Cells[satir, sutun + i].Font.Name = "Arial Black";
            }
            satir++;

            for (int i = 0; i < dataGridView1.Columns.Count; i++)
            {
                for (int j = 0; j < dataGridView1.Rows.Count; j++)
                {
                    Microsoft.Office.Interop.Excel.Range myRange = (Microsoft.Office.Interop.Excel.Range)sheet1.Cells[j + 2, i + 1];
                    myRange.Value2 = dataGridView1[i, j].Value;
                }
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            getir();
            olus1();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            getir2();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            getir3();
            olus2();
        }
        protected void Temizle()
        {
            bilara.Text = "";
            bilad.Text = "";
            biles.Text = "";
            biltop.Text = "";
           


        }
        private void button2_Click(object sender, EventArgs e)
        {
            Temizle();
        }

        private void gel()
        {
            Con.Open();
            string sorgu = " select uyesu,tcsu,adsu,fisu,sumevki,actarihsu,toplamsaat from SuTbl where uyesu = '" + bilara.Text + "'";
            SqlCommand kmt = new SqlCommand(sorgu, Con);
            DataTable ds = new DataTable();
            SqlDataAdapter sud = new SqlDataAdapter(kmt);
            sud.Fill(ds);
            dataGridView1.DataSource = ds;
            Con.Close();
        }
        private void olus()
        {
            dataGridView1.Columns[0].HeaderCell.Value = "Üye Numarası";
            dataGridView1.Columns[1].HeaderCell.Value = "Ad Soyad";
            dataGridView1.Columns[2].HeaderCell.Value = "Tc Numarası";
            dataGridView1.Columns[3].HeaderCell.Value = "Fiş Numarası";
            dataGridView1.Columns[4].HeaderCell.Value = "Sulama Mevkisi";
            dataGridView1.Columns[5].HeaderCell.Value = "Sulama Tarihi";
            dataGridView1.Columns[6].HeaderCell.Value = "Toplam Saat";

        }
        private void olus1()
        {
            dataGridView1.Columns[0].HeaderCell.Value = "Üye Numarası";
            dataGridView1.Columns[1].HeaderCell.Value = "Ad Soyad";
            dataGridView1.Columns[2].HeaderCell.Value = "Tc Numarası";
            dataGridView1.Columns[3].HeaderCell.Value = "Kalan Tutar";
       

        }
        private void olus2()
        {
            dataGridView1.Columns[0].HeaderCell.Value = "Üye Numarası";
            dataGridView1.Columns[1].HeaderCell.Value = "Ad Soyad";
            dataGridView1.Columns[2].HeaderCell.Value = "Baba Adı";
            dataGridView1.Columns[3].HeaderCell.Value = "Anne Adı";
            dataGridView1.Columns[4].HeaderCell.Value = "Üye Numarası";
            dataGridView1.Columns[5].HeaderCell.Value = "Tel Numarası";
            dataGridView1.Columns[6].HeaderCell.Value = "Adres";
            dataGridView1.Columns[7].HeaderCell.Value = "Açıklama";
            dataGridView1.Columns[8].HeaderCell.Value = "Sulama Alanı";
            dataGridView1.Columns[9].HeaderCell.Value = "Ortaklık No";
            dataGridView1.Columns[10].HeaderCell.Value = "Ortaklık Payı";
            dataGridView1.Columns[11].HeaderCell.Value = "Ödenen Pay ";
            dataGridView1.Columns[12].HeaderCell.Value = "Kalan Pay";
            dataGridView1.Columns[13].HeaderCell.Value = "Ort. Giriş Tarihi";
            dataGridView1.Columns[14].HeaderCell.Value = "Karar Tarihi";
            dataGridView1.Columns[15].HeaderCell.Value = "Karar No";
            dataGridView1.Columns[16].HeaderCell.Value = "Ort. Devir No";



        }

        private void button8_Click(object sender, EventArgs e)
        {
            gel();
            olus();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            bilara.Text = this.dataGridView1.CurrentRow.Cells[0].Value.ToString();
            bilad.Text = this.dataGridView1.CurrentRow.Cells[1].Value.ToString();
            biles.Text = this.dataGridView1.CurrentRow.Cells[2].Value.ToString();
            biltop.Text = this.dataGridView1.CurrentRow.Cells[3].Value.ToString();
          
        }
    }
}
