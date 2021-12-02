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
    public partial class RegisterNurse : Form
    {
        public RegisterNurse()
        {
            InitializeComponent();
        }

        private void Register_Load(object sender, EventArgs e)
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

        
        private void btn_next_Click(object sender, EventArgs e)
        {
            
           

            Regex regex = new Regex(@"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$");
            bool isValid = regex.IsMatch(textBox_email.Text.Trim());
            if (textBox_fullName.Text == "" || textBox_email.Text == "" || textBox_username.Text == "" || textBox_password.Text == "" || textBox_no.Text == "" || comboBox_gender.Text == "")
            {
                MessageBox.Show("Please fill all the fields", "Registration Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btn_back_Click(sender, e);
            }
            else if (!isValid)
            {
                MessageBox.Show("Please fill the email correctly (Ex. demo@mail.com)", "Registration Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btn_back_Click(sender, e);
            }
            else
            {
                panel_main.Visible = false;
                btn_next.Visible = false;
                label_btnSignIn.Visible = false;
                bunifuLabel4.Visible = false;
                bunifuSeparator1.Visible = false;

                panel_1.Visible = true;
                btn_finish.Visible = true;
                btn_back.Visible = true;
            }

        }
        private void btn_finish_Click(object sender, EventArgs e)
        {
            if (textBox_address.Text == "" || textBox_college.Text == "" || textBox_desc.Text == "")
            {
                MessageBox.Show("Please fill all the fields", "Registration Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            else if (checkBox.Checked != true)
            {
                MessageBox.Show("Please check the Privacy Policy!");
            }
            else
            {
                try
                {
                    //connection 
                    string myConnection = "datasource=localhost;port=3306;username=root;password=";
                    string Query = "insert into gonurse.db_nurses (full_name,email,username,password,balance,gender,age,no_telp,alamat,pendidikan,nurse_desc,isApprove) values('" + this.textBox_fullName.Text + "','" + this.textBox_email.Text + "','" + this.textBox_username.Text + "','" + Encrypt(this.textBox_password.Text) + "','" + '0' + "','" + this.comboBox_gender.Text + "','" + this.numeric_age.Value + "','" + this.textBox_no.Text + "','" + this.textBox_address.Text + "','" + this.textBox_college.Text + "','" + this.textBox_desc.Text + "','" + '0' + "');";

                    MySqlConnection myConn = new MySqlConnection(myConnection);
                    MySqlCommand cmdDatabase = new MySqlCommand(Query, myConn);
                    MySqlDataReader myReader;
                    myConn.Open();
                    myReader = cmdDatabase.ExecuteReader();
                    MessageBox.Show("Your Nurse Account has been Successfully Created", "Registration Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    clearData();
                    btn_back_Click(sender, e);
                    this.Hide();
                    isApproved form_approve = new isApproved();
                    Form formbackground = new Form();
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

                        form_approve.Owner = formbackground;
                        form_approve.ShowDialog();
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
            comboBox_gender.Text = "";
            numeric_age.Value = 20;
            textBox_no.Text = "";
            textBox_address.Text = "";
            textBox_college.Text = "";
            textBox_desc.Text = "";
            checkBox.Checked = false;
        }

        private void btn_back_Click(object sender, EventArgs e)
        {
            panel_main.Visible = true;
            btn_next.Visible = true;
            label_btnSignIn.Visible = true;
            bunifuLabel4.Visible = true;

            panel_1.Visible = false;
            btn_finish.Visible = false;
            btn_back.Visible = false;
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
            //Numbers only
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
               (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void bunifuLabel1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void bunifuLabel4_Click(object sender, EventArgs e)
        {

        }

        private void panel_main_Click(object sender, EventArgs e)
        {

        }

        private void textBox_password_TextChanged(object sender, EventArgs e)
        {

        }

        private void label_password_Click(object sender, EventArgs e)
        {

        }

        private void textBox_username_TextChanged(object sender, EventArgs e)
        {

        }

        private void label_username_Click(object sender, EventArgs e)
        {

        }

        private void bunifuTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void bunifuLabel6_Click(object sender, EventArgs e)
        {

        }

        private void bunifuLabel3_Click(object sender, EventArgs e)
        {

        }

        private void bunifuLabel2_Click(object sender, EventArgs e)
        {

        }

        private void guna2ComboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void bunifuLabel9_Click(object sender, EventArgs e)
        {

        }

        private void panel_1_Click(object sender, EventArgs e)
        {

        }

        private void bunifuLabel9_Click_1(object sender, EventArgs e)
        {

        }

        private void bunifuTextBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void bunifuLabel3_Click_1(object sender, EventArgs e)
        {

        }

        private void bunifuTextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void bunifuPictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void bunifuTextBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void btn_exit_Click(object sender, EventArgs e)
        {

        }

        private void textBox_email_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void bunifuIconButton1_Click(object sender, EventArgs e)
        {
            Welcome form_welcome = new Welcome();
            this.Hide();
            form_welcome.Show();
        }

        private void textBox_college_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox_password_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void textBox_email_TextChanged(object sender, EventArgs e)
        {

        }

        
    }
}
