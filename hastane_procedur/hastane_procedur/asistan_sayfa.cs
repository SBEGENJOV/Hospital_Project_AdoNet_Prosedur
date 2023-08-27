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
    public partial class asistan_sayfa : Form
    {
       
        public asistan_sayfa()
        {
            InitializeComponent();
            this.IsMdiContainer = true;
        }
        private hasta_bilgiler_doktor hdgec = new hasta_bilgiler_doktor();
        private recete_bilgiler_doktor rdgec = new recete_bilgiler_doktor();
        private void asistan_sayfa_Load(object sender, EventArgs e)
        {

        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            rdgec.Hide();
            hdgec.Show();
            hdgec.MdiParent = this;
            hdgec.Location = new Point(150, 100);
            hdgec.ControlBox = false;
        }

        private void simpleButton5_Click(object sender, EventArgs e)
        {
            rdgec.Show();
            rdgec.MdiParent = this;
            hdgec.Hide();
            rdgec.Location = new Point(150, 100);
            rdgec.ControlBox = false;
        }

        private void simpleButton6_Click(object sender, EventArgs e)
        {
            Form1 geri =new Form1();
            geri.Show();
            this.Hide();
        }
    }
}
