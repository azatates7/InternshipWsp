using System; 
using System.Data;
using System.Data.SqlClient;
using System.Drawing; 
using System.Windows.Forms;

namespace C_Sharp_Mssql_Form_Implements
{
    public partial class Form1 : Form
    {
        string connstr = "server=AA7\\SQLEXPRESS;" + "Trusted_Connection=true;" + "database=testdbb; " + "connection timeout=30";

        public Form1()
        {
            InitializeComponent();
            SqlConnection cnn = new SqlConnection();
            cnn.ConnectionString = connstr;
            cnn.Open();
            showallrecords();
            label1.Text = "Connection OK";
        }

        private void showallrecords()
        {
            try
            {
                SqlConnection cnn = new SqlConnection();
                cnn.ConnectionString = connstr;
                cnn.Open();
                String query = "SELECT COUNT(*) FROM userlist";
                SqlCommand command = new SqlCommand(query, cnn);
                int count = Convert.ToInt32(command.ExecuteScalar());
                SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM userlist", cnn);
                DataSet ds = new DataSet();
                da.Fill(ds, "User");
                if (ds.Tables[0].Rows.Count > 0)
                {
                    dataGridView1.DefaultCellStyle.BackColor = Color.Azure;
                    dataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.Brown;
                    dataGridView1.DataSource = ds.Tables["User"];
                    label2.Text = count + " records founded";
                }
                else
                {
                    label2.Text = "No records founded";
                }

                da.Dispose();
                cnn.Close();

            }

            catch (SqlException ex)
            {
                MessageBox.Show("Hata : " + ex);
            }
        }

        private void insertuser(object sender, EventArgs e)
        {
            try
            {
                int id = Int32.Parse(textBox1.Text);
                SqlConnection cnn = new SqlConnection();
                cnn.ConnectionString = connstr;
                cnn.Open();
                string query = "SELECT * FROM userlist WHERE id=" + id;
                SqlCommand command = new SqlCommand(query, cnn);
                SqlDataReader rdr = command.ExecuteReader();
                if (!rdr.Read())
                {
                    rdr.Close();
                    string name = name = textBox2.Text;
                    string userkey = textBox3.Text.ToString();
                    Console.WriteLine(id + name + userkey);
                    query = "INSERT INTO userlist (id, name, userkey) VALUES (@id, @name, @userkey)";
                    using (SqlCommand command0 = new SqlCommand(query, cnn))
                    {
                        command0.Parameters.AddWithValue("@id", id);
                        command0.Parameters.AddWithValue("@name", name);
                        command0.Parameters.AddWithValue("@userkey", userkey);

                        int result = command0.ExecuteNonQuery();
                    }
                    cnn.Close();
                    label1.Text = "Inserted Succcessfully";
                    textBox1.Text = null; textBox2.Text = null; textBox3.Text = null;
                    showallrecords();
                }
                else
                {
                    rdr.Close();
                    label1.Text = "record founded can't insert";
                }
            }
            catch (Exception ex)
            {
                label1.Text = "I/O Error";
            }
        }

        private void updateuser(object sender, EventArgs e)
        {
            try
            {
                SqlConnection cnn = new SqlConnection();
                cnn.ConnectionString = connstr;
                cnn.Open();
                string connectionString = connstr;
                int selectedrowindex = dataGridView1.SelectedCells[0].RowIndex;
                DataGridViewRow selectedRow = dataGridView1.Rows[selectedrowindex];
                int key = Convert.ToInt32(selectedRow.Cells["id"].Value);
                int id = Convert.ToInt32(textBox1.Text);
                string query = "SELECT * FROM userlist WHERE id=" + id;
                SqlCommand command = new SqlCommand(query, cnn);
                SqlDataReader rdr = command.ExecuteReader();
                if (!rdr.Read())
                {
                    using (SqlConnection conn = new SqlConnection(connectionString))
                    {
                        conn.Open();
                        String name = textBox2.Text;
                        String userkey = textBox3.Text;

                        using (SqlCommand cmd = new SqlCommand("UPDATE userlist SET id=@id, name=@name, userkey=@userkey WHERE id=" + key, conn))
                        {
                            cmd.Parameters.AddWithValue("@id", id);
                            cmd.Parameters.AddWithValue("@name", name);
                            cmd.Parameters.AddWithValue("@userkey", userkey);

                            int rows = cmd.ExecuteNonQuery();
                            label1.Text = "Updated Successfully";
                        }
                    }
                    showallrecords();
                }
                else
                {
                    label1.Text = "Update Error : Double PK";
                }

            }
            catch (Exception ex)
            {
                label1.Text = "I/O Error";
            }
        }

        private void selectrow(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedCells.Count > 0)
            {
                int selectedrowindex = dataGridView1.SelectedCells[0].RowIndex;
                DataGridViewRow selectedRow = dataGridView1.Rows[selectedrowindex];
                textBox1.Text = Convert.ToString(selectedRow.Cells["id"].Value);
                textBox2.Text = Convert.ToString(selectedRow.Cells["name"].Value);
                textBox3.Text = Convert.ToString(selectedRow.Cells["userkey"].Value);
            }
        }

        private void deleteuser(object sender, EventArgs e)
        {
            try
            {
                int id = Int32.Parse(textBox1.Text);
                SqlConnection cnn = new SqlConnection();
                cnn.ConnectionString = connstr;
                cnn.Open();
                SqlCommand command = new SqlCommand("DELETE FROM userlist WHERE id=@id", cnn);
                SqlParameter param = new SqlParameter("@id", id);
                command.Parameters.Add(param);
                int result = command.ExecuteNonQuery();
                label1.Text = "Deleted Succesfully";
                showallrecords();
                cnn.Close();
            }
            catch (Exception ex)
            {
                label1.Text = "I/O Error";
            }
        }

        private void searchname(object sender, EventArgs e)
        {
            var dataTable = (DataTable)dataGridView1.DataSource;
            var dataView = dataTable.DefaultView;
            dataView.RowFilter = string.Format("Name like '{0}%'", userbox.Text);
        }

    }
}
