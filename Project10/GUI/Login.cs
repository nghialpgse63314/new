using ProjectC;
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

namespace Project10.GUI
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void bLogin_Click(object sender, EventArgs e)
        {
            string connString = @"Initial Catalog=Hotels;Data Source=NGHIALPGSE63314\LPGN;Integrated Security=true";
            SqlConnection conn = new SqlConnection(connString);
           
            SqlDataAdapter da = new SqlDataAdapter("Select * from Admin where Username = '" + txtUsername.Text + "' and Password = '" + txtPassword.Text + "'", conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count == 1)
            {
                this.Hide();
                Form1 f = new Form1();
                
                f.Show();
            }
            else
            {
                MessageBox.Show("Check your username and password");
            }
        }

        private void bExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
