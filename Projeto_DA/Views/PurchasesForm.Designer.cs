namespace Projeto_DA.Views
{
    partial class PurchasesForm
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
            Button btnExportCSV;
            dgvPurchases = new DataGridView();
            txtName = new TextBox();
            label1 = new Label();
            btnAdd = new Button();
            btnClose = new Button();
            btnDelete = new Button();
            btnDetails = new Button();
            btnExportCSV = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvPurchases).BeginInit();
            SuspendLayout();
            // 
            // btnExportCSV
            // 
            btnExportCSV.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 204);
            btnExportCSV.ForeColor = Color.Black;
            btnExportCSV.Location = new Point(12, 333);
            btnExportCSV.Name = "btnExportCSV";
            btnExportCSV.Size = new Size(194, 57);
            btnExportCSV.TabIndex = 7;
            btnExportCSV.Text = "Export CSV";
            btnExportCSV.UseVisualStyleBackColor = true;
            btnExportCSV.Click += btnExportCSV_Click;
            // 
            // dgvPurchases
            // 
            dgvPurchases.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvPurchases.Location = new Point(12, 106);
            dgvPurchases.Name = "dgvPurchases";
            dgvPurchases.Size = new Size(776, 221);
            dgvPurchases.TabIndex = 0;
            
            // 
            // txtName
            // 
            txtName.Location = new Point(55, 77);
            txtName.Name = "txtName";
            txtName.Size = new Size(113, 23);
            txtName.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 204);
            label1.ForeColor = SystemColors.ControlLightLight;
            label1.Location = new Point(55, 57);
            label1.Name = "label1";
            label1.Size = new Size(113, 17);
            label1.TabIndex = 2;
            label1.Text = "Nome da Compra:";
            // 
            // btnAdd
            // 
            btnAdd.FlatStyle = FlatStyle.Flat;
            btnAdd.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 204);
            btnAdd.ForeColor = SystemColors.ControlLightLight;
            btnAdd.Location = new Point(254, 67);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(79, 38);
            btnAdd.TabIndex = 3;
            btnAdd.Text = "Adicionar";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // btnClose
            // 
            btnClose.FlatStyle = FlatStyle.Flat;
            btnClose.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 204);
            btnClose.ForeColor = SystemColors.ControlLightLight;
            btnClose.Location = new Point(339, 67);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(108, 38);
            btnClose.TabIndex = 4;
            btnClose.Text = "Fechar Compra";
            btnClose.UseVisualStyleBackColor = true;
            btnClose.Click += btnClose_Click;
            // 
            // btnDelete
            // 
            btnDelete.FlatStyle = FlatStyle.Flat;
            btnDelete.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 204);
            btnDelete.ForeColor = SystemColors.ControlLightLight;
            btnDelete.Location = new Point(454, 67);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(79, 38);
            btnDelete.TabIndex = 5;
            btnDelete.Text = "Eleminar";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            // 
            // btnDetails
            // 
            btnDetails.FlatStyle = FlatStyle.Flat;
            btnDetails.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 204);
            btnDetails.ForeColor = SystemColors.ControlLightLight;
            btnDetails.Location = new Point(539, 67);
            btnDetails.Name = "btnDetails";
            btnDetails.Size = new Size(97, 38);
            btnDetails.TabIndex = 6;
            btnDetails.Text = "Ver Artigos";
            btnDetails.UseVisualStyleBackColor = true;
            btnDetails.Click += btnDetails_Click;
            // 
            // PurchasesForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(28, 28, 30);
            ClientSize = new Size(800, 450);
            Controls.Add(btnExportCSV);
            Controls.Add(btnDetails);
            Controls.Add(btnDelete);
            Controls.Add(btnClose);
            Controls.Add(btnAdd);
            Controls.Add(label1);
            Controls.Add(txtName);
            Controls.Add(dgvPurchases);
            ForeColor = SystemColors.ControlLightLight;
            Name = "PurchasesForm";
            Text = "PurchaseForm";
            Load += PurchasesForm_Load;
            ((System.ComponentModel.ISupportInitialize)dgvPurchases).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgvPurchases;
        private TextBox txtName;
        private Label label1;
        private Button btnAdd;
        private Button btnClose;
        private Button btnDelete;
        private Button btnDetails;
    }
}