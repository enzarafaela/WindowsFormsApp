using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp
{
    public class Funcionario
    {

        public string nome, cpf;
        public float salarioBruto, desconto, adicional, salarioLiquido;

        public Funcionario(string nomeParam, float salarioBrutoParam, string CPF)
        {
            this.nome = nomeParam;
            this.salarioBruto = salarioBrutoParam;
            this.cpf = CPF;
        }

        public Funcionario(string nomeParam, float salarioBrutoParam, 
                          float descontoParam, float adicionalParam, string CPF)
        {
            this.nome = nomeParam;
            this.salarioBruto = salarioBrutoParam;
            this.adicional = adicionalParam;
            this.desconto = descontoParam;
            this.cpf = CPF;
        }

       
        public void CalcularLiquido(float salario, float desconto, float adicional)
        {
            this.salarioLiquido = ((salario - desconto) + adicional);
        }

        public void CalcularLiquido(float salario, float adicional)
        {
            this.salarioLiquido = (salario + adicional);
        }
    }
}
