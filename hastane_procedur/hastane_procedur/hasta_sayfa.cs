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
    public partial class hasta_sayfa : Form
    {
        public hasta_sayfa()
        {
            InitializeComponent();
        }
        SqlConnection conn = new SqlConnection("Server=DESKTOP-5K7HMBT\\SQLEXPRESS;Database=hastane_otomasyon;Integrated Security=true;");
        private void simpleButton1_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand();
            komut.Connection = conn;
            komut.CommandType = CommandType.StoredProcedure;
            komut.CommandText = "hastaKisiListele";
            komut.Parameters.AddWithValue("hastaNo", kullanıcı_giris.deger);
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
            komut.CommandText = "hastaRecete";
            komut.Parameters.AddWithValue("hastaNo", kullanıcı_giris.deger);
            SqlDataAdapter dr = new SqlDataAdapter(komut);
            DataTable filldata = new DataTable();
            dr.Fill(filldata);
            dataGridView1.DataSource = filldata;
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            conn.Open();
            SqlCommand command = new SqlCommand();
            command.Connection = conn;
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "hastaGuncelle";
            command.Parameters.AddWithValue("hastaNo", textBox1.Tag);
            command.Parameters.AddWithValue("adSoyad", textBox2.Text);
            command.Parameters.AddWithValue("yas", textBox1.Text);
            command.Parameters.AddWithValue("boy", textBox3.Text);
            command.Parameters.AddWithValue("kilo", textBox4.Text);
            command.ExecuteNonQuery();
            conn.Close();
            MessageBox.Show("Bilgilerin güncellendi");
            hListele();
        }
        public void hListele()
        {
            SqlCommand komut = new SqlCommand();
            komut.Connection = conn;
            komut.CommandType = CommandType.StoredProcedure;
            komut.CommandText = "hastaKisiListele";
            komut.Parameters.AddWithValue("hastaNo", kullanıcı_giris.deger);
            SqlDataAdapter dr = new SqlDataAdapter(komut);
            DataTable filldata = new DataTable();
            dr.Fill(filldata);
            dataGridView1.DataSource = filldata;
        }
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow satir = dataGridView1.CurrentRow;
            textBox1.Tag = satir.Cells["hastaNo"].Value.ToString();
            textBox2.Text = satir.Cells["adSoyad"].Value.ToString();
            textBox1.Text = satir.Cells["yas"].Value.ToString();
            textBox3.Text = satir.Cells["boy"].Value.ToString();
            textBox4.Text = satir.Cells["kilo"].Value.ToString();
        }

        private void simpleButton4_Click(object sender, EventArgs e)
        {
            kullanıcı_giris.deger = 0;
            Form1 form1 = new Form1();
            form1.Show();
            this.Hide();
        }
    }
}
