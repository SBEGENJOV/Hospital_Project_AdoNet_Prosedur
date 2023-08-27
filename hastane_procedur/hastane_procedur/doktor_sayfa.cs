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
    public partial class doktor_sayfa : Form
    {
       private hasta_bilgiler_doktor hdgec = new hasta_bilgiler_doktor();
       private doktor_bilgiler_doktor ddgec = new doktor_bilgiler_doktor();
       private poliklinik_bilgiler_doktor pdgec = new poliklinik_bilgiler_doktor();
       private recete_bilgiler_doktor rdgec = new recete_bilgiler_doktor();
       private asistan_bilgiler_doktor adgec = new asistan_bilgiler_doktor();
        public doktor_sayfa()
        {
            InitializeComponent();
            this.IsMdiContainer = true;
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            ddgec.Hide();
            pdgec.Hide();
            rdgec.Hide();
            adgec.Hide();
            hdgec.Show();
            hdgec.MdiParent = this;
            hdgec.Location = new Point(220, 140);
            hdgec.ControlBox = false;
        }

        private void simpleButton6_Click(object sender, EventArgs e)
        {
            Form1 ageri=new Form1();
            ageri.Show();
            this.Hide();
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            ddgec.Show();
            ddgec.MdiParent = this;
            pdgec.Hide();
            rdgec.Hide();
            adgec.Hide();
            hdgec.Hide();
            ddgec.Location = new Point(220, 140);
            ddgec.ControlBox = false;
        }

        private void simpleButton7_Click(object sender, EventArgs e)
        {
            ddgec.Hide();
            pdgec.Show();
            pdgec.MdiParent = this;
            rdgec.Hide();
            adgec.Hide();
            hdgec.Hide();
            pdgec.Location = new Point(220, 140);
            pdgec.ControlBox = false;
        }

        private void simpleButton5_Click(object sender, EventArgs e)
        {
            ddgec.Hide();
            pdgec.Hide();
            rdgec.Show();
            rdgec.MdiParent = this;
            adgec.Hide();
            hdgec.Hide();
            rdgec.Location = new Point(220, 140);
            rdgec.ControlBox = false;
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            ddgec.Hide();
            pdgec.Hide();
            rdgec.Hide();
            adgec.Show();
            adgec.MdiParent = this;
            hdgec.Hide();
            adgec.Location = new Point(220, 140);
            adgec.ControlBox = false;
        }

        private void doktor_sayfa_Load(object sender, EventArgs e)
        {

        }

        private void simpleButton4_Click(object sender, EventArgs e)
        {
            doktor_raporlama dr= new doktor_raporlama();
            dr.Show();
            this.Hide();
        }
    }
}
