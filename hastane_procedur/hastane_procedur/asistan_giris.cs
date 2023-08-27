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
    public partial class asistan_giris : Form
    {
        public asistan_giris()
        {
            InitializeComponent();
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            Form1 geri = new Form1();
            geri.Show();
            this.Hide();
        }
        SqlConnection conn = new SqlConnection("Server=DESKTOP-5K7HMBT\\SQLEXPRESS;Database=hastane_otomasyon;Integrated Security=true;");
        private void simpleButton1_Click(object sender, EventArgs e)
        {
            conn.Open();
            SqlCommand command = new SqlCommand();
            command.Connection = conn;
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "aLogin";
            command.Parameters.AddWithValue("kullanıcıAdi", textBox1.Text);
            command.Parameters.AddWithValue("kullanıcıSifre", textBox2.Text);
            command.ExecuteNonQuery();
            conn.Close();
            MessageBox.Show("Giriş başarılı");
            asistan_sayfa agec = new asistan_sayfa();
            agec.Show();
            this.Hide();
        }
    }
}
