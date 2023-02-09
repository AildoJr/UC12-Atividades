namespace Pessoas.Interfaces
{
    public interface IPessoaFisica
    {
        bool validarDataNascimento();
        bool validarDataNascimento(DateTime dataNasc);
    }
}