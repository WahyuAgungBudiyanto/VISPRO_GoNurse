using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GoNurse
{
    public partial class Welcome : Form
    {
        public Welcome()
        {
            InitializeComponent();
        }
        private void Welcome_Load(object sender, EventArgs e)
        {

        }
        Login form_login = new Login();
        RegisterUser form_registerUser = new RegisterUser();
        RegisterNurse form_registerNurse = new RegisterNurse();
        private void label_btnSignIn_Click(object sender, EventArgs e)
        {
            this.Hide();
            form_login.Show();
            form_registerNurse.Hide();
            form_registerUser.Hide();

        }
        private void btn_member_Click(object sender, EventArgs e)
        {
            this.Hide();
            form_registerUser.Show();
            form_registerNurse.Hide();
            form_login.Hide();
        }

        private void btn_nurse_Click(object sender, EventArgs e)
        {
            this.Hide();
            form_registerNurse.Show();
            form_registerUser.Hide();
            form_login.Hide();
        }
        private void btn_exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        Form formbackground = new Form();
        private void label_btnAbout_Click(object sender, EventArgs e)
        {
            About form_about = new About();
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

                form_about.Owner = formbackground;
                form_about.ShowDialog();
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
    }
}
