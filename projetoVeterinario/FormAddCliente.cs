using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace projetoVeterinario
{
    public partial class FormAddCliente : Form
    {
        public FormAddCliente()
        {
            InitializeComponent();
        }

        string connectionString = "Data Source=localhost\\SQLEXPRESS;Initial catalog=projeto_veterinario;Integrated Security=True";

        //botão de cadastro
        private void btn_AddCliente_Click(object sender, EventArgs e)
        {
            string nome = textBox_nome.Text.Trim();
            string endereco = textBox_Endereco.Text.Trim();
            int novoId = -1;

            if (string.IsNullOrEmpty(nome) || string.IsNullOrEmpty(endereco)){
                MessageBox.Show("Preencha o nome e endereço.");
                return;
            }

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                string query = @"INSERT INTO cliente (nome, endereco) values (@nome, @endereco); SELECT SCOPE_IDENTITY()";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@nome", nome);
                    cmd.Parameters.AddWithValue("@endereco", endereco);

                    object result = cmd.ExecuteScalar();

                    if (result != null)
                    {
                        novoId = Convert.ToInt32(Convert.ToDecimal(result));
                        MessageBox.Show("Cliente adicionado!");

                        FormClientInfo formInfo = new FormClientInfo(novoId);
                        formInfo.ShowDialog();

                        this.Close();

                    }
                    else
                    {
                        MessageBox.Show("Erro ao obter o ID do novo cliente!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }


                }
            }
        }
    }
}
