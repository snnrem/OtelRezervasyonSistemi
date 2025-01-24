using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _1_finalOdevOtelOtomasyonu
{
    public partial class odaBilgileriGuncelle : Form
    {
        public odaBilgileriGuncelle()
        {
            InitializeComponent();
        }

        private void button109_Click(object sender, EventArgs e)
        {
            odaBilgileriGuncelle od = new odaBilgileriGuncelle();
            od.Show();
            this.Hide();
        }

        private void button111_Click(object sender, EventArgs e)
        {
            odalar od = new odalar();
            od.Show();
            this.Hide();
        }

        private void button110_Click(object sender, EventArgs e)
        {
            anaForm fr = new anaForm();
            fr.Show();
            this.Hide();
        }
    }
}
