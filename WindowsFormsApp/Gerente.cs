using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp
{
    class Gerente : Funcionario
    {
        string setor;

        public new void CalcularBonus() // sobrescrita
        {
            this.adicional = this.SalarioBruto * 2 / 100;
        }

        public new void CalcularBonus(string tipo) // sobrecarga
        {
            this.adicional = this.SalarioBruto * 2 / 100;
        }

        public Gerente(string nomeParam, float salarioBrutoParam,
                       float descontoParam, float adicionalParam, string CPF, string cargo)
        {

            this.nome = nomeParam;
            this.SalarioBruto = salarioBrutoParam;
            this.adicional = adicionalParam;
            this.desconto = descontoParam;
            this.cpf = CPF;
            this.cargo = cargo;
        }
    }
}
