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
    public partial class CRUDPatient : Form
    {
        public CRUDPatient()
        {
            InitializeComponent();
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            if (textBox_fName.Text == "" || comboBox_gender.Text == "" || textBox_age.Value < 1 || textBox_symptoms.Text == "" || textBox_desc.Text == "" || textBox_address.Text == "")
            {
                MessageBox.Show("Please fill all the fields", "Registration Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            else
            {
                //connection 
                string myConnection = "datasource=localhost;port=3306;username=root;password=";
                string Query = "UPDATE gonurse.db_patient SET patient_name= '" + this.textBox_fName.Text + "',patient_gender='" + this.comboBox_gender.Text + "',patient_age='" + this.textBox_age.Text + "',patient_symptoms='" + this.textBox_symptoms.Text + "',patient_desc= '" + this.textBox_desc.Text + "',patient_address= '" + this.textBox_address.Text + "' WHERE id_patient= '" + this.textBox_id.Text + "';";
                MySqlConnection myConn = new MySqlConnection(myConnection);
                MySqlCommand cmdDatabase = new MySqlCommand(Query, myConn);
                MySqlDataReader myReader;

                try
                {
                    myConn.Open();
                    myReader = cmdDatabase.ExecuteReader();
                    MessageBox.Show("Patient has been edited", "Edited Successfully", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    AddRequest form_request = new AddRequest();
                    form_request.textBox_searchtop.Text = "";
                    form_request.refresh();
                    form_request.Show();
                    this.Hide();
                    while (myReader.Read())
                    {

                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void btn_back_Click(object sender, EventArgs e)
        {
            AddRequest form_request = new AddRequest();
            form_request.Show();
            this.Hide();
        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            //connection 
            string myConnection = "datasource=localhost;port=3306;username=root;password=";
            string Query = "DELETE from gonurse.db_patient WHERE id_patient= '" + this.textBox_id.Text + "';";
            MySqlConnection myConn = new MySqlConnection(myConnection);
            MySqlCommand cmdDatabase = new MySqlCommand(Query, myConn);
            MySqlDataReader myReader;

            try
            {
                myConn.Open();
                myReader = cmdDatabase.ExecuteReader();
                MessageBox.Show("Patient has been deleted", "Deleted Successfully", MessageBoxButtons.OK, MessageBoxIcon.Information);
                AddRequest form_request = new AddRequest();
                form_request.refresh();
                this.Hide();
                form_request.Show();
                while (myReader.Read())
                {

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btn_choose_Click(object sender, EventArgs e)
        {

            AddRequest form_request = new AddRequest();
            form_request.label_patID.Text = textBox_id.Text;
            this.Hide();
            form_request.Show();
        }

        private void textBox_fName_KeyPress(object sender, KeyPressEventArgs e)
        {
            //No Numbers Allowed
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar))
            {
                e.Handled = true;
                base.OnKeyPress(e);
            }
        }

        private void textBox_symptoms_KeyPress(object sender, KeyPressEventArgs e)
        {
            //No Numbers Allowed
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar))
            {
                e.Handled = true;
                base.OnKeyPress(e);
            }
        }
    }
}
