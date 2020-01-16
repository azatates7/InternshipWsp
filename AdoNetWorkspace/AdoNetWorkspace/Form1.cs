using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace AdoNetWorkspace
{
    public partial class Form1 : Form
    { 
        public Form1()
        {
            InitializeComponent();
        }

        UserDAL option = new UserDAL();

        private void Form1_Load(object sender, EventArgs e)
        {
            GetAllRecords();
            cnnlbl.Text = "Connected Succesfully"; 
        }

        private void GetAllRecords()
        {
            try
            {
                dataGridView1.DataSource = option.GetAll();
                cntlbl.Text = option.CountItems() + " records founded";
            }
            catch(Exception ex)
            {
                cnnlbl.Text = "I/O Error";
                Console.WriteLine(ex.Message);
            }
        }
         
        private void selectrow(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedCells.Count > 0)
            {
                int selectedrowindex = dataGridView1.SelectedCells[0].RowIndex;
                DataGridViewRow selectedRow = dataGridView1.Rows[selectedrowindex];
                textBox1.Text = Convert.ToString(selectedRow.Cells["name"].Value);
                textBox2.Text = Convert.ToString(selectedRow.Cells["userkey"].Value);
            }
        }

        private void btnadd_Click(object sender, EventArgs e)
        {
            try
            {
                if(textBox1.Text == "" || textBox2.Text == "")
                {
                    cnnlbl.Text = "I/O Error";
                }
                else
                {
                    option.InsertUser(new User
                    {
                        name = textBox1.Text,
                        userkey = textBox2.Text,
                    });
                    cnnlbl.Text = "Inserted Successfully";
                }
                GetAllRecords();
            }
            catch (Exception ex)
            {
                cnnlbl.Text = "I/O Error";
                Console.WriteLine(ex.Message);
            }
        }

        private void btnupd_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox1.Text == "" || textBox2.Text == "")
                {
                    cnnlbl.Text = "I/O Error";
                }
                else
                {
                    int selectedrowindex = dataGridView1.SelectedCells[0].RowIndex;
                    DataGridViewRow selectedRow = dataGridView1.Rows[selectedrowindex];
                    int key = Convert.ToInt32(selectedRow.Cells["id"].Value);
                    option.UpdateUser(new User
                    {
                        name = textBox1.Text,
                        userkey = textBox2.Text,
                    }, key);
                    GetAllRecords();
                }
            }
            catch (Exception ex)
            {
                cnnlbl.Text = "I/O Error";
                Console.WriteLine(ex.Message);
            }
        }

        private void btndel_Click(object sender, EventArgs e)
        {
            try
            {
                int selectedrowindex = dataGridView1.SelectedCells[0].RowIndex;
                DataGridViewRow selectedRow = dataGridView1.Rows[selectedrowindex];
                int key = Convert.ToInt32(selectedRow.Cells["id"].Value);
                option.DeleteUser(key);
                GetAllRecords();
            }
            catch(Exception ex)
            {
                cnnlbl.Text = "I/O Error";
                Console.WriteLine(ex.Message);
            }
        }

        private void searchuser(object sender, EventArgs e)
        {
            try
            {
                var tuple = option.SearchUser(userbox.Text); 
                DataTable dt = tuple.Item1;
                dataGridView1.DataSource = dt;
                int counter = tuple.Item2;
                cntlbl.Text = counter + " records founded"; 
            }
            catch (Exception ex)
            {
                cnnlbl.Text = "I/O Error";
                Console.WriteLine(ex.Message);
            }
        }
    }
    } 