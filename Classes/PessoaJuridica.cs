using Pessoas.Interfaces;

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
            throw new NotImplementedException();
        }

    }
}