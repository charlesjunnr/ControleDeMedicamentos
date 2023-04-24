using ControleDeMedicamentos.ModuloFornecedor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleDeMedicamentos.ModuloMedicamento
{
    public class Medicamento
    {
        public string nome { get; set; }
        public string tipo { get; set; }
        public int id { get; set; }
        public int quantidade { get; set; }
        public bool estaDisponivel { get; set; }
        public Fornecedor Fornecedor { get; set; }
        public void AumentarQuantidade(int quantidade)
        {
            this.quantidade += quantidade;
        }
        public void DiminuirQuantidade(int quantidade)
        {
            this.quantidade -= quantidade;
        }
        public static int contadorId = 1;
        public void AdicionarId()
        {
            id = contadorId++;
        }

    }
}
