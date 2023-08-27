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
    public partial class kullanıcı_giris : Form
    {
        public kullanıcı_giris()
        {
            InitializeComponent();
        }
        SqlConnection conn = new SqlConnection("Server=DESKTOP-5K7HMBT\\SQLEXPRESS;Database=hastane_otomasyon;Integrated Security=true;");
        private void simpleButton2_Click(object sender, EventArgs e)
        {
            Form1 geri = new Form1();
            geri.Show();
            this.Hide();
        }
        public static int deger;
        private void simpleButton1_Click(object sender, EventArgs e)
        {
            if (deger == 0)
            {
                conn.Open();
                SqlCommand command = new SqlCommand();
                command.Connection = conn;
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "hLogin";
                command.Parameters.AddWithValue("adSoyad", textBox1.Text);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    deger = Convert.ToInt32(reader["hastaNo"]);
                }
                reader.Close();
                conn.Close();
                MessageBox.Show("Giriş başarılı");
                hasta_sayfa hsayfa = new hasta_sayfa();
                hsayfa.Show();
                this.Hide();
            }
        }
    }
}
