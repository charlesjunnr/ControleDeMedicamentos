using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ControleDeMedicamentos.ModuloMae;

namespace ControleDeMedicamentos.ModuloFuncionario
{
    internal class TelaFuncionario : TelaMae
    {
        
        private RepositorioFuncionario repositorioFuncionario;
        public TelaFuncionario(RepositorioFuncionario repositorioFuncionario)
        {
            this.repositorioFuncionario = repositorioFuncionario;
        }

        public string ApresentarMenuFuncionario()
        {
            Console.Clear();
            ApresentarCabecalho("Menu de Funcionários", ConsoleColor.Yellow);
            Console.WriteLine(" [1] - Cadastrar novo funcionário ");
            Console.WriteLine(" [2] - Visualizar funcionário ");
            Console.WriteLine(" [3] - Editar funcionário ");
            Console.WriteLine(" [4] - Excluir funcionário ");
            Console.WriteLine(" [5] - Sair ");
            Console.WriteLine(" ---------------------------------------------------------------------------------------------------------- ");

            string opcao = Console.ReadLine();

            return opcao;
        }

        internal void CadastrarFuncionario()
        {
            Console.Clear();
            ApresentarCabecalho("CADASTRO DE FUNCIONÁRIOS", ConsoleColor.Yellow);
            Console.Write("Nome: ");
            string nome = Console.ReadLine();

            Console.Write("Unidade de Saúde: ");
            string unidadeSaude = Console.ReadLine();

            Console.Write("Endereço: ");
            string endereco = Console.ReadLine();

            Console.Write("Telefone: ");
            string telefone = Console.ReadLine();

            Console.Write("CPF: ");
            string cpf = Console.ReadLine();


            Funcionario funcionario = new Funcionario(nome, unidadeSaude, endereco, cpf, telefone);

            repositorioFuncionario.AdicionarNaLista(funcionario);

            ApresentarMensagem("Funcionário registrado com sucesso!", ConsoleColor.Green);
           
            Console.ReadLine();
        }

        internal void EditarFuncionario()
        {
            bool temFuncionario = VisualizarFuncionario(false);
            if (temFuncionario == false)
            {
                return;
            }

            ApresentarCabecalho("Editar funcionário", ConsoleColor.Yellow);
            Console.WriteLine("Digite o Id do funcionário: ");
            int posicao = Convert.ToInt32(Console.ReadLine());

            Funcionario funcionarioEditado = repositorioFuncionario.BuscarPorId(posicao);

            Console.Write("Nome: ");
            funcionarioEditado.nomeFuncionario = Console.ReadLine();

            Console.Write("Unidade de Saúde: ");
            funcionarioEditado.unidadeSaude = Console.ReadLine();

            Console.Write("Endereço: ");
            funcionarioEditado.endereco = Console.ReadLine();

            Console.Write("Telefone: ");
            funcionarioEditado.telefone = Console.ReadLine();

            Console.Write("CPF: ");
            funcionarioEditado.cpf = Console.ReadLine();
            ApresentarMensagem("Funcionário editado com sucesso!", ConsoleColor.Green);
            Console.ReadLine();

        }

        internal void ExcluirFuncionario()
        {
            bool temFuncionario = VisualizarFuncionario(false);
            if(temFuncionario == false) 
            {
                return;
            }
            ApresentarCabecalho("EXCLUIR FUNCIONÁRIO", ConsoleColor.Yellow);
            Console.WriteLine("Digite o Id do funcionário: ");
            int posicao = Convert.ToInt32(Console.ReadLine());

            Funcionario funcionarioDeletado = repositorioFuncionario.BuscarPorId(posicao);

            repositorioFuncionario.Excluir(funcionarioDeletado);
            ApresentarMensagem("Funcionário excluído com sucesso!", ConsoleColor.Green);
            Console.ReadLine();
        }

        public bool VisualizarFuncionario(bool mostrarCabecalho)
        {
            Console.Clear();
            if(this.repositorioFuncionario.listaRegistros.Count == 0)
            {
                ApresentarMensagem("Não há funcionários cadastrados", ConsoleColor.Red);
                Console.ReadLine();
                return false;
            }
            ApresentarCabecalho("FUNCIONÁRIOS", ConsoleColor.Yellow);

            Console.WriteLine("| {0, -3} | {1, -30} | {2,-20} | {3,-20} | {4,-20} |", " ID", "Nome", "USB", "CPF", "Telefone");
            Console.WriteLine(" ---------------------------------------------------------------------------------------------------------- ");

            foreach (Funcionario funcionario in repositorioFuncionario.listaRegistros)
            {
                Console.WriteLine("| {0, -3} | {1, -30} | {2,-20} | {3,-20} | {4,-20} |", funcionario.id, funcionario.nomeFuncionario, funcionario.unidadeSaude, funcionario.telefone, funcionario.cpf);
                Console.WriteLine(" ---------------------------------------------------------------------------------------------------------- ");
            }
            Console.ReadLine();
            return true;
        }

        public void ApresentarFuncionarioTeste()
        {
            string nome = "João Carlos";
            string unidade = "USB Coral";
            string endereco = "Rua das Rosas, nº 12";
            string telefone = "4199352739";
            string cpf = "869.256.285-11";

            Funcionario newFuncionario = new Funcionario(nome, unidade, endereco, telefone, cpf);
            this.repositorioFuncionario.AdicionarNaLista(newFuncionario);
        }

    }
}
