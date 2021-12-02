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
    public partial class AddPatient : Form
    {
        public AddPatient()
        {
            InitializeComponent();
        }

        private void btn_back_Click(object sender, EventArgs e)
        {
            AddRequest form_request = new AddRequest();
            form_request.Show();
            this.Hide();
        }
        
        private void btn_save_Click(object sender, EventArgs e)
        {
            if (textBox_fName.Text == "" || comboBox_gender.Text == "" || textBox_age.Value < 1 || textBox_symptoms.Text =="" || textBox_desc.Text == "" || textBox_address.Text == "")
            {
                MessageBox.Show("Please fill all the fields", "Registration Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            else
            {
                try
                {

                    //connection 
                    string myConnection = "datasource=localhost;port=3306;username=root;password=";
                    /* string Query = $"insert into gonurse.db_customerrequest (id_request,patient_name) values('',{label_fName.Text}); ";*/
                    string Query = $"INSERT INTO gonurse.db_patient(id_patient, id_user, patient_name, patient_gender, patient_age, patient_symptoms, patient_desc, patient_address,isTaken) VALUES('', '{global.customer_id}', '{textBox_fName.Text}', '{comboBox_gender.Text}', '{textBox_age.Text}', '{textBox_symptoms.Text}', '{textBox_desc.Text}', '{textBox_address.Text}', 'not taken');";
                    MySqlConnection myConn = new MySqlConnection(myConnection);
                    MySqlCommand cmdDatabase = new MySqlCommand(Query, myConn);
                    MySqlDataReader myReader;
                    myConn.Open();
                    myReader = cmdDatabase.ExecuteReader();
                    MessageBox.Show("Patient has been added", "Added Successfully", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

                AddRequest form_request = new AddRequest();
                this.Hide();
                form_request.Show();
            }
          
        }
        private void btn_clear_Click(object sender, EventArgs e)
        {
            textBox_fName.Text = "";
            comboBox_gender.Text = "";
            textBox_age.Value = 1;
            textBox_symptoms.Text = "";
            textBox_desc.Text = "";
            textBox_address.Text = "";
        }

        private void bunifuDatePicker1_ValueChanged(object sender, EventArgs e)
        {
            
        }

        private void AddPatient_Load(object sender, EventArgs e)
        {

        }

        private void textBox_fName_TextChanged(object sender, EventArgs e)
        {

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
