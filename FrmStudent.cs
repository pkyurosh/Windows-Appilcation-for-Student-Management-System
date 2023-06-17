using SMS.Bll;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using SMS.Utils;

namespace SMS
{
    public partial class FrmStudent : Form
    {
        public FrmStudent()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {
           
            }

        private void txtFee_TextChanged(object sender, EventArgs e)
        {

        }

        private void cmbCourse_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                Student s = new Student();
                s.Name = txtName.Text;
                s.Address = txtAddress.Text;
                s.Course = cmbCourse.Text;
                s.Fee = Convert.ToInt32(txtFee.Text);
                StudentDao sd = new StudentDao();
                sd.SaveStudent(s);
                MessageBox.Show("IDataRecord Saved!", "SMS");
                LoadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "SMS");
            }

        }
        private void ClearData()
        {
            txtName.Text = " ";
            txtAddress.Text = " ";
            cmbCourse.SelectedIndex = 0;
            txtFee.Text = "";
            txtName.Text = "Name";
            txtName.Focus();
        }
        private void LoadData()
        {
            try
            {
                StudentDao sd = new StudentDao();
                DataTable dt = sd.AllStudents();
                dataGridView1.DataSource = dt;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "SMS");
            }
        }

        private void FrmStudent_Load(object sender, EventArgs e)
        {
            LoadData();
            ClearData();

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int i = dataGridView1.CurrentRow.Index;
            Gc.SID = Convert.ToInt16(dataGridView1.Rows[i].Cells["SID"].Value);
            txtName.Text = dataGridView1.Rows[i].Cells["Name"].Value.ToString();
            txtAddress.Text = dataGridView1.Rows[i].Cells["Address"].Value.ToString();
            cmbCourse.Text = dataGridView1.Rows[i].Cells["Course"].Value.ToString();
            txtFee.Text = dataGridView1.Rows[i].Cells["Fee"].Value.ToString();
        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

            Student s = new Student();
            s.SID = Gc.SID;
            s.Name = txtName.Text;
            s.Address = txtAddress.Text;
            s.Course = cmbCourse.Text;
            s.Fee = Convert.ToInt32(txtFee.Text);
            StudentDao sd = new StudentDao();
            sd.UpdateStudent(s);
            MessageBox.Show("Record Updated", "SMS");
            MessageBox.Show("IDataRecord Saved!", "SMS");
            LoadData();
            ClearData();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                Student s = new Student();
               
                StudentDao sd = new StudentDao();
                sd.DeleteStudent(Gc.SID);
                MessageBox.Show("Record Deleted", "SMS", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
           
                LoadData();
                ClearData();

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "SMS");
            }
        }
    }
    }

