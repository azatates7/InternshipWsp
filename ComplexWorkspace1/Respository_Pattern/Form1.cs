using Respository_Pattern.RepositoryFramework3.DAL.Concreat;
using Respository_Pattern.RepositoryFramework3.Entities;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace Respository_Pattern
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

          PersonelDAL2 pd = new PersonelDAL2();  

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                GetAllRecords();
                cnnlbl.Text = "Connected Succesfully"; 
            }
            catch(Exception ex)
            {
                cnnlbl.Text = "Connection Error";
                Console.WriteLine(ex.Message);
            }
        }

        private void GetAllRecords()
        {
            try
            {
                dgw.DataSource = pd.GetAll();
                // dataGridView1.DataSource = pd.GetAll();  
                //cntlbl.Text = ur.Count(new Personel()) + " records founded";
                //cntlbl.Text = pd.PersonelCounter() + " records founded";
            }
            catch (Exception ex)
            {
                cnnlbl.Text = "I/O Error";
                Console.WriteLine(ex.Message);
            }
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        { 
            try
            {
                string colname = dgw.Columns[2].Name;
                if (textBox1.Text == "" || textBox2.Text == "")
                {
                    cnnlbl.Text = "I/O Error";
                }
                else
                {
                    pd.Add(new Personel2
                    {
                        PersonelName = textBox1.Text,
                        
                        PersonelDepartment = textBox2.Text,
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

        private void BtnUpd_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox1.Text == "" || textBox2.Text == "")
                {
                    cnnlbl.Text = "I/O Error";
                }
                else
                {
                    int selectedrowindex = dgw.SelectedCells[0].RowIndex;
                    DataGridViewRow selectedRow = dgw.Rows[selectedrowindex];
                    int key = Convert.ToInt32(selectedRow.Cells["id"].Value);
                    pd.Update(new Personel2
                    {
                        PersonelId = key,
                        PersonelName = textBox1.Text,
                        PersonelDepartment = textBox2.Text,
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

        private void BtnDel_Click(object sender, EventArgs e)
        {
            try
            {
                int selectedrowindex = dgw.SelectedCells[0].RowIndex;
                DataGridViewRow selectedRow = dgw.Rows[selectedrowindex];
                int key = Convert.ToInt32(selectedRow.Cells["id"].Value);
                pd.Delete(new Personel2
                {
                    PersonelId = key,
                });
                cnnlbl.Text = "Deleted Successfully";
                GetAllRecords();
            }
            catch (Exception ex)
            {
                cnnlbl.Text = "I/O Error";
                Console.WriteLine(ex.Message);
            }
        }

        private void Userbox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                String key = Userbox.Text;
                var rs0 = pd.GetAll().Where(a => a.PersonelId.ToString().Contains(key)).ToList();
                var rs1 = pd.GetAll().Where(a => a.PersonelName.ToUpper().Contains(key.ToUpper())).ToList();
                var rs2 = pd.GetAll().Where(a => a.PersonelDepartment.ToUpper().Contains(key.ToUpper())).ToList();
                rs0.AddRange(rs1);
                rs0.AddRange(rs2);
                dgw.DataSource = rs0;

                int cnt = rs0.Count;
                cntlbl.Text = cnt + " records founded";
            }
            catch (Exception ex)
            {
                cnnlbl.Text = "I/O Error";
                Console.WriteLine(ex.Message);
            }
        }
    }
} 