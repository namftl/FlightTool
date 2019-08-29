namespace SelaFlights
{
    partial class AppScr
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AppScr));
            this.QuerryPanel = new System.Windows.Forms.Panel();
            this.Q3 = new System.Windows.Forms.Button();
            this.Q2 = new System.Windows.Forms.Button();
            this.Q1 = new System.Windows.Forms.Button();
            this.InputPanel = new System.Windows.Forms.Panel();
            this.ConfirmInput = new System.Windows.Forms.Button();
            this.BackInput = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.CityB = new System.Windows.Forms.TextBox();
            this.CityA = new System.Windows.Forms.TextBox();
            this.ResultsPanel = new System.Windows.Forms.Panel();
            this.BackResults = new System.Windows.Forms.Button();
            this.ResultText = new System.Windows.Forms.TextBox();
            this.ExitButton = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.SelectFileButton = new System.Windows.Forms.Button();
            this.FileNameText = new System.Windows.Forms.TextBox();
            this.QueryBack = new System.Windows.Forms.Button();
            this.FileConfirm = new System.Windows.Forms.Button();
            this.FilePanel = new System.Windows.Forms.Panel();
            this.QuerryPanel.SuspendLayout();
            this.InputPanel.SuspendLayout();
            this.ResultsPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.FilePanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // QuerryPanel
            // 
            this.QuerryPanel.AutoSize = true;
            this.QuerryPanel.BackColor = System.Drawing.SystemColors.HighlightText;
            this.QuerryPanel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.QuerryPanel.Controls.Add(this.Q3);
            this.QuerryPanel.Controls.Add(this.Q2);
            this.QuerryPanel.Controls.Add(this.Q1);
            this.QuerryPanel.Location = new System.Drawing.Point(269, 12);
            this.QuerryPanel.Name = "QuerryPanel";
            this.QuerryPanel.Size = new System.Drawing.Size(303, 193);
            this.QuerryPanel.TabIndex = 0;
            // 
            // Q3
            // 
            this.Q3.AutoSize = true;
            this.Q3.Location = new System.Drawing.Point(3, 133);
            this.Q3.Name = "Q3";
            this.Q3.Padding = new System.Windows.Forms.Padding(3);
            this.Q3.Size = new System.Drawing.Size(131, 29);
            this.Q3.TabIndex = 5;
            this.Q3.Text = "5 Farthest Destinations";
            this.Q3.UseVisualStyleBackColor = true;
            this.Q3.Click += new System.EventHandler(this.Query_Click);
            // 
            // Q2
            // 
            this.Q2.AutoSize = true;
            this.Q2.Location = new System.Drawing.Point(3, 69);
            this.Q2.Name = "Q2";
            this.Q2.Padding = new System.Windows.Forms.Padding(3);
            this.Q2.Size = new System.Drawing.Size(125, 29);
            this.Q2.TabIndex = 4;
            this.Q2.Text = "Most Flights From City";
            this.Q2.UseVisualStyleBackColor = true;
            this.Q2.Click += new System.EventHandler(this.Query_Click);
            // 
            // Q1
            // 
            this.Q1.AutoSize = true;
            this.Q1.Location = new System.Drawing.Point(3, 3);
            this.Q1.Name = "Q1";
            this.Q1.Padding = new System.Windows.Forms.Padding(3);
            this.Q1.Size = new System.Drawing.Size(178, 29);
            this.Q1.TabIndex = 3;
            this.Q1.Text = "Avg Depature And Arrival Delays";
            this.Q1.UseVisualStyleBackColor = true;
            this.Q1.Click += new System.EventHandler(this.Query_Click);
            // 
            // InputPanel
            // 
            this.InputPanel.AutoSize = true;
            this.InputPanel.BackColor = System.Drawing.SystemColors.ControlLight;
            this.InputPanel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.InputPanel.Controls.Add(this.ConfirmInput);
            this.InputPanel.Controls.Add(this.BackInput);
            this.InputPanel.Controls.Add(this.label2);
            this.InputPanel.Controls.Add(this.label1);
            this.InputPanel.Controls.Add(this.CityB);
            this.InputPanel.Controls.Add(this.CityA);
            this.InputPanel.Location = new System.Drawing.Point(12, 220);
            this.InputPanel.Name = "InputPanel";
            this.InputPanel.Size = new System.Drawing.Size(776, 100);
            this.InputPanel.TabIndex = 1;
            // 
            // ConfirmInput
            // 
            this.ConfirmInput.AutoSize = true;
            this.ConfirmInput.ForeColor = System.Drawing.Color.ForestGreen;
            this.ConfirmInput.Location = new System.Drawing.Point(677, 55);
            this.ConfirmInput.Name = "ConfirmInput";
            this.ConfirmInput.Size = new System.Drawing.Size(75, 23);
            this.ConfirmInput.TabIndex = 5;
            this.ConfirmInput.Text = "Confirm";
            this.ConfirmInput.UseVisualStyleBackColor = true;
            this.ConfirmInput.Click += new System.EventHandler(this.ConfirmInput_Click);
            // 
            // BackInput
            // 
            this.BackInput.AutoSize = true;
            this.BackInput.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.BackInput.Location = new System.Drawing.Point(20, 55);
            this.BackInput.Name = "BackInput";
            this.BackInput.Size = new System.Drawing.Size(75, 23);
            this.BackInput.TabIndex = 4;
            this.BackInput.Text = "back";
            this.BackInput.UseVisualStyleBackColor = true;
            this.BackInput.UseWaitCursor = true;
            this.BackInput.Click += new System.EventHandler(this.BackInput_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(501, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(31, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "CityB";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(252, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(31, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "CityA";
            // 
            // CityB
            // 
            this.CityB.Location = new System.Drawing.Point(457, 42);
            this.CityB.Name = "CityB";
            this.CityB.Size = new System.Drawing.Size(130, 20);
            this.CityB.TabIndex = 1;
            this.CityB.Click += new System.EventHandler(this.CityB_Click);
            // 
            // CityA
            // 
            this.CityA.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.CityA.BackColor = System.Drawing.SystemColors.Window;
            this.CityA.Location = new System.Drawing.Point(211, 42);
            this.CityA.Name = "CityA";
            this.CityA.Size = new System.Drawing.Size(121, 20);
            this.CityA.TabIndex = 0;
            this.CityA.Click += new System.EventHandler(this.CityA_ClickOrText);
            this.CityA.TextChanged += new System.EventHandler(this.CityA_ClickOrText);
            // 
            // ResultsPanel
            // 
            this.ResultsPanel.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ResultsPanel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.ResultsPanel.Controls.Add(this.BackResults);
            this.ResultsPanel.Controls.Add(this.ResultText);
            this.ResultsPanel.Location = new System.Drawing.Point(12, 336);
            this.ResultsPanel.Name = "ResultsPanel";
            this.ResultsPanel.Size = new System.Drawing.Size(776, 100);
            this.ResultsPanel.TabIndex = 3;
            // 
            // BackResults
            // 
            this.BackResults.AutoSize = true;
            this.BackResults.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.BackResults.Location = new System.Drawing.Point(20, 58);
            this.BackResults.Name = "BackResults";
            this.BackResults.Size = new System.Drawing.Size(75, 23);
            this.BackResults.TabIndex = 1;
            this.BackResults.Text = "back";
            this.BackResults.UseVisualStyleBackColor = true;
            this.BackResults.Click += new System.EventHandler(this.BackResults_Click);
            // 
            // ResultText
            // 
            this.ResultText.Location = new System.Drawing.Point(109, 13);
            this.ResultText.Multiline = true;
            this.ResultText.Name = "ResultText";
            this.ResultText.ReadOnly = true;
            this.ResultText.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.ResultText.Size = new System.Drawing.Size(643, 68);
            this.ResultText.TabIndex = 0;
            this.ResultText.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // ExitButton
            // 
            this.ExitButton.AutoSize = true;
            this.ExitButton.ForeColor = System.Drawing.Color.OrangeRed;
            this.ExitButton.Location = new System.Drawing.Point(34, 442);
            this.ExitButton.Name = "ExitButton";
            this.ExitButton.Size = new System.Drawing.Size(33, 23);
            this.ExitButton.TabIndex = 4;
            this.ExitButton.Text = "exit";
            this.ExitButton.UseVisualStyleBackColor = true;
            this.ExitButton.Click += new System.EventHandler(this.Exit_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(599, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(189, 152);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 5;
            this.pictureBox1.TabStop = false;
            // 
            // SelectFileButton
            // 
            this.SelectFileButton.FlatAppearance.BorderSize = 2;
            this.SelectFileButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SelectFileButton.Location = new System.Drawing.Point(21, 0);
            this.SelectFileButton.Name = "SelectFileButton";
            this.SelectFileButton.Size = new System.Drawing.Size(172, 109);
            this.SelectFileButton.TabIndex = 6;
            this.SelectFileButton.Text = "Select File";
            this.SelectFileButton.UseVisualStyleBackColor = true;
            this.SelectFileButton.Click += new System.EventHandler(this.SelectFileButton_Click);
            // 
            // FileNameText
            // 
            this.FileNameText.Location = new System.Drawing.Point(21, 118);
            this.FileNameText.Name = "FileNameText";
            this.FileNameText.Size = new System.Drawing.Size(172, 20);
            this.FileNameText.TabIndex = 7;
            // 
            // QueryBack
            // 
            this.QueryBack.AutoSize = true;
            this.QueryBack.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.QueryBack.Location = new System.Drawing.Point(633, 177);
            this.QueryBack.Name = "QueryBack";
            this.QueryBack.Size = new System.Drawing.Size(75, 23);
            this.QueryBack.TabIndex = 8;
            this.QueryBack.Text = "Back";
            this.QueryBack.UseVisualStyleBackColor = true;
            this.QueryBack.Click += new System.EventHandler(this.QueryBack_Click);
            // 
            // FileConfirm
            // 
            this.FileConfirm.AutoSize = true;
            this.FileConfirm.ForeColor = System.Drawing.Color.ForestGreen;
            this.FileConfirm.Location = new System.Drawing.Point(62, 159);
            this.FileConfirm.Name = "FileConfirm";
            this.FileConfirm.Size = new System.Drawing.Size(75, 23);
            this.FileConfirm.TabIndex = 9;
            this.FileConfirm.Text = "Confirm";
            this.FileConfirm.UseVisualStyleBackColor = true;
            this.FileConfirm.Click += new System.EventHandler(this.FileConfirm_Click);
            // 
            // FilePanel
            // 
            this.FilePanel.Controls.Add(this.SelectFileButton);
            this.FilePanel.Controls.Add(this.FileNameText);
            this.FilePanel.Controls.Add(this.FileConfirm);
            this.FilePanel.Location = new System.Drawing.Point(13, 12);
            this.FilePanel.Name = "FilePanel";
            this.FilePanel.Size = new System.Drawing.Size(225, 193);
            this.FilePanel.TabIndex = 10;
            // 
            // AppScr
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ClientSize = new System.Drawing.Size(824, 477);
            this.Controls.Add(this.FilePanel);
            this.Controls.Add(this.QueryBack);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.ExitButton);
            this.Controls.Add(this.ResultsPanel);
            this.Controls.Add(this.InputPanel);
            this.Controls.Add(this.QuerryPanel);
            this.Name = "AppScr";
            this.Text = "AppScr";
            this.QuerryPanel.ResumeLayout(false);
            this.QuerryPanel.PerformLayout();
            this.InputPanel.ResumeLayout(false);
            this.InputPanel.PerformLayout();
            this.ResultsPanel.ResumeLayout(false);
            this.ResultsPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.FilePanel.ResumeLayout(false);
            this.FilePanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        
        #endregion

        private System.Windows.Forms.Panel QuerryPanel;
        private System.Windows.Forms.Button Q1;
        private System.Windows.Forms.Button Q3;
        private System.Windows.Forms.Button Q2;
        private System.Windows.Forms.Panel InputPanel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox CityB;
        private System.Windows.Forms.TextBox CityA;
        private System.Windows.Forms.Button BackInput;
        private System.Windows.Forms.Panel ResultsPanel;
        private System.Windows.Forms.Button BackResults;
        private System.Windows.Forms.TextBox ResultText;
        private System.Windows.Forms.Button ExitButton;
        private System.Windows.Forms.Button ConfirmInput;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button SelectFileButton;
        private System.Windows.Forms.TextBox FileNameText;
        private System.Windows.Forms.Button QueryBack;
        private System.Windows.Forms.Button FileConfirm;
        private System.Windows.Forms.Panel FilePanel;
    }
}