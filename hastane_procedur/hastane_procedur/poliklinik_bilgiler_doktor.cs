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
    public partial class poliklinik_bilgiler_doktor : Form
    {
        SqlConnection conn = new SqlConnection("Server=DESKTOP-5K7HMBT\\SQLEXPRESS;Database=hastane_otomasyon;Integrated Security=true;");

        public poliklinik_bilgiler_doktor()
        {
            InitializeComponent();
        }
        public void polListele()
        {
            SqlCommand komut = new SqlCommand();
            komut.Connection = conn;
            komut.CommandType = CommandType.StoredProcedure;
            komut.CommandText = "polListele";
            SqlDataAdapter dr = new SqlDataAdapter(komut);
            DataTable filldata = new DataTable();
            dr.Fill(filldata);
            dataGridView4.DataSource = filldata;
        }
        private void button17_Click(object sender, EventArgs e)
        {
            polListele();
        }

        private void button16_Click(object sender, EventArgs e)
        {
            conn.Open();
            SqlCommand command = new SqlCommand();
            command.Connection = conn;
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "polEkle";
            command.Parameters.AddWithValue("polKapasite", textBox14.Text);
            command.Parameters.AddWithValue("polBasHemsire", textBox13.Text);
            command.Parameters.AddWithValue("polAdres", textBox12.Text);
            command.Parameters.AddWithValue("polCiro", textBox11.Text);
            command.ExecuteNonQuery();
            conn.Close();
            MessageBox.Show("Kayıt eklendi");
            polListele();
        }

        private void button15_Click(object sender, EventArgs e)
        {
            conn.Open();
            SqlCommand command = new SqlCommand();
            command.Connection = conn;
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "polGuncelle";
            command.Parameters.AddWithValue("polikilinikNo", textBox14.Tag);
            command.Parameters.AddWithValue("polKapasite", textBox14.Text);
            command.Parameters.AddWithValue("polBasHemsire", textBox13.Text);
            command.Parameters.AddWithValue("polAdres", textBox12.Text);
            command.Parameters.AddWithValue("polCiro", textBox11.Text);
            command.ExecuteNonQuery();
            conn.Close();
            MessageBox.Show("Poliklinik bilgileri güncellendi");
            polListele();
        }

        private void button14_Click(object sender, EventArgs e)
        {
            conn.Open();
            SqlCommand command = new SqlCommand();
            command.Connection = conn;
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "polSil";
            command.Parameters.AddWithValue("polikilinikNo", textBox14.Tag);
            command.ExecuteNonQuery();
            conn.Close();
            MessageBox.Show("Poliklinik Silindi");
            polListele();
        }
    }
}
