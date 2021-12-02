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

namespace GoNurse.Customers
{
    public partial class DashboardCustomer : Form
    {
        public DashboardCustomer()
        {
            InitializeComponent();
        }

        private void DashboardCustomer_Load(object sender, EventArgs e)
        {
            countOrder();
            countPatient();
            countHistory();
            label_nama.Text = global.customer_fullname;
        }
       
        public void countOrder()
        {
            //connection 
            string myConnection = "datasource=localhost;port=3306;username=root;password=";
            MySqlConnection myConn = new MySqlConnection(myConnection);
            string sql = "select count(*) from gonurse.db_transaction WHERE id_user='" + global.customer_id + "' and (status= 'pending' or status= 'on going' or status='waiting');";
            MySqlCommand cmd;
            try
            {
                myConn.Open();
                cmd = new MySqlCommand(sql, myConn);
                Int32 rows_count = Convert.ToInt32(cmd.ExecuteScalar());
                cmd.Dispose();
                myConn.Close();
               
                label_order.Text = rows_count.ToString();
                
                
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
        public void countPatient()
        {
            //connection 
            string myConnection = "datasource=localhost;port=3306;username=root;password=";
            MySqlConnection myConn = new MySqlConnection(myConnection);
            string sql = "select count(*) from gonurse.db_patient WHERE id_user='" + global.customer_id + "';";
            MySqlCommand cmd;
            try
            {
                myConn.Open();
                cmd = new MySqlCommand(sql, myConn);
                Int32 rows_count = Convert.ToInt32(cmd.ExecuteScalar());
                cmd.Dispose();
                myConn.Close();

                label_patient.Text = rows_count.ToString();


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
        public void countHistory()
        {
            //connection 
            string myConnection = "datasource=localhost;port=3306;username=root;password=";
            MySqlConnection myConn = new MySqlConnection(myConnection);
            string sql = "select count(*) from gonurse.db_transaction WHERE id_user='" + global.customer_id + "';";
            MySqlCommand cmd;
            try
            {
                myConn.Open();
                cmd = new MySqlCommand(sql, myConn);
                Int32 rows_count = Convert.ToInt32(cmd.ExecuteScalar());
                cmd.Dispose();
                myConn.Close();

                label_history.Text = rows_count.ToString();


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

        private void btn_home_Click(object sender, EventArgs e)
        {
            DashboardCustomer form_dashboard = new DashboardCustomer();
            this.Hide();
            form_dashboard.Show();
        }

        private void bunifuLabel3_Click(object sender, EventArgs e)
        {

        }

        private void btn_find_Click(object sender, EventArgs e)
        {
           /* //connection 
            string myConnection = "datasource=localhost;port=3306;username=root;Convert Zero Datetime=True;password=";
            MySqlConnection myConn = new MySqlConnection(myConnection);
            MySqlCommand cmdDatabase = new MySqlCommand("SELECT * FROM gonurse.db_transaction where id_nurse='" + global.nurse_id + "' and status='" + "on going" + "' ;", myConn);
            try
            {
                MySqlDataAdapter sda = new MySqlDataAdapter();
                sda.SelectCommand = cmdDatabase;
                DataTable dbdataset = new DataTable();
                sda.Fill(dbdataset);
                BindingSource bSource = new BindingSource();
                MessageBox.Show("You have on going transaction, please finish it first before searching for patient.");
                bSource.DataSource = dbdataset;
                sda.Update(dbdataset);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

*/
            AddRequest form_addR = new AddRequest();
            this.Hide();
            form_addR.Show();

        }

        private void btn_records_Click(object sender, EventArgs e)
        {
           
        }

        private void btn_logout_Click(object sender, EventArgs e)
        {
            Login form_login = new Login();
            this.Hide();
            form_login.Show();
        }

        private void btn_Projects_Click(object sender, EventArgs e)
        {
            Transaction form_records = new Transaction();
            this.Hide();/*
            form_records.waitingData();*/
            form_records.Show();
        }

        private void btn_History_Click(object sender, EventArgs e)
        {
            Transaction form_records = new Transaction();
            this.Hide();
            form_records.panel_history.BringToFront();
            form_records.Show();
        }
    }
}
