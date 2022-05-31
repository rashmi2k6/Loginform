using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LoginForm
{
    public partial class LoginForm : Form
    {
        Login_Class Obj_data = new Login_Class();

        public LoginForm()
        {
            InitializeComponent();
            LoadCaptcha();
        }
        int clickcounter = 1;
        int number = 0;

        private void btn_Register_Click(object sender, EventArgs e)
        {
            this.Hide();
            var RegForm_Obj = new RegForm();
            RegForm_Obj.Closed += (s, args) => this.Close();
            RegForm_Obj.Show();

        }

        private void btn_Exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btn_Login_Click(object sender, EventArgs e)
        {
            captchcheck();

            string message = Obj_data.Login(txt_UserName.Text, txt_Password.Text);
            if (message == "User Login Successfully")
            {
                MessageBox.Show(message);
                this.Hide();
                var DashboardForm_Obj = new DashboardForm();
                DashboardForm_Obj.Closed += (s, args) => this.Close();
                DashboardForm_Obj.Show();
            }
            else
            {
                MessageBox.Show(message);
            }

        }

        private void LoadCaptcha()
        {

            Random refresh = new Random();
            number = refresh.Next(5, 6);
            int capnum = 0;
            string captcha = "";

            do
            {

                int chr = refresh.Next(48, 123);
                if ((chr >= 48 && chr <= 57) || (chr >= 97 && chr <= 123) || (chr >= 65 && chr <= 90))
                {
                    captcha = captcha + (char)chr;
                    capnum++;
                    if (capnum == number)
                        break;

                }
            }
            while (true);
            lbl.Text = captcha.ToString();

        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            LoadCaptcha();
        }

        private void captchcheck()

        {
            if (txt_captcha.Text != lbl.Text.ToString())
            {
                MessageBox.Show("Please enter the CAPTCHA correctly.");
                txt_captcha.BackColor = Color.OrangeRed;
                txt_captcha.Focus();
            }
            else
            {
                MessageBox.Show(" CAPTCHA meets correctly.");
                //Login sign_in = new Login(textBox1.Text, textBox2.Text, textBox3.Text);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            LoadCaptcha();
        }

    }

}
