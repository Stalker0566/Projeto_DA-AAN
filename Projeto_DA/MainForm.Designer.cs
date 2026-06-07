namespace Projeto_DA
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            panel1 = new Panel();
            btnStats = new Button();
            btnPurchases = new Button();
            btnBudgets = new Button();
            btnArticles = new Button();
            btnCategories = new Button();
            btnUsers = new Button();
            lblWelcome = new Label();
            dataGridViewPurchases = new DataGridView();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewPurchases).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(44, 44, 46);
            panel1.Controls.Add(btnStats);
            panel1.Controls.Add(btnPurchases);
            panel1.Controls.Add(btnBudgets);
            panel1.Controls.Add(btnArticles);
            panel1.Controls.Add(btnCategories);
            panel1.Controls.Add(btnUsers);
            panel1.Dock = DockStyle.Left;
            panel1.Location = new Point(0, 0);
            panel1.Margin = new Padding(3, 4, 3, 4);
            panel1.Name = "panel1";
            panel1.Size = new Size(229, 748);
            panel1.TabIndex = 0;
            // 
            // btnStats
            // 
            btnStats.FlatStyle = FlatStyle.Flat;
            btnStats.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Italic, GraphicsUnit.Point, 204);
            btnStats.ForeColor = SystemColors.ControlLightLight;
            btnStats.Location = new Point(53, 409);
            btnStats.Margin = new Padding(3, 4, 3, 4);
            btnStats.Name = "btnStats";
            btnStats.Size = new Size(123, 41);
            btnStats.TabIndex = 5;
            btnStats.Text = "Estatistica";
            btnStats.UseVisualStyleBackColor = true;
            // 
            // btnPurchases
            // 
            btnPurchases.FlatStyle = FlatStyle.Flat;
            btnPurchases.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Italic, GraphicsUnit.Point, 204);
            btnPurchases.ForeColor = SystemColors.ControlLightLight;
            btnPurchases.Location = new Point(53, 343);
            btnPurchases.Margin = new Padding(3, 4, 3, 4);
            btnPurchases.Name = "btnPurchases";
            btnPurchases.Size = new Size(123, 41);
            btnPurchases.TabIndex = 4;
            btnPurchases.Text = "Compras";
            btnPurchases.UseVisualStyleBackColor = true;
            btnPurchases.Click += btnPurchases_Click;
            // 
            // btnBudgets
            // 
            btnBudgets.FlatStyle = FlatStyle.Flat;
            btnBudgets.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Italic, GraphicsUnit.Point, 204);
            btnBudgets.ForeColor = SystemColors.ControlLightLight;
            btnBudgets.Location = new Point(53, 277);
            btnBudgets.Margin = new Padding(3, 4, 3, 4);
            btnBudgets.Name = "btnBudgets";
            btnBudgets.Size = new Size(123, 41);
            btnBudgets.TabIndex = 3;
            btnBudgets.Text = "Orcamentos";
            btnBudgets.UseVisualStyleBackColor = true;
            btnBudgets.Click += btnBudgets_Click;
            // 
            // btnArticles
            // 
            btnArticles.FlatStyle = FlatStyle.Flat;
            btnArticles.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 204);
            btnArticles.ForeColor = SystemColors.ControlLightLight;
            btnArticles.Location = new Point(53, 214);
            btnArticles.Margin = new Padding(3, 4, 3, 4);
            btnArticles.Name = "btnArticles";
            btnArticles.Size = new Size(123, 41);
            btnArticles.TabIndex = 2;
            btnArticles.Text = "Artigos";
            btnArticles.UseVisualStyleBackColor = true;
            btnArticles.Click += btnArticles_Click;
            // 
            // btnCategories
            // 
            btnCategories.FlatStyle = FlatStyle.Flat;
            btnCategories.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 204);
            btnCategories.ForeColor = SystemColors.ControlLightLight;
            btnCategories.Location = new Point(53, 152);
            btnCategories.Margin = new Padding(3, 4, 3, 4);
            btnCategories.Name = "btnCategories";
            btnCategories.Size = new Size(123, 41);
            btnCategories.TabIndex = 1;
            btnCategories.Text = "Categorias";
            btnCategories.UseVisualStyleBackColor = true;
            btnCategories.Click += btnCategories_Click;
            // 
            // btnUsers
            // 
            btnUsers.FlatStyle = FlatStyle.Flat;
            btnUsers.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Italic, GraphicsUnit.Point, 204);
            btnUsers.ForeColor = SystemColors.ControlLightLight;
            btnUsers.Location = new Point(53, 88);
            btnUsers.Margin = new Padding(3, 4, 3, 4);
            btnUsers.Name = "btnUsers";
            btnUsers.Size = new Size(123, 41);
            btnUsers.TabIndex = 0;
            btnUsers.Text = "Users";
            btnUsers.UseCompatibleTextRendering = true;
            btnUsers.UseVisualStyleBackColor = true;
            btnUsers.Click += btnUsers_Click;
            // 
            // lblWelcome
            // 
            lblWelcome.AutoSize = true;
            lblWelcome.Font = new Font("Segoe UI Semibold", 18F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 204);
            lblWelcome.ForeColor = SystemColors.ControlLightLight;
            lblWelcome.Location = new Point(517, 83);
            lblWelcome.Name = "lblWelcome";
            lblWelcome.Size = new Size(208, 41);
            lblWelcome.TabIndex = 2;
            lblWelcome.Text = "Welcome msg";
            lblWelcome.Click += lblWelcome_Click;
            // 
            // dataGridViewPurchases
            // 
            dataGridViewPurchases.AllowUserToAddRows = false;
            dataGridViewPurchases.BackgroundColor = Color.FromArgb(28, 28, 30);
            dataGridViewPurchases.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewPurchases.Location = new Point(427, 267);
            dataGridViewPurchases.Margin = new Padding(3, 4, 3, 4);
            dataGridViewPurchases.Name = "dataGridViewPurchases";
            dataGridViewPurchases.RowHeadersWidth = 51;
            dataGridViewPurchases.Size = new Size(480, 176);
            dataGridViewPurchases.TabIndex = 3;
            dataGridViewPurchases.CellContentClick += dataGridViewPurchases_CellContentClick;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(28, 28, 30);
            ClientSize = new Size(1010, 748);
            Controls.Add(dataGridViewPurchases);
            Controls.Add(lblWelcome);
            Controls.Add(panel1);
            Margin = new Padding(3, 4, 3, 4);
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Main";
            Load += MainForm_Load;
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridViewPurchases).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel1;
        private Button btnStats;
        private Button btnPurchases;
        private Button btnBudgets;
        private Button btnArticles;
        private Button btnCategories;
        private Button btnUsers;
        private Label lblWelcome;
        private DataGridView dataGridViewPurchases;
    }
}
