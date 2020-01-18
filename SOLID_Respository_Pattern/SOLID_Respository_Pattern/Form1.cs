using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SOLID_Respository_Pattern
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        UserRepository ur = new UserRepository();

        private void Form1_Load(object sender, EventArgs e)
        {
            GetAllRecords();
        }

        private void GetAllRecords()
        {
            try
            {
                dataGridView1.DataSource = ur.GetList();
                //cntlbl.Text = ur.CountUser() + " records founded";
            }
            catch (Exception ex)
            {
                cnnlbl.Text = "I/O Error";
                Console.WriteLine(ex.Message);
            }
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
                    ur.AddUser(new User
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
                    ur.UpdateUser(new User
                    {
                        id = key,
                        name = textBox1.Text,
                        userkey = textBox2.Text,
                    });
                    cnnlbl.Text = "Updated Successfully";
                }
                GetAllRecords();
            } 
            catch (Exception ex)
            {
                cnnlbl.Text = "I/O Error";
                Console.WriteLine(ex.Message);
            }
        }

        private void selectrow(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.SelectedCells.Count > 0)
            {
                int selectedrowindex = dataGridView1.SelectedCells[0].RowIndex;
                DataGridViewRow selectedRow = dataGridView1.Rows[selectedrowindex];
                textBox1.Text = Convert.ToString(selectedRow.Cells["name"].Value);
                textBox2.Text = Convert.ToString(selectedRow.Cells["userkey"].Value);
            }
        }

        private void btndel_Click(object sender, EventArgs e)
        {
            try
            {
                int selectedrowindex = dataGridView1.SelectedCells[0].RowIndex;
                DataGridViewRow selectedRow = dataGridView1.Rows[selectedrowindex];
                int key = Convert.ToInt32(selectedRow.Cells["id"].Value);
                ur.DeleteUser(new User
                {
                    id = key,
                });
                cnnlbl.Text = "Deleted Successfully";
                GetAllRecords();
            }
            catch(Exception ex)
            {
                cnnlbl.Text = "I/O Error";
                Console.WriteLine(ex.Message);
            }
        }

        private void userbox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                String key = userbox.Text;
                var rs0 = ur.GetList().Where(a => a.id.ToString().Contains(key)).ToList();
                var rs1 = ur.GetList().Where(a => a.name.ToUpper().Contains(key.ToUpper())).ToList();
                var rs2 = ur.GetList().Where(a => a.userkey.ToUpper().Contains(key.ToUpper())).ToList();
                rs0.AddRange(rs1);
                rs0.AddRange(rs2);
                dataGridView1.DataSource = rs0;

                int cnt = rs0.Count;
                cntlbl.Text = cnt + " records founded";
            }
            catch(Exception ex)
            {
                cnnlbl.Text = "I/O Error";
                Console.WriteLine(ex.Message);
            }
        }
    }
}