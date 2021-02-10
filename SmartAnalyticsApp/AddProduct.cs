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
    public partial class AddProduct : Form
    {
        public AddProduct()
        {
            InitializeComponent();
        }
        public void InsertTypeProduct()
        {
            DbConn.Insert(textBox7.Text, "TypeProduct");
        }
        private void AddMakerButton_Click(object sender, EventArgs e)
        {
            Task task = new Task(InsertTypeProduct);
            task.Start();
            task.Wait();
            this.Close();
        }
    }
}
