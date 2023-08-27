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
   
    public partial class doktor_giris : Form
    {
        SqlConnection conn = new SqlConnection("Server=DESKTOP-5K7HMBT\\SQLEXPRESS;Database=hastane_otomasyon;Integrated Security=true;");
        public doktor_giris()
        {
            InitializeComponent();
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            Form1 geri = new Form1();
            geri.Show();
            this.Hide();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            conn.Open();
            SqlCommand command = new SqlCommand();
            command.Connection = conn;
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "dLogin";
            command.Parameters.AddWithValue("yoneticiAdi", textBox1.Text);
            command.Parameters.AddWithValue("yoneticiSifre", textBox2.Text);
            command.ExecuteNonQuery();
            conn.Close();
            MessageBox.Show("Giriş başarılı");
            doktor_sayfa dgit = new doktor_sayfa();
            dgit.Show();
            this.Hide();
        }
    }
}
