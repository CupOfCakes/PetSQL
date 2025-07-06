namespace projetoVeterinario
{
    partial class Form1
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
            label_filtro = new Label();
            label_busca = new Label();
            textBox_busca = new TextBox();
            button_filtro = new Button();
            dataGrid = new DataGridView();
            label_ordernar = new Label();
            cmb_ordernar = new ComboBox();
            btn_AddCliente = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGrid).BeginInit();
            SuspendLayout();
            // 
            // label_filtro
            // 
            label_filtro.AutoSize = true;
            label_filtro.Location = new Point(15, 14);
            label_filtro.Name = "label_filtro";
            label_filtro.Size = new Size(52, 20);
            label_filtro.TabIndex = 0;
            label_filtro.Text = "Filtros:";
            // 
            // label_busca
            // 
            label_busca.AutoSize = true;
            label_busca.Location = new Point(15, 55);
            label_busca.Name = "label_busca";
            label_busca.Size = new Size(50, 20);
            label_busca.TabIndex = 1;
            label_busca.Text = "Busca:";
            // 
            // textBox_busca
            // 
            textBox_busca.Location = new Point(71, 52);
            textBox_busca.Name = "textBox_busca";
            textBox_busca.Size = new Size(125, 27);
            textBox_busca.TabIndex = 2;
            // 
            // button_filtro
            // 
            button_filtro.Location = new Point(291, 85);
            button_filtro.Name = "button_filtro";
            button_filtro.Size = new Size(295, 29);
            button_filtro.TabIndex = 3;
            button_filtro.Text = "Aplicar filtros";
            button_filtro.UseVisualStyleBackColor = true;
            button_filtro.Click += btnAplicarFiltros_Click;
            // 
            // dataGrid
            // 
            dataGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGrid.Location = new Point(12, 120);
            dataGrid.Name = "dataGrid";
            dataGrid.RowHeadersWidth = 51;
            dataGrid.Size = new Size(574, 318);
            dataGrid.TabIndex = 4;
            dataGrid.CellClick += dataGrid_delete_Click;
            dataGrid.CellDoubleClick += dataGrid_CellDoubleClick;
            // 
            // label_ordernar
            // 
            label_ordernar.AutoSize = true;
            label_ordernar.Location = new Point(198, 54);
            label_ordernar.Name = "label_ordernar";
            label_ordernar.Size = new Size(98, 20);
            label_ordernar.TabIndex = 5;
            label_ordernar.Text = "Ordernar por:";
            // 
            // cmb_ordernar
            // 
            cmb_ordernar.FormattingEnabled = true;
            cmb_ordernar.Items.AddRange(new object[] { "", "cliente em ordem alfabetica", "mais animais", "menos animais" });
            cmb_ordernar.Location = new Point(291, 51);
            cmb_ordernar.Name = "cmb_ordernar";
            cmb_ordernar.Size = new Size(151, 28);
            cmb_ordernar.TabIndex = 7;
            // 
            // btn_AddCliente
            // 
            btn_AddCliente.Location = new Point(12, 85);
            btn_AddCliente.Name = "btn_AddCliente";
            btn_AddCliente.Size = new Size(273, 29);
            btn_AddCliente.TabIndex = 8;
            btn_AddCliente.Text = "Adicionar Cliente";
            btn_AddCliente.UseVisualStyleBackColor = true;
            btn_AddCliente.Click += btn_AddCliente_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(595, 450);
            Controls.Add(btn_AddCliente);
            Controls.Add(cmb_ordernar);
            Controls.Add(label_ordernar);
            Controls.Add(dataGrid);
            Controls.Add(button_filtro);
            Controls.Add(textBox_busca);
            Controls.Add(label_busca);
            Controls.Add(label_filtro);
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)dataGrid).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        private void DataGrid_delete_Click(object sender, DataGridViewCellEventArgs e)
        {
            throw new NotImplementedException();
        }

        #endregion

        private Label label_filtro;
        private Label label_busca;
        private TextBox textBox_busca;
        private Button button_filtro;
        private DataGridView dataGrid;
        private Label label_ordernar;
        private ComboBox cmb_ordernar;
        private Button btn_AddCliente;
    }
}
