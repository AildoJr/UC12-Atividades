using Pessoas.Interfaces;
using System.Text.RegularExpressions;

namespace Pessoas.Classes
{
    public class PessoaJuridica : Pessoa, IPessoaJuridica
    {
        public string ?cnpj{get;set;}

        public override float pagarImposto(float rendimento)
        {
            return rendimento;
        }
        public bool validarCNPJ(string cnpj)
        {
            // Consideramos duas formas de se escrever um CPF:
            // 1 - Completo, com números, pontos, barra e traço: 12.345.678/0001-23       18 dígitos
            // 2 - Apenas números: 12345678000123           14 dígitos
            // A matriz de uma empresa tem a sequência 0001 no CNPJ. Preisaremos verificar se essa seqüência está presente!

            if (Regex.IsMatch(cnpj, @"^(\d{2}[\.]\d{3}[\.]\d{3}[/]\d{4}[-]\d{2})$")) // Utilizando a função Regex para verificar se o CNPJ segue o primeiro padrão
            {
                if (cnpj.Length == 18) // Verificando se tem o número correto de dígitos, nesse caso, 18.
                {
                    if (cnpj.Substring(11, 4) == "0001") // Verificando se a sequência 0001 está presente
                    { 
                        Console.WriteLine("CNPJ válido!");
                        return true;
                    }
                }
            }
            else // Se não seguir o formato 1, pode estar apenas com números: formato 2
            {
                if(Regex.IsMatch(cnpj,@"^([0-9]{14})$")) // [0-9] tem o mesmo efeito de \d
                {
                    if (cnpj.Substring(8, 4) == "0001") // Verificando se a sequência 0001 está presente
                    { 
                        Console.WriteLine("CNPJ válido!");
                        return true;
                    }
                }
                
            }
            Console.WriteLine("CNPJ inválido!");
            return false;
        }
    }
}