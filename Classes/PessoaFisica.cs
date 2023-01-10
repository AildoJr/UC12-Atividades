using Pessoas.Interfaces;

namespace Pessoas.Classes
{
    public class PessoaFisica : Pessoa, IPessoaFisica
    {
        public string ?cpf{get;set;}

        public DateTime ?dataNascimento{get;set;}

        public override float pagarImposto(float rendimento)
        {
            return rendimento;
        }

        public bool validarDataNascimento(DateTime dataNasc)
        {
            DateTime dataAtual = DateTime.Today;
            double idade = (dataAtual - dataNasc).TotalDays / 365.25;
            if (idade >= 18)
            {
                return true;
            }
            return false;
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
            return false;
        }
    }
}