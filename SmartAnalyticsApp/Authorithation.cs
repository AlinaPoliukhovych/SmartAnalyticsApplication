using DevExpress.XtraCharts;
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

namespace SmartAnalyticsApp
{
    public partial class Authorization : Form
    {
        public Authorization()
        {
            InitializeComponent();
        }
        string connectionString = @"Data Source=DESKTOP-VFFBM2L\MSSQLSERVER04;
                                        Initial Catalog=Dairy;Integrated Security=True";

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }
       
        private async void simpleButton1_Click(object sender, EventArgs e)
        {
            String login = textBox1.Text;
            String password = textBox2.Text;

            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                string pass = null;
                sqlConnection.Open();
                SqlDataReader sqlReader = null;
                SqlCommand command;
                command = new SqlCommand("CheckAdmins", sqlConnection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("login", SqlDbType.NVarChar).Value = textBox1.Text.Trim();

                try
                {
                    sqlReader = await command.ExecuteReaderAsync();
                    while (await sqlReader.ReadAsync())
                    {
                        pass = Convert.ToString(sqlReader["pas"]);

                    }
                    if (textBox2.Text == pass)
                    {                        
                        XtraForm2 xtraForm2 = new XtraForm2();
                        xtraForm2.Show();
                    }
                    else
                    {
                        textBox2.Text = "";
                        MessageBox.Show("Введено неправильні облікові дані.", "Увага", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    }
                }
                catch (Exception ex)
                {
                    //MessageBox.Show("Введено неправильні облікові дані.", "Увага", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                }
                finally
                {
                    if (sqlReader != null)
                        sqlReader.Close();
                }
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Registration authorithation = new Registration();
            authorithation.Show();
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ChangePassw changePassw = new ChangePassw();
            changePassw.Show();
        }
    }
}
