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
    public partial class Transaction : Form
    {
        public Transaction()
        {
            InitializeComponent();
        }

        private void RecordsOnGoing_Load(object sender, EventArgs e)
        {
            refresh();
        }
        private void refresh()
        {
            //connection 
            string myConnection = "datasource=localhost;port=3306;username=root;Convert Zero Datetime=True;password=";
            MySqlConnection myConn = new MySqlConnection(myConnection);
            MySqlCommand cmdDatabase = new MySqlCommand("SELECT * FROM (SELECT DISTINCT r.status,r.id_request,r.id_nurse, p.patient_name,r.lama_sewa,r.price, r.id_user,r.id_patient,p.patient_gender,p.patient_age,p.patient_symptoms,p.patient_desc,p.patient_address,n.full_name,n.gender,n.age,n.alamat,n.pendidikan,n.nurse_desc, ROW_NUMBER() OVER(PARTITION BY p.patient_name ORDER BY r.id_request DESC) rn from gonurse.db_transaction r JOIN gonurse.db_patient p JOIN gonurse.db_nurses n where r.id_patient = p.id_patient and(r.id_nurse = n.id_nurse) and r.id_user = '" + global.customer_id + "') a WHERE rn = 1; ", myConn);
            try
            {
                MySqlDataAdapter sda = new MySqlDataAdapter();
                sda.SelectCommand = cmdDatabase;
                DataTable dbdataset = new DataTable();
                sda.Fill(dbdataset);
                BindingSource bSource = new BindingSource();

                bSource.DataSource = dbdataset;
                dataGrid_history.DataSource = bSource;
                sda.Update(dbdataset);
                dataGrid_history.Columns["id_user"].Visible = false;
                dataGrid_history.Columns["rn"].Visible = false;
                dataGrid_history.Columns["id_patient"].Visible = false;
                dataGrid_history.Columns["patient_gender"].Visible = false;
                dataGrid_history.Columns["patient_age"].Visible = false;
                dataGrid_history.Columns["patient_symptoms"].Visible = false;
                dataGrid_history.Columns["patient_desc"].Visible = false;
                dataGrid_history.Columns["patient_address"].Visible = false;

                dataGrid_history.Columns["full_name"].Visible = false;
                dataGrid_history.Columns["gender"].Visible = false;
                dataGrid_history.Columns["age"].Visible = false;
                dataGrid_history.Columns["alamat"].Visible = false;
                dataGrid_history.Columns["pendidikan"].Visible = false;
                dataGrid_history.Columns["nurse_desc"].Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btn_back_Click(object sender, EventArgs e)
        {
            DashboardCustomer form_dashboard = new DashboardCustomer();
            this.Hide();
            form_dashboard.countOrder();
            form_dashboard.Show();
        }


        private void comboBox_records_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox_records.Text == "All")
            {
                refresh();
            }
            /*else if (comboBox_records.Text == "Pending")
            {
                //connection 
                string myConnection = "datasource=localhost;port=3306;username=root;Convert Zero Datetime=True;password=";
                MySqlConnection myConn = new MySqlConnection(myConnection);
                MySqlCommand cmdDatabase = new MySqlCommand("SELECT r.status, r.id_request, n.id_nurse, p.patient_name,r.lama_sewa,r.price,   r.id_patient,p.patient_gender,p.patient_age,p.patient_symptoms,p.patient_desc,p.patient_address,n.full_name,n.gender,n.age,n.alamat,n.pendidikan,n.nurse_desc FROM gonurse.db_transaction r JOIN gonurse.db_patient p JOIN gonurse.db_nurses n where r.id_patient = p.id_patient and r.id_nurse = n.id_nurse and r.id_user='" + global.customer_id + "' and status='" + "pending" + "' ;", myConn);
                try
                {
                    MySqlDataAdapter sda = new MySqlDataAdapter();
                    sda.SelectCommand = cmdDatabase;
                    DataTable dbdataset = new DataTable();
                    sda.Fill(dbdataset);
                    BindingSource bSource = new BindingSource();

                    bSource.DataSource = dbdataset;
                    dataGrid_history.DataSource = bSource;
                    sda.Update(dbdataset);
                    dataGrid_history.Columns["id_patient"].Visible = false;
                    dataGrid_history.Columns["patient_gender"].Visible = false;
                    dataGrid_history.Columns["patient_age"].Visible = false;
                    dataGrid_history.Columns["patient_symptoms"].Visible = false;
                    dataGrid_history.Columns["patient_desc"].Visible = false;
                    dataGrid_history.Columns["patient_address"].Visible = false;

                    dataGrid_history.Columns["full_name"].Visible = false;
                    dataGrid_history.Columns["gender"].Visible = false;
                    dataGrid_history.Columns["age"].Visible = false;
                    dataGrid_history.Columns["alamat"].Visible = false;
                    dataGrid_history.Columns["pendidikan"].Visible = false;
                    dataGrid_history.Columns["nurse_desc"].Visible = false;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else if (comboBox_records.Text == "On Going")
            {
                //connection 
                string myConnection = "datasource=localhost;port=3306;username=root;Convert Zero Datetime=True;password=";
                MySqlConnection myConn = new MySqlConnection(myConnection);
                MySqlCommand cmdDatabase = new MySqlCommand("SELECT r.status, r.id_request, n.id_nurse, p.patient_name,r.lama_sewa,r.price,   r.id_patient,p.patient_gender,p.patient_age,p.patient_symptoms,p.patient_desc,p.patient_address,n.full_name,n.gender,n.age,n.alamat,n.pendidikan,n.nurse_desc FROM gonurse.db_transaction r JOIN gonurse.db_patient p JOIN gonurse.db_nurses n where r.id_patient = p.id_patient and r.id_nurse = n.id_nurse and r.id_user='" + global.customer_id + "' and status='" + "on going" + "' ;", myConn);
                try
                {
                    MySqlDataAdapter sda = new MySqlDataAdapter();
                    sda.SelectCommand = cmdDatabase;
                    DataTable dbdataset = new DataTable();
                    sda.Fill(dbdataset);
                    BindingSource bSource = new BindingSource();

                    bSource.DataSource = dbdataset;
                    dataGrid_history.DataSource = bSource;
                    sda.Update(dbdataset);
                    dataGrid_history.Columns["id_patient"].Visible = false;
                    dataGrid_history.Columns["patient_gender"].Visible = false;
                    dataGrid_history.Columns["patient_age"].Visible = false;
                    dataGrid_history.Columns["patient_symptoms"].Visible = false;
                    dataGrid_history.Columns["patient_desc"].Visible = false;
                    dataGrid_history.Columns["patient_address"].Visible = false;

                    dataGrid_history.Columns["full_name"].Visible = false;
                    dataGrid_history.Columns["gender"].Visible = false;
                    dataGrid_history.Columns["age"].Visible = false;
                    dataGrid_history.Columns["alamat"].Visible = false;
                    dataGrid_history.Columns["pendidikan"].Visible = false;
                    dataGrid_history.Columns["nurse_desc"].Visible = false;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else if (comboBox_records.Text == "Waiting")
            {
                waitingData();
            }
            else if (comboBox_records.Text == "Finished")
            {
                //connection 
                string myConnection = "datasource=localhost;port=3306;username=root;Convert Zero Datetime=True;password=";
                MySqlConnection myConn = new MySqlConnection(myConnection);
                MySqlCommand cmdDatabase = new MySqlCommand("SELECT r.status, r.id_request, n.id_nurse, p.patient_name,r.lama_sewa,r.price,   r.id_patient,p.patient_gender,p.patient_age,p.patient_symptoms,p.patient_desc,p.patient_address,n.full_name,n.gender,n.age,n.alamat,n.pendidikan,n.nurse_desc FROM gonurse.db_transaction r JOIN gonurse.db_patient p JOIN gonurse.db_nurses n where r.id_patient = p.id_patient and r.id_nurse = n.id_nurse and r.id_user='" + global.customer_id + "' and status='" + "finished" + "' ;", myConn);
                try
                {
                    MySqlDataAdapter sda = new MySqlDataAdapter();
                    sda.SelectCommand = cmdDatabase;
                    DataTable dbdataset = new DataTable();
                    sda.Fill(dbdataset);
                    BindingSource bSource = new BindingSource();

                    bSource.DataSource = dbdataset;
                    dataGrid_history.DataSource = bSource;
                    sda.Update(dbdataset);
                    dataGrid_history.Columns["id_patient"].Visible = false;
                    dataGrid_history.Columns["patient_gender"].Visible = false;
                    dataGrid_history.Columns["patient_age"].Visible = false;
                    dataGrid_history.Columns["patient_symptoms"].Visible = false;
                    dataGrid_history.Columns["patient_desc"].Visible = false;
                    dataGrid_history.Columns["patient_address"].Visible = false;

                    dataGrid_history.Columns["full_name"].Visible = false;
                    dataGrid_history.Columns["gender"].Visible = false;
                    dataGrid_history.Columns["age"].Visible = false;
                    dataGrid_history.Columns["alamat"].Visible = false;
                    dataGrid_history.Columns["pendidikan"].Visible = false;
                    dataGrid_history.Columns["nurse_desc"].Visible = false;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else if (comboBox_records.Text == "Cancelled")
            {
                //connection 
                string myConnection = "datasource=localhost;port=3306;username=root;Convert Zero Datetime=True;password=";
                MySqlConnection myConn = new MySqlConnection(myConnection);
                MySqlCommand cmdDatabase = new MySqlCommand("SELECT r.status, r.id_request, n.id_nurse, p.patient_name,r.lama_sewa,r.price,   r.id_patient,p.patient_gender,p.patient_age,p.patient_symptoms,p.patient_desc,p.patient_address,n.full_name,n.gender,n.age,n.alamat,n.pendidikan,n.nurse_desc FROM gonurse.db_transaction r JOIN gonurse.db_patient p JOIN gonurse.db_nurses n where r.id_patient = p.id_patient and r.id_nurse = n.id_nurse and r.id_user='" + global.customer_id + "' and status='" + "cancelled" + "' ;", myConn);
                try
                {
                    MySqlDataAdapter sda = new MySqlDataAdapter();
                    sda.SelectCommand = cmdDatabase;
                    DataTable dbdataset = new DataTable();
                    sda.Fill(dbdataset);
                    BindingSource bSource = new BindingSource();

                    bSource.DataSource = dbdataset;
                    dataGrid_history.DataSource = bSource;
                    sda.Update(dbdataset);
                    dataGrid_history.Columns["id_patient"].Visible = false;
                    dataGrid_history.Columns["patient_gender"].Visible = false;
                    dataGrid_history.Columns["patient_age"].Visible = false;
                    dataGrid_history.Columns["patient_symptoms"].Visible = false;
                    dataGrid_history.Columns["patient_desc"].Visible = false;
                    dataGrid_history.Columns["patient_address"].Visible = false;

                    dataGrid_history.Columns["full_name"].Visible = false;
                    dataGrid_history.Columns["gender"].Visible = false;
                    dataGrid_history.Columns["age"].Visible = false;
                    dataGrid_history.Columns["alamat"].Visible = false;
                    dataGrid_history.Columns["pendidikan"].Visible = false;
                    dataGrid_history.Columns["nurse_desc"].Visible = false;
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
            MySqlCommand cmdDatabase = new MySqlCommand("SELECT r.status, r.id_request, n.id_nurse, p.patient_name,r.lama_sewa,r.price,   r.id_patient,p.patient_gender,p.patient_age,p.patient_symptoms,p.patient_desc,p.patient_address,n.full_name,n.gender,n.age,n.alamat,n.pendidikan,n.nurse_desc FROM gonurse.db_transaction r JOIN gonurse.db_patient p JOIN gonurse.db_nurses n where r.id_patient = p.id_patient and r.id_nurse = n.id_nurse and r.id_user='" + global.customer_id + "' and status='" + "waiting" + "' ;", myConn);
            try
            {
                MySqlDataAdapter sda = new MySqlDataAdapter();
                sda.SelectCommand = cmdDatabase;
                DataTable dbdataset = new DataTable();
                sda.Fill(dbdataset);
                BindingSource bSource = new BindingSource();

                bSource.DataSource = dbdataset;
                dataGrid_history.DataSource = bSource;
                sda.Update(dbdataset);
                dataGrid_history.Columns["id_patient"].Visible = false;
                dataGrid_history.Columns["patient_gender"].Visible = false;
                dataGrid_history.Columns["patient_age"].Visible = false;
                dataGrid_history.Columns["patient_symptoms"].Visible = false;
                dataGrid_history.Columns["patient_desc"].Visible = false;
                dataGrid_history.Columns["patient_address"].Visible = false;

                dataGrid_history.Columns["full_name"].Visible = false;
                dataGrid_history.Columns["gender"].Visible = false;
                dataGrid_history.Columns["age"].Visible = false;
                dataGrid_history.Columns["alamat"].Visible = false;
                dataGrid_history.Columns["pendidikan"].Visible = false;
                dataGrid_history.Columns["nurse_desc"].Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }*/
        private void panel_buttom_Click(object sender, EventArgs e)
        {
        }

        private void btn_home_Click(object sender, EventArgs e)
        {
            DashboardCustomer form_dashboard = new DashboardCustomer();
            this.Hide();
            form_dashboard.Show();
        }



      

        private void dataGrid_history_CellClick(object sender, DataGridViewCellEventArgs e)
        {

         
        }
        public int row_index;
        private void dataGrid_history_MouseClick(object sender, MouseEventArgs e)
        {
            ContextMenu m = new ContextMenu();
            int currentMouseOverRow = dataGrid_history.HitTest(e.X, e.Y).RowIndex;
            row_index = currentMouseOverRow;
            if (row_index > -1)
            {
                DataGridViewRow row = this.dataGrid_history.Rows[row_index];
                if (row.Cells["status"].Value.ToString() == "waiting")
                {
                    if (e.Button == MouseButtons.Right)
                    {
                        //Put here your options
                        m.MenuItems.Add(new MenuItem("View Patient", new System.EventHandler(this.viewP_Click)));
                        m.MenuItems.Add(new MenuItem("View Nurse", new System.EventHandler(this.viewN_Click)));
                        m.MenuItems.Add(new MenuItem("Accept", new System.EventHandler(this.accept_Click)));
                        m.MenuItems.Add(new MenuItem("Reject", new System.EventHandler(this.reject_Click)));
                        m.Show(dataGrid_history, new Point(e.X, e.Y));
                    }
                }
                else if (row.Cells["status"].Value.ToString() == "pending")
                {
                    if (e.Button == MouseButtons.Right)
                    {
                        //Put here your options
                        m.MenuItems.Add(new MenuItem("View Patient", new System.EventHandler(this.viewP_Click)));
                        m.MenuItems.Add(new MenuItem("Cancel", new System.EventHandler(this.cancel_Clicked)));
                        m.Show(dataGrid_history, new Point(e.X, e.Y));
                    }
                }
                else if (row.Cells["status"].Value.ToString() == "on going")
                {
                    if (e.Button == MouseButtons.Right)
                    {
                        //Put here your options
                        m.MenuItems.Add(new MenuItem("View Patient", new System.EventHandler(this.viewP_Click)));
                        m.MenuItems.Add(new MenuItem("View Nurse", new System.EventHandler(this.viewN_Click)));
                        m.MenuItems.Add(new MenuItem("Finish", new System.EventHandler(this.finish_Clicked)));
                        m.Show(dataGrid_history, new Point(e.X, e.Y));
                    }
                }
                else if (row.Cells["status"].Value.ToString() == "cancelled")
                {
                    if (e.Button == MouseButtons.Right)
                    {
                        //Put here your options
                        m.MenuItems.Add(new MenuItem("View Patient", new System.EventHandler(this.viewP_Click)));
                        m.Show(dataGrid_history, new Point(e.X, e.Y));
                    }
                }
                else if (row.Cells["status"].Value.ToString() == "finished")
                {
                    if (e.Button == MouseButtons.Right)
                    {
                        //Put here your options
                        m.MenuItems.Add(new MenuItem("View Patient", new System.EventHandler(this.viewP_Click)));
                        m.MenuItems.Add(new MenuItem("View Nurse", new System.EventHandler(this.viewN_Click)));
                        m.Show(dataGrid_history, new Point(e.X, e.Y));
                    }
                }
            }
        }
        private void dataGrid_history_MouseDown(object sender, MouseEventArgs e)
        {
            dataGrid_history_MouseClick(sender, e);
        }

        private void finish_Clicked(Object sender, EventArgs e)
        {
            //connection 
            string myConnection = "datasource=localhost;port=3306;username=root;password=";
            DataGridViewRow row = this.dataGrid_history.Rows[row_index];
            string Query = "UPDATE gonurse.db_transaction SET status= 'finished' WHERE id_patient='" + row.Cells["id_patient"].Value.ToString() + "';";
            MySqlConnection myConn = new MySqlConnection(myConnection);
            MySqlCommand cmdDatabase = new MySqlCommand(Query, myConn);
            MySqlDataReader myReader;
            try
            {
                myConn.Open();
                myReader = cmdDatabase.ExecuteReader();
                MessageBox.Show("Congratulations, your request is finished!");
                update_balance_Clicked(sender, e);
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




        private void cancel_Clicked(Object sender, EventArgs e)
        {
            //connection 
            string myConnection = "datasource=localhost;port=3306;username=root;password=";
            DataGridViewRow row = this.dataGrid_history.Rows[row_index];
            string Query = "UPDATE gonurse.db_transaction SET status= 'cancelled' WHERE id_patient='" + row.Cells["id_patient"].Value.ToString() + "';";
            MySqlConnection myConn = new MySqlConnection(myConnection);
            MySqlCommand cmdDatabase = new MySqlCommand(Query, myConn);
            MySqlDataReader myReader;
           
            try
            {
                myConn.Open();
                myReader = cmdDatabase.ExecuteReader();
                MessageBox.Show("You cancelled the request!");
                setTaken(sender, e);
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
        private void setTaken(Object sender, EventArgs e)
        {
            //connection 
            string myConnection = "datasource=localhost;port=3306;username=root;password=";
            DataGridViewRow row = this.dataGrid_history.Rows[row_index];
            string Query = "UPDATE gonurse.db_patient SET isTaken= 'not taken' WHERE id_patient='" + row.Cells["id_patient"].Value.ToString() + "';";
            MySqlConnection myConn = new MySqlConnection(myConnection);
            MySqlCommand cmdDatabase = new MySqlCommand(Query, myConn);
            MySqlDataReader myReader;

            try
            {
                myConn.Open();
                myReader = cmdDatabase.ExecuteReader();
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


         private void update_balance_Clicked(Object sender, EventArgs e)
         {
             //connection 
             string myConnection = "datasource=localhost;port=3306;username=root;password=";
            DataGridViewRow row = this.dataGrid_history.Rows[row_index];
            string Query = "UPDATE gonurse.db_nurses SET balance=balance + '" + row.Cells["price"].Value.ToString() + "'  WHERE id_nurse='" + row.Cells["id_nurse"].Value.ToString() + "';";
            MySqlConnection myConn = new MySqlConnection(myConnection);
             MySqlCommand cmdDatabase = new MySqlCommand(Query, myConn);
             MySqlDataReader myReader;

             try
             {
                 myConn.Open();
                 myReader = cmdDatabase.ExecuteReader();
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




        Form formbackground = new Form();
        private void viewP_Click(Object sender, EventArgs e)
        {
            //What Happens to View Patient
            DataGridViewRow row = this.dataGrid_history.Rows[row_index];
            viewPatient form_patient = new viewPatient();

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
        private void viewN_Click(Object sender, EventArgs e)
        {
            //What Happens to View Nurse
            DataGridViewRow row = this.dataGrid_history.Rows[row_index];
            viewNurse form_nurse = new viewNurse();

                form_nurse.label_id.Text = row.Cells["id_nurse"].Value.ToString();
                form_nurse.label_nurseName.Text = row.Cells["full_name"].Value.ToString();
                form_nurse.label_nurseGender.Text = row.Cells["gender"].Value.ToString();
                form_nurse.label_nurseAge.Text = row.Cells["age"].Value.ToString();
                form_nurse.label_nurseAddress.Text = row.Cells["alamat"].Value.ToString();
                form_nurse.label_nursePendidikan.Text = row.Cells["pendidikan"].Value.ToString();
                form_nurse.label_nurseDesc.Text = row.Cells["nurse_desc"].Value.ToString();

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

                    form_nurse.Owner = formbackground;
                    form_nurse.ShowDialog();
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
        private void accept_Click(Object sender, EventArgs e)
        {
            //What Happens to Accept
            setStatusRequest(Convert.ToInt32(global.customer_id));

        }
        private void reject_Click(Object sender, EventArgs e)
        {
            //What Happens to reject
            setStatusRequest2(Convert.ToInt32(global.customer_id));
            removeIdNurse(Convert.ToInt32(global.customer_id));
        }

        void setStatusRequest(int id_user)
        {
            //connection 
            string myConnection = "datasource=localhost;port=3306;username=root;password=";

            DataGridViewRow row = this.dataGrid_history.Rows[row_index];
            string Query = "UPDATE gonurse.db_transaction SET status= 'on going'  WHERE id_patient='" + row.Cells["id_patient"].Value.ToString() + "';";
            MySqlConnection myConn = new MySqlConnection(myConnection);
            MySqlCommand cmdDatabase = new MySqlCommand(Query, myConn);
            MySqlDataReader myReader;

            try
            {
                myConn.Open();
                myReader = cmdDatabase.ExecuteReader();
                MessageBox.Show("Congratulations, your selected nurse will be on your home soon!");
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
        void setStatusRequest2(int id_user)
        {
            //connection 
            string myConnection = "datasource=localhost;port=3306;username=root;password=";

            DataGridViewRow row = this.dataGrid_history.Rows[row_index];
            string Query = "UPDATE gonurse.db_transaction SET status= 'pending' WHERE id_patient='" + row.Cells["id_patient"].Value.ToString() + "';";
            MySqlConnection myConn = new MySqlConnection(myConnection);
            MySqlCommand cmdDatabase = new MySqlCommand(Query, myConn);
            MySqlDataReader myReader;

            try
            {
                myConn.Open();
                myReader = cmdDatabase.ExecuteReader();
                MessageBox.Show("You rejected the nurse request! Your request is back on pending");
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

        void removeIdNurse(int id_user)
        {
            //connection 
            string myConnection = "datasource=localhost;port=3306;username=root;password=";

            DataGridViewRow row = this.dataGrid_history.Rows[row_index];
            string Query = "UPDATE gonurse.db_transaction SET id_nurse= '0' WHERE id_patient='" + row.Cells["id_patient"].Value.ToString() + "';";
            MySqlConnection myConn = new MySqlConnection(myConnection);
            MySqlCommand cmdDatabase = new MySqlCommand(Query, myConn);
            MySqlDataReader myReader;

            try
            {
                myConn.Open();
                myReader = cmdDatabase.ExecuteReader();
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


        private void dataGrid_history_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {

        }

        private void dataGrid_history_CellMouseUp(object sender, DataGridViewCellMouseEventArgs e)
        {

        }

        private void btn_refresh_Click(object sender, EventArgs e)
        {
            refresh();
        }

      
    }
}
