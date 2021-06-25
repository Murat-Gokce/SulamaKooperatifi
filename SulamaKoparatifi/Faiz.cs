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
    public partial class Faiz : Form
    {
        public Faiz()
        {
            InitializeComponent();
        }
        SqlConnection Con = new SqlConnection(@"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename=D:\Kodlar\Sulama kooparatifi\SulamaKoparatifi\SulamaKoparatifi\SULAMADB.mdf;Integrated Security = True; Connect Timeout = 30");

        private void pıpula()
        {
            Con.Open();
            string ekleode = "select *  from OdeTbl";
            SqlDataAdapter sa = new SqlDataAdapter(ekleode, Con);
            SqlCommandBuilder insa = new SqlCommandBuilder(sa);
            var dss = new DataSet();
            sa.Fill(dss);
            Con.Close();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            Odeme odemegec = new Odeme();
            odemegec.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Odeme odemegec1 = new Odeme();
            odemegec1.Show();
            this.Hide();
        }
        private void uygula()
        {

        }
        private void button3_Click(object sender, EventArgs e)
        {

            


        }

        private void button1_Click(object sender, EventArgs e)
        {
            Con.Open();
            string sorgu = " select odeuye from OdeTbl where odekalan>0 ";
            SqlCommand kmt = new SqlCommand(sorgu, Con);
            DataTable dt = new DataTable();
            SqlDataAdapter sud = new SqlDataAdapter(kmt);
            sud.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                listveri.Items.Add(dr["odeuye"]);
              


            }
            double sonuc, sayi;
            sayi = Convert.ToDouble(famik.Text);
            sonuc = sayi / 100;


            foreach (int item in listveri.Items)
            {
                string guncel = "update OdeTbl set odekalan=odekalan + ((odekalan/100)*'" + sonuc + "') where odeuye='"+item+"'";
                SqlCommand gun = new SqlCommand(guncel,Con);
                gun.ExecuteNonQuery();
 
               
            }
            Con.Close();
            pıpula();
            MessageBox.Show("Faiz Uygulama Başarılı",sonuc.ToString());
        }

        private void button4_Click(object sender, EventArgs e)
        {
           
        }
        
        private void Faiz_Load(object sender, EventArgs e)
        {
           
            
        }
    }
}
