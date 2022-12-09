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
            throw new NotImplementedException();
        }
    }
}