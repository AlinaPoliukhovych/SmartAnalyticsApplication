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
    public partial class ChangePassw : Form
    {
        public ChangePassw()
        {
            InitializeComponent();
        }
        string connectionString = @"Data Source=DESKTOP-VFFBM2L\MSSQLSERVER04;
                                        Initial Catalog=Dairy;Integrated Security=True";

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Authorization authorization = new Authorization();
            authorization.Show();
            this.Close();
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Registration registration = new Registration();
            registration.Show();
            this.Close();
        }

        private async void simpleButton1_Click(object sender, EventArgs e)
        {
            ///
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
                        if ((!string.IsNullOrEmpty(textBox3.Text) && !string.IsNullOrWhiteSpace(textBox3.Text) &&
                            !string.IsNullOrEmpty(textBox4.Text) && !string.IsNullOrWhiteSpace(textBox4.Text)))
                        {
                            Task task = new Task(UpdateAdmin);
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
        public async void UpdateAdmin()
        {
            try
            {
                if (!string.IsNullOrEmpty(textBox4.Text) && !string.IsNullOrWhiteSpace(textBox4.Text) &
                    (!string.IsNullOrEmpty(textBox3.Text) && !string.IsNullOrWhiteSpace(textBox3.Text)))
                {

                    using (SqlConnection sqlConnection = new SqlConnection(connectionString))
                    {
                        sqlConnection.Open();
                        SqlCommand command = new SqlCommand($"UPDATE [Admins] SET [Password]=@value WHERE login=@login", sqlConnection);

                        command.Parameters.AddWithValue("login", textBox4.Text);
                        command.Parameters.AddWithValue("value", textBox3.Text);

                        await command.ExecuteNonQueryAsync();
                    }
                    MessageBox.Show("Пароль успішно змінено!", "Повідомлення!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Заповніть всі необхідні поля!", "Увага!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Помилка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
