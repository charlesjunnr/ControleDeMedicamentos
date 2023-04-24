using ControleDeMedicamentos.ModuloMae;
using ControleDeMedicamentos.ModuloPaciente;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleDeMedicamentos.ModuloFornecedor
{
    public class RepositorioFornecedor : RepositorioMae
    {
        public void AdicionarNaLista(Fornecedor fornecedor)
        {
            fornecedor.AdicionarId();
            listaRegistros.Add(fornecedor);
        }
        public ArrayList BuscarTodos()
        {
            return listaRegistros;
        }
        public Fornecedor BuscarPorId(int id)
        {
            foreach (Fornecedor fornecedor in listaRegistros)
            {
                if (fornecedor.id == id)
                {
                    return fornecedor;
                }
            }
            return null!;

        }
        public void Excluir(Fornecedor fornecedor)
        {
            listaRegistros.Remove(fornecedor);
        }
    }
}
