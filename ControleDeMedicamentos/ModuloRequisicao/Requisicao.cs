using ControleDeMedicamentos.ModuloFuncionario;
using ControleDeMedicamentos.ModuloMedicamento;
using ControleDeMedicamentos.ModuloPaciente;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleDeMedicamentos.ModuloRequisicao
{
    internal class Requisicao
    {
        public int id { get; set; }
        public Medicamento medicamento { get; set; }
        public Paciente paciente { get; set; }
        public Funcionario funcionario { get; set; }
        public int quantidadeMedicamento { get; set; }

        public static int contadorId = 1;
        public void AdicionarId()
        {
            id = contadorId++;
        }
    }
}
