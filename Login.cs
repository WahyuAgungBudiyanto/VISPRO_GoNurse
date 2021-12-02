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

namespace GoNurse
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void Login_Load(object sender, EventArgs e)
        {
            comboBox_role.Text = "-- Please Select Role --";
        }
        private void label_btnWelcome_Click(object sender, EventArgs e)
        {
            Welcome form_welcome = new Welcome();
            this.Hide();
            form_welcome.Show();
        }
        private void label_btnForgot_Click(object sender, EventArgs e)
        {
            ForgotPassword form_forgot = new ForgotPassword();
            this.Hide();
            form_forgot.Show();
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
       private void fetchFullNameCustomers()
        {
            //connection 
            string myConnection = "datasource=localhost;port=3306;username=root;Convert Zero Datetime=True;password=";
            MySqlConnection myConn = new MySqlConnection(myConnection);
            MySqlCommand cmdDatabase = new MySqlCommand("SELECT * from gonurse.db_customers WHERE username='" + this.textBox_username.Text + "'", myConn);
            try
            {
                MySqlDataAdapter sda = new MySqlDataAdapter();
                sda.SelectCommand = cmdDatabase;
                DataTable dbdataset = new DataTable();
                sda.Fill(dbdataset);
                BindingSource bSource = new BindingSource();
                foreach (DataRow row in dbdataset.Rows)
                {
                    global.customer_fullname = row["full_name"].ToString();
                    global.customer_id = Convert.ToInt32(row["id_user"]);
                }
                bSource.DataSource = dbdataset;
                sda.Update(dbdataset);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void fetchFullNameNurses()
        {
            //connection 
            string myConnection = "datasource=localhost;port=3306;username=root;Convert Zero Datetime=True;password=";
            MySqlConnection myConn = new MySqlConnection(myConnection);
            MySqlCommand cmdDatabase = new MySqlCommand("SELECT * from gonurse.db_nurses WHERE username='" + this.textBox_username.Text + "'", myConn);
            try
            {
                MySqlDataAdapter sda = new MySqlDataAdapter();
                sda.SelectCommand = cmdDatabase;
                DataTable dbdataset = new DataTable();
                sda.Fill(dbdataset);
                BindingSource bSource = new BindingSource();
                foreach (DataRow row in dbdataset.Rows)
                {
                    global.nurse_fullname = row["full_name"].ToString();
                    global.nurse_username = row["username"].ToString();
                    global.nurse_id = Convert.ToInt32(row["id_nurse"]);
                    global.nurse_balance = Convert.ToInt32(row["balance"]);
                }
                bSource.DataSource = dbdataset;
                sda.Update(dbdataset);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void fecthAdmin()
        {
            //connection 
            string myConnection = "datasource=localhost;port=3306;username=root;Convert Zero Datetime=True;password=";
            MySqlConnection myConn = new MySqlConnection(myConnection);
            MySqlCommand cmdDatabase = new MySqlCommand("SELECT * from gonurse.db_admin WHERE username='" + this.textBox_username.Text + "'", myConn);
            try
            {
                MySqlDataAdapter sda = new MySqlDataAdapter();
                sda.SelectCommand = cmdDatabase;
                DataTable dbdataset = new DataTable();
                sda.Fill(dbdataset);
                BindingSource bSource = new BindingSource();
                foreach (DataRow row in dbdataset.Rows)
                {
                    global.admin_id = Convert.ToInt32(row["id_admin"]);
                    global.admin_name = row["full_name"].ToString();
                }
                bSource.DataSource = dbdataset;
                sda.Update(dbdataset);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        private void btn_login_Click(object sender, EventArgs e)
        {
            if(comboBox_role.Text == "-- Please Select Role --")
            {
                MessageBox.Show("Please select the correct role!", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if(comboBox_role.Text == "Member")
            {
                try
                {
                    //connection 
                    string myConnection = "datasource=localhost;port=3306;username=root;password=";
                    MySqlConnection myConn = new MySqlConnection(myConnection);

                    MySqlCommand SelectCommand = new MySqlCommand("select * from gonurse.db_customers where username= '" + this.textBox_username.Text + "' and password='" + Encrypt(this.textBox_password.Text) + "' ;", myConn);
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
                        fetchFullNameCustomers();
   ;                          Customers.DashboardCustomer dash = new Customers.DashboardCustomer();
                            dash.Show();
                            this.Hide();
                       
                        
                    }
                    else if (textBox_username.Text == "" || textBox_password.Text == "")
                    {
                        MessageBox.Show("Username or Password fields are empty", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        MessageBox.Show("Username or Password are invalid, please try again", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        textBox_username.Text = "";
                        textBox_password.Text = "";
                        textBox_username.Focus();
                    }
                    
                   
                        myConn.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }else if (comboBox_role.Text == "Nurse")
            {
                try
                {
                    //connection 
                    string myConnection = "datasource=localhost;port=3306;username=root;password=";
                MySqlConnection myConn = new MySqlConnection(myConnection);

                MySqlCommand SelectCommand = new MySqlCommand("select * from gonurse.db_nurses where username= '" + this.textBox_username.Text + "' and password='" + Encrypt(this.textBox_password.Text) + "' ;", myConn);
                MySqlDataReader myReader;
                myConn.Open();

                myReader = SelectCommand.ExecuteReader();
                int count = 0;
                string isApprove = string.Empty;

                while (myReader.Read())
                {
                    isApprove = $"{myReader.GetString("isApprove")}";
                    count = count + 1;

                }
                if (count == 1)
                {
                    if(isApprove == "1")
                    {
                            fetchFullNameNurses();
                        Nurses.DashboardNurse form_dash = new Nurses.DashboardNurse();
                        form_dash.Show();
                        this.Hide();
                        }
                        else
                        {
                            Form formbackground = new Form();
                            isApproved form_approve = new isApproved();
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
                                this.Hide();
                            }
                        }


                    }
                else if (textBox_username.Text == "" || textBox_password.Text == "")
                {
                    MessageBox.Show("Username or Password fields are empty", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }else if(Encrypt(this.textBox_password.Text) != textBox_password.Text)
                {
                    MessageBox.Show("Username or Password are invalid, please try again", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBox_username.Text = "";
                    textBox_password.Text = "";
                    textBox_username.Focus();
                }
                

                myConn.Close();
                }
                    catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else if (comboBox_role.Text == "Admin")
            {
                try
                {
                    //connection 
                    string myConnection = "datasource=localhost;port=3306;username=root;password=";
                    MySqlConnection myConn = new MySqlConnection(myConnection);

                    MySqlCommand SelectCommand = new MySqlCommand("select * from gonurse.db_admin where username= '" + this.textBox_username.Text + "' and password='" + this.textBox_password.Text + "' ;", myConn);
                    MySqlDataReader myReader;
                    myConn.Open();

                    myReader = SelectCommand.ExecuteReader();
                    int count = 0;

                    while (myReader.Read())
                    {
                        count = count + 1;

                    }
                    if (count == 1)
                    {
                        fecthAdmin();
                        DashboardAdmin dash = new DashboardAdmin();
                        dash.Show();
                        this.Hide();


                    }
                    else if (textBox_username.Text == "" || textBox_password.Text == "")
                    {
                        MessageBox.Show("Username or Password fields are empty", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        MessageBox.Show("Username or Password are invalid, please try again", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        textBox_username.Text = "";
                        textBox_password.Text = "";
                        textBox_username.Focus();
                    }

                    myConn.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void bunifuLabel2_Click(object sender, EventArgs e)
        {

        }

        private void bunifuLabel1_Click(object sender, EventArgs e)
        {

        }

        private void textBox_password_TextChanged(object sender, EventArgs e)
        {

        }
       

        }
}
