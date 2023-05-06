using Swim.Client;
using Swim.Domain.Models.UserModels;
using SwimmingClient;

namespace chat.client
{
    public partial class LoginWindow : Form
    {
        private ClientController controller;
        public LoginWindow(ClientController clientController)
        {
            InitializeComponent();
            controller = clientController;
        }

        private void clearBut_Click(object sender, EventArgs e)
        {
            userText.Clear();
            passText.Clear();
        }

        private void loginBut_Click(object sender, EventArgs e)
        {
            String user = userText.Text;
            String pass = passText.Text;
            try
            {
                controller.Login(userText.Text, passText.Text);
                //MessageBox.Show("Login succeded");
                MainForm chatWin = new MainForm(controller, new User());
                chatWin.Text = "Chat window for " + user;
                chatWin.Show();
                this.Hide();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, "Login Error " + ex.Message/*+ex.StackTrace*/, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void LoginWindow_Load(object sender, EventArgs e)
        {

        }
    }
}
