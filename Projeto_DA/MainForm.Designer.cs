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
            panel1.Name = "panel1";
            panel1.Size = new Size(200, 561);
            panel1.TabIndex = 0;
            // 
            // btnStats
            // 
            btnStats.FlatStyle = FlatStyle.Flat;
            btnStats.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 204);
            btnStats.ForeColor = SystemColors.ControlLightLight;
            btnStats.Location = new Point(57, 444);
            btnStats.Name = "btnStats";
            btnStats.Size = new Size(93, 28);
            btnStats.TabIndex = 5;
            btnStats.Text = "Estatistica";
            btnStats.UseVisualStyleBackColor = true;
            btnStats.Click += btnStats_Click;
            // 
            // btnPurchases
            // 
            btnPurchases.FlatStyle = FlatStyle.Flat;
            btnPurchases.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 204);
            btnPurchases.ForeColor = SystemColors.ControlLightLight;
            btnPurchases.Location = new Point(57, 359);
            btnPurchases.Name = "btnPurchases";
            btnPurchases.Size = new Size(93, 28);
            btnPurchases.TabIndex = 4;
            btnPurchases.Text = "Compras";
            btnPurchases.UseVisualStyleBackColor = true;
            btnPurchases.Click += btnPurchases_Click;
            // 
            // btnBudgets
            // 
            btnBudgets.FlatStyle = FlatStyle.Flat;
            btnBudgets.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 204);
            btnBudgets.ForeColor = SystemColors.ControlLightLight;
            btnBudgets.Location = new Point(57, 281);
            btnBudgets.Name = "btnBudgets";
            btnBudgets.Size = new Size(93, 28);
            btnBudgets.TabIndex = 3;
            btnBudgets.Text = "Orcamentos";
            btnBudgets.UseVisualStyleBackColor = true;
            btnBudgets.Click += btnBudgets_Click;
            // 
            // btnArticles
            // 
            btnArticles.FlatStyle = FlatStyle.Flat;
            btnArticles.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 204);
            btnArticles.ForeColor = SystemColors.ControlLightLight;
            btnArticles.Location = new Point(57, 200);
            btnArticles.Name = "btnArticles";
            btnArticles.Size = new Size(93, 27);
            btnArticles.TabIndex = 2;
            btnArticles.Text = "Artigos";
            btnArticles.UseVisualStyleBackColor = true;
            btnArticles.Click += btnArticles_Click;
            // 
            // btnCategories
            // 
            btnCategories.FlatStyle = FlatStyle.Flat;
            btnCategories.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 204);
            btnCategories.ForeColor = SystemColors.ControlLightLight;
            btnCategories.Location = new Point(57, 123);
            btnCategories.Name = "btnCategories";
            btnCategories.Size = new Size(93, 31);
            btnCategories.TabIndex = 1;
            btnCategories.Text = "Categorias";
            btnCategories.UseVisualStyleBackColor = true;
            btnCategories.Click += btnCategories_Click;
            // 
            // btnUsers
            // 
            btnUsers.FlatStyle = FlatStyle.Flat;
            btnUsers.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 204);
            btnUsers.ForeColor = SystemColors.ControlLightLight;
            btnUsers.Location = new Point(57, 62);
            btnUsers.Name = "btnUsers";
            btnUsers.Size = new Size(93, 23);
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
            lblWelcome.Location = new Point(499, 27);
            lblWelcome.Name = "lblWelcome";
            lblWelcome.Size = new Size(80, 32);
            lblWelcome.TabIndex = 2;
            lblWelcome.Text = "label2";
            // 
            // dataGridViewPurchases
            // 
            dataGridViewPurchases.AllowUserToAddRows = false;
            dataGridViewPurchases.BackgroundColor = Color.FromArgb(28, 28, 30);
            dataGridViewPurchases.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewPurchases.Location = new Point(245, 109);
            dataGridViewPurchases.Name = "dataGridViewPurchases";
            dataGridViewPurchases.Size = new Size(587, 404);
            dataGridViewPurchases.TabIndex = 3;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(28, 28, 30);
            ClientSize = new Size(884, 561);
            Controls.Add(dataGridViewPurchases);
            Controls.Add(lblWelcome);
            Controls.Add(panel1);
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
