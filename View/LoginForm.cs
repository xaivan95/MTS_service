using MaterialSkin2DotNet;
using MaterialSkin2DotNet.Controls;
using MTS_service.Control;
using MTS_service.View;

namespace MTS_service
{
    public partial class LoginForm : MaterialForm
    {
        MTS_service.Model.ApplicationContext db;
        public LoginForm()
        {
            InitializeComponent();
            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.Red300, Primary.Red900, Primary.Red500, Accent.Red200, TextShade.WHITE);
        }

        private void materialRaisedButton1_Click(object sender, EventArgs e)
        {
            var emp = Authorization.Authorizations(Login.Text, Password.Text);
            if (emp != null)
            {
                db = new MTS_service.Model.ApplicationContext();
                if (emp.User_category == 1) { var adm = new AdminForm(emp, db); adm.Show(); }
                if (emp.User_category == 2) { var adm = new UserForm(emp, db); adm.Show(); }

                this.Hide();
            }
            else
                ErrorLabel.Visible = true;
            ErrorLabel.ForeColor = Color.Red;
            Login.Text = "¬ведите логин";
            Password.Text = "¬ведите пароль";
        }

        private void Login_Click(object sender, EventArgs e)
        {
            if (Login.Text.Equals("¬ведите логин")) Login.Text = "";
        }

        private void Password_Click(object sender, EventArgs e)
        {
            if (Password.Text.Equals("¬ведите пароль")) Password.Text = "";
        }

        private void LoginForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}