using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp
{
    public class Funcionario
    {

        public string nome, cpf, cargo;
        public float desconto, adicional, salarioLiquido;
        private float salarioBruto;

        // encapsulamento
        public float SalarioBruto {
            // acessador get = obtem o valor do campo
            get => salarioBruto;

            // acessador set = "seta" um valor no campo
            set {
                if (value > 0) // posso criar validações antes de "setar"
                    salarioBruto = value;
            }
        }

        //TrÊs Sobrecargas do Construtor "Funcionario"

        // Construtor com 3 parametros
        public Funcionario(string nomeParam, float salarioBrutoParam, string CPF)
        {
            this.nome = nomeParam;
            this.SalarioBruto = salarioBrutoParam;
            this.cpf = CPF;
        }

        // Construtor vazio
        public Funcionario()
        {

        }

        // Construtor com cinco parametros
        public Funcionario(string nomeParam, float salarioBrutoParam, 
                          float descontoParam, float adicionalParam, string CPF, string cargoParam)
        {
            this.nome = nomeParam;
            this.SalarioBruto = salarioBrutoParam;
            this.adicional = adicionalParam;
            this.desconto = descontoParam;
            this.cpf = CPF;
            this.cargo = cargoParam;
        }

        
        // Sobrecarga do Metodo CalcularLiquido 
        // Sobrecarga= diferencia-se pela assinatura (parametros)
        // Executa ou um ou outro metodo. Vai depender dos parametros.
        public void CalcularLiquido(float salario, float desconto, float adicional) 
        {
            this.salarioLiquido = ((salario - desconto) + adicional);
        }

        public void CalcularLiquido(float salario, float adicional)
        {
            this.salarioLiquido = (salario + adicional);
        }

        public void CalcularBonus()
        {
            this.adicional = this.SalarioBruto * 1 / 100;
        }
    }
}
