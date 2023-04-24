using ControleDeMedicamentos.ModuloMae;
using ControleDeMedicamentos.ModuloPaciente;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleDeMedicamentos.ModuloMedicamento
{
    internal class RepositorioMedicamento : RepositorioMae 
    {
        public void AdicionarNaLista(Medicamento medicamento)
        {
            medicamento.AdicionarId();
            listaRegistros.Add(medicamento);
        }
        public ArrayList BuscarTodos()
        {
            return listaRegistros;
        }
        public Medicamento BuscarPorId(int id)
        {
            foreach (Medicamento medicamento in listaRegistros)
            {
                if (medicamento.id == id)
                {
                    return medicamento;
                }
            }
            return null!;

        }
        public void Excluir(Medicamento medicamento)
        {
            listaRegistros.Remove(medicamento);
        }
        public void ValidarDisponibilidade()
        {
            foreach (Medicamento medicamento in listaRegistros)
            {
                if (medicamento.quantidade > 0)
                {
                    medicamento.estaDisponivel = true;
                }
                else
                {
                    medicamento.estaDisponivel = false;
                }
            }
        }
    }
}
