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
using System.Globalization;

namespace GoNurse.Nurses
{
    public partial class FindPatient : Form
    {
        public FindPatient()
        {
            InitializeComponent();
        }
        private void FindPatient_Load(object sender, EventArgs e)
        {
            refresh();
        }
        private void refresh()
        {
            //connection 
            string myConnection = "datasource=localhost;port=3306;username=root;Convert Zero Datetime=True;password=";
            MySqlConnection myConn = new MySqlConnection(myConnection);
            /*           MySqlCommand cmdDatabase = new MySqlCommand("SELECT r.status,r.id_request,r.id_nurse, p.patient_name,r.lama_sewa,r.price from gonurse.db_transaction r JOIN gonurse.db_patient p where r.id_nurse='" + global.nurse_id + "'", myConn);*/
            MySqlCommand cmdDatabase = new MySqlCommand("SELECT r.id_request, p.patient_address, p.patient_symptoms ,r.lama_sewa,r.price,r.start_date,r.end_date,p.patient_name, p.patient_gender,p.patient_age,p.patient_desc from gonurse.db_transaction r JOIN gonurse.db_patient p where r.id_patient = p.id_patient and r.status = 'pending'", myConn);
            try
            {
                MySqlDataAdapter sda = new MySqlDataAdapter();
                sda.SelectCommand = cmdDatabase;
                DataTable dbdataset = new DataTable();
                sda.Fill(dbdataset);
                BindingSource bSource = new BindingSource();

                bSource.DataSource = dbdataset;
                dataGrid.DataSource = bSource;
                sda.Update(dbdataset);
                dataGrid.Columns["patient_name"].Visible = false;
                dataGrid.Columns["patient_gender"].Visible = false;
                dataGrid.Columns["patient_age"].Visible = false;
                dataGrid.Columns["patient_desc"].Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
   
        private void comboBox_filter_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox_filter.Text == "All")
            {
                refresh();
            }
            else if (comboBox_filter.Text == "lama_sewa 1 Day")
            {
                //connection 
                string myConnection = "datasource=localhost;port=3306;username=root;Convert Zero Datetime=True;password=";
                MySqlConnection myConn = new MySqlConnection(myConnection);
                MySqlCommand cmdDatabase = new MySqlCommand("SELECT r.id_request, p.patient_address, p.patient_symptoms ,r.lama_sewa,r.price,r.start_date,r.end_date,p.patient_name, p.patient_gender,p.patient_age,p.patient_desc from gonurse.db_transaction r JOIN gonurse.db_patient p where r.id_patient = p.id_patient and r.status = 'pending' and lama_sewa= '1 Day'", myConn);
                try
                {
                    MySqlDataAdapter sda = new MySqlDataAdapter();
                    sda.SelectCommand = cmdDatabase;
                    DataTable dbdataset = new DataTable();
                    sda.Fill(dbdataset);
                    BindingSource bSource = new BindingSource();

                    bSource.DataSource = dbdataset;
                    dataGrid.DataSource = bSource;
                    sda.Update(dbdataset);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else if (comboBox_filter.Text == "lama_sewa 1 Week")
            {
                //connection 
                string myConnection = "datasource=localhost;port=3306;username=root;Convert Zero Datetime=True;password=";
                MySqlConnection myConn = new MySqlConnection(myConnection);
                MySqlCommand cmdDatabase = new MySqlCommand("SELECT r.id_request, p.patient_address, p.patient_symptoms ,r.lama_sewa,r.price,r.start_date,r.end_date,p.patient_name, p.patient_gender,p.patient_age,p.patient_desc from gonurse.db_transaction r JOIN gonurse.db_patient p where r.id_patient = p.id_patient and r.status = 'pending' and lama_sewa= '1 Week'", myConn);
                try
                {
                    MySqlDataAdapter sda = new MySqlDataAdapter();
                    sda.SelectCommand = cmdDatabase;
                    DataTable dbdataset = new DataTable();
                    sda.Fill(dbdataset);
                    BindingSource bSource = new BindingSource();

                    bSource.DataSource = dbdataset;
                    dataGrid.DataSource = bSource;
                    sda.Update(dbdataset);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else if (comboBox_filter.Text == "lama_sewa 1 Month")
            {
                //connection 
                string myConnection = "datasource=localhost;port=3306;username=root;Convert Zero Datetime=True;password=";
                MySqlConnection myConn = new MySqlConnection(myConnection);
                MySqlCommand cmdDatabase = new MySqlCommand("SELECT r.id_request, p.patient_address, p.patient_symptoms ,r.lama_sewa,r.price,r.start_date,r.end_date,p.patient_name, p.patient_gender,p.patient_age,p.patient_desc from gonurse.db_transaction r JOIN gonurse.db_patient p where r.id_patient = p.id_patient and r.status = 'pending' and lama_sewa= '1 Month'", myConn);
                try
                {
                    MySqlDataAdapter sda = new MySqlDataAdapter();
                    sda.SelectCommand = cmdDatabase;
                    DataTable dbdataset = new DataTable();
                    sda.Fill(dbdataset);
                    BindingSource bSource = new BindingSource();

                    bSource.DataSource = dbdataset;
                    dataGrid.DataSource = bSource;
                    sda.Update(dbdataset);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else if(comboBox_filter.Text == "price ASC")
            {

                //connection 
                string myConnection = "datasource=localhost;port=3306;username=root;Convert Zero Datetime=True;password=";
                MySqlConnection myConn = new MySqlConnection(myConnection);
                MySqlCommand cmdDatabase = new MySqlCommand("SELECT r.id_request, p.patient_address, p.patient_symptoms ,r.lama_sewa,r.price,r.start_date,r.end_date,p.patient_name, p.patient_gender,p.patient_age,p.patient_desc from gonurse.db_transaction r JOIN gonurse.db_patient p where r.id_patient = p.id_patient and r.status = 'pending' ORDER BY r.price ASC", myConn);
                try
                {
                    MySqlDataAdapter sda = new MySqlDataAdapter();
                    sda.SelectCommand = cmdDatabase;
                    DataTable dbdataset = new DataTable();
                    sda.Fill(dbdataset);
                    BindingSource bSource = new BindingSource();

                    bSource.DataSource = dbdataset;
                    dataGrid.DataSource = bSource;
                    sda.Update(dbdataset);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else if (comboBox_filter.Text == "price DESC")
            {
                //connection 
                string myConnection = "datasource=localhost;port=3306;username=root;Convert Zero Datetime=True;password=";
                MySqlConnection myConn = new MySqlConnection(myConnection);
                MySqlCommand cmdDatabase = new MySqlCommand("SELECT r.id_request, p.patient_address, p.patient_symptoms ,r.lama_sewa,r.price,r.start_date,r.end_date,p.patient_name, p.patient_gender,p.patient_age,p.patient_desc from gonurse.db_transaction r JOIN gonurse.db_patient p where r.id_patient = p.id_patient and r.status = 'pending' ORDER BY r.price DESC", myConn);
                try
                {
                    MySqlDataAdapter sda = new MySqlDataAdapter();
                    sda.SelectCommand = cmdDatabase;
                    DataTable dbdataset = new DataTable();
                    sda.Fill(dbdataset);
                    BindingSource bSource = new BindingSource();

                    bSource.DataSource = dbdataset;
                    dataGrid.DataSource = bSource;
                    sda.Update(dbdataset);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else if (comboBox_filter.Text == "gender MALE")
            {
                //connection 
                string myConnection = "datasource=localhost;port=3306;username=root;Convert Zero Datetime=True;password=";
                MySqlConnection myConn = new MySqlConnection(myConnection);
                MySqlCommand cmdDatabase = new MySqlCommand("SELECT r.id_request, p.patient_address, p.patient_symptoms ,r.lama_sewa,r.price,r.start_date,r.end_date,p.patient_name, p.patient_gender,p.patient_age,p.patient_desc from gonurse.db_transaction r JOIN gonurse.db_patient p where r.id_patient = p.id_patient and r.status = 'pending' and p.patient_gender='male'", myConn);
                try
                {
                    MySqlDataAdapter sda = new MySqlDataAdapter();
                    sda.SelectCommand = cmdDatabase;
                    DataTable dbdataset = new DataTable();
                    sda.Fill(dbdataset);
                    BindingSource bSource = new BindingSource();

                    bSource.DataSource = dbdataset;
                    dataGrid.DataSource = bSource;
                    sda.Update(dbdataset);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else if (comboBox_filter.Text == "gender FEMALE")
            {
                //connection 
                string myConnection = "datasource=localhost;port=3306;username=root;Convert Zero Datetime=True;password=";
                MySqlConnection myConn = new MySqlConnection(myConnection);
                MySqlCommand cmdDatabase = new MySqlCommand("SELECT r.id_request, p.patient_address, p.patient_symptoms ,r.lama_sewa,r.price,r.start_date,r.end_date,p.patient_name, p.patient_gender,p.patient_age,p.patient_desc from gonurse.db_transaction r JOIN gonurse.db_patient p where r.id_patient = p.id_patient and r.status = 'pending' and p.patient_gender='female'", myConn);
                try
                {
                    MySqlDataAdapter sda = new MySqlDataAdapter();
                    sda.SelectCommand = cmdDatabase;
                    DataTable dbdataset = new DataTable();
                    sda.Fill(dbdataset);
                    BindingSource bSource = new BindingSource();

                    bSource.DataSource = dbdataset;
                    dataGrid.DataSource = bSource;
                    sda.Update(dbdataset);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else if (comboBox_filter.Text == "patient_age <= 30")
            {
                //connection 
                string myConnection = "datasource=localhost;port=3306;username=root;Convert Zero Datetime=True;password=";
                MySqlConnection myConn = new MySqlConnection(myConnection);
                MySqlCommand cmdDatabase = new MySqlCommand("SELECT r.id_request, p.patient_address, p.patient_symptoms ,r.lama_sewa,r.price,r.start_date,r.end_date,p.patient_name, p.patient_gender,p.patient_age,p.patient_desc from gonurse.db_transaction r JOIN gonurse.db_patient p where r.id_patient = p.id_patient and r.status = 'pending' and p.patient_age <= 30", myConn);
                try
                {
                    MySqlDataAdapter sda = new MySqlDataAdapter();
                    sda.SelectCommand = cmdDatabase;
                    DataTable dbdataset = new DataTable();
                    sda.Fill(dbdataset);
                    BindingSource bSource = new BindingSource();

                    bSource.DataSource = dbdataset;
                    dataGrid.DataSource = bSource;
                    sda.Update(dbdataset);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else if (comboBox_filter.Text == "patient_age >= 30")
            {
                //connection 
                string myConnection = "datasource=localhost;port=3306;username=root;Convert Zero Datetime=True;password=";
                MySqlConnection myConn = new MySqlConnection(myConnection);
                MySqlCommand cmdDatabase = new MySqlCommand("SELECT r.id_request, p.patient_address, p.patient_symptoms ,r.lama_sewa,r.price,r.start_date,r.end_date,p.patient_name, p.patient_gender,p.patient_age,p.patient_desc from gonurse.db_transaction r JOIN gonurse.db_patient p where r.id_patient = p.id_patient and r.status = 'pending' and p.patient_age >= 30", myConn);
                try
                {
                    MySqlDataAdapter sda = new MySqlDataAdapter();
                    sda.SelectCommand = cmdDatabase;
                    DataTable dbdataset = new DataTable();
                    sda.Fill(dbdataset);
                    BindingSource bSource = new BindingSource();

                    bSource.DataSource = dbdataset;
                    dataGrid.DataSource = bSource;
                    sda.Update(dbdataset);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

        }

        private void btn_home_Click(object sender, EventArgs e)
        {
            DashboardNurse form_dashboard = new DashboardNurse();
            this.Hide();
            form_dashboard.Show();
        }

        private void btn_back_Click(object sender, EventArgs e)
        {
            DashboardNurse form_dashboard = new DashboardNurse();
            this.Hide();
            form_dashboard.Show();
        }
       
            private void dataGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            MakeDeal form_deal = new MakeDeal();
            try
            {

                DataGridViewRow row = this.dataGrid.Rows[e.RowIndex];

                form_deal.label_id.Text = row.Cells["id_request"].Value.ToString();
                form_deal.label_patientName.Text = row.Cells["patient_name"].Value.ToString();
                form_deal.label_patientGender.Text = row.Cells["patient_gender"].Value.ToString();
                form_deal.label_patientAge.Text = row.Cells["patient_age"].Value.ToString();
                form_deal.label_patientSymptoms.Text = row.Cells["patient_symptoms"].Value.ToString();
                form_deal.label_patientDesc.Text = row.Cells["patient_desc"].Value.ToString();
                form_deal.label_patientAddr.Text = row.Cells["patient_address"].Value.ToString();
                form_deal.label_lamaSewa.Text = row.Cells["lama_sewa"].Value.ToString();
                form_deal.label_price.Text = row.Cells["price"].Value.ToString();
                form_deal.label_startDate.Text = row.Cells["start_date"].Value.ToString();
                form_deal.label_endDate.Text = row.Cells["end_date"].Value.ToString();

                /* string startDate = row.Cells["start_date"].Value.ToString();
                 string endDate = row.Cells["end_date"].Value.ToString();

                 DateTime dateTime = DateTime.ParseExact(startDate, "MM/dd/yyyy hh:mm:ss tt", CultureInfo.InvariantCulture);
                 form_deal.label_startDate.Text = dateTime.ToString("MM-dd-yyyy");

                 dateTime = DateTime.ParseExact(endDate, "MM/dd/yyyy hh:mm:ss tt", CultureInfo.InvariantCulture);
                 form_deal.label_endDate.Text = dateTime.ToString("MM-dd-yyyy");*/


                form_deal.Show();
                this.Hide();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
