using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp
{
    public class ListaFuncionario
    {
        List<Funcionario> Funcionarios = new List<Funcionario>();
                
        public void ArmazenarFuncionario(string nome, float salario, float desconto,
                                         float adicional, string cpf, bool semDesconto)
        {
            Funcionario funcionarioObj = new Funcionario(nome, salario, desconto, adicional, cpf);

            if (semDesconto)
                funcionarioObj.CalcularLiquido(funcionarioObj.salarioBruto, funcionarioObj.adicional);
            else
                funcionarioObj.CalcularLiquido(funcionarioObj.salarioBruto, funcionarioObj.desconto, funcionarioObj.adicional);

            Funcionarios.Add(funcionarioObj);

        }

        public void RemoverFuncionario(string cpf)
        {
            // Implementar
        }

        public void BuscarFuncionario(string cpf)
        {
            //Implementar
        }

        
    }
}
