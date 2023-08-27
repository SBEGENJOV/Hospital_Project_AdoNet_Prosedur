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
    public partial class doktor_bilgiler_doktor : Form
    {
        public doktor_bilgiler_doktor()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button9_Click(object sender, EventArgs e)
        {

        }

        private void button10_Click(object sender, EventArgs e)
        {

        }

        private void button11_Click(object sender, EventArgs e)
        {

        }

        private void button12_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView3_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        SqlConnection conn = new SqlConnection("Server=DESKTOP-5K7HMBT\\SQLEXPRESS;Database=hastane_otomasyon;Integrated Security=true;");
        public void doktorListele()
        {
            SqlCommand komut = new SqlCommand();
            komut.Connection = conn;
            komut.CommandType = CommandType.StoredProcedure;
            komut.CommandText = "doktorListele";
            SqlDataAdapter dr = new SqlDataAdapter(komut);
            DataTable filldata = new DataTable();
            dr.Fill(filldata);
            dataGridView3.DataSource = filldata;
        }
        private void button12_Click_1(object sender, EventArgs e)
        {
            doktorListele();
        }

        private void button11_Click_1(object sender, EventArgs e)
        {
            conn.Open();
            SqlCommand command = new SqlCommand();
            command.Connection = conn;
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "doktorEkle";
            command.Parameters.AddWithValue("dokAdSoyad", textBox10.Text);
            command.Parameters.AddWithValue("dokMaas", textBox9.Text);
            command.Parameters.AddWithValue("dokBolum", textBox8.Text);
            command.Parameters.AddWithValue("dokYas", textBox3.Text);
            command.Parameters.AddWithValue("polikilinikNo", comboBox1.Text);
            command.ExecuteNonQuery();
            conn.Close();
            MessageBox.Show("Kayıt eklendi");
            doktorListele();
        }

        private void button10_Click_1(object sender, EventArgs e)
        {
            conn.Open();
            SqlCommand command = new SqlCommand();
            command.Connection = conn;
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "doktorGuncelle";
            command.Parameters.AddWithValue("doktorNo", textBox10.Tag);
            command.Parameters.AddWithValue("dokAdSoyad", textBox10.Text);
            command.Parameters.AddWithValue("dokMaas", textBox9.Text);
            command.Parameters.AddWithValue("dokBolum", textBox8.Text);
            command.Parameters.AddWithValue("dokYas", textBox3.Text);
            command.Parameters.AddWithValue("polikilinikNo", comboBox1.Text);
            command.ExecuteNonQuery();
            conn.Close();
            MessageBox.Show("Doktor güncellendi");
            doktorListele();
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            conn.Open();
            SqlCommand command = new SqlCommand();
            command.Connection = conn;
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "doktorAra";
            command.Parameters.AddWithValue("dokAdSoyad", textBox10.Text);

            SqlDataAdapter dr = new SqlDataAdapter(command);
            DataTable filldata = new DataTable();
            dr.Fill(filldata);
            dataGridView3.DataSource = filldata;
            command.ExecuteNonQuery();
            conn.Close();
        }

        private void button9_Click_1(object sender, EventArgs e)
        {
            conn.Open();
            SqlCommand command = new SqlCommand();
            command.Connection = conn;
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "DoktorSil";
            command.Parameters.AddWithValue("doktorNo", textBox10.Tag);
            command.ExecuteNonQuery();
            conn.Close();
            MessageBox.Show("Doktor Silindi");
            doktorListele();
        }

        private void dataGridView3_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow satir = dataGridView3.CurrentRow;
            textBox10.Tag = satir.Cells["doktorNo"].Value.ToString();
            textBox10.Text = satir.Cells["dokAdSoyad"].Value.ToString();
            textBox9.Text = satir.Cells["dokMaas"].Value.ToString();
            textBox8.Text = satir.Cells["dokBolum"].Value.ToString();
            textBox3.Text = satir.Cells["dokYas"].Value.ToString();
            comboBox1.Text = satir.Cells["polikilinikNo"].Value.ToString();
            doktorListele();
        }
    }
}
