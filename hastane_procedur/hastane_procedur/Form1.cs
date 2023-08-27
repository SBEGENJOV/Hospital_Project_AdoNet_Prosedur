using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace hastane_procedur
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void pictureEdit1_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void pictureEdit2_EditValueChanged(object sender, EventArgs e)
        {
           
        }

        private void pictureEdit3_EditValueChanged(object sender, EventArgs e)
        {
            
        }

        private void pictureEdit4_EditValueChanged(object sender, EventArgs e)
        {
            
        }

        private void pictureEdit2_Click(object sender, EventArgs e)
        {
            doktor_giris dgir = new doktor_giris();
            dgir.Show();
            this.Hide();
        }
        private void pictureEdit3_Click(object sender, EventArgs e)
        {
            
        }
        private void pictureEdit4_Click(object sender, EventArgs e)
        {
            
        }

        private void pictureEdit3_Click_1(object sender, EventArgs e)
        {
            asistan_giris agir = new asistan_giris();
            agir.Show();
            this.Hide();
        }

        private void pictureEdit4_Click_1(object sender, EventArgs e)
        {
            kullanıcı_giris kgir = new kullanıcı_giris();
            kgir.Show();
            this.Hide();
        }
    }
}
