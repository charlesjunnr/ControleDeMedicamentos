using ControleDeMedicamentos.ModuloFornecedor;
using ControleDeMedicamentos.ModuloFuncionario;
using ControleDeMedicamentos.ModuloMae;
using ControleDeMedicamentos.ModuloMedicamento;
using ControleDeMedicamentos.ModuloPaciente;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleDeMedicamentos.ModuloReposicao
{
    internal class TelaReposicao : TelaMae
    {
        private RepositorioReposicao repositorioReposicao;
        private RepositorioMedicamento repositorioMedicamento;
        private RepositorioFuncionario repositorioFuncionario;
        private RepositorioFornecedor repositorioFornecedor;
        private RepositorioReposicao repositorioReposicao1;

        public TelaReposicao(RepositorioReposicao repositorioReposicao, RepositorioMedicamento repositorioMedicamento, RepositorioFuncionario repositorioFuncionario, RepositorioFornecedor repositorioFornecedor)
        {
            this.repositorioMedicamento = repositorioMedicamento;
            this.repositorioFuncionario = repositorioFuncionario;
            this.repositorioFornecedor = repositorioFornecedor;
            this.repositorioReposicao = repositorioReposicao;
        }

        public string ApresentarMenuReposicao()
        {

            ApresentarCabecalho("Reposição de Medicamentos", ConsoleColor.Green);
            Console.WriteLine(" [1] - Cadastrar Nova Reposição ");
            Console.WriteLine(" [2] - Visualizar Reposições ");
            Console.WriteLine(" [3] - Voltar ");
            string opcao = Console.ReadLine();
            return opcao;
        }

        internal void CadastrarNovaReposicao()
        {
            Console.Clear();
            ApresentarCabecalho("Cadastro de Reposição", ConsoleColor.Green);

            Reposicao reposicao = new Reposicao();

            VisualizarPreRequisitosMedicamentos(true);
            Console.WriteLine("Digite o ID do Medicamento: ");
            int idMedicamento = Convert.ToInt32(Console.ReadLine());
            Medicamento medicamentoReposicao = repositorioMedicamento.BuscarPorId(idMedicamento);
            reposicao.medicamento = medicamentoReposicao;

            Console.WriteLine("Digite a quantidade de Medicamentos: ");
            reposicao.quantidadeMedicamento = Convert.ToInt32(Console.ReadLine());
            reposicao.medicamento.quantidade += reposicao.quantidadeMedicamento;

            VisualizarPreRequisitosFornecedor(true);
            Console.WriteLine("Digite o ID do Fornecedor: ");
            int idFornecedor = Convert.ToInt32(Console.ReadLine());
            Fornecedor fornecedorReposicao = repositorioFornecedor.BuscarPorId(idFornecedor);
            reposicao.fornecedor = fornecedorReposicao;

            VisualizarPreRequisitosFuncionario(true);
            Console.WriteLine("Digite o ID do Funcionário: ");
            int idFuncionario = Convert.ToInt32(Console.ReadLine());
            Funcionario funcionarioReposicao = repositorioFuncionario.BuscarPorId(idFuncionario);
            reposicao.funcionario = funcionarioReposicao;

            reposicao.DateTime = DateTime.Today;

            repositorioReposicao.AdicionarNaLista(reposicao);
            ApresentarMensagem("Reposição feita com sucesso!", ConsoleColor.Green);
            Console.ReadLine();

        }

        public bool VisualizarReposicoes(bool temReposicao)
        {
            if (repositorioReposicao.listaRegistros.Count == 0)
            {
                ApresentarMensagem("Não há reposições registradas!", ConsoleColor.Red);
                Console.ReadKey();
                return false;
            }
            ApresentarMensagem("Reposições", ConsoleColor.Cyan);
            Console.WriteLine();
            Console.WriteLine("| {0, -3} | {1, -20} | {2, -20} | {3, -20} | {4, -30} | {5, -20} ", " ID", "Medicamento", "Fornecedor", "Funcionário", "Quantidade adicionada", "Data");
            Console.WriteLine(" --------------------------------------------------------------------------------------------------------------- ");

            foreach (Reposicao reposicao in repositorioReposicao.listaRegistros)
            {
                Console.WriteLine("| {0, -3} | {1, -20} | {2, -20} | {3, -20} | {4, -30} | {5, -20} ", reposicao.id, reposicao.medicamento.nome, reposicao.fornecedor.nome, reposicao.funcionario.nomeFuncionario, reposicao.quantidadeMedicamento, reposicao.DateTime.ToShortDateString()); 
            }
            Console.ReadLine();
            return true;
        }
        public bool VisualizarPreRequisitosMedicamentos(bool temMedicamento)
        {
            if (repositorioMedicamento.listaRegistros.Count == 0)
            {
                ApresentarMensagem("Não há medicamentos registrados!", ConsoleColor.Red);
                Console.ReadKey();
                return false;
            }
            ApresentarMensagem("Medicamentos: ", ConsoleColor.Green);
            Console.WriteLine();
            Console.WriteLine("| {0, -3} | {1, -20} | {2, -13} |", " ID", "Medicamento", "Quantidade");
            Console.WriteLine(" ---------------------------------------------------------------------------------------------------------- ");
            foreach (Medicamento medicamento in repositorioMedicamento.listaRegistros)
            {
                Console.WriteLine("| {0, -3} | {1, -20} | {2, -13} |", medicamento.id, medicamento.nome, medicamento.quantidade);
                Console.WriteLine(" ---------------------------------------------------------------------------------------------------------- ");
            }
            return true;
        }
        public bool VisualizarPreRequisitosFuncionario(bool temFuncionario)
        {
            if (repositorioFuncionario.listaRegistros.Count == 0)
            {
                ApresentarMensagem("Não há funcionários registrados!", ConsoleColor.Red);
                Console.ReadKey();
                return false;
            }

            ApresentarMensagem("Funcionários: ", ConsoleColor.Green);
            Console.WriteLine();
            Console.WriteLine("| {0, -3} | {1, -20} |", " ID", "Funcionario");
            Console.WriteLine(" ---------------------------------------------------------------------------------------------------------- ");
            foreach (Funcionario funcionario in repositorioFuncionario.listaRegistros)
            {
                Console.WriteLine("| {0, -3} | {1, -20} |", funcionario.id, funcionario.nomeFuncionario);
                Console.WriteLine(" ---------------------------------------------------------------------------------------------------------- ");
            }

            return true;

        }
        public bool VisualizarPreRequisitosFornecedor(bool temFornecedor)
        {
            if (repositorioFornecedor.listaRegistros.Count == 0)
            {
                ApresentarMensagem("Não há fornecedores registrados!", ConsoleColor.Red);
                Console.ReadKey();
                return false;
            }

            ApresentarMensagem("Fornecedores: ", ConsoleColor.Green);
            Console.WriteLine();
            Console.WriteLine("| {0, -3} | {1, -20} | {2, -20} |", " ID", "Fornecedor", "Empresa");
            Console.WriteLine(" ---------------------------------------------------------------------------------------------------------- ");
            foreach (Fornecedor fornecedor in repositorioFornecedor.listaRegistros)
            {
                Console.WriteLine("| {0, -3} | {1, -20} | {2, -20} |", fornecedor.id, fornecedor.nome, fornecedor.empresa);
                Console.WriteLine(" ---------------------------------------------------------------------------------------------------------- ");
            }

            return true;

        }
    }
}
