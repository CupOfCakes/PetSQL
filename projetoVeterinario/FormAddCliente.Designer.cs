namespace projetoVeterinario
{
    partial class FormAddCliente
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
            textBox_nome = new TextBox();
            label_Endereco = new Label();
            textBox_Endereco = new TextBox();
            btn_AddCliente = new Button();
            SuspendLayout();
            // 
            // label_Nome
            // 
            label_Nome.AutoSize = true;
            label_Nome.Location = new Point(12, 9);
            label_Nome.Name = "label_Nome";
            label_Nome.Size = new Size(53, 20);
            label_Nome.TabIndex = 0;
            label_Nome.Text = "Nome:";
            // 
            // textBox_nome
            // 
            textBox_nome.Location = new Point(68, 6);
            textBox_nome.Name = "textBox_nome";
            textBox_nome.Size = new Size(270, 27);
            textBox_nome.TabIndex = 1;
            // 
            // label_Endereco
            // 
            label_Endereco.AutoSize = true;
            label_Endereco.Location = new Point(12, 48);
            label_Endereco.Name = "label_Endereco";
            label_Endereco.Size = new Size(74, 20);
            label_Endereco.TabIndex = 2;
            label_Endereco.Text = "Endereço:";
            // 
            // textBox_Endereco
            // 
            textBox_Endereco.Location = new Point(92, 45);
            textBox_Endereco.Name = "textBox_Endereco";
            textBox_Endereco.Size = new Size(246, 27);
            textBox_Endereco.TabIndex = 3;
            // 
            // btn_AddCliente
            // 
            btn_AddCliente.Location = new Point(107, 87);
            btn_AddCliente.Name = "btn_AddCliente";
            btn_AddCliente.Size = new Size(140, 29);
            btn_AddCliente.TabIndex = 4;
            btn_AddCliente.Text = "Cadastrar cliente";
            btn_AddCliente.UseVisualStyleBackColor = true;
            btn_AddCliente.Click += btn_AddCliente_Click;
            // 
            // FormAddCliente
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(350, 128);
            Controls.Add(btn_AddCliente);
            Controls.Add(textBox_Endereco);
            Controls.Add(label_Endereco);
            Controls.Add(textBox_nome);
            Controls.Add(label_Nome);
            Name = "FormAddCliente";
            Text = "Novo cliente";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label_Nome;
        private TextBox textBox_nome;
        private Label label_Endereco;
        private TextBox textBox_Endereco;
        private Button btn_AddCliente;
    }
}