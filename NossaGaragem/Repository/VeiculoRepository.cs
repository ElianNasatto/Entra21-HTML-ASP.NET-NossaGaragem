using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace Repository
{
    public class VeiculoRepository
    {
        public int Inserir(Veiculo veiculo)
        {

            SqlCommand comando = Conexao.Conectar();
            comando.CommandText = "INSERT INTO veiculos (modelo,id_categoria,valor) OUTPUT INSERTED.ID VALUES (@MODELO,@ID_CATEGORIA,@VALOR)";

            comando.Parameters.AddWithValue("@MODELO", veiculo.Modelo);
            comando.Parameters.AddWithValue("@ID_CATEGORIA", veiculo.IdCategoria);
            comando.Parameters.AddWithValue("@VALOR", veiculo.Valor);
            int id = Convert.ToInt32(comando.ExecuteScalar());
            comando.Connection.Close();
            return id;
        }

        public List<Veiculo> ObterTodos()
        {
            SqlCommand comando = Conexao.Conectar();
            comando.CommandText = @"SELECT 
                                    veiculos.id AS 'VeiculoId',
                                    veiculos.modelo AS 'Modelo',
                                    veiculos.valor AS 'Valor',
                                    categorias.nome AS 'CategoriaNome'
            FROM veiculos INNER JOIN categorias ON (veiculos.id_categoria = categorias.id)";
            DataTable tabela = new DataTable();
            tabela.Load(comando.ExecuteReader());
            comando.Connection.Close();

            List<Veiculo> lista = new List<Veiculo>();

            foreach (DataRow linha in tabela.Rows)
            {
                Veiculo veiculo = new Veiculo();
                veiculo.Id = Convert.ToInt32(linha["VeiculoId"]);
                veiculo.Modelo = linha["Modelo"].ToString();
                veiculo.Valor = Convert.ToDecimal(linha["Valor"]);
                veiculo.Categoria = new Categoria();
                veiculo.Categoria.Nome = linha["CategoriaNome"].ToString();
                lista.Add(veiculo);

            }
            return lista;
        }

        public void Deletar(int id)
        {
            SqlCommand comando = Conexao.Conectar();
            comando.CommandText = "DELETE FROM veiculos WHERE id=@ID";
            comando.Parameters.AddWithValue("@ID", id);
            comando.ExecuteNonQuery();
            comando.Connection.Close();

        }

        public Veiculo ObterPeloId(int id)
        {
            SqlCommand comando = Conexao.Conectar();
            comando.CommandText = @"SELECT
                                    veiculos.modelo AS 'Modelo'
FROM veiculos WHERE id = "
        }
    }
}
