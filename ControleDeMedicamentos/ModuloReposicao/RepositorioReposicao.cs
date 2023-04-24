using ControleDeMedicamentos.ModuloMae;
using ControleDeMedicamentos.ModuloPaciente;
using ControleDeMedicamentos.ModuloRequisicao;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleDeMedicamentos.ModuloReposicao
{
    internal class RepositorioReposicao : RepositorioMae
    {
        public void AdicionarNaLista(Reposicao reposicao)
        {
            reposicao.AdicionarId();
            listaRegistros.Add(reposicao);
        }
        public ArrayList BuscarTodos()
        {
            return listaRegistros;
        }
        public Reposicao BuscarPorId(int id)
        {
            foreach (Reposicao reposicao in listaRegistros)
            {
                if (reposicao.id == id)
                {
                    return reposicao;
                }
            }
            return null!;

        }
        public void Excluir(Reposicao reposicao)
        {
            listaRegistros.Remove(reposicao);
        }
    }
}
