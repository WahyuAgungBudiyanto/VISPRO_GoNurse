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
    public partial class AddRequest2 : Form
    {
        public AddRequest2()
        {
            InitializeComponent();
        }

        private void btn_back_Click(object sender, EventArgs e)
        {
            AddRequest form_request = new AddRequest();
            this.Hide();
            form_request.Show();
        }

        private void btn_req_Click(object sender, EventArgs e)
        {
          /*  try
            {
                //connection 
                string myConnection = "datasource=localhost;port=3306;username=root;password=";
                *//* string Query = $"insert into gonurse.db_customerrequest (id_request,patient_name) values('',{label_fName.Text}); ";*//*
                string Query = $"INSERT INTO gonurse.db_transaction(id_request,id_user, id_patient,id_nurse, lama_sewa, price, status, star, review, start_date, end_date, created_at) VALUES('','{global.customer_id}' ,'{label_patID.Text}',NULL, '{comboBox_day.Text}', '{label_total.Text}', 'pending', '', '', '{bunifuDatePicker1.Value.ToString("yyyy-MM-dd HH:mm:ss")}', '{bunifuDatePicker2.Value.ToString("yyyy-MM-dd HH:mm:ss")}', '{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}');";
                MySqlConnection myConn = new MySqlConnection(myConnection);
                MySqlCommand cmdDatabase = new MySqlCommand(Query, myConn);

                MySqlDataReader myReader;
                myConn.Open();
                myReader = cmdDatabase.ExecuteReader();
                MessageBox.Show("Your request has been posted", "Request Success", MessageBoxButtons.OK, MessageBoxIcon.Information);


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            update_status(Convert.ToInt32(label_patID.Text));*/
        }
    }
}
