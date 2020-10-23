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
    public partial class Registration : Form
    {
        public Registration()
        {
            InitializeComponent();
        }
        string connectionString = @"Data Source=DESKTOP-VFFBM2L\MSSQLSERVER04;
                                        Initial Catalog=Dairy;Integrated Security=True";

        private void Form1_Load(object sender, EventArgs e)
        {
            ChartControl chart = new ChartControl();

            chart.DataSource = CreateChartData();
            chart.SeriesDataMember = "Виробник";
            chart.SeriesTemplate.ArgumentDataMember = "Sum";
            chart.SeriesTemplate.ValueDataMembers.AddRange(new string[] { "Sum" });

            chart.SeriesTemplate.View = new StackedBarSeriesView();

            chart.SeriesNameTemplate.BeginText = "Виробник: ";

            chart.Dock = DockStyle.Fill;
            this.Controls.Add(chart);

            //dataGridView1.DataSource = CreateChartData();
        }
        private DataTable CreateChartData()
        {
            //Create an empty table.
            //DataTable table = new DataTable("Table1");

            //// Add three columns to the table.
            //table.Columns.Add("Month", typeof(String));
            //table.Columns.Add("Section", typeof(String));
            //table.Columns.Add("Value", typeof(Int32));

            //// Add data rows to the table.
            //table.Rows.Add(new object[] { "Jan", "Section1", 10 });
            //table.Rows.Add(new object[] { "Jan", "Section2", 20 });
            //table.Rows.Add(new object[] { "Feb", "Section1", 20 });
            //table.Rows.Add(new object[] { "Feb", "Section2", 30 });
            //table.Rows.Add(new object[] { "March", "Section1", 15 });
            //table.Rows.Add(new object[] { "March", "Section2", 25 });

            //return table;
            /////////////////////////////////////////////////////////////////
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Open();
                SqlCommand command = new SqlCommand("ChartByMakerSum", sqlConnection);
                command.CommandType = CommandType.StoredProcedure;
                DataTable dt = new DataTable();
                dt.Load(command.ExecuteReader());
                //dataGridView6.DataSource = dt;
                sqlConnection.Close();
                return dt;
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Authorization authorization = new Authorization();
            authorization.Show();
            this.Close();
        }

        private async void simpleButton1_Click(object sender, EventArgs e)
        {
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
                    if (textBox2.Text==pass)
                    {
                        if ((!string.IsNullOrEmpty(textBox3.Text) && !string.IsNullOrWhiteSpace(textBox3.Text) &&
                            !string.IsNullOrEmpty(textBox4.Text) && !string.IsNullOrWhiteSpace(textBox4.Text)))
                        {
                            Task task = new Task(InsertAdmin);
                            task.Start();
                            task.Wait();
                            this.Close();
                            XtraForm2 xtraForm2 = new XtraForm2();
                            xtraForm2.Show();
                        }
                        else
                            MessageBox.Show("Заповніть всі поля!", "Увага!", MessageBoxButtons.OK, MessageBoxIcon.Warning);


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
        public void InsertAdmin()
        {
            DbConn.Insert(textBox4.Text, textBox3.Text, "Admins");
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ChangePassw changePassw = new ChangePassw();
            changePassw.Show();
            this.Close();
        }
    }
}
