using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Veiculo
    {
        public int Id;
        public string Modelo;
        public decimal Valor;

        public int IdCategoria;

        public Categoria Categoria;
    }
}
