using ControleDeMedicamentos.ModuloFornecedor;
using ControleDeMedicamentos.ModuloFuncionario;
using ControleDeMedicamentos.ModuloMae;
using ControleDeMedicamentos.ModuloMedicamento;
using ControleDeMedicamentos.ModuloPaciente;
using ControleDeMedicamentos.ModuloReposicao;
using ControleDeMedicamentos.ModuloRequisicao;

namespace ControleDeMedicamentos
{
    internal class Program
    {
        static void Main(string[] args)
        {
            TelaMae telaMae = new TelaMae();
            RepositorioFuncionario repositorioFuncionario = new RepositorioFuncionario();
            TelaFuncionario telaFuncionario = new TelaFuncionario(repositorioFuncionario);
           
            RepositorioPaciente repositorioPaciente = new RepositorioPaciente();
            TelaPaciente telaPaciente = new TelaPaciente(repositorioPaciente);

            RepositorioFornecedor repositorioFornecedor = new RepositorioFornecedor();
            TelaFornecedor telaFornecedor = new TelaFornecedor(repositorioFornecedor);

            RepositorioMedicamento repositorioMedicamento = new RepositorioMedicamento();
            TelaMedicamento telaMedicamento = new TelaMedicamento(repositorioMedicamento, repositorioFornecedor);

            RepositorioRequisicao repositorioRequisicao = new RepositorioRequisicao();
            TelaRequisicao telaRequisicao = new TelaRequisicao(repositorioRequisicao, repositorioMedicamento, repositorioFuncionario, repositorioPaciente);

            RepositorioReposicao repositorioReposicao = new RepositorioReposicao();
            TelaReposicao telaReposicao = new TelaReposicao(repositorioReposicao, repositorioMedicamento, repositorioFuncionario, repositorioFornecedor);

            telaFuncionario.ApresentarFuncionarioTeste();
            telaFornecedor.ApresentarFornecedorTeste();
            telaMedicamento.ApresentarMedicamentoTeste();
            telaPaciente.ApresentarPacienteTeste();

            string opcao;
            while (true)
            {   
                opcao = telaMae.ApresentarMenu();
                if(opcao == "7")
                {
                    break;
                }else if(opcao == "1") 
                {
                    string opcaoMenu2 = telaFuncionario.ApresentarMenuFuncionario();
                    if(opcaoMenu2 == "5")
                    {
                        continue;
                    }else if(opcaoMenu2 == "1")
                    {
                        telaFuncionario.CadastrarFuncionario();
                    }else if(opcaoMenu2 == "2")
                    {
                        bool temFuncionario = telaFuncionario.VisualizarFuncionario(true);
                        if(temFuncionario)
                        {
                            
                        }
                    }else if(opcaoMenu2 == "3")
                    {
                        telaFuncionario.EditarFuncionario();
                    }else if(opcaoMenu2 == "4")
                    {
                        telaFuncionario.ExcluirFuncionario();
                    }
                }else if( opcao == "2")
                {
                    string opcaoMenu3 = telaPaciente.ApresentarMenuPaciente();
                    if (opcaoMenu3 == "5")
                    {
                        continue;
                    }
                    else if (opcaoMenu3 == "1")
                    {
                        telaPaciente.CadastrarPaciente();
                    }
                    else if (opcaoMenu3 == "2")
                    {
                        bool temPaciente = telaPaciente.VisualizarPaciente(true);
                        if (temPaciente)
                        {

                        }
                    }
                    else if (opcaoMenu3 == "3")
                    {
                        telaPaciente.EditarPaciente();
                    }
                    else if (opcaoMenu3 == "4")
                    {
                        telaPaciente.ExcluirPaciente();
                    }
                }else if (opcao == "3")
                {
                    string opcaoMenu4 = telaMedicamento.ApresentarMenuMedicamento();
                    if (opcaoMenu4 == "5")
                    {
                        continue;
                    }
                    else if (opcaoMenu4 == "1")
                    {
                        telaMedicamento.CadastrarMedicamento();
                    }
                    else if (opcaoMenu4 == "2")
                    {
                        bool temMedicamento = telaMedicamento.VisualizarMedicamento(true);
                        if (temMedicamento)
                        {

                        }
                    }
                    else if (opcaoMenu4 == "3")
                    {
                        telaMedicamento.EditarMedicamento();
                    }
                    else if (opcaoMenu4 == "4")
                    {
                        telaMedicamento.ExcluirMedicamento();
                    }
                }else if(opcao == "4")
                {
                    string opcaoMenu5 = telaFornecedor.ApresentarMenuFornecedor();
                    if (opcaoMenu5 == "5")
                    {
                        continue;
                    }
                    else if (opcaoMenu5 == "1")
                    {
                        telaFornecedor.CadastrarFornecedor();
                    }
                    else if (opcaoMenu5 == "2")
                    {
                        bool temFornecedor = telaFornecedor.VisualizarFornecedor(true);
                        if (temFornecedor)
                        {

                        }
                    }
                    else if (opcaoMenu5 == "3")
                    {
                        telaFornecedor.EditarFornecedor();
                    }
                    else if (opcaoMenu5 == "4")
                    {
                        telaFornecedor.ExcluirFornecedor();
                    }
                }else if(opcao == "5")
                {
                    string opcaoMenu6 = telaRequisicao.ApresentarMenuRequisicao();
                    if (opcaoMenu6 == "6")
                    {
                        continue;
                    }
                    else if (opcaoMenu6 == "1")
                    {
                        telaRequisicao.CadastrarRequisicao();
                    }else if (opcaoMenu6 == "2")
                    {
                        telaRequisicao.VisualizarRequisicoes(true);
                    }else if( opcaoMenu6 == "3")
                    {
                        telaRequisicao.MedicamentosMaisSolicitados();
                    }else if (opcaoMenu6 == "4")
                    {
                        telaRequisicao.EditarRequisicao();
                    }else if(opcaoMenu6 == "5")
                    {
                        telaRequisicao.ExcluirRequisicao();
                    }
                }else if(opcao == "6")
                {
                    string opcaoMenu7 = telaReposicao.ApresentarMenuReposicao();
                    if(opcaoMenu7 == "6")
                    {
                        continue;
                    }else if(opcaoMenu7 == "1")
                    {
                        telaReposicao.CadastrarNovaReposicao();
                    }else if(opcaoMenu7 == "2")
                    {
                        telaReposicao.VisualizarReposicoes(true);
                    }else if(opcaoMenu7 == "3")
                    {
                        telaReposicao.MedicamentosMaisRepostos();
                    }else if( opcaoMenu7 == "4")
                    {
                        telaReposicao.EditarReposicao();
                    }else if( opcaoMenu7 == "5")
                    {
                        telaReposicao.ExcluirReposicao();
                    }
                }
            }
        }
    }
}