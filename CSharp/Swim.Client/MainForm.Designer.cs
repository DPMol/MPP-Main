using System.ComponentModel;

namespace SwimmingClient
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }

            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new Container();
            nameTB = new TextBox();
            addButton = new Button();
            trialsGridView = new DataGridView();
            distanceColumn = new DataGridViewTextBoxColumn();
            styleColumn = new DataGridViewTextBoxColumn();
            participantGridView = new DataGridView();
            label4 = new Label();
            ageTB = new TextBox();
            label5 = new Label();
            trialsAddGridView = new DataGridView();
            trialBindingSource = new BindingSource(components);
            trialBindingSource1 = new BindingSource(components);
            participantBindingSource = new BindingSource(components);
            distanceAddColumn = new DataGridViewTextBoxColumn();
            styleAddColumn = new DataGridViewTextBoxColumn();
            nameColumn = new DataGridViewTextBoxColumn();
            ageColumn = new DataGridViewTextBoxColumn();
            ((ISupportInitialize)trialsGridView).BeginInit();
            ((ISupportInitialize)participantGridView).BeginInit();
            ((ISupportInitialize)trialsAddGridView).BeginInit();
            ((ISupportInitialize)trialBindingSource).BeginInit();
            ((ISupportInitialize)trialBindingSource1).BeginInit();
            ((ISupportInitialize)participantBindingSource).BeginInit();
            SuspendLayout();
            // 
            // nameTB
            // 
            nameTB.Location = new Point(12, 397);
            nameTB.Name = "nameTB";
            nameTB.Size = new Size(365, 23);
            nameTB.TabIndex = 1;
            nameTB.TextChanged += nameTB_TextChanged;
            // 
            // addButton
            // 
            addButton.Location = new Point(157, 520);
            addButton.Name = "addButton";
            addButton.Size = new Size(66, 27);
            addButton.TabIndex = 9;
            addButton.Text = "Add";
            addButton.UseVisualStyleBackColor = true;
            addButton.Click += addButton_Click;
            // 
            // trialsGridView
            // 
            trialsGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            trialsGridView.Columns.AddRange(new DataGridViewColumn[] { distanceColumn, styleColumn });
            trialsGridView.Location = new Point(12, 12);
            trialsGridView.Name = "trialsGridView";
            trialsGridView.RowHeadersWidth = 62;
            trialsGridView.RowTemplate.Height = 24;
            trialsGridView.Size = new Size(365, 340);
            trialsGridView.TabIndex = 10;
            trialsGridView.CellClick += trialsGridView_CellClick;
            // 
            // distanceColumn
            // 
            distanceColumn.DataPropertyName = "distance";
            distanceColumn.HeaderText = "Distance";
            distanceColumn.MinimumWidth = 8;
            distanceColumn.Name = "distanceColumn";
            distanceColumn.Width = 150;
            // 
            // styleColumn
            // 
            styleColumn.DataPropertyName = "style";
            styleColumn.HeaderText = "Style";
            styleColumn.MinimumWidth = 8;
            styleColumn.Name = "styleColumn";
            styleColumn.Width = 150;
            // 
            // participantGridView
            // 
            participantGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            participantGridView.Columns.AddRange(new DataGridViewColumn[] { nameColumn, ageColumn });
            participantGridView.Location = new Point(383, 12);
            participantGridView.Name = "participantGridView";
            participantGridView.RowHeadersWidth = 62;
            participantGridView.RowTemplate.Height = 24;
            participantGridView.Size = new Size(364, 340);
            participantGridView.TabIndex = 15;
            // 
            // label4
            // 
            label4.Location = new Point(12, 372);
            label4.Name = "label4";
            label4.Size = new Size(43, 22);
            label4.TabIndex = 17;
            label4.Text = "Name";
            // 
            // ageTB
            // 
            ageTB.Location = new Point(12, 448);
            ageTB.Name = "ageTB";
            ageTB.Size = new Size(364, 23);
            ageTB.TabIndex = 2;
            // 
            // label5
            // 
            label5.Location = new Point(12, 423);
            label5.Name = "label5";
            label5.Size = new Size(48, 22);
            label5.TabIndex = 18;
            label5.Text = "Age";
            // 
            // trialsAddGridView
            // 
            trialsAddGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            trialsAddGridView.Columns.AddRange(new DataGridViewColumn[] { distanceAddColumn, styleAddColumn });
            trialsAddGridView.Location = new Point(382, 372);
            trialsAddGridView.Name = "trialsAddGridView";
            trialsAddGridView.RowHeadersWidth = 62;
            trialsAddGridView.RowTemplate.Height = 24;
            trialsAddGridView.Size = new Size(365, 226);
            trialsAddGridView.TabIndex = 19;
            // 
            // trialBindingSource
            // 
            trialBindingSource.DataSource = typeof(Swim.Domain.Models.TrialModels.Trial);
            // 
            // trialBindingSource1
            // 
            trialBindingSource1.DataSource = typeof(Swim.Domain.Models.TrialModels.Trial);
            // 
            // participantBindingSource
            // 
            participantBindingSource.DataSource = typeof(Swim.Domain.Models.ParticipantModels.Participant);
            // 
            // distanceAddColumn
            // 
            distanceAddColumn.DataPropertyName = "distance";
            distanceAddColumn.HeaderText = "Distance";
            distanceAddColumn.MinimumWidth = 8;
            distanceAddColumn.Name = "distanceAddColumn";
            distanceAddColumn.Width = 150;
            // 
            // styleAddColumn
            // 
            styleAddColumn.DataPropertyName = "style";
            styleAddColumn.HeaderText = "Style";
            styleAddColumn.MinimumWidth = 8;
            styleAddColumn.Name = "styleAddColumn";
            styleAddColumn.Width = 150;
            // 
            // nameColumn
            // 
            nameColumn.DataPropertyName = "name";
            nameColumn.HeaderText = "Name";
            nameColumn.MinimumWidth = 8;
            nameColumn.Name = "nameColumn";
            nameColumn.Width = 150;
            // 
            // ageColumn
            // 
            ageColumn.DataPropertyName = "age";
            ageColumn.HeaderText = "Age";
            ageColumn.MinimumWidth = 8;
            ageColumn.Name = "ageColumn";
            ageColumn.Width = 150;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Control;
            ClientSize = new Size(759, 622);
            Controls.Add(trialsAddGridView);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(participantGridView);
            Controls.Add(trialsGridView);
            Controls.Add(addButton);
            Controls.Add(ageTB);
            Controls.Add(nameTB);
            Location = new Point(15, 15);
            Name = "MainForm";
            Load += MainForm_Load;
            ((ISupportInitialize)trialsGridView).EndInit();
            ((ISupportInitialize)participantGridView).EndInit();
            ((ISupportInitialize)trialsAddGridView).EndInit();
            ((ISupportInitialize)trialBindingSource).EndInit();
            ((ISupportInitialize)trialBindingSource1).EndInit();
            ((ISupportInitialize)participantBindingSource).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        private System.Windows.Forms.Label label11;

        private System.Windows.Forms.Label label10;

        private System.Windows.Forms.Label label9;

        private System.Windows.Forms.Label label8;

        private System.Windows.Forms.Label label5;

        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridView participantGridView;

        private System.Windows.Forms.DataGridView trialsGridView;

        private System.Windows.Forms.Button addButton;

        private System.Windows.Forms.DateTimePicker birthDatePicker;
        private System.Windows.Forms.TextBox countryTB;
        private System.Windows.Forms.TextBox streetTB;
        private System.Windows.Forms.TextBox raceIdsTB;

        private System.Windows.Forms.TextBox nameTB;
        private System.Windows.Forms.TextBox ageTB;

        #endregion
        private DataGridView trialsAddGridView;
        private DataGridViewTextBoxColumn distanceColumn;
        private DataGridViewTextBoxColumn styleColumn;
        private BindingSource trialBindingSource;
        private BindingSource trialBindingSource1;
        private BindingSource participantBindingSource;
        private DataGridViewTextBoxColumn nameColumn;
        private DataGridViewTextBoxColumn ageColumn;
        private DataGridViewTextBoxColumn distanceAddColumn;
        private DataGridViewTextBoxColumn styleAddColumn;
    }
}