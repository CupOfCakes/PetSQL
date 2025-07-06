namespace projetoVeterinario
{
    partial class FormClientInfo
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
            label_Nome = new Label();
            textBox_Nome = new TextBox();
            label_Contatos = new Label();
            label_Animais = new Label();
            dataGrid_Animais = new DataGridView();
            btn_editar = new Button();
            btn_SalvarNome = new Button();
            btn_Voltar = new Button();
            btn_AddContato = new Button();
            btn_RemoverContato = new Button();
            textBox_AddContato = new TextBox();
            btn_Editar_Contato = new Button();
            textBox_AddAnimal = new TextBox();
            comboBox_AddRaca = new ComboBox();
            btn_AddAnimal = new Button();
            textBox_AddIdadeAnimal = new TextBox();
            btn_EditarAnimal = new Button();
            btn_ExcluirAnimal = new Button();
            label_Endereo = new Label();
            textBox_Endereco = new TextBox();
            btn_SalvarEndereco = new Button();
            flowLayoutPanelContatos = new FlowLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)dataGrid_Animais).BeginInit();
            SuspendLayout();
            // 
            // label_Nome
            // 
            label_Nome.AutoSize = true;
            label_Nome.Location = new Point(12, 19);
            label_Nome.Name = "label_Nome";
            label_Nome.Size = new Size(53, 20);
            label_Nome.TabIndex = 0;
            label_Nome.Text = "Nome:";
            // 
            // textBox_Nome
            // 
            textBox_Nome.Enabled = false;
            textBox_Nome.Location = new Point(68, 12);
            textBox_Nome.Name = "textBox_Nome";
            textBox_Nome.Size = new Size(293, 27);
            textBox_Nome.TabIndex = 1;
            // 
            // label_Contatos
            // 
            label_Contatos.AutoSize = true;
            label_Contatos.Location = new Point(12, 94);
            label_Contatos.Name = "label_Contatos";
            label_Contatos.Size = new Size(71, 20);
            label_Contatos.TabIndex = 3;
            label_Contatos.Text = "Contatos:";
            // 
            // label_Animais
            // 
            label_Animais.AutoSize = true;
            label_Animais.Location = new Point(12, 257);
            label_Animais.Name = "label_Animais";
            label_Animais.Size = new Size(65, 20);
            label_Animais.TabIndex = 4;
            label_Animais.Text = "Animais:";
            // 
            // dataGrid_Animais
            // 
            dataGrid_Animais.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGrid_Animais.Location = new Point(12, 280);
            dataGrid_Animais.MultiSelect = false;
            dataGrid_Animais.Name = "dataGrid_Animais";
            dataGrid_Animais.ReadOnly = true;
            dataGrid_Animais.RowHeadersWidth = 51;
            dataGrid_Animais.Size = new Size(508, 159);
            dataGrid_Animais.TabIndex = 5;
            dataGrid_Animais.CellClick += dataGrid_Animais_CellClick;
            dataGrid_Animais.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            // 
            // btn_editar
            // 
            btn_editar.Location = new Point(121, 501);
            btn_editar.Name = "btn_editar";
            btn_editar.Size = new Size(94, 29);
            btn_editar.TabIndex = 6;
            btn_editar.Text = "Editar";
            btn_editar.UseVisualStyleBackColor = true;
            btn_editar.Click += btn_editar_Click;
            // 
            // btn_SalvarNome
            // 
            btn_SalvarNome.Location = new Point(367, 12);
            btn_SalvarNome.Name = "btn_SalvarNome";
            btn_SalvarNome.Size = new Size(123, 29);
            btn_SalvarNome.TabIndex = 7;
            btn_SalvarNome.Text = "Salvar nome";
            btn_SalvarNome.UseVisualStyleBackColor = true;
            btn_SalvarNome.Visible = false;
            btn_SalvarNome.Click += btn_salvarNome_Click;
            // 
            // btn_Voltar
            // 
            btn_Voltar.Location = new Point(121, 501);
            btn_Voltar.Name = "btn_Voltar";
            btn_Voltar.Size = new Size(94, 29);
            btn_Voltar.TabIndex = 8;
            btn_Voltar.Text = "Voltar";
            btn_Voltar.UseVisualStyleBackColor = true;
            btn_Voltar.Visible = false;
            btn_Voltar.Click += btn_Voltar_Click;
            // 
            // btn_AddContato
            // 
            btn_AddContato.Location = new Point(146, 209);
            btn_AddContato.Name = "btn_AddContato";
            btn_AddContato.Size = new Size(103, 29);
            btn_AddContato.TabIndex = 9;
            btn_AddContato.Text = "Add contato";
            btn_AddContato.UseVisualStyleBackColor = true;
            btn_AddContato.Visible = false;
            btn_AddContato.Click += btn_AddContato_Click;
            // 
            // btn_RemoverContato
            // 
            btn_RemoverContato.Location = new Point(250, 208);
            btn_RemoverContato.Name = "btn_RemoverContato";
            btn_RemoverContato.Size = new Size(94, 29);
            btn_RemoverContato.TabIndex = 10;
            btn_RemoverContato.Text = "Exc contato";
            btn_RemoverContato.UseVisualStyleBackColor = true;
            btn_RemoverContato.Visible = false;
            btn_RemoverContato.Click += btn_RemoverContato_Click;
            // 
            // textBox_AddContato
            // 
            textBox_AddContato.Location = new Point(15, 209);
            textBox_AddContato.MaxLength = 12;
            textBox_AddContato.Name = "textBox_AddContato";
            textBox_AddContato.Size = new Size(125, 27);
            textBox_AddContato.TabIndex = 11;
            textBox_AddContato.Visible = false;
            textBox_AddContato.KeyPress += textBox_AddContato_KeyPress;
            // 
            // btn_Editar_Contato
            // 
            btn_Editar_Contato.Location = new Point(146, 209);
            btn_Editar_Contato.Name = "btn_Editar_Contato";
            btn_Editar_Contato.Size = new Size(103, 29);
            btn_Editar_Contato.TabIndex = 12;
            btn_Editar_Contato.Text = "Edit contato";
            btn_Editar_Contato.UseVisualStyleBackColor = true;
            btn_Editar_Contato.Visible = false;
            btn_Editar_Contato.Click += btn_Editar_Contato_Click;
            // 
            // textBox_AddAnimal
            // 
            textBox_AddAnimal.Location = new Point(12, 445);
            textBox_AddAnimal.Name = "textBox_AddAnimal";
            textBox_AddAnimal.Size = new Size(125, 27);
            textBox_AddAnimal.TabIndex = 13;
            textBox_AddAnimal.Visible = false;
            // 
            // comboBox_AddRaca
            // 
            comboBox_AddRaca.FormattingEnabled = true;
            comboBox_AddRaca.Location = new Point(204, 445);
            comboBox_AddRaca.Name = "comboBox_AddRaca";
            comboBox_AddRaca.Size = new Size(116, 28);
            comboBox_AddRaca.TabIndex = 15;
            comboBox_AddRaca.Text = "Raça";
            comboBox_AddRaca.Visible = false;
            // 
            // btn_AddAnimal
            // 
            btn_AddAnimal.Location = new Point(326, 444);
            btn_AddAnimal.Name = "btn_AddAnimal";
            btn_AddAnimal.Size = new Size(94, 29);
            btn_AddAnimal.TabIndex = 16;
            btn_AddAnimal.Text = "Add animal";
            btn_AddAnimal.UseVisualStyleBackColor = true;
            btn_AddAnimal.Click += btn_AddAnimal_Click;
            // 
            // textBox_AddIdadeAnimal
            // 
            textBox_AddIdadeAnimal.Location = new Point(143, 445);
            textBox_AddIdadeAnimal.Name = "textBox_AddIdadeAnimal";
            textBox_AddIdadeAnimal.Size = new Size(55, 27);
            textBox_AddIdadeAnimal.TabIndex = 17;
            textBox_AddIdadeAnimal.Visible = false;
            textBox_AddIdadeAnimal.KeyPress += textBox_AddIdadeAnimal_KeyPress;
            // 
            // btn_EditarAnimal
            // 
            btn_EditarAnimal.Location = new Point(326, 443);
            btn_EditarAnimal.Name = "btn_EditarAnimal";
            btn_EditarAnimal.Size = new Size(94, 29);
            btn_EditarAnimal.TabIndex = 18;
            btn_EditarAnimal.Text = "Edit animal";
            btn_EditarAnimal.UseVisualStyleBackColor = true;
            btn_EditarAnimal.Visible = false;
            btn_EditarAnimal.Click += btn_EditarAnimal_Click;
            // 
            // btn_ExcluirAnimal
            // 
            btn_ExcluirAnimal.Location = new Point(426, 445);
            btn_ExcluirAnimal.Name = "btn_ExcluirAnimal";
            btn_ExcluirAnimal.Size = new Size(94, 29);
            btn_ExcluirAnimal.TabIndex = 19;
            btn_ExcluirAnimal.Text = "Exc Animal";
            btn_ExcluirAnimal.UseVisualStyleBackColor = true;
            btn_ExcluirAnimal.Visible = false;
            btn_ExcluirAnimal.Click += btn_ExcluirAnimal_Click;
            // 
            // label_Endereo
            // 
            label_Endereo.AutoSize = true;
            label_Endereo.Location = new Point(12, 56);
            label_Endereo.Name = "label_Endereo";
            label_Endereo.Size = new Size(74, 20);
            label_Endereo.TabIndex = 20;
            label_Endereo.Text = "Endereço:";
            // 
            // textBox_Endereco
            // 
            textBox_Endereco.Enabled = false;
            textBox_Endereco.Location = new Point(92, 53);
            textBox_Endereco.Name = "textBox_Endereco";
            textBox_Endereco.Size = new Size(269, 27);
            textBox_Endereco.TabIndex = 21;
            // 
            // btn_SalvarEndereco
            // 
            btn_SalvarEndereco.Location = new Point(367, 53);
            btn_SalvarEndereco.Name = "btn_SalvarEndereco";
            btn_SalvarEndereco.Size = new Size(123, 29);
            btn_SalvarEndereco.TabIndex = 22;
            btn_SalvarEndereco.Text = "Salvar endereco";
            btn_SalvarEndereco.UseVisualStyleBackColor = true;
            btn_SalvarEndereco.Visible = false;
            btn_SalvarEndereco.Click += btn_SalvarEndereco_Click;
            // 
            // flowLayoutPanelContatos
            // 
            flowLayoutPanelContatos.Enabled = false;
            flowLayoutPanelContatos.Location = new Point(12, 121);
            flowLayoutPanelContatos.Name = "flowLayoutPanelContatos";
            flowLayoutPanelContatos.Size = new Size(349, 72);
            flowLayoutPanelContatos.TabIndex = 23;
            flowLayoutPanelContatos.Click += flowLayoutPanelContatos_Click;
            // 
            // FormClientInfo
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(529, 551);
            Controls.Add(flowLayoutPanelContatos);
            Controls.Add(btn_SalvarEndereco);
            Controls.Add(textBox_Endereco);
            Controls.Add(label_Endereo);
            Controls.Add(btn_ExcluirAnimal);
            Controls.Add(btn_EditarAnimal);
            Controls.Add(textBox_AddIdadeAnimal);
            Controls.Add(btn_AddAnimal);
            Controls.Add(comboBox_AddRaca);
            Controls.Add(textBox_AddAnimal);
            Controls.Add(btn_Editar_Contato);
            Controls.Add(textBox_AddContato);
            Controls.Add(btn_RemoverContato);
            Controls.Add(btn_AddContato);
            Controls.Add(btn_Voltar);
            Controls.Add(btn_SalvarNome);
            Controls.Add(btn_editar);
            Controls.Add(dataGrid_Animais);
            Controls.Add(label_Animais);
            Controls.Add(label_Contatos);
            Controls.Add(textBox_Nome);
            Controls.Add(label_Nome);
            Name = "FormClientInfo";
            Text = "FormClientInfo";
            Click += FormClientInfo_Click;
            ((System.ComponentModel.ISupportInitialize)dataGrid_Animais).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }


        #endregion

        private Label label_Nome;
        private TextBox textBox_Nome;
        private Label label_Contatos;
        private Label label_Animais;
        private DataGridView dataGrid_Animais;
        private Button btn_editar;
        private Button btn_SalvarNome;
        private Button btn_Voltar;
        private Button btn_AddContato;
        private Button btn_RemoverContato;
        private TextBox textBox_AddContato;
        private Button btn_Editar_Contato;
        private TextBox textBox_AddAnimal;
        private ComboBox comboBox_AddRaca;
        private Button btn_AddAnimal;
        private TextBox textBox_AddIdadeAnimal;
        private Button btn_EditarAnimal;
        private Button btn_ExcluirAnimal;
        private Label label_Endereo;
        private TextBox textBox_Endereco;
        private Button btn_SalvarEndereco;
        private FlowLayoutPanel flowLayoutPanelContatos;
    }
}