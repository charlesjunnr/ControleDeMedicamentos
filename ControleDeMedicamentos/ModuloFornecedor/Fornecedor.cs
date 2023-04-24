using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleDeMedicamentos.ModuloFornecedor
{
    public class Fornecedor
    {
        public string nome { get; set; }
        public int id { get; set; }
        public string telefone { get; set; }
        public string empresa { get; set; }
        public string cnpj { get ; set; }

        public static int contadorId = 1;
        public void AdicionarId()
        {
            id = contadorId++;
        }
    }
}
