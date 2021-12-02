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
    public partial class MakeDeal : Form
    {
        public MakeDeal()
        {
            InitializeComponent();
        }

        private void MakeDeal_Load(object sender, EventArgs e)
        {

        }

        private void btn_accept_Click(object sender, EventArgs e)
        {
            update_status(Convert.ToInt32(label_id.Text));
            update_nurse();
            Transaction form_transaction = new Transaction();
            this.Hide();
            form_transaction.Show();

        }
        private void update_nurse()
        {
            try
            {
                //connection 
                string myConnection = "datasource=localhost;port=3306;username=root;password=";
                /* string Query = $"insert into gonurse.db_customerrequest (id_request,patient_name) values('',{label_fName.Text}); ";*/
                string Query = $"UPDATE gonurse.db_transaction SET id_nurse={global.nurse_id}  WHERE  id_request='" + label_id.Text + "';";
                MySqlConnection myConn = new MySqlConnection(myConnection);
                MySqlCommand cmdDatabase = new MySqlCommand(Query, myConn);
                MySqlDataReader myReader;

                try
                {
                    myConn.Open();
                    myReader = cmdDatabase.ExecuteReader();
                    MessageBox.Show("id nurse updated");
                    while (myReader.Read())
                    {

                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        void update_status(int id_request)
        {
            //connection 
            string myConnection = "datasource=localhost;port=3306;username=root;password=";
            string Query = "UPDATE gonurse.db_transaction SET status='waiting' WHERE  id_request='" + label_id.Text + "';";
            MySqlConnection myConn = new MySqlConnection(myConnection);
            MySqlCommand cmdDatabase = new MySqlCommand(Query, myConn);
            MySqlDataReader myReader;

            try
            {
                myConn.Open();
                myReader = cmdDatabase.ExecuteReader();
                MessageBox.Show("status updated");
                while (myReader.Read())
                {

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void btn_back_Click(object sender, EventArgs e)
        {
            FindPatient form_find = new FindPatient();
            this.Hide();
            form_find.Show();
        }
    }
}
