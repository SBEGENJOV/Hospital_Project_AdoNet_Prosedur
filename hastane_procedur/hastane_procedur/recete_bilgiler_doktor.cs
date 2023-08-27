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
    public partial class recete_bilgiler_doktor : Form
    {
        SqlConnection conn = new SqlConnection("Server=DESKTOP-5K7HMBT\\SQLEXPRESS;Database=hastane_otomasyon;Integrated Security=true;");
        public recete_bilgiler_doktor()
        {
            InitializeComponent();
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
                comboBox1.Items.Add(reader["doktorNo"]);
            }
            conn.Close();
        }
        public void hasListele()
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = conn;
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.CommandText = "hastaListele";
            conn.Open();
            SqlDataReader reader = sqlCommand.ExecuteReader();
            while (reader.Read()) //true oldugu sürece çalışacak.
            {
                comboBox2.Items.Add(reader["hastaNo"]);
            }
            conn.Close();
        }
        public void recListele()
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
        private void recete_bilgiler_doktor_Load(object sender, EventArgs e)
        {
            dokListele();
            hasListele();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            recListele();
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            if (DateTime.TryParseExact(maskedTextBox1.Text, "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out DateTime tarih))
            {
                conn.Open();
                SqlCommand command = new SqlCommand();
                command.Connection = conn;
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "receteEkle";
                command.Parameters.AddWithValue("receteTarih", tarih);
                command.Parameters.AddWithValue("receteAdi", textBox2.Text);
                command.Parameters.AddWithValue("doktorNo", comboBox1.Text);
                command.Parameters.AddWithValue("hastaNo", comboBox2.Text);
                command.ExecuteNonQuery();
                conn.Close();
                MessageBox.Show("Kayıt eklendi");
                recListele();
            }
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            conn.Open();
            SqlCommand command = new SqlCommand();
            command.Connection = conn;
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "receteGuncelle";
            command.Parameters.AddWithValue("receteNo", textBox2.Tag);
            command.Parameters.AddWithValue("receteTarih", maskedTextBox1.Text);
            command.Parameters.AddWithValue("receteAdi", textBox2.Text);
            command.Parameters.AddWithValue("doktorNo", comboBox1.Text);
            command.Parameters.AddWithValue("hastaNo", comboBox2.Text);
            command.ExecuteNonQuery();
            conn.Close();
            MessageBox.Show("Kayıt eklendi");
            recListele();
        }

        private void simpleButton5_Click(object sender, EventArgs e)
        {
            conn.Open();
            SqlCommand command = new SqlCommand();
            command.Connection = conn;
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "receteSil";
            command.Parameters.AddWithValue("receteNo", textBox2.Tag);
            command.ExecuteNonQuery();
            conn.Close();
            MessageBox.Show("Recete Silindi");
            recListele();
        }

        private void simpleButton4_Click(object sender, EventArgs e)
        {
            conn.Open();
            SqlCommand command = new SqlCommand();
            command.Connection = conn;
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "receteAra";
            command.Parameters.AddWithValue("receteAdi", textBox2.Text);
            SqlDataAdapter dr = new SqlDataAdapter(command);
            DataTable filldata = new DataTable();
            dr.Fill(filldata);
            dataGridView1.DataSource = filldata;
            command.ExecuteNonQuery();
            conn.Close();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow satir = dataGridView1.CurrentRow;
            textBox2.Tag = satir.Cells["receteNo"].Value.ToString();
            maskedTextBox1.Text = satir.Cells["receteTarih"].Value.ToString();
            textBox2.Text = satir.Cells["receteAdi"].Value.ToString();
            comboBox1.Text = satir.Cells["doktorNo"].Value.ToString();
            comboBox2.Text = satir.Cells["hastaNo"].Value.ToString();
        }
    }
}
