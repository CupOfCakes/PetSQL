using System.Data;
using System.Data.SqlClient;

namespace projetoVeterinario
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        string connectionString = "Data Source=localhost\\SQLEXPRESS;Initial catalog=projeto_veterinario;Integrated Security=True";

        //Botões adicionar cliente
        private void btn_AddCliente_Click(object sender, EventArgs e)
        {
            FormAddCliente frm = new FormAddCliente();
            frm.ShowDialog();
        }

        //botão de aplicar filtro
        private void btnAplicarFiltros_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                string busca = textBox_busca.Text.Trim();
                string ordernarPor = cmb_ordernar.SelectedItem?.ToString();

                string query = @"SELECT 
                                c.id,
                                c.nome,
                                COUNT(a.id) AS qtd_animais
                                FROM 
                                    cliente c
                                LEFT JOIN 
                                    animal a ON a.id_cliente = c.id";

                if (!string.IsNullOrEmpty(busca))
                {
                    query += @" WHERE c.nome like @busca ";
                }

                query += " GROUP BY c.id, c.nome ";

                if (!string.IsNullOrEmpty(ordernarPor))
                {
                    if (ordernarPor == "mais animais")
                    {
                        query += " ORDER BY COUNT(a.id) DESC ";
                    }
                    else if (ordernarPor == "menos animais")
                    {
                        query += " ORDER BY COUNT(a.id) ASC ";
                    }
                    else if (ordernarPor == "cliente em ordem alfabetica")
                    {
                        query += " ORDER BY c.nome ";
                    }
                }

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    if (!string.IsNullOrEmpty(busca))
                    {
                        cmd.Parameters.AddWithValue("@busca", "%" + busca + "%");
                    }

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    dataGrid.DataSource = dt;

                    if (!dataGrid.Columns.Contains("BtnExcluir"))
                    {
                        DataGridViewButtonColumn BtnExcluir = new DataGridViewButtonColumn();
                        BtnExcluir.Name = "BtnExcluir";
                        BtnExcluir.HeaderText = "Excluir";
                        BtnExcluir.Text = "Excluir";
                        BtnExcluir.UseColumnTextForButtonValue = true;

                        dataGrid.Columns.Add(BtnExcluir);
                    }

                }

            }

        } //private select

        //botão de deleção no datagrid
        private void dataGrid_delete_Click(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex == dataGrid.Columns["BtnExcluir"].Index)
            {
                int idCliente = Convert.ToInt32(dataGrid.Rows[e.RowIndex].Cells["id"].Value);
                string nameCliente = Convert.ToString(dataGrid.Rows[e.RowIndex].Cells["nome"].Value);

                var resultado = MessageBox.Show($"Tem certea que deseja deletar {@nameCliente}?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (resultado == DialogResult.Yes)
                {
                    using (SqlConnection conn = new SqlConnection(connectionString))
                    {
                        conn.Open();

                        string query = $"DELETE FROM cliente WHERE id={idCliente}";

                        using (SqlCommand cmd = new SqlCommand(query, conn))
                        {
                            cmd.ExecuteNonQuery();
                        }

                        MessageBox.Show("Cliente excluido com sucesso");
                        btnAplicarFiltros_Click(null, null);

                    }

                }

            }
        }//delete

        //abrir as informações do cliente ao dar double click
        private void dataGrid_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) // Pra não ativar no cabeçalho
            {
                int clienteId = Convert.ToInt32(dataGrid.Rows[e.RowIndex].Cells["id"].Value);

                FormClientInfo formInfo = new FormClientInfo(clienteId);
                formInfo.ShowDialog(); // Modal, espera fechar
            }
        }

        
    }

}
