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
using System.Security.Cryptography;
using System.Text.RegularExpressions;
namespace GoNurse
{
    public partial class ForgotPassword : Form
    {
        public ForgotPassword()
        {
            InitializeComponent();
        }

        Login form_login = new Login();
        private void btn_back_Click(object sender, EventArgs e)
        {
            
            form_login.Show();
            this.Hide();
        }

        private void btn_login_Click(object sender, EventArgs e)
        {
            Regex regex = new Regex(@"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$");
            bool isValid = regex.IsMatch(textBox_email.Text.Trim());
            if (textBox_email.Text == "")
            {
                MessageBox.Show("Please fill the email fields", "ForgotPassword Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            else if (!isValid)
            {
                MessageBox.Show("Please fill the email correctly (Ex. demo@mail.com)", "ForgotPassword Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox_email.Text = "";
            }
            else if (comboBox_role.Text == "-- Please Select Role --")
            {
                MessageBox.Show("Please select the correct role!", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (comboBox_role.Text == "Member")
            {
                //connection 
                string myConnection = "datasource=localhost;port=3306;username=root;password=";
                MySqlConnection myConn = new MySqlConnection(myConnection);

                MySqlCommand SelectCommand = new MySqlCommand("select * from gonurse.db_customers where email= '" + this.textBox_email.Text + "';", myConn);
                MySqlDataReader myReader;
                myConn.Open();

                myReader = SelectCommand.ExecuteReader();
                int count = 0;
                DataTable dt = new DataTable();

                while (myReader.Read())
                {
                    count = count + 1;

                }
                if (count == 1)
                {

                    panel.Visible = true;
                }

                else
                {
                    MessageBox.Show("Email invalid, please try again", "Change Password Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
                myConn.Close();
            }
            else if (comboBox_role.Text == "Nurse")
            {
                //connection 
                string myConnection = "datasource=localhost;port=3306;username=root;password=";
                MySqlConnection myConn = new MySqlConnection(myConnection);

                MySqlCommand SelectCommand = new MySqlCommand("select * from gonurse.db_nurses where email= '" + this.textBox_email.Text + "';", myConn);
                MySqlDataReader myReader;
                myConn.Open();

                myReader = SelectCommand.ExecuteReader();
                int count = 0;
                DataTable dt = new DataTable();

                while (myReader.Read())
                {
                    count = count + 1;

                }
                if (count == 1)
                {

                    panel.Visible = true;
                }

                else
                {
                    MessageBox.Show("Email invalid, please try again", "Change Password Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
                myConn.Close();
            }
            else if (comboBox_role.Text == "Admin")
            {
                //connection 
                string myConnection = "datasource=localhost;port=3306;username=root;password=";
                MySqlConnection myConn = new MySqlConnection(myConnection);

                MySqlCommand SelectCommand = new MySqlCommand("select * from gonurse.db_admin where email= '" + this.textBox_email.Text + "';", myConn);
                MySqlDataReader myReader;
                myConn.Open();

                myReader = SelectCommand.ExecuteReader();
                int count = 0;
                DataTable dt = new DataTable();

                while (myReader.Read())
                {
                    count = count + 1;

                }
                if (count == 1)
                {

                    panel.Visible = true;
                }

                else
                {
                    MessageBox.Show("Email invalid, please try again", "Change Password Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
                myConn.Close();
            }

        }
        static string key { get; set; } = "A!9HHhi%XjjYY4YP2@Nob009X";
        public static string Encrypt(string text)
        {
            using (var md5 = new MD5CryptoServiceProvider())
            {
                using (var tdes = new TripleDESCryptoServiceProvider())
                {
                    tdes.Key = md5.ComputeHash(UTF8Encoding.UTF8.GetBytes(key));
                    tdes.Mode = CipherMode.ECB;
                    tdes.Padding = PaddingMode.PKCS7;

                    using (var transform = tdes.CreateEncryptor())
                    {
                        byte[] textBytes = UTF8Encoding.UTF8.GetBytes(text);
                        byte[] bytes = transform.TransformFinalBlock(textBytes, 0, textBytes.Length);
                        return Convert.ToBase64String(bytes, 0, bytes.Length);
                    }
                }
            }
        }
        private void bunifuButton21_Click(object sender, EventArgs e)
        {
            if (comboBox_role.Text == "Member")
            {
                //connection 
                string myConnection = "datasource=localhost;port=3306;username=root;password=";
                string Query = "UPDATE gonurse.db_customers SET password= '" + Encrypt(new1.Text) + "'WHERE email='" + textBox_email.Text + "';";
                MySqlConnection myConn = new MySqlConnection(myConnection);
                MySqlCommand cmdDatabase = new MySqlCommand(Query, myConn);
                MySqlDataReader myReader;
                try
                {
                    myConn.Open();
                    myReader = cmdDatabase.ExecuteReader();
                    MessageBox.Show("Congratulations, you have changed your password!");
                    form_login.Show();
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
            else if (comboBox_role.Text == "Nurse")
            {
                //connection 
                string myConnection = "datasource=localhost;port=3306;username=root;password=";
                string Query = "UPDATE gonurse.db_nurses SET password= '" + Encrypt(new1.Text) + "'WHERE email='" + textBox_email.Text + "';";
                MySqlConnection myConn = new MySqlConnection(myConnection);
                MySqlCommand cmdDatabase = new MySqlCommand(Query, myConn);
                MySqlDataReader myReader;
                try
                {
                    myConn.Open();
                    myReader = cmdDatabase.ExecuteReader();
                    MessageBox.Show("Congratulations, you have changed your password!");
                    form_login.Show();
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
            if (comboBox_role.Text == "Asmin")
            {
                //connection 
                string myConnection = "datasource=localhost;port=3306;username=root;password=";
                string Query = "UPDATE gonurse.db_admin SET password= '" + Encrypt(new1.Text) + "'WHERE email='" + textBox_email.Text + "';";
                MySqlConnection myConn = new MySqlConnection(myConnection);
                MySqlCommand cmdDatabase = new MySqlCommand(Query, myConn);
                MySqlDataReader myReader;
                try
                {
                    myConn.Open();
                    myReader = cmdDatabase.ExecuteReader();
                    MessageBox.Show("Congratulations, you have changed your password!");
                    form_login.Show();
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

        private void new1_KeyPress(object sender, KeyPressEventArgs e)
        {
            //No Space Allowed
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
                base.OnKeyPress(e);
            }
        }

        private void comboBox_role_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void ForgotPassword_Load(object sender, EventArgs e)
        {
            comboBox_role.Text = "-- Please Select Role --";
        }
    }
}
