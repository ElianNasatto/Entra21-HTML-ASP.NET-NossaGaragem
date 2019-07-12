using Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class CategoriaRepository
    {
        public List<Categoria> ObterTodos()
        {
            SqlCommand comando = Conexao.Conectar();
            comando.CommandText = "SELECT * FROM categorias";
            DataTable tabela = new DataTable();
            tabela.Load(comando.ExecuteReader());

            comando.Connection.Close();

            List<Categoria> lista = new List<Categoria>();
            foreach (DataRow linha in tabela.Rows)
            {

            }


            return lista;
        }

    }
}
