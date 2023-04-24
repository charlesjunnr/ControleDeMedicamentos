using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleDeMedicamentos.ModuloPaciente
{
    public class Paciente
    {
        public string nome { get; set; }
        public string cartaoSUS { get; set; }
        public string area { get; set; }
        public string telefone { get; set; }
        public int id;
        public static int contadorId = 1;
        public void AdicionarId()
        {
            id = contadorId++;
        }
    }
}
