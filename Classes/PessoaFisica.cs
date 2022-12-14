using Pessoas.Interfaces;

namespace Pessoas.Classes
{
    public class PessoaFisica : Pessoa, IPessoaFisica
    {
        public string ?cpf{get;set;}

        public DateTime ?dataNascimento{get;set;}

        public PessoaFisica()
        {

        }

        public PessoaFisica(string NomePesFis, string CadPesFis)
        {
            this.nome = NomePesFis;
            this.cpf = CadPesFis;
        }
        public PessoaFisica(string NomePesFis, string CadPesFis, DateTime dataNasc)
        {
            this.nome = NomePesFis;
            this.cpf = CadPesFis;
            this.dataNascimento = dataNasc;
        }
        public PessoaFisica(string NomePesFis, string CadPesFis, float salario)
        {
            this.nome = NomePesFis;
            this.cpf = CadPesFis;
            this.rendimento = salario;
        }
        public PessoaFisica(string NomePesFis, string CadPesFis, DateTime dataNasc, float salario)
        {
            this.nome = NomePesFis;
            this.cpf = CadPesFis;
            this.dataNascimento = dataNasc;
            this.rendimento = salario;
        }

        public override float pagarImposto()
        {
            if(rendimento <= 1500)
            {
                return 0;
            }
            if(rendimento <= 5000)//  Não é necessário o else, pois caso a condição anterior seja verdadeira, a execução desse trecho de código será interrompida pelo return
            {
                return (rendimento * 0.03f);
            }
            return rendimento * 0.05f;//  Não é necessário o else, pois caso alguma das condições anteriores sejam verdadeiras, a execução desse trecho de código será interrompida pelo return
        }

        public override float pagarImposto(float salario)
        {
            if(salario <= 1500)
            {
                return 0;
            }
            if(salario <= 5000) //  Não é necessário o else, pois caso a condição anterior seja verdadeira, a execução desse trecho de código será interrompida pelo return
            {
                return (salario * 0.03f);
            }
            return salario * 0.05f; //  Não é necessário o else, pois caso alguma das condições anteriores sejam verdadeiras, a execução desse trecho de código será interrompida pelo return
        }

        public bool validarDataNascimento(DateTime dataNasc)
        {
            DateTime dataAtual = DateTime.Today;
            double idade = (dataAtual - dataNasc).TotalDays / 365.25;
            if (idade >= 18)
            {
                return true;
            }
            return false; //  Não é necessário o else, pois caso a condição anterior seja verdadeira, a execução desse trecho de código será interrompida pelo return
        }
        public bool ValidarDataNascimento(String dataNasc)
        {
            DateTime dataConvertida;
            if (DateTime.TryParse(dataNasc, out dataConvertida))
            {
                DateTime dataAtual = DateTime.Today;
                double idade = (dataAtual - dataConvertida).TotalDays / 365.25;
                if (idade >= 18)
                {
                    return true;
                }
            } 
            return false; //  Não é necessário o else, pois caso a condição anterior seja verdadeira, a execução desse trecho de código será interrompida pelo return
        }
    }
}