using ControleDeMedicamentos.ModuloMae;
using ControleDeMedicamentos.ModuloMedicamento;
using ControleDeMedicamentos.ModuloPaciente;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleDeMedicamentos.ModuloFornecedor
{
    internal class TelaFornecedor : TelaMae
    {
        private RepositorioFornecedor repositorioFornecedor;
        public TelaFornecedor(RepositorioFornecedor repositorioFornecedor)
        {
            this.repositorioFornecedor = repositorioFornecedor;
        }

        internal string ApresentarMenuFornecedor()
        {
            Console.Clear();
            ApresentarCabecalho("Menu de Fornecedores", ConsoleColor.Yellow);
            Console.WriteLine(" [1] - Cadastrar novo fornecedor ");
            Console.WriteLine(" [2] - Visualizar fornecedores ");
            Console.WriteLine(" [3] - Editar fornecedores ");
            Console.WriteLine(" [4] - Excluir fornecedores ");
            Console.WriteLine(" [5] - Sair ");
            string opcao = Console.ReadLine();

            return opcao;
        }

        internal void CadastrarFornecedor()
        {
            Console.Clear();
            ApresentarCabecalho("Cadastro de Fornecedores", ConsoleColor.Yellow);

            Fornecedor fornecedor = new Fornecedor();

            Console.Write("Nome: ");
            fornecedor.nome = Console.ReadLine();

            Console.Write("Empresa: ");
            fornecedor.empresa = Console.ReadLine();

            Console.Write("CNPJ: ");
            fornecedor.cnpj = Console.ReadLine();

            Console.Write("Telefone: ");
            fornecedor.telefone = Console.ReadLine();

            repositorioFornecedor.AdicionarNaLista(fornecedor);

            ApresentarMensagem("Fornecedor registrado com sucesso!", ConsoleColor.Green);

            Console.ReadLine();
        }

        public void EditarFornecedor()
        {
            bool temFornecedor = VisualizarFornecedor(false);
            if (temFornecedor == false)
            {
                return;
            }

            ApresentarCabecalho("Editar fornecedor", ConsoleColor.Cyan);
            Console.WriteLine("Digite o Id do fornecedor: ");
            int posicao = Convert.ToInt32(Console.ReadLine());

            Fornecedor fornecedorEditado = repositorioFornecedor.BuscarPorId(posicao);

            Console.Write("Nome: ");
            fornecedorEditado.nome = Console.ReadLine();

            Console.Write("Empresa: ");
            fornecedorEditado.empresa = Console.ReadLine();

            Console.Write("CNPJ: ");
            fornecedorEditado.cnpj = Console.ReadLine();

            Console.Write("Telefone: ");
            fornecedorEditado.telefone = Console.ReadLine();


            ApresentarMensagem("Fornecedor editado com sucesso!", ConsoleColor.Green);
            Console.ReadLine();

        }
        public bool VisualizarFornecedor(bool mostrarCabecalho)
        {
            Console.Clear();
            if (repositorioFornecedor.listaRegistros.Count == 0)
            {
                ApresentarMensagem("Não há fornecedores cadastrados", ConsoleColor.Red);
                Console.ReadLine();
                return false;
            }
            ApresentarCabecalho("Fornecedores", ConsoleColor.Cyan);

            Console.WriteLine("| {0, -3} | {1, -30} | {2,-20} | {3,-25} | {4,-13} |", " ID", "Nome", "Empresa", "CNPJ", "Telefone");

            Console.WriteLine(" ---------------------------------------------------------------------------------------------------------- ");

            foreach (Fornecedor fornecedor in repositorioFornecedor.listaRegistros)
            {
                Console.WriteLine("| {0, -3} | {1, -30} | {2,-20} | {3,-25} | {4,-13} |", fornecedor.id, fornecedor.nome, fornecedor.empresa, fornecedor.cnpj, fornecedor.telefone);
                Console.WriteLine(" ---------------------------------------------------------------------------------------------------------- ");
            }
            Console.ReadLine();
            return true;
        }

        internal void ExcluirFornecedor()
        {
            bool temFornecedor = VisualizarFornecedor(false);
            if (temFornecedor == false)
            {
                return;
            }
            ApresentarCabecalho("Excluindo fornecedor", ConsoleColor.Cyan);
            Console.WriteLine("Digite o Id do fornecedor: ");
            int posicao = Convert.ToInt32(Console.ReadLine());

            Fornecedor fornecedorDeletado = repositorioFornecedor.BuscarPorId(posicao);

            repositorioFornecedor.Excluir(fornecedorDeletado);
            ApresentarMensagem("Fornecedor excluído com sucesso!", ConsoleColor.Green);
            Console.ReadLine();
        }
        public void ApresentarFornecedorTeste()
        {
            Fornecedor fornecedorTeste = new Fornecedor();

            fornecedorTeste.nome = "Chico Silva";
            fornecedorTeste.empresa = "Libbs";
            fornecedorTeste.telefone = "49999400611";
            fornecedorTeste.cnpj = "61.586.558/0013-29";

            this.repositorioFornecedor.AdicionarNaLista(fornecedorTeste);
        }
    }
}
