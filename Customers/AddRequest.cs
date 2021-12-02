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
    public partial class AddRequest : Form
    {
        public int simpanPrice;
        public int simpanLength;
        public AddRequest()
        {
            InitializeComponent();
        }
        private void btn_back_Click(object sender, EventArgs e)
        {
            DashboardCustomer form_dash = new DashboardCustomer();
            this.Hide();
            form_dash.countOrder();
            form_dash.Show();
        }

        private void AddRequest_Load(object sender, EventArgs e)
        {
            refresh();
        }
        public void refresh()
        {
            //connection 
            string myConnection = "datasource=localhost;port=3306;username=root;Convert Zero Datetime=True;password=";
            MySqlConnection myConn = new MySqlConnection(myConnection);
            MySqlCommand cmdDatabase = new MySqlCommand("SELECT id_patient,patient_name,patient_gender,patient_age,patient_symptoms,patient_desc,patient_address FROM gonurse.db_patient where id_user='" + global.customer_id + "' and isTaken='" + "not taken" + "' ;", myConn);
            try
            {
                MySqlDataAdapter sda = new MySqlDataAdapter();
                sda.SelectCommand = cmdDatabase;
                DataTable dbdataset = new DataTable();
                sda.Fill(dbdataset);
                BindingSource bSource = new BindingSource();

                bSource.DataSource = dbdataset;
                dataGridView_patient.DataSource = bSource;
                sda.Update(dbdataset);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        

        private void btn_addPatient_Click(object sender, EventArgs e)
        {
           
            AddPatient form_addPatient = new AddPatient();
            form_addPatient.Show();
            this.Hide();
        }

        
        private void comboBox_day_SelectedIndexChanged(object sender, EventArgs e)
        {
            simpanPrice = 0;
            if (comboBox_day.Text == "1 Day")
            {
                bunifuDatePicker2.Value = bunifuDatePicker1.Value.AddDays(1);
                simpanPrice += 100000;
                bunifuDatePicker1.Enabled = true;
                bunifuDatePicker2.Enabled = false;
            }
            else if (comboBox_day.Text == "1 Week")
            {
                bunifuDatePicker2.Value = bunifuDatePicker1.Value.AddDays(7);
                simpanPrice += 700000;
                bunifuDatePicker1.Enabled = true;
                bunifuDatePicker2.Enabled = false;
            }
            else if (comboBox_day.Text == "1 Month")
            {
                bunifuDatePicker2.Value = bunifuDatePicker1.Value.AddDays(30);
                simpanPrice += 3000000;
                bunifuDatePicker1.Enabled = true;
                bunifuDatePicker2.Enabled = false;
            }
           

            label_total.Text = simpanPrice.ToString();
        }
        private void bunifuDatePicker1_ValueChanged(object sender, EventArgs e)
        {
            if (comboBox_day.Text == "1 Day")
            {
                bunifuDatePicker2.Value = bunifuDatePicker1.Value.AddDays(1);
                simpanPrice += 100000;
                bunifuDatePicker1.Enabled = true;
                bunifuDatePicker2.Enabled = false;
            }
            else if (comboBox_day.Text == "1 Week")
            {
                bunifuDatePicker2.Value = bunifuDatePicker1.Value.AddDays(7);
                simpanPrice += 700000;
                bunifuDatePicker1.Enabled = true;
                bunifuDatePicker2.Enabled = false;
            }
            else if (comboBox_day.Text == "1 Month")
            {
                bunifuDatePicker2.Value = bunifuDatePicker1.Value.AddDays(30);
                simpanPrice += 3000000;
                bunifuDatePicker1.Enabled = true;
                bunifuDatePicker2.Enabled = false;
            }
        }

        private void dataGridRecords_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            CRUDPatient form_crudPatient = new CRUDPatient();
            try
            {
                
                DataGridViewRow row = this.dataGridView_patient.Rows[e.RowIndex];
                
                form_crudPatient.textBox_id.Text = row.Cells["id_patient"].Value.ToString();
                form_crudPatient.textBox_fName.Text = row.Cells["patient_name"].Value.ToString();
                form_crudPatient.comboBox_gender.SelectedItem = row.Cells["patient_gender"].Value.ToString();
                form_crudPatient.textBox_age.Text = row.Cells["patient_age"].Value.ToString();
                form_crudPatient.textBox_symptoms.Text = row.Cells["patient_symptoms"].Value.ToString();
                form_crudPatient.textBox_desc.Text = row.Cells["patient_desc"].Value.ToString();
                form_crudPatient.textBox_address.Text = row.Cells["patient_address"].Value.ToString();

                form_crudPatient.Show();
                this.Hide();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
           
        }

        private void textBox_searchtop_TextChanged(object sender, EventArgs e)
        {
            //connection 
            string myConnection = "datasource=localhost;port=3306;username=root;password=";
            MySqlConnection myConn = new MySqlConnection(myConnection);
            MySqlCommand cmdDatabase = new MySqlCommand("SELECT id_patient,patient_name,patient_gender,patient_age,patient_symptoms,patient_desc,patient_address FROM gonurse.db_patient JOIN gonurse.db_customers c where c.id_user='" + global.customer_id + "' and isTaken='" + "not taken" + "' ;", myConn);
            try
            {
                MySqlDataAdapter sda = new MySqlDataAdapter();
                sda.SelectCommand = cmdDatabase;
                DataTable dbdataset = new DataTable();
                sda.Fill(dbdataset);
                BindingSource bSource = new BindingSource();

                bSource.DataSource = dbdataset;
                dataGridView_patient.DataSource = bSource;
                sda.Update(dbdataset);

                DataView DV = new DataView(dbdataset);
                DV.RowFilter = string.Format("patient_name LIKE '%{0}%'", textBox_searchtop.Text);
                dataGridView_patient.DataSource = DV;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void btn_req_Click(object sender, EventArgs e)
        {
           /* Form formbackground = new Form();
            AddRequest2 form_request2 = new AddRequest2();
            try
            {
                formbackground.StartPosition = FormStartPosition.Manual;
                formbackground.FormBorderStyle = FormBorderStyle.None;
                formbackground.Opacity = .50d;
                formbackground.BackColor = Color.Black;
                formbackground.WindowState = FormWindowState.Maximized;
                formbackground.TopMost = true;
                formbackground.Location = this.Location;
                formbackground.ShowInTaskbar = false;
                formbackground.Show();

                form_request2.Owner = formbackground;
                form_request2.ShowDialog();
                formbackground.Hide();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                formbackground.Hide();
            }
*/

            try
            {
                //connection 
                string myConnection = "datasource=localhost;port=3306;username=root;password=";
                /* string Query = $"insert into gonurse.db_customerrequest (id_request,patient_name) values('',{label_fName.Text}); ";*/
                string Query = $"INSERT INTO gonurse.db_transaction(id_request,id_user, id_patient,id_nurse, lama_sewa, price, status, start_date, end_date, created_at) VALUES('','{global.customer_id}' ,'{label_patID.Text}','0', '{comboBox_day.Text}', '{label_total.Text}', 'pending', '{bunifuDatePicker1.Value.ToString("yyyy-MM-dd")}', '{bunifuDatePicker2.Value.ToString("yyyy-MM-dd")}', '{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}');";
                MySqlConnection myConn = new MySqlConnection(myConnection);
                MySqlCommand cmdDatabase = new MySqlCommand(Query, myConn);
               
                MySqlDataReader myReader;
                myConn.Open();
                myReader = cmdDatabase.ExecuteReader();
                MessageBox.Show("Your request has been posted", "Request Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                update_status(Convert.ToInt32(label_patID.Text));
                Transaction form_transaction = new Transaction();
                form_transaction.Show();

                this.Hide();

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
            string Query = "UPDATE gonurse.db_patient SET isTaken= 'taken' WHERE  id_patient='" + label_patID.Text + "';";
            MySqlConnection myConn = new MySqlConnection(myConnection);
            MySqlCommand cmdDatabase = new MySqlCommand(Query, myConn);
            MySqlDataReader myReader;

            try
            {
                myConn.Open();
                myReader = cmdDatabase.ExecuteReader();
                MessageBox.Show("Updated");
                refresh();
                while (myReader.Read())
                {

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        private void panel_main_Click(object sender, EventArgs e)
        {

        }

        private void btn_refresh_Click(object sender, EventArgs e)
        {
            refresh();
        }

        private void bunifuColorTransition1_ColorChanged(object sender, Bunifu.UI.WinForms.BunifuColorTransition.ColorChangedEventArgs e)
        {

        }
    }
}
