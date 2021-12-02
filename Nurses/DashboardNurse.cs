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
namespace GoNurse.Nurses
{
    public partial class DashboardNurse : Form
    {
        public DashboardNurse()
        {
            InitializeComponent();
            
        }
        private void DashboardNurse_Load(object sender, EventArgs e)
        {
            label_nama.Text = global.nurse_fullname;
            label_balance.Text = global.nurse_balance.ToString();
            countOrder();
            countHistory();
        }
        private void btn_logout_Click(object sender, EventArgs e)
        {
            Login form_login = new Login();
            this.Hide();
            form_login.Show();
        }


        public void countOrder()
        {
            //connection 
            string myConnection = "datasource=localhost;port=3306;username=root;password=";
            MySqlConnection myConn = new MySqlConnection(myConnection);
            string sql = "select count(*) from gonurse.db_transaction WHERE id_nurse='" + global.nurse_id + "' and (status= 'pending' or status= 'on going' or status='waiting');";
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
     
        public void countHistory()
        {
            //connection 
            string myConnection = "datasource=localhost;port=3306;username=root;password=";
            MySqlConnection myConn = new MySqlConnection(myConnection);
            string sql = "select count(*) from gonurse.db_transaction WHERE id_nurse='" + global.nurse_id + "';";
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

        private void btn_find_Click(object sender, EventArgs e)
        {
            FindPatient form_find = new FindPatient();
            this.Hide();
            form_find.Show();
        }

        private void bunifuButton21_Click(object sender, EventArgs e)
        {

        }

        private void label_totalCus_Click(object sender, EventArgs e)
        {

        }

        private void panel_top_ControlAdded(object sender, ControlEventArgs e)
        {

        }

        private void bunifuButton22_Click(object sender, EventArgs e)
        {

        }

        private void bunifuLabel3_Click(object sender, EventArgs e)
        {

        }

        private void bunifuIconButton1_Click(object sender, EventArgs e)
        {

        }

        private void btn_profile_Click(object sender, EventArgs e)
        {

        }

        private void btn_notif_Click(object sender, EventArgs e)
        {

        }

        private void label_nama_Click(object sender, EventArgs e)
        {

        }

        private void bunifuLabel2_Click(object sender, EventArgs e)
        {

        }

        private void panel_buttom_Click(object sender, EventArgs e)
        {

        }

        private void label_totalStar_Click(object sender, EventArgs e)
        {

        }

        private void btn_Projects_Click(object sender, EventArgs e)
        {
            Transaction form_records = new Transaction();
            this.Hide();
            form_records.Show();
        }

        private void btn_home_Click(object sender, EventArgs e)
        {

        }
    }
}
