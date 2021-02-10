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
    public partial class AddMaker : Form
    {
        public AddMaker()
        {
            InitializeComponent();
        }

        private void AddMakerButton_Click(object sender, EventArgs e)
        {

            Task task = new Task(InsertMaker);
            task.Start();
            task.Wait();
            this.Close();
            new XtraForm2().ShowMaker();
        }
        public void InsertMaker()
        {
            DbConn.Insert(textBox7.Text, "Maker");
        }
    }
}
