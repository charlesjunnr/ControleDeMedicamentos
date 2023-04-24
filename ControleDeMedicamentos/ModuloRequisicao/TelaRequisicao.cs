using ControleDeMedicamentos.ModuloFornecedor;
using ControleDeMedicamentos.ModuloFuncionario;
using ControleDeMedicamentos.ModuloMae;
using ControleDeMedicamentos.ModuloMedicamento;
using ControleDeMedicamentos.ModuloPaciente;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleDeMedicamentos.ModuloRequisicao
{
    internal class TelaRequisicao : TelaMae
    {
        private RepositorioRequisicao repositorioRequisicao;
        private RepositorioMedicamento repositorioMedicamento;
        private RepositorioFuncionario repositorioFuncionario;
        private RepositorioPaciente repositorioPaciente;

        public TelaRequisicao(RepositorioRequisicao repositorioRequisicao, RepositorioMedicamento repositorioMedicamento, RepositorioFuncionario repositorioFuncionario, RepositorioPaciente repositorioPaciente)
        {
            this.repositorioMedicamento = repositorioMedicamento;
            this.repositorioFuncionario = repositorioFuncionario;
            this.repositorioPaciente = repositorioPaciente;
            this.repositorioRequisicao = repositorioRequisicao;
        }
        public string ApresentarMenuRequisicao()
        {
            
            ApresentarCabecalho("Requisições", ConsoleColor.DarkGreen);
            Console.WriteLine(" [1] - Cadastrar Nova Requisição ");
            Console.WriteLine(" [2] - Visualizar Requisições ");
            Console.WriteLine(" [3] - Visualizar Medicamentos mais retirados ");
            Console.WriteLine(" [4] - Sair ");
            Console.WriteLine(" ---------------------------------------------------------------------------------------------------------- ");

            string opcao = Console.ReadLine();
            return opcao;
        }
        internal void CadastrarRequisicao()
        {
            Console.Clear();
            ApresentarCabecalho("Cadastro de Requisição", ConsoleColor.DarkGreen);
            
            Requisicao requisicao = new Requisicao();

            VisualizarPreRequisitosMedicamentos(true);
            Console.WriteLine("Id do medicamento: ");
            int idMedicamento = Convert.ToInt32(Console.ReadLine());
            Medicamento medicamentoRequisicao = repositorioMedicamento.BuscarPorId(idMedicamento);
            requisicao.medicamento = medicamentoRequisicao;

            Console.WriteLine("Quantidade de caixas: ");
            requisicao.quantidadeMedicamento = Convert.ToInt32(Console.ReadLine());

            if (requisicao.medicamento.quantidade < requisicao.quantidadeMedicamento)
            {
                ApresentarMensagem("Não há caixas o suficiente!", ConsoleColor.Red);
                Console.ReadLine();
                return;
            }
            requisicao.medicamento.DiminuirQuantidade(requisicao.quantidadeMedicamento);
            
            VisualizarPreRequisitosPacientes(true);
            Console.WriteLine("Id do paciente: ");
            int idPaciente = Convert.ToInt32(Console.ReadLine());
            Paciente paciente = repositorioPaciente.BuscarPorId(idPaciente);
            requisicao.paciente = paciente;

            VisualizarPreRequisitosFuncionario(true);
            Console.WriteLine("Id do funcionário: ");
            int idFuncionario = Convert.ToInt32(Console.ReadLine());
            Funcionario funcionario = repositorioFuncionario.BuscarPorId(idFuncionario);
            requisicao.funcionario = funcionario;

            repositorioRequisicao.AdicionarNaLista(requisicao);
            ApresentarMensagem("Requisição adicionada com sucesso!", ConsoleColor.Green);
            
            repositorioMedicamento.ValidarDisponibilidade();
            Console.ReadLine();
        }
        internal bool VisualizarRequisicoes(bool temRequisicao)
        {
            if (repositorioRequisicao.listaRegistros.Count == 0)
            {
                ApresentarMensagem("Não há requisições registradas!", ConsoleColor.Red);
                Console.ReadKey();
                return false;
            }
            ApresentarMensagem("\nRequisições", ConsoleColor.Yellow);
            Console.WriteLine();
            Console.WriteLine("| {0, -3} | {1, -20} | {2, -20} | {3, -20} | {4, -20} ", " ID", "Paciente", "Funcionário", "Medicamento", "Quantidade retirada");
            Console.WriteLine(" ---------------------------------------------------------------------------------------------------------- ");

            foreach (Requisicao requisicao in repositorioRequisicao.listaRegistros)
            {
                Console.WriteLine("| {0, -3} | {1, -20} | {2, -20} | {3, -20} | {4, -20} ", requisicao.id, requisicao.paciente.nome, requisicao.funcionario.nomeFuncionario, requisicao.medicamento.nome, requisicao.quantidadeMedicamento);
            }

            Console.ReadLine();
            return true;
        }
        public bool VisualizarPreRequisitosPacientes(bool temRequisitos)
        {
            
            if (repositorioPaciente.listaRegistros.Count == 0)
            {
                ApresentarMensagem("Não há pacientes registrados!", ConsoleColor.Red);
                Console.ReadKey();
                return false;
            }

            ApresentarMensagem("\nPacientes: ", ConsoleColor.Green);
            Console.WriteLine();
            Console.WriteLine("| {0, -3} | {1, -20} |", " ID", "Paciente");
            Console.WriteLine(" -------------------------------- ");
            
            foreach (Paciente paciente in repositorioPaciente.listaRegistros)
            {
                Console.WriteLine("| {0, -3} | {1, -20} |", paciente.id, paciente.nome);
                
            }
            Console.WriteLine();

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
            ApresentarMensagem("\nMedicamentos: ", ConsoleColor.Green);
            Console.WriteLine();
            Console.WriteLine("| {0, -3} | {1, -20} | {2, -13} |", " ID", "Medicamento", "Quantidade");
            Console.WriteLine(" ---------------------------------------- ");
            foreach (Medicamento medicamento in repositorioMedicamento.listaRegistros)
            {
                Console.WriteLine("| {0, -3} | {1, -20} | {2, -13} |", medicamento.id, medicamento.nome, medicamento.quantidade);
            }
            Console.WriteLine();

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
            
            ApresentarMensagem("\nFuncionários: ", ConsoleColor.Green);
            Console.WriteLine();
            Console.WriteLine("| {0, -3} | {1, -20} |", " ID", "Funcionario");
            Console.WriteLine(" -------------------------------- ");
            foreach (Funcionario funcionario in repositorioFuncionario.listaRegistros)
            {
                Console.WriteLine("| {0, -3} | {1, -20} |", funcionario.id, funcionario.nomeFuncionario);
            }
            Console.WriteLine();


            return true;

        }
        public void MedicamentosMaisSolicitados()
        {
            ArrayList requisicoes = repositorioRequisicao.BuscarTodos();
            List<Requisicao> requisicao = new List<Requisicao>(requisicoes.Cast<Requisicao>());
            List<Requisicao> listaOrdenada = requisicao.OrderByDescending(i => i.quantidadeMedicamento).ToList();

            ApresentarMensagem("Medicamentos mais retirados: ", ConsoleColor.Blue);
            Console.WriteLine("| {0, -3} | {1, -20} | {2, -20} |", "ID", "Nome", "Quantidade");
            Console.WriteLine(" -------------------------------- ");
            
            foreach (Requisicao re in listaOrdenada) 
            {
                Console.WriteLine("| {0, -3} | {1, -20} | {2, -20} |", re.id, re.medicamento.nome, re.quantidadeMedicamento);
            }
            Console.ReadLine();
        }
    }
}
