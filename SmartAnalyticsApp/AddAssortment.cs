using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SmartAnalyticsApp
{
    public partial class AddAssortment : Form
    {
        public AddAssortment()
        {
            InitializeComponent();
        }
       
        private void simpleButton3_Click(object sender, EventArgs e)
        {
            DbConn.Insert(textBox34.Text, textBox35.Text, textBox36.Text, textBox37.Text, textBox39.Text, "PriceList");

            this.Close();
        }
    }
}
