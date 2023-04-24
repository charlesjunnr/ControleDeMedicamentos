using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ControleDeMedicamentos.ModuloMae;

namespace ControleDeMedicamentos.ModuloFuncionario
{
    public class RepositorioFuncionario : RepositorioMae
    {
        public void AdicionarNaLista(Funcionario funcionario)
        {
            funcionario.AdicionarId();
            listaRegistros.Add(funcionario);
        }
        public ArrayList BuscarTodos()
        {
            return listaRegistros;
        }
        public Funcionario BuscarPorId(int id)
        {
            foreach (Funcionario funcionario in listaRegistros)
            {
                if (funcionario.id == id)
                {
                    return funcionario;
                }
            }
            return null!;

        }
        public void Excluir(Funcionario funcionario)
        {
            listaRegistros.Remove(funcionario);
        }
    }
}
