using ControleDeMedicamentos.ModuloFuncionario;
using ControleDeMedicamentos.ModuloMae;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleDeMedicamentos.ModuloRequisicao
{
    internal class RepositorioRequisicao : RepositorioMae
    {
        public void AdicionarNaLista(Requisicao requisicao)
        {
            requisicao.AdicionarId();
            listaRegistros.Add(requisicao);
        }
        public ArrayList BuscarTodos()
        {
            return listaRegistros;
        }
        public Requisicao BuscarPorId(int id)
        {
            foreach (Requisicao requisicao in listaRegistros)
            {
                if (requisicao.id == id)
                {
                    return requisicao;
                }
            }
            return null!;

        }
    }
}
