using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace GoNurse
{
    public partial class DashboardAdmin : Form
    {
        public DashboardAdmin()
        {
            InitializeComponent();
        }

        private void bunifuPanel1_Click(object sender, EventArgs e)
        {

        }

        private void btn_menu_Click(object sender, EventArgs e)
        {

        }

        private void Dashboard_Load(object sender, EventArgs e)
        {
            label_nama.Text = global.admin_name;
            totalCustomer(); 
            totalTrans(); 
            totalNurseVer(); 
            totalNursePen(); 
            totalPatient();

        }
     
      
        private void totalCustomer()
        {
            //connection 
            string myConnection = "datasource=localhost;port=3306;username=root;password=";
            MySqlConnection myConn = new MySqlConnection(myConnection);
            string sql = "select count(*) from gonurse.db_customers;";
            MySqlCommand cmd;
            try
            {
                myConn.Open();
                cmd = new MySqlCommand(sql, myConn);
                Int32 rows_count = Convert.ToInt32(cmd.ExecuteScalar());
                cmd.Dispose();
                myConn.Close();

                label_totalCus.Text = rows_count.ToString();


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                if (myConn.State == ConnectionState.Open)
                {
                    myConn.Close();
                }
            }
        }
        private void totalTrans()
        {
            //connection 
            string myConnection = "datasource=localhost;port=3306;username=root;password=";
            MySqlConnection myConn = new MySqlConnection(myConnection);
            string sql = "select count(*) from gonurse.db_transaction;";
            MySqlCommand cmd;
            try
            {
                myConn.Open();
                cmd = new MySqlCommand(sql, myConn);
                Int32 rows_count = Convert.ToInt32(cmd.ExecuteScalar());
                cmd.Dispose();
                myConn.Close();
                label_totalTrans.Text = rows_count.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                if (myConn.State == ConnectionState.Open)
                {
                    myConn.Close();
                }
            }
        }
        private void totalNurseVer()
        {
            //connection 
            string myConnection = "datasource=localhost;port=3306;username=root;password=";
            MySqlConnection myConn = new MySqlConnection(myConnection);
            string sql = "select count(*) from gonurse.db_nurses WHERE isApprove='1';";
            MySqlCommand cmd;
            try
            {
                myConn.Open();
                cmd = new MySqlCommand(sql, myConn);
                Int32 rows_count = Convert.ToInt32(cmd.ExecuteScalar());
                cmd.Dispose();
                myConn.Close();
                label_totalNurseVer.Text = rows_count.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                if (myConn.State == ConnectionState.Open)
                {
                    myConn.Close();
                }
            }
        }
        private void totalNursePen()
        {
            //connection 
            string myConnection = "datasource=localhost;port=3306;username=root;password=";
            MySqlConnection myConn = new MySqlConnection(myConnection);
            string sql = "select count(*) from gonurse.db_nurses WHERE isApprove='0';";
            MySqlCommand cmd;
            try
            {
                myConn.Open();
                cmd = new MySqlCommand(sql, myConn);
                Int32 rows_count = Convert.ToInt32(cmd.ExecuteScalar());
                cmd.Dispose();
                myConn.Close();
                total_nursePen.Text = rows_count.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                if (myConn.State == ConnectionState.Open)
                {
                    myConn.Close();
                }
            }
        }
        private void totalPatient()
        {
            //connection 
            string myConnection = "datasource=localhost;port=3306;username=root;password=";
            MySqlConnection myConn = new MySqlConnection(myConnection);
            string sql = "select count(*) from gonurse.db_patient;";
            MySqlCommand cmd;
            try
            {
                myConn.Open();
                cmd = new MySqlCommand(sql, myConn);
                Int32 rows_count = Convert.ToInt32(cmd.ExecuteScalar());
                cmd.Dispose();
                myConn.Close();
                label_totalPatient.Text = rows_count.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                if (myConn.State == ConnectionState.Open)
                {
                    myConn.Close();
                }
            }
        }

        private void bunifuButton23_Click(object sender, EventArgs e)
        {

        }

        private void bunifuPanel2_Click(object sender, EventArgs e)
        {

        }

        private void guna2CirclePictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void bunifuButton24_Click(object sender, EventArgs e)
        {

        }

        private void btn_logout_Click(object sender, EventArgs e)
        {
            Login form_login = new Login();
            this.Hide();
            form_login.Show();
        }

        private void btn_home_Click(object sender, EventArgs e)
        {
            DashboardAdmin form_login = new DashboardAdmin();
            this.Hide();
            form_login.Show();
        }

        private void btn_nursePending_Click(object sender, EventArgs e)
        {
            Admin.NursePending form_pending = new Admin.NursePending();
            this.Hide();
            form_pending.Show();
        }
    }
}
