using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleDeMedicamentos.ModuloFuncionario
{
    public class Funcionario
    {
        public string nomeFuncionario { get; set; }
        public string unidadeSaude { get; set; }
        public string endereco { get; set; }
        public string cpf { get; set; }
        public string telefone { get; set; }

        public int id { get; private set; }
        public Funcionario(string nome, string unidade, string endereco, string cpf, string telefone)
        {
            nomeFuncionario = nome;
            unidadeSaude = unidade;
            this.endereco = endereco;
            this.cpf = cpf;
            this.telefone = telefone;
        }
        public static int contadorId = 1;
        public void AdicionarId()
        {
            id = contadorId++;
        }



    }
}
