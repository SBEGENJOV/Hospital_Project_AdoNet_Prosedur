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

namespace hastane_procedur
{
    public partial class asistan_bilgiler_doktor : Form
    {
        public asistan_bilgiler_doktor()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow satir = dataGridView1.CurrentRow;
            textBox2.Tag = satir.Cells["kullanıcıAdi"].Value.ToString();
            textBox1.Text = satir.Cells["kullanıcıSifre"].Value.ToString();
            textBox2.Text = satir.Cells["kullanıcıAdi"].Value.ToString();
        }
        SqlConnection conn = new SqlConnection("Server=DESKTOP-5K7HMBT\\SQLEXPRESS;Database=hastane_otomasyon;Integrated Security=true;");
        private void simpleButton1_Click(object sender, EventArgs e)
        {
            asListe();
        }
        public void asListe()
        {
            SqlCommand komut = new SqlCommand();
            komut.Connection = conn;
            komut.CommandType = CommandType.StoredProcedure;
            komut.CommandText = "aListele";
            SqlDataAdapter dr = new SqlDataAdapter(komut);
            DataTable filldata = new DataTable();
            dr.Fill(filldata);
            dataGridView1.DataSource = filldata;
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            conn.Open();
            SqlCommand command = new SqlCommand();
            command.Connection = conn;
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "aEkle";
            command.Parameters.AddWithValue("kullanıcıAdi", textBox2.Text);
            command.Parameters.AddWithValue("kullanıcıSifre", textBox1.Text);
            command.ExecuteNonQuery();
            conn.Close();
            MessageBox.Show("Asistan eklendi");
            asListe();
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            conn.Open();
            SqlCommand command = new SqlCommand();
            command.Connection = conn;
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "aGuncelle";
            command.Parameters.AddWithValue("kullanıcıAdi", textBox2.Text);
            command.Parameters.AddWithValue("kullanıcıSifre", textBox1.Text);
            command.ExecuteNonQuery();
            conn.Close();
            MessageBox.Show("Asistan Güncellendi");
            asListe();
        }

        private void simpleButton5_Click(object sender, EventArgs e)
        {
            conn.Open();
            SqlCommand command = new SqlCommand();
            command.Connection = conn;
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "aSil";
            command.Parameters.AddWithValue("kullanıcıAdi", textBox2.Text);
            command.ExecuteNonQuery();
            conn.Close();
            MessageBox.Show("Asistan Silindi");
            asListe();
        }
    }
}
