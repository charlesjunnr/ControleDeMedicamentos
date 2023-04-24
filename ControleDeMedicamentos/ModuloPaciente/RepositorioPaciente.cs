using ControleDeMedicamentos.ModuloFuncionario;
using ControleDeMedicamentos.ModuloMae;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleDeMedicamentos.ModuloPaciente
{
    public class RepositorioPaciente : RepositorioMae
    {
        public void AdicionarNaLista(Paciente paciente)
        {
            paciente.AdicionarId();
            listaRegistros.Add(paciente);
        }
        public ArrayList BuscarTodos()
        {
            return listaRegistros;
        }
        public Paciente BuscarPorId(int id)
        {
            foreach (Paciente paciente in listaRegistros)
            {
                if (paciente.id == id)
                {
                    return paciente;
                }
            }
            return null!;

        }
        public void Excluir(Paciente paciente)
        {
            listaRegistros.Remove(paciente);
        }
    }
}
