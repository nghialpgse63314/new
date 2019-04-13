using ProjectC.BLL;
using ProjectC.DTO;
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

namespace test
{
    public partial class Form1 : Form
    {
        GuestBLL guestBLL;
       
        DataSet ds = new DataSet();
        DataTable dt = new DataTable();
        DBConnection conn;
        SqlCommand cmd;
        string connString = @"uid=sa;pwd=123456789;Initial Catalog=Hotels;Data Source=NGHIALPGSE63314\LPGN";

        public Form1()
        {
            InitializeComponent();
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "dd-MM-yyyy";
            dateTimePicker2.Format = DateTimePickerFormat.Custom;
            dateTimePicker2.CustomFormat = "dd-MM-yyyy";
            guestBLL = new GuestBLL();
            conn = new DBConnection();
            cmd = new SqlCommand();
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "dd-MM-yyyy";
            dateTimePicker2.Format = DateTimePickerFormat.Custom;
            dateTimePicker2.CustomFormat = "dd-MM-yyyy";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            DateTime checkin = dateTimePicker1.Value.Date;
            DateTime checkout = dateTimePicker2.Value.Date;
            TimeSpan  ts = checkout - checkin;
            int days = ts.Days;
            double price = 100;
            double pay = days * price;
            textBox1.Text = pay.ToString();

        }

        private void loadDataGridView()
        {
            //string connString = @"uid=sa;pwd=123456789;Initial Catalog=Hotels;Data Source=NGHIALPGSE63314\LPGN";
            //SqlConnection conn = new SqlConnection(connString);

            //string query = "select * from Room, Guest where roomid = roomnumber";
            //SqlCommand cmd = new SqlCommand(query, conn);
            //SqlDataAdapter da = new SqlDataAdapter(cmd);
            //DataSet ds = new DataSet();

            //try
            //{
            //    if (conn.State == ConnectionState.Closed)
            //    {
            //        conn.Open();
            //    }
            //    da.Fill(ds, "ThanhVien");
            //}
            //catch (SqlException se)
            //{

            //    throw new Exception(se.Message);
            //}
            //finally
            //{
            //    conn.Close();
            //}
            ////d.Format = DateTimePickerFormat.Custom;
            ////dtpJoinDate.CustomFormat = "dd-MM-yyyy";
            //dataGridView3.DataSource = ds.Tables["ThanhVien"];

            //////dataGridView3.Columns["guestid"].Visible = false;
            ////dataGridView3.Columns["phone"].Visible = false;
            ////dataGridView3.Columns["address"].Visible = false;

            ////dataGridView3.Columns["datein"].DefaultCellStyle.Format = "dd-MM-yyyy";
            ////dtpJoinDate.Format = DateTimePickerFormat.Custom;
            ////dtpJoinDate.CustomFormat = "dd-MM-yyyy";
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dataGridView3.DataSource = guestBLL.GetCustomerList().ToList();
        }

        private void dataGridView3_Click(object sender, EventArgs e)
        {
            if (dataGridView3.SelectedRows.Count > 0)
            {
                dateTimePicker1.Value = (DateTime)dataGridView3.SelectedRows[0].Cells["datein"].Value;
                dateTimePicker2.Value = (DateTime)dataGridView3.SelectedRows[0].Cells["dateout"].Value;
                txtRoomid.Text = dataGridView3.SelectedRows[0].Cells["roomid"].Value.ToString();
                txtPhone.Text = dataGridView3.SelectedRows[0].Cells["phone"].Value.ToString();
                txtID.Text = dataGridView3.SelectedRows[0].Cells["id"].Value.ToString();
                txtName.Text = dataGridView3.SelectedRows[0].Cells["name"].Value.ToString();
                txtAddress.Text = dataGridView3.SelectedRows[0].Cells["address"].Value.ToString();


            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            txtID.Clear();
            txtName.Clear();
            txtRoomid.Clear();
            txtPhone.Clear();
            txtAddress.Clear();
        }

        private void bRegister_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(txtID.Text);
            string name = txtName.Text;
            string address = txtAddress.Text;
            int phone = Convert.ToInt32(txtPhone.Text);
            int roomid = Convert.ToInt32(txtRoomid.Text);
            DateTime datein = dateTimePicker1.Value.Date;
            DateTime dateout = dateTimePicker1.Value.Date;
            SqlConnection conn = new SqlConnection(connString);

            try
            {

              
                if(dateTimePicker2.Value < dateTimePicker1.Value)
                {
                    MessageBox.Show("INvalid")
                }
                {
                    guestBLL.insertGuest(id, name, address, phone, roomid,datein,dateout);
                    MessageBox.Show("Insert successfull");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void bRemove_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(txtID.Text);
            try
            {
                guestBLL.deleteCustomer(id);
                MessageBox.Show("Delete successfull");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void bSearch_Click(object sender, EventArgs e)
        {

        }
    }
}
