using ControleDeMedicamentos.ModuloFuncionario;
using ControleDeMedicamentos.ModuloMae;
using ControleDeMedicamentos.ModuloMedicamento;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleDeMedicamentos.ModuloPaciente
{
    public class TelaPaciente : TelaMae
    {
        private RepositorioPaciente repositorioPaciente;
        public TelaPaciente(RepositorioPaciente repositorioPaciente)
        {
            this.repositorioPaciente = repositorioPaciente;
        }

        internal string ApresentarMenuPaciente()
        {
            Console.Clear();
            ApresentarCabecalho("Menu de Pacientes", ConsoleColor.Yellow);
            Console.WriteLine(" [1] - Cadastrar novo paciente ");
            Console.WriteLine(" [2] - Visualizar pacientes ");
            Console.WriteLine(" [3] - Editar pacientes ");
            Console.WriteLine(" [4] - Excluir pacientes ");
            Console.WriteLine(" [5] - Sair ");
            string opcao = Console.ReadLine();

            return opcao;
        }

        internal void CadastrarPaciente()
        {
            Console.Clear();
            ApresentarCabecalho("Cadastro de Pacientes", ConsoleColor.Yellow);

            Paciente paciente = new Paciente();

            Console.Write("Nome: ");
            paciente.nome = Console.ReadLine();

            Console.Write("Área: ");
            paciente.area = Console.ReadLine();

            Console.Write("Cartão SUS: ");
            paciente.cartaoSUS = Console.ReadLine();

            Console.Write("Telefone: ");
            paciente.telefone = Console.ReadLine();

            repositorioPaciente.AdicionarNaLista(paciente);

            ApresentarMensagem("Paciente registrado com sucesso!", ConsoleColor.Green);

            Console.ReadLine();
        }

        public void EditarPaciente()
        {
            bool temPaciente = VisualizarPaciente(false);
            if (temPaciente == false)
            {
                return;
            }

            ApresentarCabecalho("Editar paciente", ConsoleColor.Cyan);
            Console.WriteLine("Digite o Id do paciente: ");
            int posicao = Convert.ToInt32(Console.ReadLine());

            Paciente pacienteEditado = repositorioPaciente.BuscarPorId(posicao);

            Console.Write("Nome: ");
            pacienteEditado.nome = Console.ReadLine();

            Console.Write("Área: ");
            pacienteEditado.area = Console.ReadLine();

            Console.Write("Cartão SUS: ");
            pacienteEditado.cartaoSUS = Console.ReadLine();

            Console.Write("Telefone: ");
            pacienteEditado.telefone = Console.ReadLine();


            ApresentarMensagem("Paciente editado com sucesso!", ConsoleColor.Green);
            Console.ReadLine();

        }
        public bool VisualizarPaciente(bool mostrarCabecalho)
        {
            Console.Clear();
            if (repositorioPaciente.listaRegistros.Count == 0)
            {
                ApresentarMensagem("Não há pacientes cadastrados", ConsoleColor.Red);
                Console.ReadLine();
                return false;
            }
            ApresentarCabecalho("Pacientes", ConsoleColor.Cyan);

            Console.WriteLine("| {0, -3} | {1, -30} | {2,-20} | {3,-20} |", " ID", "Nome", "Área", "Cartão SUS", "Telefone");
            Console.WriteLine(" ---------------------------------------------------------------------------------------------------------- ");

            foreach (Paciente paciente in repositorioPaciente.listaRegistros)
            {
                Console.WriteLine("| {0, -3} | {1, -30} | {2,-20} | {3,-20} |", paciente.id, paciente.nome, paciente.area, paciente.cartaoSUS, paciente.telefone);
                Console.WriteLine(" ---------------------------------------------------------------------------------------------------------- ");
            }
            Console.ReadLine();
            return true;
        }

        internal void ExcluirPaciente()
        {
            bool temPaciente = VisualizarPaciente(false);
            if (temPaciente == false)
            {
                return;
            }
            ApresentarCabecalho("Excluindo paciente", ConsoleColor.Cyan);
            Console.WriteLine("Digite o Id do paciente: ");
            int posicao = Convert.ToInt32(Console.ReadLine());

            Paciente pacienteDeletado = repositorioPaciente.BuscarPorId(posicao);

            repositorioPaciente.Excluir(pacienteDeletado);
            ApresentarMensagem("Paciente excluído com sucesso!", ConsoleColor.Green);
            Console.ReadLine();
        }
        public void ApresentarPacienteTeste()
        {
            Paciente pacienteTeste = new Paciente();

            pacienteTeste.nome = "Sabrina Matos";
            pacienteTeste.area = "113.10";
            pacienteTeste.telefone = "49999506413";
            pacienteTeste.cartaoSUS = "705 6034 6924 3018";

            this.repositorioPaciente.AdicionarNaLista(pacienteTeste);
        }
    }
}
