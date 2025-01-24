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
    public partial class gelirGiderler : Form
    {
        public gelirGiderler()
        {
            InitializeComponent();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            anaForm fr = new anaForm();
            fr.Show();
            this.Hide();
        }

        private void yoneticiBilgileriBtn_Click(object sender, EventArgs e)
        {
            
        }
    }
}
