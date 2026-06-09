namespace Projeto_DA.Views
{
    partial class StatisticsForm
    {
        /// <summary>
        /// Variável necessária para o designer.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Liberta os recursos utilizados.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao designer – não modificar
        /// o conteúdo deste método no editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            // declaração dos controlos do formulário
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();

            // --- Tab 1 ---
            this.lblTituloMeses = new System.Windows.Forms.Label();
            this.dgvMeses = new System.Windows.Forms.DataGridView();
            this.lblTituloCompras = new System.Windows.Forms.Label();
            this.dgvComprasFechadas = new System.Windows.Forms.DataGridView();

            // --- Tab 2 ---
            this.lblTituloApoio = new System.Windows.Forms.Label();
            this.lblOrcamentoSugerido = new System.Windows.Forms.Label();
            this.lblOrcamentoRestante = new System.Windows.Forms.Label();
            this.lblSemanaAtual = new System.Windows.Forms.Label();
            this.lblCustoTotal = new System.Windows.Forms.Label();
            this.lblTituloLista = new System.Windows.Forms.Label();
            this.dgvListaSugerida = new System.Windows.Forms.DataGridView();
            this.btnGerarSugestao = new System.Windows.Forms.Button();

            // inicialização suspensa para evitar repaints desnecessários
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMeses)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvComprasFechadas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListaSugerida)).BeginInit();
            this.SuspendLayout();

            // ---------------------------------------------------------------
            // tabControl1
            // ---------------------------------------------------------------
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.TabIndex = 0;

            // ---------------------------------------------------------------
            // tabPage1 — Estatísticas
            // ---------------------------------------------------------------
            this.tabPage1.Controls.Add(this.lblTituloMeses);
            this.tabPage1.Controls.Add(this.dgvMeses);
            this.tabPage1.Controls.Add(this.lblTituloCompras);
            this.tabPage1.Controls.Add(this.dgvComprasFechadas);
            this.tabPage1.BackColor = System.Drawing.Color.FromArgb(28, 28, 30);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Text = "Estatísticas";
            this.tabPage1.TabIndex = 0;

            // ---------------------------------------------------------------
            // tabPage2 — Apoio à Decisão
            // ---------------------------------------------------------------
            this.tabPage2.Controls.Add(this.lblTituloApoio);
            this.tabPage2.Controls.Add(this.lblOrcamentoSugerido);
            this.tabPage2.Controls.Add(this.lblOrcamentoRestante);
            this.tabPage2.Controls.Add(this.lblSemanaAtual);
            this.tabPage2.Controls.Add(this.lblCustoTotal);
            this.tabPage2.Controls.Add(this.btnGerarSugestao);
            this.tabPage2.Controls.Add(this.lblTituloLista);
            this.tabPage2.Controls.Add(this.dgvListaSugerida);
            this.tabPage2.BackColor = System.Drawing.Color.FromArgb(28, 28, 30);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Text = "Apoio à Decisão";
            this.tabPage2.TabIndex = 1;

            // ---------------------------------------------------------------
            // TAB 1 — controlos
            // ---------------------------------------------------------------

            // título da tabela de meses
            this.lblTituloMeses.AutoSize = false;
            this.lblTituloMeses.Text = "Orçamentos vs. Total de Compras por Mês";
            this.lblTituloMeses.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblTituloMeses.ForeColor = System.Drawing.Color.White;
            this.lblTituloMeses.Location = new System.Drawing.Point(10, 10);
            this.lblTituloMeses.Size = new System.Drawing.Size(400, 24);
            this.lblTituloMeses.Name = "lblTituloMeses";

            // tabela de orçamentos por mês
            this.dgvMeses.Location = new System.Drawing.Point(10, 38);
            this.dgvMeses.Size = new System.Drawing.Size(760, 180);
            this.dgvMeses.Name = "dgvMeses";
            this.dgvMeses.TabIndex = 1;
            this.dgvMeses.ReadOnly = true;
            this.dgvMeses.AllowUserToAddRows = false;
            this.dgvMeses.AllowUserToDeleteRows = false;
            this.dgvMeses.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvMeses.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvMeses.MultiSelect = false;
            this.dgvMeses.RowHeadersVisible = false;
            // estilo escuro
            this.dgvMeses.BackgroundColor = System.Drawing.Color.FromArgb(38, 38, 40);
            this.dgvMeses.DefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(45, 45, 48);
            this.dgvMeses.DefaultCellStyle.ForeColor = System.Drawing.Color.White;
            this.dgvMeses.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.DodgerBlue;
            this.dgvMeses.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.White;
            this.dgvMeses.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(28, 28, 30);
            this.dgvMeses.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.Color.White;
            this.dgvMeses.EnableHeadersVisualStyles = false;

            // título da tabela de compras fechadas
            this.lblTituloCompras.AutoSize = false;
            this.lblTituloCompras.Text = "Compras Fechadas — Artigos Previstos vs. Não Previstos";
            this.lblTituloCompras.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblTituloCompras.ForeColor = System.Drawing.Color.White;
            this.lblTituloCompras.Location = new System.Drawing.Point(10, 230);
            this.lblTituloCompras.Size = new System.Drawing.Size(500, 24);
            this.lblTituloCompras.Name = "lblTituloCompras";

            // tabela de compras fechadas
            this.dgvComprasFechadas.Location = new System.Drawing.Point(10, 258);
            this.dgvComprasFechadas.Size = new System.Drawing.Size(760, 180);
            this.dgvComprasFechadas.Name = "dgvComprasFechadas";
            this.dgvComprasFechadas.TabIndex = 2;
            this.dgvComprasFechadas.ReadOnly = true;
            this.dgvComprasFechadas.AllowUserToAddRows = false;
            this.dgvComprasFechadas.AllowUserToDeleteRows = false;
            this.dgvComprasFechadas.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvComprasFechadas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvComprasFechadas.MultiSelect = false;
            this.dgvComprasFechadas.RowHeadersVisible = false;
            // estilo escuro
            this.dgvComprasFechadas.BackgroundColor = System.Drawing.Color.FromArgb(38, 38, 40);
            this.dgvComprasFechadas.DefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(45, 45, 48);
            this.dgvComprasFechadas.DefaultCellStyle.ForeColor = System.Drawing.Color.White;
            this.dgvComprasFechadas.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.DodgerBlue;
            this.dgvComprasFechadas.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.White;
            this.dgvComprasFechadas.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(28, 28, 30);
            this.dgvComprasFechadas.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.Color.White;
            this.dgvComprasFechadas.EnableHeadersVisualStyles = false;

            // ---------------------------------------------------------------
            // TAB 2 — controlos
            // ---------------------------------------------------------------

            // título da tab de apoio à decisão
            this.lblTituloApoio.AutoSize = false;
            this.lblTituloApoio.Text = "Apoio à Decisão";
            this.lblTituloApoio.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblTituloApoio.ForeColor = System.Drawing.Color.DodgerBlue;
            this.lblTituloApoio.Location = new System.Drawing.Point(10, 10);
            this.lblTituloApoio.Size = new System.Drawing.Size(300, 30);
            this.lblTituloApoio.Name = "lblTituloApoio";

            // label que mostra o orçamento sugerido
            this.lblOrcamentoSugerido.AutoSize = false;
            this.lblOrcamentoSugerido.Text = "Orçamento Sugerido para o Próximo Mês: (clique em Gerar)";
            this.lblOrcamentoSugerido.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblOrcamentoSugerido.ForeColor = System.Drawing.Color.LightGreen;
            this.lblOrcamentoSugerido.Location = new System.Drawing.Point(10, 45);
            this.lblOrcamentoSugerido.Size = new System.Drawing.Size(600, 24);
            this.lblOrcamentoSugerido.Name = "lblOrcamentoSugerido";

            // label que mostra o orçamento restante
            this.lblOrcamentoRestante.AutoSize = false;
            this.lblOrcamentoRestante.Text = "Orçamento Restante do Mês Atual: (clique em Gerar)";
            this.lblOrcamentoRestante.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblOrcamentoRestante.ForeColor = System.Drawing.Color.LightGreen;
            this.lblOrcamentoRestante.Location = new System.Drawing.Point(10, 72);
            this.lblOrcamentoRestante.Size = new System.Drawing.Size(600, 24);
            this.lblOrcamentoRestante.Name = "lblOrcamentoRestante";

            // label que mostra a semana atual
            this.lblSemanaAtual.AutoSize = false;
            this.lblSemanaAtual.Text = "Semana atual do mês: (clique em Gerar)";
            this.lblSemanaAtual.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblSemanaAtual.ForeColor = System.Drawing.Color.Silver;
            this.lblSemanaAtual.Location = new System.Drawing.Point(10, 100);
            this.lblSemanaAtual.Size = new System.Drawing.Size(600, 22);
            this.lblSemanaAtual.Name = "lblSemanaAtual";

            // label que mostra o custo estimado total
            this.lblCustoTotal.AutoSize = false;
            this.lblCustoTotal.Text = "Custo Estimado Total da Lista Sugerida: (clique em Gerar)";
            this.lblCustoTotal.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblCustoTotal.ForeColor = System.Drawing.Color.DodgerBlue;
            this.lblCustoTotal.Location = new System.Drawing.Point(10, 125);
            this.lblCustoTotal.Size = new System.Drawing.Size(600, 24);
            this.lblCustoTotal.Name = "lblCustoTotal";

            // botão para gerar a sugestão
            this.btnGerarSugestao.Text = "Gerar Sugestão de Lista de Compras";
            this.btnGerarSugestao.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnGerarSugestao.ForeColor = System.Drawing.Color.White;
            this.btnGerarSugestao.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnGerarSugestao.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGerarSugestao.Location = new System.Drawing.Point(10, 155);
            this.btnGerarSugestao.Size = new System.Drawing.Size(280, 34);
            this.btnGerarSugestao.Name = "btnGerarSugestao";
            this.btnGerarSugestao.TabIndex = 1;
            this.btnGerarSugestao.Click += new System.EventHandler(this.btnGerarSugestao_Click);

            // título da lista sugerida
            this.lblTituloLista.AutoSize = false;
            this.lblTituloLista.Text = "Lista de Compras Sugerida (artigos que cabem no orçamento ordenados por preferência):";
            this.lblTituloLista.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblTituloLista.ForeColor = System.Drawing.Color.White;
            this.lblTituloLista.Location = new System.Drawing.Point(10, 195);
            this.lblTituloLista.Size = new System.Drawing.Size(600, 24);
            this.lblTituloLista.Name = "lblTituloLista";

            // tabela com a lista sugerida
            this.dgvListaSugerida.Location = new System.Drawing.Point(10, 222);
            this.dgvListaSugerida.Size = new System.Drawing.Size(760, 210);
            this.dgvListaSugerida.Name = "dgvListaSugerida";
            this.dgvListaSugerida.TabIndex = 2;
            this.dgvListaSugerida.ReadOnly = true;
            this.dgvListaSugerida.AllowUserToAddRows = false;
            this.dgvListaSugerida.AllowUserToDeleteRows = false;
            this.dgvListaSugerida.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvListaSugerida.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvListaSugerida.MultiSelect = false;
            this.dgvListaSugerida.RowHeadersVisible = false;
            // estilo escuro
            this.dgvListaSugerida.BackgroundColor = System.Drawing.Color.FromArgb(38, 38, 40);
            this.dgvListaSugerida.DefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(45, 45, 48);
            this.dgvListaSugerida.DefaultCellStyle.ForeColor = System.Drawing.Color.White;
            this.dgvListaSugerida.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.DodgerBlue;
            this.dgvListaSugerida.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.White;
            this.dgvListaSugerida.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(28, 28, 30);
            this.dgvListaSugerida.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.Color.White;
            this.dgvListaSugerida.EnableHeadersVisualStyles = false;

            // ---------------------------------------------------------------
            // StatisticsForm — configuração geral do formulário
            // ---------------------------------------------------------------
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(28, 28, 30);
            this.ClientSize = new System.Drawing.Size(800, 500);
            this.Controls.Add(this.tabControl1);
            this.Name = "StatisticsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Estatísticas";
            this.Load += new System.EventHandler(this.StatisticsForm_Load);

            // retomar layouts
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMeses)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvComprasFechadas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListaSugerida)).EndInit();
            this.ResumeLayout(false);
        }

        #endregion

        // declaração dos campos privados para todos os controlos
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;

        // tab 1
        private System.Windows.Forms.Label lblTituloMeses;
        private System.Windows.Forms.DataGridView dgvMeses;
        private System.Windows.Forms.Label lblTituloCompras;
        private System.Windows.Forms.DataGridView dgvComprasFechadas;

        // tab 2
        private System.Windows.Forms.Label lblTituloApoio;
        private System.Windows.Forms.Label lblOrcamentoSugerido;
        private System.Windows.Forms.Label lblOrcamentoRestante;
        private System.Windows.Forms.Label lblSemanaAtual;
        private System.Windows.Forms.Label lblCustoTotal;
        private System.Windows.Forms.Button btnGerarSugestao;
        private System.Windows.Forms.Label lblTituloLista;
        private System.Windows.Forms.DataGridView dgvListaSugerida;
    }
}