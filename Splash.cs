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
    public partial class Splash : Form
    {
        public Splash()
        {
            InitializeComponent();
        }

        private void Splash_Load(object sender, EventArgs e)
        {
            timer_loading.Start();
            
        }
       
        private void timer_loading_Tick(object sender, EventArgs e)
        {
           if(bunifuCircleProgress1.Value < 100)
            {
                bunifuCircleProgress1.Value += 4;
            }
            else
            {
                timer_loading.Stop();
                Welcome form_welcome = new Welcome();
                form_welcome.Show();
                this.Hide();
            }
        }
    }
}
