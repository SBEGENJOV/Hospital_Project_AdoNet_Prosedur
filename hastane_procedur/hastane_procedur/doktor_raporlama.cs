using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace hastane_procedur
{
    public partial class doktor_raporlama : Form
    {
        SqlConnection conn = new SqlConnection("Server=DESKTOP-5K7HMBT\\SQLEXPRESS;Database=hastane_otomasyon;Integrated Security=true;");
        public doktor_raporlama()
        {
            InitializeComponent();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand();
            komut.Connection = conn;
            komut.CommandType = CommandType.StoredProcedure;
            komut.CommandText = "hastaListele";
            SqlDataAdapter dr = new SqlDataAdapter(komut);
            DataTable filldata = new DataTable();
            dr.Fill(filldata);
            dataGridView1.DataSource = filldata;
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand();
            komut.Connection = conn;
            komut.CommandType = CommandType.StoredProcedure;
            komut.CommandText = "receteListele";
            SqlDataAdapter dr = new SqlDataAdapter(komut);
            DataTable filldata = new DataTable();
            dr.Fill(filldata);
            dataGridView1.DataSource = filldata;
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand();
            komut.Connection = conn;
            komut.CommandType = CommandType.StoredProcedure;
            komut.CommandText = "doktorListele";
            SqlDataAdapter dr = new SqlDataAdapter(komut);
            DataTable filldata = new DataTable();
            dr.Fill(filldata);
            dataGridView1.DataSource = filldata;
        }

        private void simpleButton4_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand();
            komut.Connection = conn;
            komut.CommandType = CommandType.StoredProcedure;
            komut.CommandText = "polListele";
            SqlDataAdapter dr = new SqlDataAdapter(komut);
            DataTable filldata = new DataTable();
            dr.Fill(filldata);
            dataGridView1.DataSource = filldata;
        }

        private void simpleButton12_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand();
            komut.Connection = conn;
            komut.CommandType = CommandType.StoredProcedure;
            komut.CommandText = "hyas";
            SqlDataAdapter dr = new SqlDataAdapter(komut);
            DataTable filldata = new DataTable();
            dr.Fill(filldata);
            dataGridView1.DataSource = filldata;
        }

        private void simpleButton13_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand();
            komut.Connection = conn;
            komut.CommandType = CommandType.StoredProcedure;
            komut.CommandText = "hboy";
            SqlDataAdapter dr = new SqlDataAdapter(komut);
            DataTable filldata = new DataTable();
            dr.Fill(filldata);
            dataGridView1.DataSource = filldata;
        }

        private void simpleButton14_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand();
            komut.Connection = conn;
            komut.CommandType = CommandType.StoredProcedure;
            komut.CommandText = "hkilo";
            SqlDataAdapter dr = new SqlDataAdapter(komut);
            DataTable filldata = new DataTable();
            dr.Fill(filldata);
            dataGridView1.DataSource = filldata;
        }
        private void simpleButton5_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex==0)
            {
                SqlCommand komut = new SqlCommand();
                komut.Connection = conn;
                komut.CommandType = CommandType.StoredProcedure;
                komut.CommandText = "hsayi";
                SqlDataAdapter dr = new SqlDataAdapter(komut);
                DataTable filldata = new DataTable();
                dr.Fill(filldata);
                dataGridView1.DataSource = filldata;
            }
            else if(comboBox1.SelectedIndex==1)
            {
                SqlCommand komut = new SqlCommand();
                komut.Connection = conn;
                komut.CommandType = CommandType.StoredProcedure;
                komut.CommandText = "rsayi";
                SqlDataAdapter dr = new SqlDataAdapter(komut);
                DataTable filldata = new DataTable();
                dr.Fill(filldata);
                dataGridView1.DataSource = filldata;
            }
            else if (comboBox1.SelectedIndex == 2)
            {
                SqlCommand komut = new SqlCommand();
                komut.Connection = conn;
                komut.CommandType = CommandType.StoredProcedure;
                komut.CommandText = "psayi";
                SqlDataAdapter dr = new SqlDataAdapter(komut);
                DataTable filldata = new DataTable();
                dr.Fill(filldata);
                dataGridView1.DataSource = filldata;
            }
            else if (comboBox1.SelectedIndex == 3)
            {
                SqlCommand komut = new SqlCommand();
                komut.Connection = conn;
                komut.CommandType = CommandType.StoredProcedure;
                komut.CommandText = "dsayi";
                SqlDataAdapter dr = new SqlDataAdapter(komut);
                DataTable filldata = new DataTable();
                dr.Fill(filldata);
                dataGridView1.DataSource = filldata;
            }
            else if (comboBox1.SelectedIndex == 4)
            {
                SqlCommand komut = new SqlCommand();
                komut.Connection = conn;
                komut.CommandType = CommandType.StoredProcedure;
                komut.CommandText = "asayi";
                SqlDataAdapter dr = new SqlDataAdapter(komut);
                DataTable filldata = new DataTable();
                dr.Fill(filldata);
                dataGridView1.DataSource = filldata;
            }
        }

        private void simpleButton6_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand();
            komut.Connection = conn;
            komut.CommandType = CommandType.StoredProcedure;
            komut.CommandText = "hNoBilgi";
            komut.Parameters.AddWithValue("hastaNo", textBox1.Text);
            SqlDataAdapter dr = new SqlDataAdapter(komut);
            DataTable filldata = new DataTable();
            dr.Fill(filldata);
            dataGridView1.DataSource = filldata;
        }
        public void dokListele()
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = conn;
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.CommandText = "doktorListele";
            conn.Open();
            SqlDataReader reader = sqlCommand.ExecuteReader();
            while (reader.Read()) //true oldugu sürece çalışacak.
            {
                comboBox3.Items.Add(reader["doktorNo"]);
                comboBox4.Items.Add(reader["doktorNo"]);
            }
            conn.Close();
        }
        private void doktor_raporlama_Load(object sender, EventArgs e)
        {
            dokListele();
        }

        private void simpleButton7_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand();
            komut.Connection = conn;
            komut.CommandType = CommandType.StoredProcedure;
            komut.CommandText = "dhasta";
            komut.Parameters.AddWithValue("doktorNo", comboBox3.Text);
            SqlDataAdapter dr = new SqlDataAdapter(komut);
            DataTable filldata = new DataTable();
            dr.Fill(filldata);
            dataGridView1.DataSource = filldata;
        }

        private void simpleButton8_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand();
            komut.Connection = conn;
            komut.CommandType = CommandType.StoredProcedure;
            komut.CommandText = "drecete";
            komut.Parameters.AddWithValue("doktorNo", comboBox4.Text);
            SqlDataAdapter dr = new SqlDataAdapter(komut);
            DataTable filldata = new DataTable();
            dr.Fill(filldata);
            dataGridView1.DataSource = filldata;
        }

        private void simpleButton11_Click(object sender, EventArgs e)
        {
            if (comboBox5.SelectedIndex == 0)
            {
                SqlCommand komut = new SqlCommand();
                komut.Connection = conn;
                komut.CommandType = CommandType.StoredProcedure;
                komut.CommandText = "cpol";
                SqlDataAdapter dr = new SqlDataAdapter(komut);
                DataTable filldata = new DataTable();
                dr.Fill(filldata);
                dataGridView1.DataSource = filldata;
            }
            else if (comboBox5.SelectedIndex==1)
            {
                SqlCommand komut = new SqlCommand();
                komut.Connection = conn;
                komut.CommandType = CommandType.StoredProcedure;
                komut.CommandText = "cokhastaDok";
                SqlDataAdapter dr = new SqlDataAdapter(komut);
                DataTable filldata = new DataTable();
                dr.Fill(filldata);
                dataGridView1.DataSource = filldata;
            }
            else if (comboBox5.SelectedIndex == 2)
            {
                SqlCommand komut = new SqlCommand();
                komut.Connection = conn;
                komut.CommandType = CommandType.StoredProcedure;
                komut.CommandText = "cokreceteHasta";
                SqlDataAdapter dr = new SqlDataAdapter(komut);
                DataTable filldata = new DataTable();
                dr.Fill(filldata);
                dataGridView1.DataSource = filldata;
            }
            else if (comboBox5.SelectedIndex == 3)
            {
                SqlCommand komut = new SqlCommand();
                komut.Connection = conn;
                komut.CommandType = CommandType.StoredProcedure;
                komut.CommandText = "enkappol";
                SqlDataAdapter dr = new SqlDataAdapter(komut);
                DataTable filldata = new DataTable();
                dr.Fill(filldata);
                dataGridView1.DataSource = filldata;
            }
            else if (comboBox5.SelectedIndex == 4)
            {
                SqlCommand komut = new SqlCommand();
                komut.Connection = conn;
                komut.CommandType = CommandType.StoredProcedure;
                komut.CommandText = "enyaslı";
                SqlDataAdapter dr = new SqlDataAdapter(komut);
                DataTable filldata = new DataTable();
                dr.Fill(filldata);
                dataGridView1.DataSource = filldata;
            }
            else if (comboBox5.SelectedIndex == 5)
            {
                SqlCommand komut = new SqlCommand();
                komut.Connection = conn;
                komut.CommandType = CommandType.StoredProcedure;
                komut.CommandText = "engenc";
                SqlDataAdapter dr = new SqlDataAdapter(komut);
                DataTable filldata = new DataTable();
                dr.Fill(filldata);
                dataGridView1.DataSource = filldata;
            }
            else if (comboBox5.SelectedIndex == 6)
            {
                SqlCommand komut = new SqlCommand();
                komut.Connection = conn;
                komut.CommandType = CommandType.StoredProcedure;
                komut.CommandText = "enkilo";
                SqlDataAdapter dr = new SqlDataAdapter(komut);
                DataTable filldata = new DataTable();
                dr.Fill(filldata);
                dataGridView1.DataSource = filldata;
            }
            else if (comboBox5.SelectedIndex == 7)
            {
                SqlCommand komut = new SqlCommand();
                komut.Connection = conn;
                komut.CommandType = CommandType.StoredProcedure;
                komut.CommandText = "zendok";
                SqlDataAdapter dr = new SqlDataAdapter(komut);
                DataTable filldata = new DataTable();
                dr.Fill(filldata);
                dataGridView1.DataSource = filldata;
            }
            else if (comboBox5.SelectedIndex == 8)
            {
                SqlCommand komut = new SqlCommand();
                komut.Connection = conn;
                komut.CommandType = CommandType.StoredProcedure;
                komut.CommandText = "yaslidok";
                SqlDataAdapter dr = new SqlDataAdapter(komut);
                DataTable filldata = new DataTable();
                dr.Fill(filldata);
                dataGridView1.DataSource = filldata;
            }
        }

        private void simpleButton10_Click(object sender, EventArgs e)
        {
            if (comboBox6.SelectedIndex == 0)
            {
                SqlCommand komut = new SqlCommand();
                komut.Connection = conn;
                komut.CommandType = CommandType.StoredProcedure;
                komut.CommandText = "SdokAd";
                SqlDataAdapter dr = new SqlDataAdapter(komut);
                DataTable filldata = new DataTable();
                dr.Fill(filldata);
                dataGridView1.DataSource = filldata;
            }
            else if (comboBox6.SelectedIndex == 1)
            {
                SqlCommand komut = new SqlCommand();
                komut.Connection = conn;
                komut.CommandType = CommandType.StoredProcedure;
                komut.CommandText = "Sdokmas";
                SqlDataAdapter dr = new SqlDataAdapter(komut);
                DataTable filldata = new DataTable();
                dr.Fill(filldata);
                dataGridView1.DataSource = filldata;
            }
            else if (comboBox6.SelectedIndex == 2)
            {
                SqlCommand komut = new SqlCommand();
                komut.Connection = conn;
                komut.CommandType = CommandType.StoredProcedure;
                komut.CommandText = "Sdokyas";
                SqlDataAdapter dr = new SqlDataAdapter(komut);
                DataTable filldata = new DataTable();
                dr.Fill(filldata);
                dataGridView1.DataSource = filldata;
            }
            else if (comboBox6.SelectedIndex == 3)
            {
                SqlCommand komut = new SqlCommand();
                komut.Connection = conn;
                komut.CommandType = CommandType.StoredProcedure;
                komut.CommandText = "Shasad";
                SqlDataAdapter dr = new SqlDataAdapter(komut);
                DataTable filldata = new DataTable();
                dr.Fill(filldata);
                dataGridView1.DataSource = filldata;
            }
            else if (comboBox6.SelectedIndex == 4)
            {
                SqlCommand komut = new SqlCommand();
                komut.Connection = conn;
                komut.CommandType = CommandType.StoredProcedure;
                komut.CommandText = "Shasyas";
                SqlDataAdapter dr = new SqlDataAdapter(komut);
                DataTable filldata = new DataTable();
                dr.Fill(filldata);
                dataGridView1.DataSource = filldata;
            }
            else if (comboBox6.SelectedIndex == 5)
            {
                SqlCommand komut = new SqlCommand();
                komut.Connection = conn;
                komut.CommandType = CommandType.StoredProcedure;
                komut.CommandText = "Shasboy";
                SqlDataAdapter dr = new SqlDataAdapter(komut);
                DataTable filldata = new DataTable();
                dr.Fill(filldata);
                dataGridView1.DataSource = filldata;
            }
            else if (comboBox6.SelectedIndex == 6)
            {
                SqlCommand komut = new SqlCommand();
                komut.Connection = conn;
                komut.CommandType = CommandType.StoredProcedure;
                komut.CommandText = "SpolKap";
                SqlDataAdapter dr = new SqlDataAdapter(komut);
                DataTable filldata = new DataTable();
                dr.Fill(filldata);
                dataGridView1.DataSource = filldata;
            }
            else if (comboBox6.SelectedIndex == 7)
            {
                SqlCommand komut = new SqlCommand();
                komut.Connection = conn;
                komut.CommandType = CommandType.StoredProcedure;
                komut.CommandText = "SpolCiro";
                SqlDataAdapter dr = new SqlDataAdapter(komut);
                DataTable filldata = new DataTable();
                dr.Fill(filldata);
                dataGridView1.DataSource = filldata;
            }
            else if (comboBox6.SelectedIndex == 8)
            {
                SqlCommand komut = new SqlCommand();
                komut.Connection = conn;
                komut.CommandType = CommandType.StoredProcedure;
                komut.CommandText = "SreceteTar";
                SqlDataAdapter dr = new SqlDataAdapter(komut);
                DataTable filldata = new DataTable();
                dr.Fill(filldata);
                dataGridView1.DataSource = filldata;
            }
        }

        private void simpleButton9_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand();
            komut.Connection = conn;
            komut.CommandType = CommandType.StoredProcedure;
            komut.CommandText = "polCiroToplam";
            SqlDataAdapter dr = new SqlDataAdapter(komut);
            DataTable filldata = new DataTable();
            dr.Fill(filldata);
            dataGridView1.DataSource = filldata;
        }

        private void simpleButton15_Click(object sender, EventArgs e)
        {
            doktor_sayfa  dgec =new doktor_sayfa();
            dgec.Show();
            this.Hide();
        }
    }
}
