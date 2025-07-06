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
using System.Data;
using System.Data.SqlClient;
using static System.Runtime.InteropServices.JavaScript.JSType;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;


namespace projetoVeterinario
{
    public partial class FormClientInfo : Form
    {
        //variaveis globais
        bool edicao = false;
        private int clienteId;
        string connectionString = "Data Source=localhost\\SQLEXPRESS;Initial catalog=projeto_veterinario;Integrated Security=True";
        private Label selectedLabel = null;

        public FormClientInfo(int clienteId)
        {
            InitializeComponent();
            this.clienteId = clienteId;
            CarregarDados(clienteId);
            AtivarEdicao(false);
            carregarComboBoxs_Add();
            this.Click += desmarcarDataGrid;
        }


        //carregar dados da pagina
        private void CarregarDados(int clienteId)
        {

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                //nome e endereco do cliente
                string query = "select c.nome, c.endereco from cliente c where c.id = @id";

                conn.Open();

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id", clienteId);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            textBox_Nome.Text = reader["nome"].ToString();
                            textBox_Endereco.Text = reader["endereco"].ToString();
                        }

                    }

                }
                //contatos
                // Configurações iniciais (uma vez, tipo no Load do form ou no construtor)
                flowLayoutPanelContatos.Controls.Clear();

                using (SqlCommand cmd = new SqlCommand("SELECT telefone FROM telefone WHERE id_cliente = @id", conn))
                {
                    cmd.Parameters.AddWithValue("@id", clienteId);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        flowLayoutPanelContatos.Controls.Clear();

                        while (reader.Read())
                        {
                            AdicionarContatoVisual(reader["telefone"].ToString());
                        }
                    }
                }


                //animais
                using (SqlCommand cmd = new SqlCommand(@"
                                                        SELECT a.id, a.nome, a.idade, r.raca, e.especie
                                                        FROM cliente c
                                                        LEFT JOIN animal a ON a.id_cliente = c.id
                                                        LEFT JOIN raca r ON r.id = a.id_raca
                                                        LEFT JOIN especie e ON e.id = r.id_especie
                                                        WHERE c.id = @id", conn))
                {
                    cmd.Parameters.AddWithValue("@id", clienteId);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dataGrid_Animais.DataSource = dt;
                }

            }
        }

        private void carregarComboBoxs_Add()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                using (SqlCommand cmd = new SqlCommand("SELECT id, raca FROM raca", conn))
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    DataTable dtRacas = new DataTable();
                    dtRacas.Load(reader);

                    comboBox_AddRaca.DisplayMember = "raca";
                    comboBox_AddRaca.ValueMember = "id";
                    comboBox_AddRaca.DataSource = dtRacas;


                }

            }

        }

        //ativação e desligamento da edição
        private void AtivarEdicao(bool edicao)
        {
            textBox_Nome.Enabled = edicao;
            flowLayoutPanelContatos.Enabled = edicao;
            textBox_AddContato.Visible = edicao;

            btn_editar.Visible = !edicao;

            btn_AddContato.Visible = edicao;

            textBox_AddAnimal.Visible = edicao;
            textBox_AddIdadeAnimal.Visible = edicao;
            comboBox_AddRaca.Visible = edicao;
            btn_AddAnimal.Visible = edicao;


            btn_Voltar.Visible = edicao;
            btn_SalvarNome.Visible = edicao;
            btn_SalvarEndereco.Visible = edicao;
            textBox_Endereco.Enabled = edicao;
        }

        private void btn_editar_Click(object sender, EventArgs e)
        {
            edicao = true;
            AtivarEdicao(true);
            LimparDadosDataGrid();
        }

        private void btn_Voltar_Click(object sender, EventArgs e)
        {
            CarregarDados(clienteId);
            AtivarEdicao(false);

        }

        //botões de salvar nome
        private void btn_salvarNome_Click(object sender, EventArgs e)
        {

            //update nome
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                //pega o nome antigo/no banco de dados
                string query = "select c.nome from cliente c where c.id = @id";

                conn.Open();

                string nomeCliente_antigo = "";
                string nomeCliente_novo = textBox_Nome.Text.Trim();

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id", clienteId);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            nomeCliente_antigo = reader["nome"].ToString();
                        }

                    }

                }
                //atualiza o banco de dados
                if (nomeCliente_antigo != nomeCliente_novo)
                {
                    string query_update_nome = "UPDATE cliente SET nome = @nome where id=@id";

                    using (SqlCommand cmd2 = new SqlCommand(query_update_nome, conn))
                    {
                        cmd2.Parameters.AddWithValue("@nome", nomeCliente_novo);
                        cmd2.Parameters.AddWithValue("@id", clienteId);
                        int linhasAfetadas = cmd2.ExecuteNonQuery();

                        if (linhasAfetadas > 0)
                        {
                            MessageBox.Show("Nome do cliente atualizado com sucesso!");
                        }
                        else
                        {
                            MessageBox.Show("Nada foi atualizado...");
                        }

                    }

                }

            }

        }

        //botão de salvar endereço
        private void btn_SalvarEndereco_Click(object sender, EventArgs e)
        {
            //update nome
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                //pega o nome antigo/no banco de dados
                string query = "select c.endereco from cliente c where c.id = @id";

                conn.Open();

                string endereco_antigo = "";
                string endereco_novo = textBox_Endereco.Text.Trim();

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id", clienteId);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            endereco_antigo = reader["endereco"].ToString();
                        }

                    }

                }
                //atualiza o banco de dados
                if (endereco_antigo != endereco_novo)
                {
                    string query_update_endereco = "UPDATE cliente SET endereco = @endereco where id=@id";

                    using (SqlCommand cmd2 = new SqlCommand(query_update_endereco, conn))
                    {
                        cmd2.Parameters.AddWithValue("@endereco", endereco_novo);
                        cmd2.Parameters.AddWithValue("@id", clienteId);
                        int linhasAfetadas = cmd2.ExecuteNonQuery();

                        if (linhasAfetadas > 0)
                        {
                            MessageBox.Show("Endereco do cliente atualizado com sucesso!");
                        }
                        else
                        {
                            MessageBox.Show("Nada foi atualizado...");
                        }

                    }

                }

            }

        }


        //funções auxiliares de edição dos contatos
        private void textBox_AddContato_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
        private void SelecionarLabel(Label lbl)
        {
            if (selectedLabel != null) selectedLabel.BackColor = Color.LightGray;

            selectedLabel = lbl;
            selectedLabel.BackColor = Color.LightBlue;

            btn_Editar_Contato.Visible = true;
            btn_RemoverContato.Visible = true;
            btn_AddContato.Visible = false;

            textBox_AddContato.Text = selectedLabel.Text;
            textBox_AddContato.Tag = selectedLabel.Text;

        }
        private void AdicionarContatoVisual(string texto)
        {
            Label lbl = new Label();
            lbl.Text = texto;
            lbl.AutoSize = true;
            lbl.Margin = new Padding(5);
            lbl.Padding = new Padding(10);
            lbl.BackColor = Color.LightGray;
            lbl.Cursor = Cursors.Hand;

            // Evento de clique
            lbl.Click += (s, e) =>
            {
                SelecionarLabel(lbl);
            };

            flowLayoutPanelContatos.Controls.Add(lbl);
            LimparSelecaoContato();

        }

        private void LimparSelecaoContato()
        {
            if (selectedLabel != null) selectedLabel.BackColor = Color.LightGray;

            selectedLabel = null;
            btn_Editar_Contato.Visible = false;
            btn_RemoverContato.Visible = false;
            btn_AddContato.Visible = true;

            textBox_AddContato.Clear();
            textBox_AddContato.Tag = null;
        }

        private void flowLayoutPanelContatos_Click(object sender, EventArgs e)
        {
            LimparSelecaoContato();
        }

        //botões de edição dos contatos
        private void btn_AddContato_Click(object sender, EventArgs e)
        {


            if (selectedLabel == null)
            {
                string novoContato = textBox_AddContato.Text.Trim();

                bool exist = false;

                foreach (Control item in flowLayoutPanelContatos.Controls)
                {
                    if (item is Label && item.Text == novoContato) { exist = true; break; }
                }

                if (!exist)
                {

                    textBox_AddContato.Clear();

                    using (SqlConnection conn = new SqlConnection(connectionString))
                    {
                        conn.Open();

                        string query = "INSERT INTO telefone (id_cliente, telefone) VALUES (@id, @telefone)";

                        using (SqlCommand cmd = new SqlCommand(query, conn))
                        {

                            cmd.Parameters.AddWithValue("@id", clienteId);
                            cmd.Parameters.AddWithValue("@telefone", novoContato);
                            cmd.ExecuteNonQuery();



                        }

                    }

                    AdicionarContatoVisual(novoContato);
                    MessageBox.Show("Contato adicionado com sucesso!", "Tudo certo", MessageBoxButtons.OK, MessageBoxIcon.Information);


                }
                else
                {
                    MessageBox.Show("Esse contato já está na lista!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
            else
            {
                MessageBox.Show("Digite um número de telefone válido!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }

        private void btn_Editar_Contato_Click(object sender, EventArgs e)
        {
            string contatoAntigo = selectedLabel.Text.Trim();
            string contatoNovo = textBox_AddContato.Text.Trim();

            if (string.IsNullOrEmpty(contatoNovo))
            {
                MessageBox.Show("Digite um novo número de telefone válido!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (contatoAntigo == contatoNovo)
            {
                MessageBox.Show("O novo número é igual ao atual.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                string query = "UPDATE telefone set telefone=@telefone_novo WHERE id_cliente=@id and telefone=@telefone_antigo";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@telefone_novo", contatoNovo);
                    cmd.Parameters.AddWithValue("@id", clienteId);
                    cmd.Parameters.AddWithValue("@telefone_antigo", contatoAntigo);

                    int linhasAfetadas = cmd.ExecuteNonQuery();

                    if (linhasAfetadas > 0)
                    {
                        selectedLabel.Text = contatoNovo;
                        MessageBox.Show("Contato atualizado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LimparSelecaoContato();
                    }
                    else
                    {
                        MessageBox.Show("Falha ao atualizar o contato.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }


            }


        }

        private void btn_RemoverContato_Click(object sender, EventArgs e)
        {
            if (selectedLabel != null)
            {
                string Contato = selectedLabel.Text;

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    string query = "DELETE FROM telefone where telefone=@telefone AND id_cliente=@id";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {

                        cmd.Parameters.AddWithValue("@telefone", Contato);
                        cmd.Parameters.AddWithValue("@id", clienteId);
                        int linhasAfetadas = cmd.ExecuteNonQuery();

                        if (linhasAfetadas > 0)
                        {
                            flowLayoutPanelContatos.Controls.Remove(selectedLabel);
                            selectedLabel = null;
                            MessageBox.Show("Contato removido com sucesso!", "Tudo certo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LimparSelecaoContato();
                        }
                        else
                        {
                            MessageBox.Show("Não foi possível remover o contato. Verifique se ele existe!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }

                    }

                }

            }
            else
            {
                MessageBox.Show("Selecione um contato para remover!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }


        }

        //funções auxiliares do datagrid
        private void dataGrid_Animais_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dataGrid_Animais.Rows[e.RowIndex].Cells["nome"].Value != null)
            {
                DataGridViewRow row = dataGrid_Animais.Rows[e.RowIndex];

                textBox_AddAnimal.Text = row.Cells["nome"].Value.ToString();
                textBox_AddIdadeAnimal.Text = row.Cells["idade"].Value.ToString();

                string valorRaca = row.Cells["raca"].Value.ToString();
                int indexRaca = comboBox_AddRaca.FindStringExact(valorRaca);

                if (indexRaca != -1)
                {
                    comboBox_AddRaca.SelectedIndex = indexRaca;
                }
                else
                {
                    MessageBox.Show("Raça não encontrada no ComboBox!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

            }
            if (edicao)
            {
                if (dataGrid_Animais.CurrentRow != null && dataGrid_Animais.CurrentRow.Index >= 0)
                {
                    btn_EditarAnimal.Visible = true;
                    btn_ExcluirAnimal.Visible = true;
                    btn_AddAnimal.Visible = false;
                }
                else
                {
                    btn_EditarAnimal.Visible = false;
                    btn_ExcluirAnimal.Visible = false;
                    btn_AddAnimal.Visible = true;
                }
            }
        }

        private void LimparDadosDataGrid()
        {
            textBox_AddAnimal.Clear();
            textBox_AddIdadeAnimal.Clear();
            comboBox_AddRaca.SelectedIndex = -1;

            btn_EditarAnimal.Visible = false;
            btn_ExcluirAnimal.Visible = false;
            btn_AddAnimal.Visible = true;

        }

        private void desmarcarDataGrid(object sender, EventArgs e)
        {
            if (!dataGrid_Animais.Focused && !dataGrid_Animais.Bounds.Contains(this.PointToClient(Cursor.Position)))
            {
                dataGrid_Animais.ClearSelection();

                LimparDadosDataGrid();
            }
        }

        //funções auxiliares dos botões de edição dos animais
        private void textBox_AddIdadeAnimal_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        //botões de edição dos animais
        private void btn_AddAnimal_Click(object sender, EventArgs e)
        {
            string nome = textBox_AddAnimal.Text.Trim();
            int idRaca = (int)comboBox_AddRaca.SelectedValue;

            if (!int.TryParse(textBox_AddIdadeAnimal.Text.Trim(), out int idade))
            {
                MessageBox.Show("Idade inválida! Digite um número inteiro.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }


            if (string.IsNullOrEmpty(nome))
            {
                MessageBox.Show("Digite um nome para o animal!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                string query = "INSERT INTO animal (nome, id_cliente, id_raca, idade) VALUES (@nome, @id_cliente, @raca, @idade)";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@nome", nome);
                    cmd.Parameters.AddWithValue("@id_cliente", clienteId);
                    cmd.Parameters.AddWithValue("@raca", idRaca);
                    cmd.Parameters.AddWithValue("@idade", idade);

                    cmd.ExecuteNonQuery();


                }

            }

            MessageBox.Show("Animal adicionado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            CarregarDados(clienteId); // Atualiza o DataGrid


        }


        private void btn_EditarAnimal_Click(object sender, EventArgs e)
        {

            DataGridViewRow row = dataGrid_Animais.SelectedRows[0];

            int id = Convert.ToInt32(row.Cells["id"].Value);
            string nomeAntigo = row.Cells["nome"].Value.ToString();
            int idadeAntiga = Convert.ToInt32(row.Cells["idade"].Value);
            string racaAntiga = row.Cells["raca"].Value.ToString();

            string nomeNovo = textBox_AddAnimal.Text.Trim();
            string idadeNova = textBox_AddIdadeAnimal.Text.Trim();
            int idRacaNova = (int)comboBox_AddRaca.SelectedValue;



            if (string.IsNullOrWhiteSpace(nomeNovo) || string.IsNullOrWhiteSpace(idadeNova))
            {
                MessageBox.Show("Adicione um novo nome e idade", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                string query = "UPDATE animal SET nome=@nome, idade=@idade, id_raca=@raca WHERE id_cliente=@id_cliente and id=@id";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@nome", nomeNovo);
                    cmd.Parameters.AddWithValue("@idade", idadeNova);
                    cmd.Parameters.AddWithValue("@raca", idRacaNova);
                    cmd.Parameters.AddWithValue("@id_cliente", clienteId);
                    cmd.Parameters.AddWithValue("@id", id);

                    int linhasAfetadas = cmd.ExecuteNonQuery();

                    if (linhasAfetadas > 0)
                    {
                        CarregarDados(clienteId);
                        MessageBox.Show("Animal atualizado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Falha ao atualizar o Animal.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }

            }

            LimparDadosDataGrid();

        }

        private void btn_ExcluirAnimal_Click(object sender, EventArgs e)
        {
            DataGridViewRow row = dataGrid_Animais.SelectedRows[0];

            int id = Convert.ToInt32(row.Cells["id"].Value);

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "DELETE FROM animal WHERE id=@id";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id", id);

                    int linhasAfetadas = cmd.ExecuteNonQuery();

                    if (linhasAfetadas > 0)
                    {
                        CarregarDados(clienteId);
                        MessageBox.Show("animal removido com sucesso!", "Tudo certo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Não foi possível remover o animal. Verifique se ele existe!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }


                }

            }
            LimparDadosDataGrid();
        }


        //funções do Form
        private void FormClientInfo_Click(object sender, EventArgs e)
        {
            if (!dataGrid_Animais.Focused && !dataGrid_Animais.Bounds.Contains(this.PointToClient(Cursor.Position)))
            {
                dataGrid_Animais.ClearSelection();

                // Resetar campos, se quiser
                textBox_AddAnimal.Clear();
                textBox_AddIdadeAnimal.Clear();
                comboBox_AddRaca.SelectedIndex = -1;

                // Botões
                btn_EditarAnimal.Visible = false;
                btn_ExcluirAnimal.Visible = false;
                btn_AddAnimal.Visible = true;
            }
        }
        
    }//forms
}
