using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace EntityFrameworkWorkspace
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        UserDAL dao = new UserDAL();

        private void Form1_Load(object sender, EventArgs e)
        {
            GetAllRecords();
            cnnlbl.Text = "Connected Succesfully";
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.SelectedCells.Count > 0)
            {
                int selectedrowindex = dataGridView1.SelectedCells[0].RowIndex;
                DataGridViewRow selectedRow = dataGridView1.Rows[selectedrowindex];
                textBox1.Text = Convert.ToString(selectedRow.Cells["name"].Value);
                textBox2.Text = Convert.ToString(selectedRow.Cells["userkey"].Value);
            }
        }

        private void GetAllRecords()
        {
            dataGridView1.DataSource = dao.GetAll();
            cntlbl.Text = dao.CountRecords() + " records founded";
        }

        private void btnadd_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox1.Text == "" || textBox2.Text == "")
                {
                    cnnlbl.Text = "I/O Error";
                }
                else
                { 
                    dao.AddUser(new User
                    {
                        name = textBox1.Text,
                        userkey = textBox2.Text,
                    });
                    cnnlbl.Text = "Inserted Successfully";
                }
                GetAllRecords();
            }
            catch(Exception ex)
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
                    dao.UpdateUser(new User
                    {
                        id = key,
                        name = textBox1.Text,
                        userkey = textBox2.Text,
                    });
                    cnnlbl.Text = "Updated Successfully";
                }
                GetAllRecords();
            }
            catch(Exception ex)
            {
                cnnlbl.Text = "I/O Error";
                Console.WriteLine(ex.Message);
            }
        }
         
        private void btndel_Click(object sender, EventArgs e)
        {
            int selectedrowindex = dataGridView1.SelectedCells[0].RowIndex;
            DataGridViewRow selectedRow = dataGridView1.Rows[selectedrowindex];
            int key = Convert.ToInt32(selectedRow.Cells["id"].Value);
            dao.DeleteUser(new User{
                id = key,
            });
            cnnlbl.Text = "Deleted Successfully";
            GetAllRecords();
        }
          
        private void btnref_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            userbox.Text = "";
        } 

        private void userbox_TextChanged(object sender, EventArgs e)
        {
            String key = userbox.Text;
            var rs0 = dao.GetAll().Where(a => a.id.ToString().Contains(key)).ToList();
            var rs1 = dao.GetAll().Where(a => a.name.ToUpper().Contains(key.ToUpper())).ToList();
            var rs2 = dao.GetAll().Where(a => a.userkey.ToUpper().Contains(key.ToUpper())).ToList();
            rs0.AddRange(rs1);
            rs0.AddRange(rs2);
            dataGridView1.DataSource = rs0;

            int cnt = rs0.Count;
            cntlbl.Text = cnt + " records founded";
        }
    }
}