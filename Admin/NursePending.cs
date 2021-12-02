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

namespace GoNurse.Admin
{
    public partial class NursePending : Form
    {
        public NursePending()
        {
            InitializeComponent();
        }

        private void btn_back_Click(object sender, EventArgs e)
        {
            DashboardAdmin form_dashboard = new DashboardAdmin();
            this.Hide();
            form_dashboard.Show();
        }
        private void refresh()
        { //connection 
            string myConnection = "datasource=localhost;port=3306;username=root;Convert Zero Datetime=True;password=";
            MySqlConnection myConn = new MySqlConnection(myConnection);
            MySqlCommand cmdDatabase = new MySqlCommand("SELECT isApprove, full_name,username,no_telp,email, id_nurse,gender,age,alamat,pendidikan,nurse_desc FROM gonurse.db_nurses WHERE isApprove='0'; ", myConn);
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
                dataGrid.Columns["id_nurse"].Visible = false;
                dataGrid.Columns["gender"].Visible = false;
                dataGrid.Columns["age"].Visible = false;
                dataGrid.Columns["email"].Visible = false;
                dataGrid.Columns["alamat"].Visible = false;
                dataGrid.Columns["pendidikan"].Visible = false;
                dataGrid.Columns["nurse_desc"].Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

     
        private void NursePending_Load(object sender, EventArgs e)
        {
            refresh();
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
                    if (e.Button == MouseButtons.Right)
                    {
                        //Put here your options
                        m.MenuItems.Add(new MenuItem("View Details", new System.EventHandler(this.view_Nurse_Clicked)));
                        m.MenuItems.Add(new MenuItem("Approve", new System.EventHandler(this.Approve)));
                        m.MenuItems.Add(new MenuItem("Reject", new System.EventHandler(this.Reject)));
                    m.Show(dataGrid, new Point(e.X, e.Y));
                    }
                
               
            }
        }
        Form formbackground = new Form();
        viewNurse form_nurse = new viewNurse();
        private void Approve(Object sender, EventArgs e)
        {
            DataGridViewRow row = this.dataGrid.Rows[row_index];
            string labelUsername;
            labelUsername = row.Cells["username"].Value.ToString();

            string message = "Are you sure to approve " + labelUsername + " ?";
            string title = "Approve Nurse";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result = MessageBox.Show(message, title, buttons, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                //connection 
                string myConnection = "datasource=localhost;port=3306;username=root;password=";

                string Query = "UPDATE gonurse.db_nurses SET isApprove= '1'  WHERE id_nurse='" + row.Cells["id_nurse"].Value.ToString() + "';";
                MySqlConnection myConn = new MySqlConnection(myConnection);
                MySqlCommand cmdDatabase = new MySqlCommand(Query, myConn);
                MySqlDataReader myReader;

                try
                {
                    myConn.Open();
                    myReader = cmdDatabase.ExecuteReader();
                    MessageBox.Show("Approved Success", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            else
            {
               
            }

            
        }
        private void Reject(Object sender, EventArgs e)
        {
            DataGridViewRow row = this.dataGrid.Rows[row_index];
            string labelUsername;
            labelUsername = row.Cells["username"].Value.ToString();
            string message = "Are you sure to reject approval from " + labelUsername + " ?\nYou will delete this records in the system!";
            string title = "Reject Nurse";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result = MessageBox.Show(message, title, buttons, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                //connection 
                string myConnection = "datasource=localhost;port=3306;username=root;password=";

                string Query = "DELETE FROM gonurse.db_nurses  WHERE id_nurse='" + row.Cells["id_nurse"].Value.ToString() + "';";

                MySqlConnection myConn = new MySqlConnection(myConnection);
                MySqlCommand cmdDatabase = new MySqlCommand(Query, myConn);
                MySqlDataReader myReader;

                try
                {
                    myConn.Open();
                    myReader = cmdDatabase.ExecuteReader();
                    MessageBox.Show("Rejected Success", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            else
            {

            }
          
        }
        private void view_Nurse_Clicked(Object sender, EventArgs e)
        {
            //What Happens to View Nurse
            DataGridViewRow row = this.dataGrid.Rows[row_index];
            viewNurse form_nurse = new viewNurse();

            form_nurse.label_id.Text = row.Cells["id_nurse"].Value.ToString();
            form_nurse.label_nurseName.Text = row.Cells["full_name"].Value.ToString();
            form_nurse.label_nurseUsername.Text = row.Cells["username"].Value.ToString();
            form_nurse.label_nurseEmail.Text = row.Cells["email"].Value.ToString();
            form_nurse.label_nurseGender.Text = row.Cells["gender"].Value.ToString();
            form_nurse.label_nurseAge.Text = row.Cells["age"].Value.ToString();
            form_nurse.label_nurseNo.Text = row.Cells["no_telp"].Value.ToString();
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
        private void btn_refresh_Click(object sender, EventArgs e)
        {
            refresh();
        }

        private void dataGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void textBox_searchtop_TextChanged(object sender, EventArgs e)
        {
            //connection 
            string myConnection = "datasource=localhost;port=3306;username=root;password=";
            MySqlConnection myConn = new MySqlConnection(myConnection);
            MySqlCommand cmdDatabase = new MySqlCommand("SELECT isApprove, full_name,username,no_telp,email, id_nurse,gender,age,alamat,pendidikan,nurse_desc FROM gonurse.db_nurses WHERE isApprove='0'; ", myConn);
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

                DataView DV = new DataView(dbdataset);
                DV.RowFilter = string.Format("username LIKE '%{0}%'", textBox_searchtop.Text);
                dataGrid.DataSource = DV;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        

    }
}
