using ControleDeMedicamentos.ModuloFornecedor;
using ControleDeMedicamentos.ModuloFuncionario;
using ControleDeMedicamentos.ModuloMae;
using ControleDeMedicamentos.ModuloPaciente;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleDeMedicamentos.ModuloMedicamento
{
    internal class TelaMedicamento : TelaMae
    {
        private RepositorioMedicamento repositorioMedicamento;
        private RepositorioFornecedor repositorioFornecedor;
        public TelaMedicamento(RepositorioMedicamento repositorioMedicamento, RepositorioFornecedor repositorioFornecedor)
        {
            this.repositorioMedicamento = repositorioMedicamento;
            this.repositorioFornecedor = repositorioFornecedor;
        }

        internal string ApresentarMenuMedicamento()
        {
            Console.Clear();
            ApresentarCabecalho("Menu de Medicamentos", ConsoleColor.Yellow);
            Console.WriteLine(" [1] - Cadastrar novo medicamento ");
            Console.WriteLine(" [2] - Visualizar medicamentos ");
            Console.WriteLine(" [3] - Editar medicamentos ");
            Console.WriteLine(" [4] - Excluir medicamentos ");
            Console.WriteLine(" [5] - Sair ");
            Console.WriteLine(" ---------------------------------------------------------------------------------------------------------- ");

            string opcao = Console.ReadLine();

            return opcao;
        }
        internal void CadastrarMedicamento()
        {
            Console.Clear();
            ApresentarCabecalho("Cadastro de Medicamentos", ConsoleColor.Yellow);

            Medicamento medicamento = new Medicamento();

            Console.Write("Nome: ");
            medicamento.nome = Console.ReadLine();

            Console.Write("Número de caixas: ");
            medicamento.quantidade = Convert.ToInt32(Console.ReadLine());
            

            Console.Write("Tipo: ");
            medicamento.tipo = Console.ReadLine();
            
            VisualizarFornecedorAtual();
            Console.Write("Id do fornecedor: ");
            int id = Convert.ToInt32(Console.ReadLine());

            Fornecedor fornecedor = repositorioFornecedor.BuscarPorId(id);
            if(fornecedor == null)
            {
                return;
            }
            medicamento.Fornecedor = fornecedor;
            

            repositorioMedicamento.AdicionarNaLista(medicamento);
            ApresentarMensagem("Medicamento cadastrado com sucesso!", ConsoleColor.Green);
            Console.ReadLine();
            repositorioMedicamento.ValidarDisponibilidade();
        }
        public void VisualizarFornecedorAtual()
        {
            ApresentarCabecalho("Fornecedores", ConsoleColor.Yellow);

            Console.WriteLine("| {0, -3} | {1, -30} | {2,-20} | {3,-25} | {4,-13} |", " ID", "Nome", "Empresa", "CNPJ", "Telefone");

            Console.WriteLine(" ---------------------------------------------------------------------------------------------------------- ");

            foreach (Fornecedor fornecedor in this.repositorioFornecedor.listaRegistros)
            {
                Console.WriteLine("| {0, -3} | {1, -30} | {2,-20} | {3,-25} | {4,-13} |", fornecedor.id, fornecedor.nome, fornecedor.empresa, fornecedor.cnpj, fornecedor.telefone);
            }
            Console.ReadLine();
            
        }
        public void EditarMedicamento()
        {
            bool temMedicamento = VisualizarMedicamento(false);
            if (temMedicamento == false)
            {
                return;
            }

            ApresentarCabecalho("Editar medicamento", ConsoleColor.Yellow);
            Console.WriteLine("Digite o Id do medicamento: ");
            int posicao = Convert.ToInt32(Console.ReadLine());

            Medicamento medicamentoEditado = repositorioMedicamento.BuscarPorId(posicao);

            Console.Write("Nome: ");
            medicamentoEditado.nome = Console.ReadLine();

            Console.Write("Quantidade de caixas: ");
            medicamentoEditado.quantidade = Convert.ToInt32(Console.ReadLine());
            

            Console.Write("Tipo: ");
            medicamentoEditado.tipo = Console.ReadLine();

            ApresentarMensagem("Medicamento editado com sucesso!", ConsoleColor.Green);
            Console.ReadLine();
            repositorioMedicamento.ValidarDisponibilidade();
        }
        public bool VisualizarMedicamento(bool mostrarCabecalho)
        {
            Console.Clear();
            if (repositorioMedicamento.listaRegistros.Count == 0)
            {
                ApresentarMensagem("Não há medicamentos cadastrados", ConsoleColor.Red);
                Console.ReadLine();
                return false;
            }
            ApresentarCabecalho("Medicamentos", ConsoleColor.Magenta);

            Console.WriteLine("| {0, -3} | {1, -30} | {2,-20} | {3,-20} | {4,-17} | {5,-10} |", " ID", "Nome", "Tipo", "Quantidade de caixas", "Fornecedor", "Disponibilidade");
            Console.WriteLine(" -------------------------------------------------------------------------------------------------------------------- ");

            string mensagem = "";
            foreach (Medicamento medicamento in repositorioMedicamento.listaRegistros)
            {
                if (medicamento.estaDisponivel == true)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    mensagem = "Disponível";
                    
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    mensagem = "Indisponível";
                    
                }
                Console.WriteLine("| {0, -3} | {1, -30} | {2,-20} | {3,-20} | {4,-17} | {5,-10} |", medicamento.id, medicamento.nome, medicamento.tipo, medicamento.quantidade, medicamento.Fornecedor.nome, mensagem);

                Console.ResetColor();
            }
            Console.WriteLine();
            Console.ReadLine();
            return true;
        }
        internal void ExcluirMedicamento()
        {
            bool temMedicamento = VisualizarMedicamento(false);
            if (temMedicamento == false)
            {
                return;
            }
            ApresentarCabecalho("Excluindo medicamento", ConsoleColor.Yellow);
            Console.WriteLine("Digite o Id do medicamento: ");
            int posicao = Convert.ToInt32(Console.ReadLine());

            Medicamento medicamentoDeletado = repositorioMedicamento.BuscarPorId(posicao);

            repositorioMedicamento.Excluir(medicamentoDeletado);
            ApresentarMensagem("Medicamento excluído com sucesso!", ConsoleColor.Green);
            Console.ReadLine();
        }
        public void ApresentarMedicamentoTeste()
        {
            Medicamento medicamentoTeste = new Medicamento();

            medicamentoTeste.nome = "Zetran XL";
            medicamentoTeste.quantidade = 10;
            medicamentoTeste.tipo = "Antidepressivo";
            medicamentoTeste.estaDisponivel = true;
            Fornecedor fornecedorTeste = repositorioFornecedor.BuscarPorId(1);
            medicamentoTeste.Fornecedor = fornecedorTeste;

            this.repositorioMedicamento.AdicionarNaLista(medicamentoTeste);
        }
        
    }
}
