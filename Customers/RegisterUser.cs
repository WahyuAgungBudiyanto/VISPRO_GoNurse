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
using System.Text.RegularExpressions;
using System.Globalization;
using System.Security.Cryptography;

namespace GoNurse
{
    public partial class RegisterUser : Form
    {
        public RegisterUser()
        {
            InitializeComponent();
        }

        private void RegisterUser_Load(object sender, EventArgs e)
        {

        }


        Login form_login = new Login();
        private void label_btnSignIn_Click(object sender, EventArgs e)
        {
            form_login.Show();
            this.Hide();
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
        private void btn_register_Click(object sender, EventArgs e)
        {
            Regex regex = new Regex(@"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$");
            bool isValid = regex.IsMatch(textBox_email.Text.Trim());
            
            if (textBox_fullName.Text == "" || textBox_email.Text == "" || textBox_username.Text == "" || textBox_password.Text == "" || textBox_no.Text == "")
            {
                MessageBox.Show("Please fill all the fields", "Registration Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }else if (!isValid)
            {
                MessageBox.Show("Please fill the email correctly (Ex. demo@mail.com)", "Registration Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if(checkBox.Checked != true)
            {
                MessageBox.Show("Please check the Privacy Policy!");
            }
            else
            {
                try
                {
                    //connection 
                    string myConnection = "datasource=localhost;port=3306;username=root;password=";
                    string Query = "insert into gonurse.db_customers (id_user,full_name,email,username,password,no_telp) values('','" + this.textBox_fullName.Text + "','" + this.textBox_email.Text + "','" + this.textBox_username.Text + "','" + Encrypt(this.textBox_password.Text) + "','"  + this.textBox_no.Text + "'); ";
                    MySqlConnection myConn = new MySqlConnection(myConnection);
                    MySqlCommand cmdDatabase = new MySqlCommand(Query, myConn);
                    MySqlDataReader myReader;
                    myConn.Open();
                    myReader = cmdDatabase.ExecuteReader();
                    MessageBox.Show("Your Member Account has been Successfully Created", "Registration Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    clearData();
                }
                catch (Exception ex)
                {
                    /*MessageBox.Show(ex.Message);*/
                    MessageBox.Show("Your username or email has been taken.", "Registration Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void clearData()
        {
            textBox_fullName.Text = "";
            textBox_email.Text = "";
            textBox_username.Text = "";
            textBox_password.Text = "";
            textBox_no.Text = "";
            checkBox.Checked = false;
        }

        private void textBox_fullName_KeyPress(object sender, KeyPressEventArgs e)
        {
            //No Numbers Allowed
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar))
            {
                e.Handled = true;
                base.OnKeyPress(e);
            }
        }

        private void textBox_username_KeyPress(object sender, KeyPressEventArgs e)
        {
            //No Space Allowed
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
                base.OnKeyPress(e);
            }
        }

        private void textBox_password_KeyPress(object sender, KeyPressEventArgs e)
        {
            //No Space Allowed
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
                base.OnKeyPress(e);
            }
        }

        private void textBox_no_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Numbers Only
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
             (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }
        private void textBox_email_KeyPress(object sender, KeyPressEventArgs e)
        {
           
        }
        private void bunifuTextBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void btn_back_Click(object sender, EventArgs e)
        {
            
            Welcome form_welcome = new Welcome();
            this.Hide();
            form_welcome.Show();
        }

        private void bunifuLabel12_Click(object sender, EventArgs e)
        {

        }
    }
}
