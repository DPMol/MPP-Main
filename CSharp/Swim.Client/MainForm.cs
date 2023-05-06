using Swim.Client;
using Swim.Domain.Models.ParticipantModels;
using Swim.Domain.Models.TrialModels;
using Swim.Domain.Models.UserModels;

namespace SwimmingClient
{

    public partial class MainForm : Form
    {
        private ClientController controller;
        private User user;

        public MainForm(ClientController controller, User user)
        {
            this.controller = controller;
            this.user = user;
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            trialsGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            trialsGridView.MultiSelect = false;
            trialsAddGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            trialsAddGridView.MultiSelect = true;
            participantGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            participantGridView.MultiSelect = false;
            LoadTrials();
        }

        public void LoadTrials()
        {
            trialsGridView.DataSource = null;
            trialsGridView.Rows.Clear();
            trialsAddGridView.DataSource = null;
            trialsAddGridView.Rows.Clear();

            var trials = controller.GetTrials();
            trialsGridView.DataSource = trials;
            trialsAddGridView.DataSource = new List<Trial>(trials);
        }

        public void LoadParticipants()
        {
            participantGridView.DataSource = null;
            participantGridView.Rows.Clear();

            if (trialsGridView.CurrentRow == null)
            {
                return;
            }

            var trial = trialsGridView.CurrentRow.DataBoundItem as Trial;

            var participants = controller.GetParticipants(trial);

            participantGridView.DataSource = participants;
        }

        private void logOutButton_Click(object sender, EventArgs e)
        {
            try
            {
                controller.logout();
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        private void addButton_Click(object sender, EventArgs e)
        {
            try
            {
                var trials = new List<Trial>();
                foreach(DataGridViewRow row in trialsAddGridView.SelectedRows) {
                    trials.Add(row.DataBoundItem as Trial);
                }
                var name = nameTB.Text;
                var age = int.Parse(ageTB.Text);

                controller.AddParticipant(
                    new Participant()
                    {
                        Name = name,
                        Age = age,
                        Trials = trials
                    }
                    );
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void nameTB_TextChanged(object sender, EventArgs e)
        {

        }

        private void trialsGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            LoadParticipants();
        }

        public delegate void UpdateContent();
    }
}