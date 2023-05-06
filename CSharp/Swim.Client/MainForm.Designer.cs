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
            label1 = new Label();
            nameTB = new TextBox();
            addButton = new Button();
            racesGridView = new DataGridView();
            idColumn = new DataGridViewTextBoxColumn();
            distanceColumn = new DataGridViewTextBoxColumn();
            styleColumn = new DataGridViewTextBoxColumn();
            dateColumn = new DataGridViewTextBoxColumn();
            numberOfContestantsColumn = new DataGridViewTextBoxColumn();
            label2 = new Label();
            searchNameTB = new TextBox();
            searchButton = new Button();
            label3 = new Label();
            contestantsGridView = new DataGridView();
            nameColumn = new DataGridViewTextBoxColumn();
            ageColumn = new DataGridViewTextBoxColumn();
            racesColumn = new DataGridViewTextBoxColumn();
            logOutButton = new Button();
            label4 = new Label();
            ageTB = new TextBox();
            label5 = new Label();
            ((ISupportInitialize)racesGridView).BeginInit();
            ((ISupportInitialize)contestantsGridView).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.Location = new Point(420, 14);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(200, 36);
            label1.TabIndex = 0;
            label1.Text = "Add new contestant";
            // 
            // nameTB
            // 
            nameTB.Location = new Point(205, 114);
            nameTB.Margin = new Padding(4, 5, 4, 5);
            nameTB.Name = "nameTB";
            nameTB.Size = new Size(124, 31);
            nameTB.TabIndex = 1;
            nameTB.TextChanged += nameTB_TextChanged;
            // 
            // addButton
            // 
            addButton.Location = new Point(135, 245);
            addButton.Margin = new Padding(4, 5, 4, 5);
            addButton.Name = "addButton";
            addButton.Size = new Size(94, 45);
            addButton.TabIndex = 9;
            addButton.Text = "Add";
            addButton.UseVisualStyleBackColor = true;
            addButton.Click += addButton_Click;
            // 
            // racesGridView
            // 
            racesGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            racesGridView.Columns.AddRange(new DataGridViewColumn[] { idColumn, distanceColumn, styleColumn, dateColumn, numberOfContestantsColumn });
            racesGridView.Location = new Point(151, 441);
            racesGridView.Margin = new Padding(4, 5, 4, 5);
            racesGridView.Name = "racesGridView";
            racesGridView.RowHeadersWidth = 62;
            racesGridView.RowTemplate.Height = 24;
            racesGridView.Size = new Size(748, 234);
            racesGridView.TabIndex = 10;
            // 
            // idColumn
            // 
            idColumn.HeaderText = "ID";
            idColumn.MinimumWidth = 8;
            idColumn.Name = "idColumn";
            idColumn.Width = 150;
            // 
            // distanceColumn
            // 
            distanceColumn.HeaderText = "Distance";
            distanceColumn.MinimumWidth = 8;
            distanceColumn.Name = "distanceColumn";
            distanceColumn.Width = 150;
            // 
            // styleColumn
            // 
            styleColumn.HeaderText = "Style";
            styleColumn.MinimumWidth = 8;
            styleColumn.Name = "styleColumn";
            styleColumn.Width = 150;
            // 
            // dateColumn
            // 
            dateColumn.HeaderText = "Scheduled Day";
            dateColumn.MinimumWidth = 8;
            dateColumn.Name = "dateColumn";
            dateColumn.Width = 150;
            // 
            // numberOfContestantsColumn
            // 
            numberOfContestantsColumn.HeaderText = "No. Participants";
            numberOfContestantsColumn.MinimumWidth = 8;
            numberOfContestantsColumn.Name = "numberOfContestantsColumn";
            numberOfContestantsColumn.Width = 150;
            // 
            // label2
            // 
            label2.Location = new Point(438, 400);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(166, 36);
            label2.TabIndex = 11;
            label2.Text = "Available races";
            // 
            // searchNameTB
            // 
            searchNameTB.Location = new Point(390, 784);
            searchNameTB.Margin = new Padding(4, 5, 4, 5);
            searchNameTB.Name = "searchNameTB";
            searchNameTB.Size = new Size(124, 31);
            searchNameTB.TabIndex = 12;
            // 
            // searchButton
            // 
            searchButton.Location = new Point(510, 784);
            searchButton.Margin = new Padding(4, 5, 4, 5);
            searchButton.Name = "searchButton";
            searchButton.Size = new Size(94, 36);
            searchButton.TabIndex = 13;
            searchButton.Text = "Search";
            searchButton.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            label3.Location = new Point(420, 745);
            label3.Margin = new Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new Size(166, 36);
            label3.TabIndex = 14;
            label3.Text = "Search contestants";
            // 
            // contestantsGridView
            // 
            contestantsGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            contestantsGridView.Columns.AddRange(new DataGridViewColumn[] { nameColumn, ageColumn, racesColumn });
            contestantsGridView.Location = new Point(226, 861);
            contestantsGridView.Margin = new Padding(4, 5, 4, 5);
            contestantsGridView.Name = "contestantsGridView";
            contestantsGridView.RowHeadersWidth = 62;
            contestantsGridView.RowTemplate.Height = 24;
            contestantsGridView.Size = new Size(578, 234);
            contestantsGridView.TabIndex = 15;
            // 
            // nameColumn
            // 
            nameColumn.HeaderText = "Name";
            nameColumn.MinimumWidth = 8;
            nameColumn.Name = "nameColumn";
            nameColumn.Width = 150;
            // 
            // ageColumn
            // 
            ageColumn.HeaderText = "Age";
            ageColumn.MinimumWidth = 8;
            ageColumn.Name = "ageColumn";
            ageColumn.Width = 150;
            // 
            // racesColumn
            // 
            racesColumn.HeaderText = "Races";
            racesColumn.MinimumWidth = 8;
            racesColumn.Name = "racesColumn";
            racesColumn.Width = 150;
            // 
            // logOutButton
            // 
            logOutButton.Location = new Point(911, 1158);
            logOutButton.Margin = new Padding(4, 5, 4, 5);
            logOutButton.Name = "logOutButton";
            logOutButton.Size = new Size(94, 66);
            logOutButton.TabIndex = 16;
            logOutButton.Text = "Log Out";
            logOutButton.UseVisualStyleBackColor = true;
            logOutButton.Click += logOutButton_Click;
            // 
            // label4
            // 
            label4.Location = new Point(135, 112);
            label4.Margin = new Padding(4, 0, 4, 0);
            label4.Name = "label4";
            label4.Size = new Size(62, 36);
            label4.TabIndex = 17;
            label4.Text = "Name";
            // 
            // ageTB
            // 
            ageTB.Location = new Point(205, 173);
            ageTB.Margin = new Padding(4, 5, 4, 5);
            ageTB.Name = "ageTB";
            ageTB.Size = new Size(124, 31);
            ageTB.TabIndex = 2;
            // 
            // label5
            // 
            label5.Location = new Point(135, 173);
            label5.Margin = new Padding(4, 0, 4, 0);
            label5.Name = "label5";
            label5.Size = new Size(69, 36);
            label5.TabIndex = 18;
            label5.Text = "Age";
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Control;
            ClientSize = new Size(1020, 1242);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(logOutButton);
            Controls.Add(contestantsGridView);
            Controls.Add(label3);
            Controls.Add(searchButton);
            Controls.Add(searchNameTB);
            Controls.Add(label2);
            Controls.Add(racesGridView);
            Controls.Add(addButton);
            Controls.Add(ageTB);
            Controls.Add(nameTB);
            Controls.Add(label1);
            Location = new Point(15, 15);
            Margin = new Padding(4, 5, 4, 5);
            Name = "MainForm";
            Load += MainForm_Load;
            ((ISupportInitialize)racesGridView).EndInit();
            ((ISupportInitialize)contestantsGridView).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        private System.Windows.Forms.DataGridViewTextBoxColumn nameColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ageColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn racesColumn;

        private System.Windows.Forms.DataGridViewTextBoxColumn idColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn distanceColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn styleColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dateColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn numberOfContestantsColumn;

        private System.Windows.Forms.Label label11;

        private System.Windows.Forms.Label label10;

        private System.Windows.Forms.Label label9;

        private System.Windows.Forms.Label label8;

        private System.Windows.Forms.Label label5;

        private System.Windows.Forms.Label label4;

        private System.Windows.Forms.Button logOutButton;

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox searchNameTB;
        private System.Windows.Forms.Button searchButton;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView contestantsGridView;

        private System.Windows.Forms.DataGridView racesGridView;

        private System.Windows.Forms.Button addButton;

        private System.Windows.Forms.DateTimePicker birthDatePicker;
        private System.Windows.Forms.TextBox countryTB;
        private System.Windows.Forms.TextBox streetTB;
        private System.Windows.Forms.TextBox raceIdsTB;

        private System.Windows.Forms.TextBox nameTB;
        private System.Windows.Forms.TextBox ageTB;

        private System.Windows.Forms.Label label1;

        #endregion
    }
}