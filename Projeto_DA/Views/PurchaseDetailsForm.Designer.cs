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
            btnSugestao = new Button();
            lblTotal = new Label();
            lblRemainingBudget = new Label();
            btnFecharCompra = new Button();
            chkNotPlanned = new CheckBox();
            txtNotes = new TextBox();
            lbNotes = new Label();
            lbQuantity = new Label();
            lbPrice = new Label();
            cmbCategories = new ComboBox();
            label1 = new Label();
            lbArtigo = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvItems).BeginInit();
            SuspendLayout();
            // 
            // lblRemainingBudget — orçamento restante (topo esquerdo)
            // 
            lblRemainingBudget.AutoSize = true;
            lblRemainingBudget.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 204);
            lblRemainingBudget.ForeColor = Color.LightGreen;
            lblRemainingBudget.Location = new Point(14, 12);
            lblRemainingBudget.Name = "lblRemainingBudget";
            lblRemainingBudget.Size = new Size(100, 32);
            lblRemainingBudget.TabIndex = 7;
            lblRemainingBudget.Text = "Orçamento Restante:";
            // 
            // btnFecharCompra — botão fechar compra (topo direito)
            // 
            btnFecharCompra.FlatStyle = FlatStyle.Flat;
            btnFecharCompra.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 204);
            btnFecharCompra.ForeColor = SystemColors.ControlLightLight;
            btnFecharCompra.Location = new Point(750, 10);
            btnFecharCompra.Name = "btnFecharCompra";
            btnFecharCompra.Size = new Size(130, 38);
            btnFecharCompra.TabIndex = 8;
            btnFecharCompra.Text = "Fechar Compra";
            btnFecharCompra.UseVisualStyleBackColor = true;
            // 
            // chkNotPlanned — checkbox artigo não previsto
            // 
            chkNotPlanned.AutoSize = true;
            chkNotPlanned.FlatStyle = FlatStyle.Flat;
            chkNotPlanned.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point, 204);
            chkNotPlanned.ForeColor = SystemColors.ControlLightLight;
            chkNotPlanned.Location = new Point(600, 18);
            chkNotPlanned.Name = "chkNotPlanned";
            chkNotPlanned.Size = new Size(145, 23);
            chkNotPlanned.TabIndex = 9;
            chkNotPlanned.Text = "Artigo Não Previsto";
            chkNotPlanned.UseVisualStyleBackColor = true;
            // 
            // label1 — label "Categoria"
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 204);
            label1.ForeColor = SystemColors.ControlLightLight;
            label1.Location = new Point(14, 58);
            label1.Name = "label1";
            label1.Size = new Size(63, 15);
            label1.TabIndex = 15;
            label1.Text = "Categoria";
            // 
            // cmbCategories — combo box de categorias
            // 
            cmbCategories.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbCategories.FormattingEnabled = true;
            cmbCategories.Location = new Point(14, 76);
            cmbCategories.Name = "cmbCategories";
            cmbCategories.Size = new Size(140, 23);
            cmbCategories.TabIndex = 14;
            cmbCategories.SelectedIndexChanged += cmbCategories_SelectedIndexChanged;
            // 
            // lbArtigo — label "Artigo"
            // 
            lbArtigo.AutoSize = true;
            lbArtigo.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 204);
            lbArtigo.ForeColor = SystemColors.ControlLightLight;
            lbArtigo.Location = new Point(164, 58);
            lbArtigo.Name = "lbArtigo";
            lbArtigo.Size = new Size(42, 15);
            lbArtigo.TabIndex = 16;
            lbArtigo.Text = "Artigo";
            // 
            // cmbArticles — combo box de artigos
            // 
            cmbArticles.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbArticles.FormattingEnabled = true;
            cmbArticles.Location = new Point(164, 76);
            cmbArticles.Name = "cmbArticles";
            cmbArticles.Size = new Size(160, 23);
            cmbArticles.TabIndex = 1;
            // 
            // lbQuantity — label "Quantidade"
            // 
            lbQuantity.AutoSize = true;
            lbQuantity.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 204);
            lbQuantity.ForeColor = SystemColors.ControlLightLight;
            lbQuantity.Location = new Point(334, 58);
            lbQuantity.Name = "lbQuantity";
            lbQuantity.Size = new Size(72, 15);
            lbQuantity.TabIndex = 12;
            lbQuantity.Text = "Quantidade";
            // 
            // txtQuantity — campo de quantidade
            // 
            txtQuantity.Location = new Point(334, 76);
            txtQuantity.Name = "txtQuantity";
            txtQuantity.Size = new Size(90, 23);
            txtQuantity.TabIndex = 2;
            // 
            // lbPrice — label "Preço"
            // 
            lbPrice.AutoSize = true;
            lbPrice.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 204);
            lbPrice.ForeColor = SystemColors.ControlLightLight;
            lbPrice.Location = new Point(434, 58);
            lbPrice.Name = "lbPrice";
            lbPrice.Size = new Size(40, 15);
            lbPrice.TabIndex = 13;
            lbPrice.Text = "Preço";
            // 
            // txtPrice — campo de preço
            // 
            txtPrice.Location = new Point(434, 76);
            txtPrice.Name = "txtPrice";
            txtPrice.Size = new Size(90, 23);
            txtPrice.TabIndex = 3;
            // 
            // btnAddItem — botão adicionar
            // 
            btnAddItem.FlatStyle = FlatStyle.Flat;
            btnAddItem.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 204);
            btnAddItem.ForeColor = SystemColors.ControlLightLight;
            btnAddItem.Location = new Point(540, 68);
            btnAddItem.Name = "btnAddItem";
            btnAddItem.Size = new Size(90, 36);
            btnAddItem.TabIndex = 4;
            btnAddItem.Text = "Adicionar";
            btnAddItem.UseVisualStyleBackColor = true;
            btnAddItem.Click += btnAddItem_Click;
            // 
            // btnRemoveItem — botão remover
            // 
            btnRemoveItem.FlatStyle = FlatStyle.Flat;
            btnRemoveItem.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 204);
            btnRemoveItem.ForeColor = SystemColors.ControlLightLight;
            btnRemoveItem.Location = new Point(640, 68);
            btnRemoveItem.Name = "btnRemoveItem";
            btnRemoveItem.Size = new Size(90, 36);
            btnRemoveItem.TabIndex = 5;
            btnRemoveItem.Text = "Remover";
            btnRemoveItem.UseVisualStyleBackColor = true;
            // 
            // btnSugestao — botão sugerir artigos
            // 
            btnSugestao.FlatStyle = FlatStyle.Flat;
            btnSugestao.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 204);
            btnSugestao.ForeColor = SystemColors.ControlLightLight;
            btnSugestao.Location = new Point(740, 68);
            btnSugestao.Name = "btnSugestao";
            btnSugestao.Size = new Size(140, 36);
            btnSugestao.TabIndex = 6;
            btnSugestao.Text = "Sugerir Artigos";
            btnSugestao.UseVisualStyleBackColor = true;
            // 
            // dgvItems — tabela de itens da compra
            // 
            dgvItems.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvItems.Location = new Point(14, 115);
            dgvItems.Name = "dgvItems";
            dgvItems.Size = new Size(866, 260);
            dgvItems.TabIndex = 0;
            dgvItems.ReadOnly = true;
            dgvItems.AllowUserToAddRows = false;
            dgvItems.AllowUserToDeleteRows = false;
            dgvItems.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvItems.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvItems.MultiSelect = false;
            dgvItems.RowHeadersVisible = false;
            // estilo escuro para a tabela
            dgvItems.BackgroundColor = Color.FromArgb(38, 38, 40);
            dgvItems.DefaultCellStyle.BackColor = Color.FromArgb(45, 45, 48);
            dgvItems.DefaultCellStyle.ForeColor = Color.White;
            dgvItems.DefaultCellStyle.SelectionBackColor = Color.DodgerBlue;
            dgvItems.DefaultCellStyle.SelectionForeColor = Color.White;
            dgvItems.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(28, 28, 30);
            dgvItems.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvItems.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            dgvItems.EnableHeadersVisualStyles = false;
            dgvItems.GridColor = Color.FromArgb(60, 60, 65);
            dgvItems.BorderStyle = BorderStyle.None;
            // 
            // lbNotes — label "Observações"
            // 
            lbNotes.AutoSize = true;
            lbNotes.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point, 204);
            lbNotes.ForeColor = SystemColors.ControlLightLight;
            lbNotes.Location = new Point(14, 388);
            lbNotes.Name = "lbNotes";
            lbNotes.Size = new Size(99, 19);
            lbNotes.TabIndex = 11;
            lbNotes.Text = "Observações:";
            // 
            // txtNotes — campo de observações
            // 
            txtNotes.Location = new Point(14, 412);
            txtNotes.Name = "txtNotes";
            txtNotes.Size = new Size(400, 23);
            txtNotes.TabIndex = 10;
            // 
            // lblTotal — total da compra (canto inferior direito)
            // 
            lblTotal.AutoSize = true;
            lblTotal.Font = new Font("Segoe UI", 14F, FontStyle.Bold, GraphicsUnit.Point, 204);
            lblTotal.ForeColor = Color.DodgerBlue;
            lblTotal.Location = new Point(540, 405);
            lblTotal.Name = "lblTotal";
            lblTotal.Size = new Size(0, 25);
            lblTotal.TabIndex = 6;
            // 
            // PurchaseDetailsForm — configuração geral do formulário
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(28, 28, 30);
            ClientSize = new Size(900, 455);
            Controls.Add(lbArtigo);
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
            Controls.Add(btnSugestao);
            Controls.Add(txtPrice);
            Controls.Add(txtQuantity);
            Controls.Add(cmbArticles);
            Controls.Add(dgvItems);
            Name = "PurchaseDetailsForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Detalhes da Compra";
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
        private Button btnSugestao;
        private Label lblTotal;
        private Label lblRemainingBudget;
        private Button btnFecharCompra;
        private CheckBox chkNotPlanned;
        private TextBox txtNotes;
        private Label lbNotes;
        private Label lbQuantity;
        private Label lbPrice;
        private ComboBox cmbCategories;
        private Label label1;
        private Label lbArtigo;
    }
}