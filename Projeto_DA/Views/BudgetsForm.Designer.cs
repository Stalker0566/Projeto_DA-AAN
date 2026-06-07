namespace Projeto_DA.Views
{
    partial class BudgetsForm
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
            dgvBudgets = new DataGridView();
            txtMonth = new TextBox();
            txtYear = new TextBox();
            txtAmount = new TextBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            btnAdd = new Button();
            btnEdit = new Button();
            btnDelete = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvBudgets).BeginInit();
            SuspendLayout();
            // 
            // dgvBudgets
            // 
            dgvBudgets.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvBudgets.Location = new Point(12, 122);
            dgvBudgets.Margin = new Padding(3, 4, 3, 4);
            dgvBudgets.Name = "dgvBudgets";
            dgvBudgets.RowHeadersWidth = 51;
            dgvBudgets.Size = new Size(887, 389);
            dgvBudgets.TabIndex = 0;
            dgvBudgets.SelectionChanged += dgvBudgets_SelectionChanged;
            // 
            // txtMonth
            // 
            txtMonth.Location = new Point(102, 76);
            txtMonth.Margin = new Padding(3, 4, 3, 4);
            txtMonth.Name = "txtMonth";
            txtMonth.Size = new Size(114, 27);
            txtMonth.TabIndex = 1;
            // 
            // txtYear
            // 
            txtYear.Location = new Point(223, 76);
            txtYear.Margin = new Padding(3, 4, 3, 4);
            txtYear.Name = "txtYear";
            txtYear.Size = new Size(114, 27);
            txtYear.TabIndex = 2;
            // 
            // txtAmount
            // 
            txtAmount.Location = new Point(344, 76);
            txtAmount.Margin = new Padding(3, 4, 3, 4);
            txtAmount.Name = "txtAmount";
            txtAmount.Size = new Size(114, 27);
            txtAmount.TabIndex = 3;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 204);
            label1.ForeColor = SystemColors.ControlLightLight;
            label1.Location = new Point(102, 49);
            label1.Name = "label1";
            label1.Size = new Size(40, 23);
            label1.TabIndex = 4;
            label1.Text = "Mes";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 204);
            label2.ForeColor = SystemColors.ControlLightLight;
            label2.Location = new Point(223, 49);
            label2.Name = "label2";
            label2.Size = new Size(40, 23);
            label2.TabIndex = 5;
            label2.Text = "Ano";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 204);
            label3.ForeColor = SystemColors.ControlLightLight;
            label3.Location = new Point(344, 49);
            label3.Name = "label3";
            label3.Size = new Size(77, 23);
            label3.TabIndex = 6;
            label3.Text = "Valor (€)";
            // 
            // btnAdd
            // 
            btnAdd.FlatStyle = FlatStyle.Flat;
            btnAdd.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 204);
            btnAdd.ForeColor = SystemColors.ControlLightLight;
            btnAdd.Location = new Point(528, 63);
            btnAdd.Margin = new Padding(3, 4, 3, 4);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(116, 40);
            btnAdd.TabIndex = 7;
            btnAdd.Text = "Adicidionar";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // btnEdit
            // 
            btnEdit.FlatStyle = FlatStyle.Flat;
            btnEdit.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 204);
            btnEdit.ForeColor = SystemColors.ControlLightLight;
            btnEdit.Location = new Point(650, 63);
            btnEdit.Margin = new Padding(3, 4, 3, 4);
            btnEdit.Name = "btnEdit";
            btnEdit.Size = new Size(116, 40);
            btnEdit.TabIndex = 8;
            btnEdit.Text = "Editar";
            btnEdit.UseVisualStyleBackColor = true;
            btnEdit.Click += btnEdit_Click;
            // 
            // btnDelete
            // 
            btnDelete.FlatStyle = FlatStyle.Flat;
            btnDelete.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 204);
            btnDelete.ForeColor = SystemColors.ControlLightLight;
            btnDelete.Location = new Point(772, 63);
            btnDelete.Margin = new Padding(3, 4, 3, 4);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(116, 40);
            btnDelete.TabIndex = 9;
            btnDelete.Text = "Eleminar";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            // 
            // BudgetsForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(28, 28, 30);
            ClientSize = new Size(914, 600);
            Controls.Add(btnDelete);
            Controls.Add(btnEdit);
            Controls.Add(btnAdd);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(txtAmount);
            Controls.Add(txtYear);
            Controls.Add(txtMonth);
            Controls.Add(dgvBudgets);
            Margin = new Padding(3, 4, 3, 4);
            Name = "BudgetsForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Budgets";
            Load += BudgetsForm_Load;
            Click += btnAdd_Click;
            ((System.ComponentModel.ISupportInitialize)dgvBudgets).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgvBudgets;
        private TextBox txtMonth;
        private TextBox txtYear;
        private TextBox txtAmount;
        private Label label1;
        private Label label2;
        private Label label3;
        private Button btnAdd;
        private Button btnEdit;
        private Button btnDelete;
    }
}