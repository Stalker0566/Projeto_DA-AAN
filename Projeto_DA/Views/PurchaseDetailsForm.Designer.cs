namespace Projeto_DA.Views
{
    partial class PurchaseDetailsForm
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
            dgvItems = new DataGridView();
            cmbArticles = new ComboBox();
            txtQuantity = new TextBox();
            txtPrice = new TextBox();
            btnAddItem = new Button();
            btnRemoveItem = new Button();
            lblTotal = new Label();
            lblRemainingBudget = new Label();
            sqlCommandBuilder1 = new Microsoft.Data.SqlClient.SqlCommandBuilder();
            btnFecharCompra = new Button();
            chkNotPlanned = new CheckBox();
            txtNotes = new TextBox();
            lbNotes = new Label();
            lbQuantity = new Label();
            lbPrice = new Label();
            cmbCategories = new ComboBox();
            label1 = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvItems).BeginInit();
            SuspendLayout();
            // 
            // dgvItems
            // 
            dgvItems.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvItems.Location = new Point(12, 105);
            dgvItems.Name = "dgvItems";
            dgvItems.Size = new Size(815, 215);
            dgvItems.TabIndex = 0;
            // 
            // cmbArticles
            // 
            cmbArticles.FormattingEnabled = true;
            cmbArticles.Location = new Point(114, 76);
            cmbArticles.Name = "cmbArticles";
            cmbArticles.Size = new Size(121, 23);
            cmbArticles.TabIndex = 1;
            // 
            // txtQuantity
            // 
            txtQuantity.Location = new Point(241, 76);
            txtQuantity.Name = "txtQuantity";
            txtQuantity.Size = new Size(100, 23);
            txtQuantity.TabIndex = 2;
            // 
            // txtPrice
            // 
            txtPrice.Location = new Point(347, 76);
            txtPrice.Name = "txtPrice";
            txtPrice.Size = new Size(100, 23);
            txtPrice.TabIndex = 3;
            // 
            // btnAddItem
            // 
            btnAddItem.FlatStyle = FlatStyle.Flat;
            btnAddItem.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 204);
            btnAddItem.ForeColor = SystemColors.ControlLightLight;
            btnAddItem.Location = new Point(512, 67);
            btnAddItem.Name = "btnAddItem";
            btnAddItem.Size = new Size(80, 36);
            btnAddItem.TabIndex = 4;
            btnAddItem.Text = "Adicionar";
            btnAddItem.UseVisualStyleBackColor = true;
            btnAddItem.Click += btnAddItem_Click;
            // 
            // btnRemoveItem
            // 
            btnRemoveItem.FlatStyle = FlatStyle.Flat;
            btnRemoveItem.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 204);
            btnRemoveItem.ForeColor = SystemColors.ControlLightLight;
            btnRemoveItem.Location = new Point(598, 67);
            btnRemoveItem.Name = "btnRemoveItem";
            btnRemoveItem.Size = new Size(80, 36);
            btnRemoveItem.TabIndex = 5;
            btnRemoveItem.Text = "Remover";
            btnRemoveItem.UseVisualStyleBackColor = true;
            // 
            // lblTotal
            // 
            lblTotal.AutoSize = true;
            lblTotal.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 204);
            lblTotal.ForeColor = SystemColors.ControlLightLight;
            lblTotal.Location = new Point(706, 69);
            lblTotal.Name = "lblTotal";
            lblTotal.Size = new Size(0, 25);
            lblTotal.TabIndex = 6;
            // 
            // lblRemainingBudget
            // 
            lblRemainingBudget.AutoSize = true;
            lblRemainingBudget.Font = new Font("Segoe UI", 21.75F, FontStyle.Bold, GraphicsUnit.Point, 204);
            lblRemainingBudget.ForeColor = SystemColors.ControlLightLight;
            lblRemainingBudget.Location = new Point(12, 9);
            lblRemainingBudget.Name = "lblRemainingBudget";
            lblRemainingBudget.Size = new Size(100, 40);
            lblRemainingBudget.TabIndex = 7;
            lblRemainingBudget.Text = "label1";
            // 
            // btnFecharCompra
            // 
            btnFecharCompra.FlatStyle = FlatStyle.Flat;
            btnFecharCompra.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 204);
            btnFecharCompra.ForeColor = SystemColors.ControlLightLight;
            btnFecharCompra.Location = new Point(452, 9);
            btnFecharCompra.Name = "btnFecharCompra";
            btnFecharCompra.Size = new Size(111, 36);
            btnFecharCompra.TabIndex = 8;
            btnFecharCompra.Text = "Fechar Compra";
            btnFecharCompra.UseVisualStyleBackColor = true;
            // 
            // chkNotPlanned
            // 
            chkNotPlanned.AutoSize = true;
            chkNotPlanned.FlatStyle = FlatStyle.Flat;
            chkNotPlanned.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 204);
            chkNotPlanned.ForeColor = SystemColors.ControlLightLight;
            chkNotPlanned.Location = new Point(598, 17);
            chkNotPlanned.Name = "chkNotPlanned";
            chkNotPlanned.Size = new Size(176, 25);
            chkNotPlanned.TabIndex = 9;
            chkNotPlanned.Text = "Artigo Não Previsto";
            chkNotPlanned.UseVisualStyleBackColor = true;
            // 
            // txtNotes
            // 
            txtNotes.Location = new Point(12, 387);
            txtNotes.Name = "txtNotes";
            txtNotes.Size = new Size(352, 23);
            txtNotes.TabIndex = 10;
            // 
            // lbNotes
            // 
            lbNotes.AutoSize = true;
            lbNotes.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 204);
            lbNotes.ForeColor = SystemColors.ControlLightLight;
            lbNotes.Location = new Point(12, 363);
            lbNotes.Name = "lbNotes";
            lbNotes.Size = new Size(111, 21);
            lbNotes.TabIndex = 11;
            lbNotes.Text = "Observações:";
            // 
            // lbQuantity
            // 
            lbQuantity.AutoSize = true;
            lbQuantity.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 204);
            lbQuantity.ForeColor = SystemColors.ControlLightLight;
            lbQuantity.Location = new Point(241, 56);
            lbQuantity.Name = "lbQuantity";
            lbQuantity.Size = new Size(78, 17);
            lbQuantity.TabIndex = 12;
            lbQuantity.Text = "Quantidade";
            // 
            // lbPrice
            // 
            lbPrice.AutoSize = true;
            lbPrice.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 204);
            lbPrice.ForeColor = SystemColors.ControlLightLight;
            lbPrice.Location = new Point(347, 56);
            lbPrice.Name = "lbPrice";
            lbPrice.Size = new Size(41, 17);
            lbPrice.TabIndex = 13;
            lbPrice.Text = "Preco";
            // 
            // cmbCategories
            // 
            cmbCategories.FormattingEnabled = true;
            cmbCategories.Location = new Point(706, 76);
            cmbCategories.Name = "cmbCategories";
            cmbCategories.Size = new Size(121, 23);
            cmbCategories.TabIndex = 14;
            cmbCategories.SelectedIndexChanged += cmbCategories_SelectedIndexChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 204);
            label1.ForeColor = SystemColors.ControlLightLight;
            label1.Location = new Point(706, 58);
            label1.Name = "label1";
            label1.Size = new Size(65, 17);
            label1.TabIndex = 15;
            label1.Text = "Categoria";
            // 
            // PurchaseDetailsForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(28, 28, 30);
            ClientSize = new Size(984, 416);
            Controls.Add(label1);
            Controls.Add(cmbCategories);
            Controls.Add(lbPrice);
            Controls.Add(lbQuantity);
            Controls.Add(lbNotes);
            Controls.Add(txtNotes);
            Controls.Add(chkNotPlanned);
            Controls.Add(btnFecharCompra);
            Controls.Add(lblRemainingBudget);
            Controls.Add(lblTotal);
            Controls.Add(btnRemoveItem);
            Controls.Add(btnAddItem);
            Controls.Add(txtPrice);
            Controls.Add(txtQuantity);
            Controls.Add(cmbArticles);
            Controls.Add(dgvItems);
            Name = "PurchaseDetailsForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "PurchaseDetailsForm";
            Load += PurchaseDetailsForm_Load;
            ((System.ComponentModel.ISupportInitialize)dgvItems).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgvItems;
        private ComboBox cmbArticles;
        private TextBox txtQuantity;
        private TextBox txtPrice;
        private Button btnAddItem;
        private Button btnRemoveItem;
        private Label lblTotal;
        private Label lblRemainingBudget;
        private Microsoft.Data.SqlClient.SqlCommandBuilder sqlCommandBuilder1;
        private Button btnFecharCompra;
        private CheckBox chkNotPlanned;
        private TextBox txtNotes;
        private Label lbNotes;
        private Label lbQuantity;
        private Label lbPrice;
        private ComboBox cmbCategories;
        private Label label1;
    }
}