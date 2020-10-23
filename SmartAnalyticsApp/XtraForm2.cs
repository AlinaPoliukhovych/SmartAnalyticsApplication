using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Threading;
using System.Data.SqlClient;
using DevExpress.XtraCharts;

namespace SmartAnalyticsApp
{
    public partial class XtraForm2 : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        string connectionString = @"Data Source=DESKTOP-VFFBM2L\MSSQLSERVER04;
                                        Initial Catalog=Dairy;Integrated Security=True";

        public XtraForm2()
        {
            InitializeComponent();
        }

        private void XtraForm2_Load(object sender, EventArgs e)
        {
            dataGridView2.DataSource = DbConn.GetData($"SELECT * FROM TypeProduct");
            dataGridView1.Font = new Font("Arial", 16.5F, GraphicsUnit.Pixel);
            dataGridView2.Font = new Font("Arial", 16.5F, GraphicsUnit.Pixel);
            dataGridView3.Font = new Font("Arial", 12.5F, GraphicsUnit.Pixel);
            dataGridView4.Font = new Font("Arial", 12.5F, GraphicsUnit.Pixel);
            dataGridView5.Font = new Font("Arial", 12.5F, GraphicsUnit.Pixel);
            dataGridView6.Font = new Font("Arial", 16.5F, GraphicsUnit.Pixel);
            dataGridView7.Font = new Font("Arial", 16.5F, GraphicsUnit.Pixel);
            dataGridView8.Font = new Font("Arial", 16.5F, GraphicsUnit.Pixel);
            dataGridView9.Font = new Font("Arial", 16.5F, GraphicsUnit.Pixel);
            dataGridView3.DataSource = DbConn.GetData($"SELECT * FROM Greasiness");
            dataGridView4.DataSource = DbConn.GetData($"SELECT Packaging.Id, TypePackaging.Namee, VolumePackaging.Valuee " +
                " FROM Packaging JOIN TypePackaging ON TypePackaging.ID = Packaging.TypePackagingID " +
                "JOIN VolumePackaging ON VolumePackaging.ID = Packaging.VolumePackagingID ");
            dataGridView5.DataSource = DbConn.GetDataTable("ShowPrice");
            ShowMaker();
            ShowCheckProduct();
            ShowCheckUnique();
            RefreshSearchForm();
            
            ShowAllSale();

            CreateChartMakerProduct__Sum();
            CreateChartTypePackaging__Sum();
            CreateChartDataAffiliate__Sum();
        }
        public void ShowMaker()
        {
            Thread.Sleep(1000);
            dataGridView1.DataSource = DbConn.GetData($"SELECT * FROM Maker");
        }
        public void InsertMaker()
        {
            DbConn.Insert(textBox9.Text, "Maker");
        }
        private void simpleButton8_Click(object sender, EventArgs e)
        {
            Task task = new Task(InsertMaker);
            task.Start();
            task.Wait();

            textBox9.Text = "";
            ShowMaker();
        }
        public void UpdateMaker()
        {
            DbConn.Update("Namee", textBox10.Text, "Maker", textBox11.Text);
        }

        private void simpleButton7_Click(object sender, EventArgs e)
        {
            Task task = new Task(UpdateMaker);
            task.Start();
            task.Wait();

            textBox10.Text = "";
            textBox11.Text = "";

            ShowMaker();
        }
        public void DeleteMaker()
        {
            DbConn.Delete(textBox12.Text, "Maker");
        }
        private void simpleButton6_Click(object sender, EventArgs e)
        {
            Task task = new Task(DeleteMaker);
            task.Start();
            task.Wait();

            textBox12.Text = "";
            ShowMaker();
        }
        public void InsertTypeProduct()
        {
            DbConn.Insert(textBox7.Text, "TypeProduct");
        }
        private void simpleButton9_Click(object sender, EventArgs e)
        {
            Task task = new Task(DeleteTypeProduct);
            task.Start();
            task.Wait();

            textBox1.Text = "";
            dataGridView2.DataSource = DbConn.GetData($"SELECT * FROM TypeProduct");
        }
        public void UpdateTypeProduct()
        {
            DbConn.Update("Namee", textBox2.Text, "TypeProduct", textBox4.Text);
        }
        private void simpleButton10_Click(object sender, EventArgs e)
        {
            Task task = new Task(UpdateTypeProduct);
            task.Start();
            task.Wait();

            textBox2.Text = "";
            textBox4.Text = "";

            dataGridView2.DataSource = DbConn.GetData($"SELECT * FROM TypeProduct");
        }
        public void DeleteTypeProduct()
        {
            DbConn.Delete(textBox1.Text, "TypeProduct");
        }

        private void simpleButton11_Click(object sender, EventArgs e)
        {
            Task task = new Task(InsertTypeProduct);
            task.Start();
            task.Wait();

            textBox7.Text = "";
            dataGridView2.DataSource = DbConn.GetData($"SELECT * FROM TypeProduct");
        }

        private async void simpleButton3_Click(object sender, EventArgs e)
        {
            if (label55.Visible)
                label55.Visible = false;
            Task task = new Task(InsertPriceList);
            task.Start();
            task.Wait();

            textBox34.Text = "";
            textBox35.Text = "";
            textBox36.Text = "";
            textBox37.Text = "";
            textBox39.Text = "";

            label55.Visible = true;
            label55.Text = "Натисніть клавішу \"Оновити\", щоб дані в таблиці оновилися.";
            await Task.Delay(4000);
            label55.Text = "";
        }
        public void InsertPriceList()
        {
            DbConn.Insert(textBox34.Text, textBox35.Text, textBox36.Text, textBox37.Text, textBox39.Text, "PriceList");
        }

        private async void simpleButton4_Click(object sender, EventArgs e)
        {
            if (label55.Visible)
                label55.Visible = false;
            Task task = new Task(UpdatePriceList);
            task.Start();
            task.Wait();

            textBox23.Text = "";
            textBox32.Text = "";
            textBox31.Text = "";
            textBox30.Text = "";
            textBox22.Text = "";
            textBox33.Text = "";

            label55.Visible = true;
            label55.Text = "Натисніть клавішу \"Оновити\", щоб дані в таблиці оновилися.";
            await Task.Delay(4000);
            label55.Text = "";
        }
        public void UpdatePriceList()
        {
            Dictionary<string, string> keyValuePairs = new Dictionary<string, string>
            {
                ["ID"] = textBox23.Text,
                ["TypeProductID"] = textBox32.Text,
                ["MakerID"] = textBox31.Text,
                ["Price"] = textBox30.Text,
                ["PackagingID"] = textBox22.Text,
                ["GreasinessID"] = textBox33.Text,
            };

            DbConn.Update(keyValuePairs, "PriceList");
        }

        private async void simpleButton5_Click(object sender, EventArgs e)
        {
            if (label55.Visible)
                label55.Visible = false;
            Task task = new Task(DeletePriceList);
            task.Start();
            task.Wait();

            textBox21.Text = "";
            label55.Visible = true;
            label55.Text = "Натисніть клавішу \"Оновити\", щоб дані в таблиці оновилися.";
            await Task.Delay(4000);
            label55.Text = "";
        }
        public void DeletePriceList()
        {
            DbConn.Delete(textBox21.Text, "PriceList");
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            dataGridView5.DataSource = DbConn.GetDataTable("ShowPrice");          
        }
        public void ShowCheckProduct()
        {
            dataGridView7.DataSource = DbConn.GetDataTable("ShowCheckProduct");
        }
        public void ShowCheckUnique()
        {
            dataGridView6.DataSource = DbConn.GetDataTable("ShowCheckUnique");
        }

        private void dataGridView6_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = dataGridView6.Rows[e.RowIndex];

            if (dataGridView6.SelectedCells.Count > 0)
            {
                int selectedrowindex = dataGridView6.SelectedCells[0].RowIndex;
                DataGridViewRow selectedRow = dataGridView6.Rows[selectedrowindex];
                string a = Convert.ToString(selectedRow.Cells["Id"].Value);

                int rowIndex = -1;
                try
                {
                    foreach (DataGridViewRow rows in dataGridView7.Rows)
                    {
                        if (rows.Cells[0].Value.ToString().Equals(a))
                        {
                            rowIndex = rows.Index;
                            dataGridView7.Rows[rows.Index].Selected = true;
                        }
                    }
                }
                catch (Exception ex)
                {
                }                
            }

        }

        private void simpleButton12_Click(object sender, EventArgs e)
        {
            dataGridView7.ClearSelection();
        }

        private void ribbonControl_Click(object sender, EventArgs e)
        {

        }
        public void ShowGroup()
        {
            try
            {
                string columns = "";

                if (checkBox1.Checked)
                {
                    columns += "TypeProduct.Namee, ";
                }
                if (checkBox2.Checked)
                {
                    columns += "Maker.Namee, ";
                }
                if (checkBox3.Checked)
                {
                    columns += "TypePackaging.Namee, ";
                }
                if (checkBox4.Checked)
                {
                    columns += "VolumePackaging.valuee, ";
                }
                if (checkBox5.Checked)
                {
                    columns += "Greasiness.Valuee, ";
                }
                if (!string.IsNullOrEmpty(columns) && !string.IsNullOrWhiteSpace(columns))
                {
                    int index = columns.LastIndexOf(",");

                    columns = columns.Remove(index);
                }
                string from = "Maker JOIN PriceList ON Maker.Id=PriceList.MakerID JOIN TypeProduct ON TypeProduct.Id = PriceList.TypeProductID JOIN Packaging ON Packaging.Id = PriceList.PackagingID  JOIN TypePackaging ON TypePackaging.Id = Packaging.TypePackagingID JOIN VolumePackaging ON VolumePackaging.Id = Packaging.VolumePackagingID JOIN Greasiness ON Greasiness.Id = PriceList.GreasinessID  JOIN CheckProduct ON CheckProduct.PriceListID = PriceList.Id JOIN CheckUnique ON CheckUnique.Id = CheckProduct.CheckUniqueID JOIN Affiliate ON Affiliate.Id = CheckUnique.AffiliateID";

                string query = $"SELECT {columns}, Sum(CheckProduct.Countt) as Count, SUM(PriceList.Price*CheckProduct.Countt) as Sum FROM {from} GROUP BY {columns}";
                dataGridView9.DataSource = null;
                dataGridView9.DataSource = DbConn.GetData(query);
            }
            catch
            {

            }
        }
        public void ShowAllSale()
        {
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))//ShowAllSale
            {
                sqlConnection.Open();
                SqlCommand command = new SqlCommand("ShowAllSale", sqlConnection);
                command.CommandType = CommandType.StoredProcedure;
                DataTable dt = new DataTable();
                dt.Load(command.ExecuteReader());
                dataGridView9.DataSource = dt;
                sqlConnection.Close();
            }
        }
        private void button5_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;

            checkBox1.Checked = false;
            checkBox2.Checked = false;
            checkBox3.Checked = false;
            checkBox4.Checked = false;
            checkBox5.Checked = false;

            ShowAllSale();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            ShowGroup();
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            ShowGroup();
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            ShowGroup();
        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            ShowGroup();
        }

        private void checkBox5_CheckedChanged(object sender, EventArgs e)
        {
            ShowGroup();
        }
        public void RefreshSearchForm()
        {

            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {

                sqlConnection.Open();
                SqlCommand command = new SqlCommand("SearchProductsBy", sqlConnection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("TypeProduct", SqlDbType.NVarChar).Value = textBox3.Text.Trim();
                command.Parameters.AddWithValue("Maker", SqlDbType.NVarChar).Value = textBox5.Text.Trim();
                command.Parameters.AddWithValue("TypePackaging", SqlDbType.NVarChar).Value = comboBox1.Text.Trim();
                command.Parameters.AddWithValue("VolumePackaging", SqlDbType.NVarChar).Value = comboBox2.Text.Trim();
                command.Parameters.AddWithValue("Greasiness", SqlDbType.NVarChar).Value = comboBox3.Text.Trim();
                command.Parameters.AddWithValue("Price", SqlDbType.NVarChar).Value = textBox6.Text.Trim();
                command.ExecuteNonQuery();
                DataTable dt = new DataTable();
                dt.Load(command.ExecuteReader());
                dataGridView8.DataSource = dt;
                sqlConnection.Close();

            }
        }
        public async void ToFiltr()
        {
                using (SqlConnection sqlConnection = new SqlConnection(connectionString))
                {
                    int count = 0;
                    int sum = 0;
                    sqlConnection.Open();
                    SqlDataReader sqlReader = null;
                    SqlCommand command;
                    command = new SqlCommand("OrdersProc", sqlConnection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("TypeProduct", SqlDbType.NVarChar).Value = textBox15.Text.Trim();
                    command.Parameters.AddWithValue("Maker", SqlDbType.NVarChar).Value = textBox14.Text.Trim();
                    command.Parameters.AddWithValue("TypePackaging", SqlDbType.NVarChar).Value = comboBox6.Text.Trim();
                    command.Parameters.AddWithValue("VolumePackaging", SqlDbType.NVarChar).Value = comboBox5.Text.Trim();
                    command.Parameters.AddWithValue("Greasiness", SqlDbType.NVarChar).Value = comboBox4.Text.Trim();

                    try
                    {

                        sqlReader = await command.ExecuteReaderAsync();
                        while (await sqlReader.ReadAsync())
                        {
                            count = Convert.ToInt32(sqlReader["CountProduct"]);
                            sum = Convert.ToInt32(sqlReader["SumProduct"]);

                        }
                        textBox13.Text = Convert.ToString(count);
                        textBox8.Text = Convert.ToString(sum);

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Не знайдено, оберіть іншу характеристику.", "Увага", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    }
                    finally
                    {
                        if (sqlReader != null)
                            sqlReader.Close();
                    }

                }
            }
        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            RefreshSearchForm();
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            RefreshSearchForm();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            RefreshSearchForm();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            RefreshSearchForm();
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            RefreshSearchForm();
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            RefreshSearchForm();
        }

        private void textBox15_TextChanged(object sender, EventArgs e)
        {
            ToFiltr();
        }

        private void textBox14_TextChanged(object sender, EventArgs e)
        {
            ToFiltr();
        }

        private void comboBox6_SelectedIndexChanged(object sender, EventArgs e)
        {
            ToFiltr();
        }

        private void comboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {
            ToFiltr();
        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            ToFiltr();
        }
        //Chart 
      
        public void CreateChartDataAffiliate__Sum()
        {
            //chart 3 - affiliate
            panel8.Controls.Clear();
            panel8.Controls.Add(ChartMaker.MakeChart("ChartByFillials", "Виробник", "Філіал", "Sum"));

            panel9.Controls.Clear();
            panel9.Controls.Add(ChartMaker.MakeChart("ChartByFillials", "Тип_продукції", "Філіал", "Sum"));
        }
        public void CreateChartDataAffiliate__Count()
        {
            //chart 3 - affiliate
            panel8.Controls.Clear();
            panel8.Controls.Add(ChartMaker.MakeChart("ChartByFillials", "Виробник", "Філіал", "Count"));

            panel9.Controls.Clear();
            panel9.Controls.Add(ChartMaker.MakeChart("ChartByFillials", "Тип_продукції", "Філіал", "Count"));
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Registration form1 = new Registration();
            form1.Show();
        }

        // Chart 3 - sum on Affiliate
        private void toggleSwitch1_Toggled(object sender, EventArgs e)
        {
            if (toggleSwitch1.IsOn == true)
            {
                CreateChartDataAffiliate__Count();
                toggleSwitch2.IsOn = false;
                toggleSwitch1.BackColor = Color.Green;
                toggleSwitch2.BackColor = Color.Red;
            }
            else
            {
                CreateChartDataAffiliate__Sum();
                toggleSwitch2.IsOn = true;
                toggleSwitch2.BackColor = Color.Green;
                toggleSwitch1.BackColor = Color.Red;
            }
        }
        // Chart 3 - sum on Affiliate
        private void toggleSwitch2_Toggled(object sender, EventArgs e)
        {
            if (toggleSwitch2.IsOn == true)
            {
                CreateChartDataAffiliate__Sum();
                toggleSwitch1.IsOn = false;
                toggleSwitch2.BackColor = Color.Green;
                toggleSwitch1.BackColor = Color.Red;

            }
            else
            {
                CreateChartDataAffiliate__Count();
                toggleSwitch1.IsOn = true;
                toggleSwitch1.BackColor = Color.Green;
                toggleSwitch2.BackColor = Color.Red;

            }
        }
        // Chart 1 - sum on maker and type product
        public void CreateChartMakerProduct__Sum()
        {
            //chart1 - maker and type product
            panel11.Controls.Clear();
            panel11.Controls.Add(ChartMaker.MakeChart("ChartByMakerSum", "Тип_продукції", "Виробник", "Sum"));

            panel10.Controls.Clear();
            panel10.Controls.Add(ChartMaker.MakeChart("ChartByMakerSum", "Виробник", "Тип_продукції", "Sum"));
        }
        public void CreateChartMakerProduct__Count()
        {
            //chart1 - maker and type product
            panel11.Controls.Clear();
            panel11.Controls.Add(ChartMaker.MakeChart("ChartByMakerSum", "Тип_продукції", "Виробник", "Count"));

            panel10.Controls.Clear();
            panel10.Controls.Add(ChartMaker.MakeChart("ChartByMakerSum", "Виробник", "Тип_продукції", "Count"));
        }
        private void toggleSwitch6_Toggled(object sender, EventArgs e)
        {
            if (toggleSwitch6.IsOn == true)
            {
                CreateChartMakerProduct__Sum();
                toggleSwitch5.IsOn = false;
                toggleSwitch6.BackColor = Color.Green;
                toggleSwitch5.BackColor = Color.Red;
            }
            else
            {
                CreateChartMakerProduct__Count();
                toggleSwitch5.IsOn = true;
                toggleSwitch5.BackColor = Color.Green;
                toggleSwitch6.BackColor = Color.Red;
            }
        }

        // Chart 1 - sum on maker and type product
        private void toggleSwitch5_Toggled(object sender, EventArgs e)
        {
            if (toggleSwitch5.IsOn == true)
            {
                CreateChartDataAffiliate__Sum();
                toggleSwitch6.IsOn = false;
                toggleSwitch6.BackColor = Color.Green;
                toggleSwitch5.BackColor = Color.Red;

            }
            else
            {
                CreateChartDataAffiliate__Count();
                toggleSwitch6.IsOn = true;
                toggleSwitch6.BackColor = Color.Green;
                toggleSwitch5.BackColor = Color.Red;

            }
        }

        //chart 2 - packaging
        public void CreateChartTypePackaging__Sum()
        {
            //chart2 - volume and packaging
            panel12.Controls.Clear();
            panel12.Controls.Add(ChartMaker.MakeChart("ChartByTypePackaging", "Ємність", "Тип_упаковки", "Sum"));

            panel16.Controls.Clear();
            panel16.Controls.Add(ChartMaker.MakeChart("ChartByTypePackagingAndProduct", "Тип_продукції", "Тип_упаковки", "Sum"));

            panel17.Controls.Clear();
            panel17.Controls.Add(ChartMaker.MakeChart("ChartByTypePackagingAndProduct", "Тип_упаковки", "Тип_продукції", "Sum"));
        }

        //chart 2 - packaging
        public void CreateChartTypePackaging__Count()
        {
            //chart2 - volume and packaging
            panel12.Controls.Clear();
            panel12.Controls.Add(ChartMaker.MakeChart("ChartByTypePackaging", "Ємність", "Тип_упаковки", "Count"));

            panel16.Controls.Clear();
            panel16.Controls.Add(ChartMaker.MakeChart("ChartByTypePackagingAndProduct", "Тип_продукції", "Тип_упаковки", "Count"));

            panel17.Controls.Clear();
            panel17.Controls.Add(ChartMaker.MakeChart("ChartByTypePackagingAndProduct", "Тип_упаковки", "Тип_продукції", "Count"));

        }

        private void toggleSwitch4_Toggled(object sender, EventArgs e)//sum
        {
            if (toggleSwitch4.IsOn == true)
            {
                CreateChartTypePackaging__Sum();
                toggleSwitch3.IsOn = false;
                toggleSwitch4.BackColor = Color.Green;
                toggleSwitch3.BackColor = Color.Red;

            }
            else
            {
                CreateChartTypePackaging__Count();
                toggleSwitch3.IsOn = true;
                toggleSwitch3.BackColor = Color.Green;
                toggleSwitch4.BackColor = Color.Red;

            }
        }

        private void toggleSwitch3_Toggled(object sender, EventArgs e)//count
        {
            if (toggleSwitch3.IsOn == true)
            {
                CreateChartTypePackaging__Count();
                toggleSwitch4.IsOn = false;
                toggleSwitch3.BackColor = Color.Green;
                toggleSwitch4.BackColor = Color.Red;
            }
            else
            {
                CreateChartTypePackaging__Sum();
                toggleSwitch4.IsOn = true;
                toggleSwitch4.BackColor = Color.Green;
                toggleSwitch3.BackColor = Color.Red;
            }
        }

        private void label9_Click(object sender, EventArgs e)
        {

        }
    }
}