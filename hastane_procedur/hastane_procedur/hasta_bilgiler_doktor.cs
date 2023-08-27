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
    public partial class hasta_bilgiler_doktor : Form
    {
        public hasta_bilgiler_doktor()
        {
            InitializeComponent();
        }
        SqlConnection conn = new SqlConnection("Server=DESKTOP-5K7HMBT\\SQLEXPRESS;Database=hastane_otomasyon;Integrated Security=true;");
        public void hastalistele()
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
        private void button4_Click(object sender, EventArgs e)
        {
            hastalistele();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            conn.Open();
            SqlCommand command = new SqlCommand();
            command.Connection = conn;
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "hastaEkle";
            command.Parameters.AddWithValue("adSoyad", textBox4.Text);
            command.Parameters.AddWithValue("yas", textBox5.Text);
            command.Parameters.AddWithValue("boy", textBox6.Text);
            command.Parameters.AddWithValue("kilo", textBox7.Text);
            command.ExecuteNonQuery();
            conn.Close();
            MessageBox.Show("Kayıt eklendi");
            hastalistele();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            conn.Open();
            SqlCommand command = new SqlCommand();
            command.Connection = conn;
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "hastaGuncelle";
            command.Parameters.AddWithValue("hastaNo", textBox4.Tag);
            command.Parameters.AddWithValue("adSoyad", textBox4.Text);
            command.Parameters.AddWithValue("yas", textBox5.Text);
            command.Parameters.AddWithValue("boy", textBox6.Text);
            command.Parameters.AddWithValue("kilo", textBox7.Text);
            command.ExecuteNonQuery();
            conn.Close();
            MessageBox.Show("hasta güncellendi");
            hastalistele();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            conn.Open();
            SqlCommand command = new SqlCommand();
            command.Connection = conn;
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "hastAra";
            command.Parameters.AddWithValue("adSoyad", textBox4.Text);

            SqlDataAdapter dr = new SqlDataAdapter(command);
            DataTable filldata = new DataTable();
            dr.Fill(filldata);
            dataGridView1.DataSource = filldata;
            command.ExecuteNonQuery();
            conn.Close();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            conn.Open();
            SqlCommand command = new SqlCommand();
            command.Connection = conn;
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "hastaSil";
            command.Parameters.AddWithValue("hastaNo", textBox4.Tag);
            command.ExecuteNonQuery();
            conn.Close();
            MessageBox.Show("Hasta Silindi");
            hastalistele();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow satir = dataGridView1.CurrentRow;
            textBox4.Tag = satir.Cells["hastaNo"].Value.ToString();
            textBox4.Text = satir.Cells["adSoyad"].Value.ToString();
            textBox5.Text = satir.Cells["yas"].Value.ToString();
            textBox6.Text = satir.Cells["boy"].Value.ToString();
            textBox7.Text = satir.Cells["kilo"].Value.ToString();
        }
    }
}
