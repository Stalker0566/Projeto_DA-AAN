namespace Projeto_DA.Views
{
    partial class StatisticsForm
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
            lblUsers = new Label();
            lblBudget = new Label();
            lblRemaining = new Label();
            lblSpent = new Label();
            tabControl1 = new TabControl();
            tabPage1 = new TabPage();
            tabPage2 = new TabPage();
            lblDecisionInfo = new Label();
            dataGridView1 = new DataGridView();
            tabControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // lblUsers
            // 
            lblUsers.AutoSize = true;
            lblUsers.Font = new Font("Segoe UI", 20.25F, FontStyle.Bold, GraphicsUnit.Point, 204);
            lblUsers.ForeColor = SystemColors.ControlLightLight;
            lblUsers.Location = new Point(93, 55);
            lblUsers.Name = "lblUsers";
            lblUsers.Size = new Size(87, 37);
            lblUsers.TabIndex = 0;
            lblUsers.Text = "Users";
            // 
            // lblBudget
            // 
            lblBudget.AutoSize = true;
            lblBudget.Font = new Font("Segoe UI", 20.25F, FontStyle.Bold, GraphicsUnit.Point, 204);
            lblBudget.ForeColor = SystemColors.ControlLightLight;
            lblBudget.Location = new Point(644, 55);
            lblBudget.Name = "lblBudget";
            lblBudget.Size = new Size(122, 37);
            lblBudget.TabIndex = 1;
            lblBudget.Text = "Budgets";
            // 
            // lblRemaining
            // 
            lblRemaining.AutoSize = true;
            lblRemaining.Font = new Font("Segoe UI", 20.25F, FontStyle.Bold, GraphicsUnit.Point, 204);
            lblRemaining.ForeColor = SystemColors.ControlLightLight;
            lblRemaining.Location = new Point(644, 247);
            lblRemaining.Name = "lblRemaining";
            lblRemaining.Size = new Size(154, 37);
            lblRemaining.TabIndex = 2;
            lblRemaining.Text = "Remaining";
            // 
            // lblSpent
            // 
            lblSpent.AutoSize = true;
            lblSpent.Font = new Font("Segoe UI", 20.25F, FontStyle.Bold, GraphicsUnit.Point, 204);
            lblSpent.ForeColor = SystemColors.ControlLightLight;
            lblSpent.Location = new Point(82, 247);
            lblSpent.Name = "lblSpent";
            lblSpent.Size = new Size(91, 37);
            lblSpent.TabIndex = 3;
            lblSpent.Text = "Spent";
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Controls.Add(tabPage2);
            tabControl1.Location = new Point(906, 73);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(200, 100);
            tabControl1.TabIndex = 4;
            // 
            // tabPage1
            // 
            tabPage1.Location = new Point(4, 24);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(192, 72);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "tabPage1";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            tabPage2.Location = new Point(4, 24);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(192, 72);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "tabPage2";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // lblDecisionInfo
            // 
            lblDecisionInfo.AutoSize = true;
            lblDecisionInfo.Font = new Font("Segoe UI Semibold", 15.75F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 204);
            lblDecisionInfo.ForeColor = SystemColors.ControlLightLight;
            lblDecisionInfo.Location = new Point(910, 30);
            lblDecisionInfo.Name = "lblDecisionInfo";
            lblDecisionInfo.Size = new Size(69, 30);
            lblDecisionInfo.TabIndex = 5;
            lblDecisionInfo.Text = "label1";
        
           
            // 
            // StatisticsForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(28, 28, 30);
            ClientSize = new Size(1184, 361);
            Controls.Add(dataGridView1);
            Controls.Add(lblDecisionInfo);
            Controls.Add(tabControl1);
            Controls.Add(lblSpent);
            Controls.Add(lblRemaining);
            Controls.Add(lblBudget);
            Controls.Add(lblUsers);
            Name = "StatisticsForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "StatisticsForm";
            Load += StatisticsForm_Load;
            tabControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblUsers;
        private Label lblBudget;
        private Label lblRemaining;
        private Label lblSpent;
        private TabControl tabControl1;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private Label lblDecisionInfo;
        private DataGridView dataGridView1;
    }
}