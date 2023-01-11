using Pessoas.Interfaces;

namespace Pessoas.Classes
{
    public abstract class Pessoa: IPessoa
    {
        public string ?nome{get; set;}

        public Endereco ?endereço{get;set;}

        public float rendimento{get;set;}

        public abstract float pagarImposto();

        public abstract float pagarImposto(float rendimento);
    }
}