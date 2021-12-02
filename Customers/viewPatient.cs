using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GoNurse.Customers
{
    public partial class viewPatient : Form
    {
        public viewPatient()
        {
            InitializeComponent();
        }

        private void btn_back_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void btn_viewNurse_Click(object sender, EventArgs e)
        {
            viewNurse form_nurse = new viewNurse();
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
    }
}
