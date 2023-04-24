using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleDeMedicamentos.ModuloMae
{
    public class TelaMae
    {
        public string ApresentarMenu()
        {
            Console.Clear();
            ApresentarCabecalho(" Controle de Medicamentos ", ConsoleColor.Yellow);
            Console.WriteLine(" [1] - Visualizar Menu de Funcionários ");
            Console.WriteLine(" [2] - Visualizar Menu de Pacientes ");
            Console.WriteLine(" [3] - Visualizar Menu de Medicamentos ");
            Console.WriteLine(" [4] - Visualizar Menu de Fornecedores ");
            Console.WriteLine(" [5] - Visualizar Requisições de Medicamentos ");
            Console.WriteLine(" [6] - Visualizar Reposição de Medicamentos ");
            Console.WriteLine(" [7] - Sair ");
            string opcao = Console.ReadLine();

            return opcao;
        }
        public void ApresentarMensagem(string mensagem, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(mensagem);
            Console.ResetColor();
        }
        public void ApresentarCabecalho(string cabecalho, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(" ---------------------------------------------------------------------------------------------------------- ");
            Console.WriteLine("                                           {0, -17}                                        ", cabecalho);
            Console.WriteLine(" ---------------------------------------------------------------------------------------------------------- ");
            Console.ResetColor();
        }
    }
}
