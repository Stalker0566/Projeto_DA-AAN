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
            ((System.ComponentModel.ISupportInitialize)dgvItems).BeginInit();
            SuspendLayout();
            // 
            // dgvItems
            // 
            dgvItems.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvItems.Location = new Point(14, 140);
            dgvItems.Margin = new Padding(3, 4, 3, 4);
            dgvItems.Name = "dgvItems";
            dgvItems.RowHeadersWidth = 51;
            dgvItems.Size = new Size(887, 287);
            dgvItems.TabIndex = 0;
            // 
            // cmbArticles
            // 
            cmbArticles.FormattingEnabled = true;
            cmbArticles.Location = new Point(14, 92);
            cmbArticles.Margin = new Padding(3, 4, 3, 4);
            cmbArticles.Name = "cmbArticles";
            cmbArticles.Size = new Size(138, 28);
            cmbArticles.TabIndex = 1;
            // 
            // txtQuantity
            // 
            txtQuantity.Location = new Point(158, 92);
            txtQuantity.Margin = new Padding(3, 4, 3, 4);
            txtQuantity.Name = "txtQuantity";
            txtQuantity.Size = new Size(114, 27);
            txtQuantity.TabIndex = 2;
            // 
            // txtPrice
            // 
            txtPrice.Location = new Point(278, 92);
            txtPrice.Margin = new Padding(3, 4, 3, 4);
            txtPrice.Name = "txtPrice";
            txtPrice.Size = new Size(114, 27);
            txtPrice.TabIndex = 3;
            // 
            // btnAddItem
            // 
            btnAddItem.FlatStyle = FlatStyle.Flat;
            btnAddItem.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 204);
            btnAddItem.ForeColor = SystemColors.ControlLightLight;
            btnAddItem.Location = new Point(495, 80);
            btnAddItem.Margin = new Padding(3, 4, 3, 4);
            btnAddItem.Name = "btnAddItem";
            btnAddItem.Size = new Size(114, 48);
            btnAddItem.TabIndex = 4;
            btnAddItem.Text = "Adicionar";
            btnAddItem.UseVisualStyleBackColor = true;
            // 
            // btnRemoveItem
            // 
            btnRemoveItem.FlatStyle = FlatStyle.Flat;
            btnRemoveItem.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 204);
            btnRemoveItem.ForeColor = SystemColors.ControlLightLight;
            btnRemoveItem.Location = new Point(615, 80);
            btnRemoveItem.Margin = new Padding(3, 4, 3, 4);
            btnRemoveItem.Name = "btnRemoveItem";
            btnRemoveItem.Size = new Size(114, 48);
            btnRemoveItem.TabIndex = 5;
            btnRemoveItem.Text = "Remover";
            btnRemoveItem.UseVisualStyleBackColor = true;
            // 
            // lblTotal
            // 
            lblTotal.AutoSize = true;
            lblTotal.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 204);
            lblTotal.ForeColor = SystemColors.ControlLightLight;
            lblTotal.Location = new Point(807, 92);
            lblTotal.Name = "lblTotal";
            lblTotal.Size = new Size(0, 32);
            lblTotal.TabIndex = 6;
            // 
            // PurchaseDetailsForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(28, 28, 30);
            ClientSize = new Size(914, 600);
            Controls.Add(lblTotal);
            Controls.Add(btnRemoveItem);
            Controls.Add(btnAddItem);
            Controls.Add(txtPrice);
            Controls.Add(txtQuantity);
            Controls.Add(cmbArticles);
            Controls.Add(dgvItems);
            Margin = new Padding(3, 4, 3, 4);
            Name = "PurchaseDetailsForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "PurchaseDetailsForm";
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
    }
}