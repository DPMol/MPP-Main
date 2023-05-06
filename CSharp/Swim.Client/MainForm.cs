using Swim.Client;
using Swim.Domain.Models.UserModels;

namespace SwimmingClient
{

    public partial class MainForm : Form
    {
        private ClientController Controller;
        private User user;

        public MainForm(ClientController controller, User user)
        {
            this.Controller = controller;
            this.user = user;
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            racesGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            racesGridView.MultiSelect = false;
            contestantsGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            contestantsGridView.MultiSelect = false;
            LoadTrials();
        }

        public void LoadTrials()
        {

        }

        private void logOutButton_Click(object sender, EventArgs e)
        {
            try
            {
                Controller.logout();
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        private void addButton_Click(object sender, EventArgs e)
        {
            string name = nameTB.Text;
            DateTime bithDate = birthDatePicker.Value;
            string email = ageTB.Text;
            string country = countryTB.Text;
            string street = streetTB.Text;
            string ids = raceIdsTB.Text;
            IList<int> idList = new List<int>();
            var stringIds = ids.Split(',');
            try
            {
                foreach (var stringId in stringIds)
                {
                    int id = int.Parse(stringId);
                    idList.Add(id);
                }
                //Controller.AddContestant(name, bithDate, email, country, city, street, postalCode, idList);
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        private void nameTB_TextChanged(object sender, EventArgs e)
        {

        }

        public delegate void UpdateContent();
    }
}