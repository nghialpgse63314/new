using Project10.GUI;
using ProjectC.BLL;
using ProjectC.DTO;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;

namespace ProjectC
{
    public partial class Form1 : Form
    {
        GuestBLL guestBLL;
        RoomBLL roomBLL;
        DataSet ds = new DataSet();
        DataTable dt = new DataTable();
        DBConnection conn;
        SqlCommand cmd;
        string connString = @"uid=sa;pwd=123456789;Initial Catalog=Hotels;Data Source=NGHIALPGSE63314\LPGN";
        

        public Form1()
        {
            InitializeComponent();
            roomBLL = new RoomBLL();
            guestBLL = new GuestBLL();
            conn = new DBConnection();
            cmd = new SqlCommand();
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "dd-MM-yyyy";
            dateTimePicker2.Format = DateTimePickerFormat.Custom;
            dateTimePicker2.CustomFormat = "dd-MM-yyyy";

        }


        private void bClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void bLoad_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = roomBLL.GetRoomList().ToList();
            dataGridView2.DataSource = guestBLL.GetCustomerList().ToList();
          
            
           
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = roomBLL.GetRoomList().ToList();
            dataGridView2.DataSource = guestBLL.GetCustomerList().ToList();
            dataGridView2.Columns["status"].Visible = false;
            dataGridView2.Columns["roomid"].Visible = false;
           
           
        }

       private void check()
        {
            string ch = "Select count(*) from login where username='" + txtRoomnumber.Text + "')";
        }

        private void bAddRoom_Click(object sender, EventArgs e)
        {
            int roomnumber = Convert.ToInt32(txtRoomnumber.Text);
            string status = cbStatus.Text;
            SqlConnection conn = new SqlConnection(connString);
            try
            {

                cmd = new SqlCommand("Select * from Room where Roomnumber='" + txtRoomnumber.Text + "'",conn);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ds);
                int i = ds.Tables[0].Rows.Count;
                if(i > 0)
                {
                    MessageBox.Show("Room " + txtRoomnumber.Text + " already exist");
                    ds.Clear();
                }
                 else if (cbStatus.Text == "Available" || cbStatus.Text == "In-used" )
                {
                    roomBLL.insertRoom(roomnumber, status);
                    MessageBox.Show("Insert succesful");
                }             
              

                else
                {
                    MessageBox.Show("Invalid");
                }
                             
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void bUpRoom_Click(object sender, EventArgs e)
        {
            string status = cbStatus.Text;
            int roomnumber = Convert.ToInt32(txtRoomnumber.Text);
           
            try
            {
                if (cbStatus.Text == "Available" || cbStatus.Text == "In-used")
                {
                    roomBLL.UpdateRoom(status, roomnumber);
                    MessageBox.Show("Update successfull");
                }
                else
                {
                    MessageBox.Show("Invalid");
                }
               
                                 
                    
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void bRemoveRoom_Click(object sender, EventArgs e)
        {
            int roomnumber = Convert.ToInt32(txtRoomnumber.Text);
            int roomid = Convert.ToInt32(txtRoomid.Text);
            SqlConnection conn = new SqlConnection(connString);
            try
            {
                foreach (DataRow row in dt.Rows)
                {

                }
                if (roomnumber == roomid && cbStatus.Text == "In-used")
                {
                    MessageBox.Show("Roomnumber " + txtRoomnumber.Text + " is used");
                }
                else
                {
                    roomBLL.deleteRoom(roomnumber);
                    MessageBox.Show("Remove successfull");
                }
                                    
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                
            }
           
        }

        private void dataGridView1_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                txtRoomnumber.Text = dataGridView1.SelectedRows[0].Cells["roomnumber"].Value.ToString();
                cbStatus.Text = dataGridView1.SelectedRows[0].Cells["status"].Value.ToString();
            }
        }

        private void dataGridView2_Click(object sender, EventArgs e)
        {
            if (dataGridView2.SelectedRows.Count > 0)
            {
                txtRoomid.Text = dataGridView2.SelectedRows[0].Cells["roomid"].Value.ToString();  
                txtPhone.Text = dataGridView2.SelectedRows[0].Cells["phone"].Value.ToString();
                txtID.Text = dataGridView2.SelectedRows[0].Cells["id"].Value.ToString();
                txtName.Text = dataGridView2.SelectedRows[0].Cells["name"].Value.ToString();
                txtAddress.Text = dataGridView2.SelectedRows[0].Cells["address"].Value.ToString();
                dateTimePicker1.Value = (DateTime)dataGridView2.SelectedRows[0].Cells["datein"].Value;
                dateTimePicker2.Value = (DateTime)dataGridView2.SelectedRows[0].Cells["dateout"].Value;
            }
        }

       
      
        private void Check()
        {
          

          
            
        }

        private void bRegister_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(txtID.Text);
            string name = txtName.Text;
            string address = txtAddress.Text;
            int phone = Convert.ToInt32(txtPhone.Text);
            int roomid = Convert.ToInt32(txtRoomid.Text);
            SqlConnection conn = new SqlConnection(connString);
            DateTime datein = dateTimePicker1.Value.Date;
            DateTime dateout = dateTimePicker1.Value.Date;
            int result = DateTime.Compare(dateout, datein); 
            try
            {

                //SqlCommand cmd1 = new SqlCommand();
                //cmd1 = new SqlCommand("select * from guest where id='" + txtID.Text + "'", conn);
                //SqlDataAdapter dad = new SqlDataAdapter(cmd1);
                //dad.Fill(ds);
                //int j = ds.Tables[0].Rows.Count;
                //if (j > 0)
                //{
                //    MessageBox.Show("id " + txtID.Text + " already exist");
                //    ds.Clear();
                //}

                //SqlCommand cmd2 = new SqlCommand();
                //cmd2 = new SqlCommand("Select * from Guest where roomid='" + txtRoomid.Text + "'", conn);
                //SqlDataAdapter da = new SqlDataAdapter(cmd2);
                //da.Fill(ds);
                //int i = ds.Tables[0].Rows.Count;
                //if (i > 0)
                //{
                //    MessageBox.Show("Room " + txtRoomid.Text + " is used");
                //    ds.Clear();
                //}
                
                if(dateTimePicker2.Value < dateTimePicker1.Value)
                {
                    MessageBox.Show("Dateout is earlier");
                }
                else
                {
                    guestBLL.insertGuest(id, name, address, phone, roomid, datein, dateout);
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
            try
            {
                GuestBLL p = new GuestBLL();
                dataGridView2.DataSource = p.GetPersons(Convert.ToInt32(txtSearch.Text));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
          
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Room room = new Room();
            room = roomBLL.getRoom(Convert.ToInt32(txtRoomnumber.Text));
           
        }

        private void txtRoomnumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar)) e.Handled = true;         //Just Digits
            if (e.KeyChar == (char)8) e.Handled = false;            //Allow Backspace
           
        }

        private void txtPhone_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar)) e.Handled = true;         //Just Digits
            if (e.KeyChar == (char)8) e.Handled = false;
        }

        private void cbStatus_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        

        private void button2_Click(object sender, EventArgs e)
        {
            txtID.Clear();
            txtName.Clear();
            txtAddress.Clear();
            txtRoomid.Clear();
            txtPhone.Clear();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            txtRoomnumber.Clear();
         
        }

        private void splitContainer2_Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

      

        private void bUpdate_Click(object sender, EventArgs e)
        {
            DateTime datein = dateTimePicker1.Value.Date;
            DateTime dateout = dateTimePicker2.Value.Date;
            int id = Convert.ToInt32(txtID.Text);
            try
            {
                guestBLL.updateGuest(id,datein, dateout);
                MessageBox.Show("Update successful");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void bCharge_Click_2(object sender, EventArgs e)
        {
            DateTime datein = dateTimePicker1.Value.Date;
            DateTime dateout = dateTimePicker2.Value.Date;
            TimeSpan ts = dateout - datein;
            float days = ts.Days;
            float price = 320.000f;
            float pay = days * price;
           
           txtPrice.Text = pay.ToString();
           
        }

        private void bLogout_Click(object sender, EventArgs e)
        {
            Login log = new Login();
            log.Show();
            this.Hide();
        }

        private void txtID_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
