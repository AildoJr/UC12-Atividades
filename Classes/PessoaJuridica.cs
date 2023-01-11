using Pessoas.Interfaces;
using System.Text.RegularExpressions;

namespace Pessoas.Classes
{
    public class PessoaJuridica : Pessoa, IPessoaJuridica
    {
        public string ?cnpj{get;set;}

        public PessoaJuridica()
        {

        }

        public PessoaJuridica(string NomePesJur, string CadPesJur)
        {
            this.nome = NomePesJur;
            this.cnpj = CadPesJur;
        }
        public PessoaJuridica(string NomePesJur, string CadPesJur, float faturamento)
        {
            this.nome = NomePesJur;
            this.cnpj = CadPesJur;
            this.rendimento = faturamento;
        }

        public override float pagarImposto()
        {
            if(rendimento <= 5000)
            {
                return (rendimento * 0.06f);
            }
            if(rendimento <= 10000) //  Não é necessário o else, pois caso a condição anterior seja verdadeira, a execução desse trecho de código será interrompida pelo return
            {
                return (rendimento * 0.08f);
            }
            return rendimento * 0.10f; //  Não é necessário o else, pois caso alguma das condições anteriores sejam verdadeiras, a execução desse trecho de código será interrompida pelo return
        }

        public override float pagarImposto(float faturamento)
        {
            if(faturamento <= 5000)
            {
                return (faturamento * 0.06f);
            }
            if(faturamento <= 10000) //  Não é necessário o else, pois caso a condição anterior seja verdadeira, a execução desse trecho de código será interrompida pelo return
            {
                return (faturamento * 0.08f);
            }
            return faturamento * 0.10f; //  Não é necessário o else, pois caso alguma das condições anteriores sejam verdadeiras, a execução desse trecho de código será interrompida pelo return
        }
        public bool validarCNPJ(string cnpj)
        {
            // Consideramos duas formas de se escrever um CPF:
            // 1 - Completo, com números, pontos, barra e traço: 12.345.678/0001-23       18 dígitos
            // 2 - Apenas números: 12345678000123           14 dígitos
            // A matriz de uma empresa tem a sequência 0001 no CNPJ. Preisaremos verificar se essa seqüência está presente!

            if (Regex.IsMatch(cnpj, @"^(\d{2}[\.]\d{3}[\.]\d{3}[/]\d{4}[-]\d{2})$")) // Utilizando a função Regex para verificar se o CNPJ segue o primeiro padrão
            {
                if (cnpj.Substring(11, 4) == "0001") // Verificando se a sequência 0001 está presente
                { 
                    Console.WriteLine("CNPJ válido!");
                    return true;
                }
            }//  Não é necessário o else, pois caso a condição anterior seja verdadeira, a execução desse trecho de código será interrompida pelo "return true"
            if(Regex.IsMatch(cnpj,@"^([0-9]{14})$")) // [0-9] tem o mesmo efeito de \d
            {
                if (cnpj.Substring(8, 4) == "0001") // Verificando se a sequência 0001 está presente
                { 
                    Console.WriteLine("CNPJ válido!");
                    return true;
                }
            }//  Não é necessário o else, pois caso a condição anterior seja verdadeira, a execução desse trecho de código será interrompida pelo "return true"
            Console.WriteLine("CNPJ inválido!");
            return false;
        }
    }
}