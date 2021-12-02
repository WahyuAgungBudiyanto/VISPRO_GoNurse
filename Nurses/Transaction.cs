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
    public partial class Transaction : Form
    {
        public Transaction()
        {
            InitializeComponent();
        }
        private void Transaction_Load(object sender, EventArgs e)
        {
            refresh();
        }
        private void refresh()
        { //connection 
            string myConnection = "datasource=localhost;port=3306;username=root;Convert Zero Datetime=True;password=";
            MySqlConnection myConn = new MySqlConnection(myConnection);
            MySqlCommand cmdDatabase = new MySqlCommand("SELECT r.status,r.id_request,r.id_nurse, p.patient_name,r.lama_sewa,r.price,r.start_date,r.end_date, r.id_user,r.id_patient,p.patient_gender,p.patient_age,p.patient_symptoms,p.patient_desc,p.patient_address,n.full_name,n.gender,n.age,n.alamat,n.pendidikan,n.nurse_desc from gonurse.db_transaction r JOIN gonurse.db_patient p JOIN gonurse.db_nurses n where r.id_patient = p.id_patient and(r.id_nurse = n.id_nurse) and r.id_nurse = '" + global.nurse_id + "'; ", myConn);
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
                dataGrid.Columns["id_user"].Visible = false;
                dataGrid.Columns["id_patient"].Visible = false;
                dataGrid.Columns["patient_gender"].Visible = false;
                dataGrid.Columns["patient_age"].Visible = false;
                dataGrid.Columns["patient_symptoms"].Visible = false;
                dataGrid.Columns["patient_desc"].Visible = false;
                dataGrid.Columns["patient_address"].Visible = false;

                dataGrid.Columns["full_name"].Visible = false;
                dataGrid.Columns["gender"].Visible = false;
                dataGrid.Columns["age"].Visible = false;
                dataGrid.Columns["alamat"].Visible = false;
                dataGrid.Columns["pendidikan"].Visible = false;
                dataGrid.Columns["nurse_desc"].Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        private void comboBox_history_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox_history.Text == "All")
            {
                refresh();
            }
           /* else if (comboBox_history.Text == "Waiting")
            {
                waitingData();
            }
            else if (comboBox_history.Text == "On Going")
            {
                //connection 
                string myConnection = "datasource=localhost;port=3306;username=root;Convert Zero Datetime=True;password=";
                MySqlConnection myConn = new MySqlConnection(myConnection);
                MySqlCommand cmdDatabase = new MySqlCommand("SELECT r.status,r.id_request,r.id_nurse, p.patient_name,r.lama_sewa,r.price,r.id_patient,p.patient_gender,p.patient_age,p.patient_symptoms,p.patient_desc,p.patient_address from gonurse.db_transaction r JOIN gonurse.db_patient p where r.id_patient = p.id_patient and r.id_nurse='" + global.nurse_id + "' and r.status='" + "on going" + "' ;", myConn);
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
                    dataGrid.Columns["id_patient"].Visible = false;
                    dataGrid.Columns["patient_gender"].Visible = false;
                    dataGrid.Columns["patient_age"].Visible = false;
                    dataGrid.Columns["patient_symptoms"].Visible = false;
                    dataGrid.Columns["patient_desc"].Visible = false;
                    dataGrid.Columns["patient_address"].Visible = false;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else if (comboBox_history.Text == "Pending")
            {
                //connection 
                string myConnection = "datasource=localhost;port=3306;username=root;Convert Zero Datetime=True;password=";
                MySqlConnection myConn = new MySqlConnection(myConnection);
                MySqlCommand cmdDatabase = new MySqlCommand("SELECT r.status,r.id_request,r.id_nurse, p.patient_name,r.lama_sewa,r.price, r.id_patient,p.patient_gender,p.patient_age,p.patient_symptoms,p.patient_desc,p.patient_address from gonurse.db_transaction r JOIN gonurse.db_patient p where r.id_patient = p.id_patient and r.id_nurse='" + global.nurse_id + "' and r.status='" + "pending" + "' ;", myConn);
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
                    dataGrid.Columns["id_patient"].Visible = false;
                    dataGrid.Columns["patient_gender"].Visible = false;
                    dataGrid.Columns["patient_age"].Visible = false;
                    dataGrid.Columns["patient_symptoms"].Visible = false;
                    dataGrid.Columns["patient_desc"].Visible = false;
                    dataGrid.Columns["patient_address"].Visible = false;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else if (comboBox_history.Text == "Finished")
            {
                //connection 
                string myConnection = "datasource=localhost;port=3306;username=root;Convert Zero Datetime=True;password=";
                MySqlConnection myConn = new MySqlConnection(myConnection);
                MySqlCommand cmdDatabase = new MySqlCommand("SELECT r.status,r.id_request,r.id_nurse, p.patient_name,r.lama_sewa,r.price, r.id_patient,p.patient_gender,p.patient_age,p.patient_symptoms,p.patient_desc,p.patient_address from gonurse.db_transaction r JOIN gonurse.db_patient p where r.id_patient = p.id_patient and r.id_nurse='" + global.nurse_id + "' and r.status='" + "finished" + "' ;", myConn);
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
                    dataGrid.Columns["id_patient"].Visible = false;
                    dataGrid.Columns["patient_gender"].Visible = false;
                    dataGrid.Columns["patient_age"].Visible = false;
                    dataGrid.Columns["patient_symptoms"].Visible = false;
                    dataGrid.Columns["patient_desc"].Visible = false;
                    dataGrid.Columns["patient_address"].Visible = false;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else if (comboBox_history.Text == "Cancelled")
            {
                //connection 
                string myConnection = "datasource=localhost;port=3306;username=root;Convert Zero Datetime=True;password=";
                MySqlConnection myConn = new MySqlConnection(myConnection);
                MySqlCommand cmdDatabase = new MySqlCommand("SELECT r.status,r.id_request,r.id_nurse, p.patient_name,r.lama_sewa,r.price, r.id_patient,p.patient_gender,p.patient_age,p.patient_symptoms,p.patient_desc,p.patient_address from gonurse.db_transaction r JOIN gonurse.db_patient p  where r.id_patient = p.id_patient and r.id_nurse='" + global.nurse_id + "' and r.status='" + "cancelled" + "' ;", myConn);
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
                    dataGrid.Columns["id_patient"].Visible = false;
                    dataGrid.Columns["patient_gender"].Visible = false;
                    dataGrid.Columns["patient_age"].Visible = false;
                    dataGrid.Columns["patient_symptoms"].Visible = false;
                    dataGrid.Columns["patient_desc"].Visible = false;
                    dataGrid.Columns["patient_address"].Visible = false;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }*/
        }
        /*  public void waitingData()
        {
            //connection 
            string myConnection = "datasource=localhost;port=3306;username=root;Convert Zero Datetime=True;password=";
            MySqlConnection myConn = new MySqlConnection(myConnection);
            MySqlCommand cmdDatabase = new MySqlCommand("SELECT r.status,r.id_request,r.id_nurse, p.patient_name,r.lama_sewa,r.price,r.id_patient,p.patient_gender,p.patient_age,p.patient_symptoms,p.patient_desc,p.patient_address from gonurse.db_transaction r JOIN gonurse.db_patient p where r.id_patient = p.id_patient and r.id_nurse='" + global.nurse_id + "' and r.status='" + "waiting" + "' ;", myConn);
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
                dataGrid.Columns["id_patient"].Visible = false;
                dataGrid.Columns["patient_gender"].Visible = false;
                dataGrid.Columns["patient_age"].Visible = false;
                dataGrid.Columns["patient_symptoms"].Visible = false;
                dataGrid.Columns["patient_desc"].Visible = false;
                dataGrid.Columns["patient_address"].Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
*/

        private void btn_home_Click(object sender, EventArgs e)
        {
            DashboardNurse form_dashboard = new DashboardNurse();
            this.Hide();
            form_dashboard.Show();
        }

        private void dataGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
      
        private void btn_back_Click(object sender, EventArgs e)
        {
            DashboardNurse form_dashboard = new DashboardNurse();
            this.Hide();
            form_dashboard.Show();
        }

        public int row_index;
        private void dataGrid_MouseClick(object sender, MouseEventArgs e)
        {
            ContextMenu m = new ContextMenu();
            int currentMouseOverRow = dataGrid.HitTest(e.X, e.Y).RowIndex;
            row_index = currentMouseOverRow;
            if (row_index > -1)
            {
                DataGridViewRow row = this.dataGrid.Rows[row_index];
                if (row.Cells["status"].Value.ToString() == "waiting")
                {
                    if (e.Button == MouseButtons.Right)
                    {
                        //Put here your options
                        m.MenuItems.Add(new MenuItem("View Patient", new System.EventHandler(this.viewP_Click)));
                        m.Show(dataGrid, new Point(e.X, e.Y));
                    }
                }
                else if (row.Cells["status"].Value.ToString() == "on going")
                {
                    if (e.Button == MouseButtons.Right)
                    {
                        //Put here your options
                        m.MenuItems.Add(new MenuItem("View Patient", new System.EventHandler(this.viewP_Click)));
                        m.Show(dataGrid, new Point(e.X, e.Y));
                    }
                }
                else if (row.Cells["status"].Value.ToString() == "finished")
                {
                    if (e.Button == MouseButtons.Right)
                    {
                        //Put here your options
                        m.MenuItems.Add(new MenuItem("View Patient", new System.EventHandler(this.viewP_Click)));
                        m.Show(dataGrid, new Point(e.X, e.Y));
                    }
                }
            }
        }



        Form formbackground = new Form();
        private void viewP_Click(Object sender, EventArgs e)
        {
            //What Happens to View Patient
            DataGridViewRow row = this.dataGrid.Rows[row_index];
            Customers.viewPatient form_patient = new Customers.viewPatient();

            form_patient.label_id.Text = row.Cells["id_patient"].Value.ToString();
            form_patient.label_patientName.Text = row.Cells["patient_name"].Value.ToString();
            form_patient.label_patientGender.Text = row.Cells["patient_gender"].Value.ToString();
            form_patient.label_patientAge.Text = row.Cells["patient_age"].Value.ToString();
            form_patient.label_patientSymptoms.Text = row.Cells["patient_symptoms"].Value.ToString();
            form_patient.label_patientDesc.Text = row.Cells["patient_desc"].Value.ToString();
            form_patient.label_patientAddress.Text = row.Cells["patient_address"].Value.ToString();

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

                form_patient.Owner = formbackground;
                form_patient.ShowDialog();
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

        }

        private void btn_refresh_Click(object sender, EventArgs e)
        {
            refresh();
        }
    }
}
