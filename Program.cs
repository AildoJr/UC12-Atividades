// See https://aka.ms/new-console-template for more information
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Pessoas.Classes;

Console.WriteLine(@$"
=============================================
|   Bem-vindo ao Sistema de Cadastro de     |
|       Pessoas Físicas e Jurídicas         |
=============================================");

Thread.Sleep(800);

//Console.BackgroundColor = ConsoleColor.Green;//cor de fundo
//Console.ForegroundColor = ConsoleColor.DarkBlue;//cor da fonte


Console.Write($"Iniciando");
for(int i=0; i<5;i++)
{
    Thread.Sleep(500);
    Console.Write(".");
}

//Console.ResetColor();

Console.WriteLine(@$"
=============================================
|       Escolha uma das opções abaixo:      |
|                                           |
|       1 - Pessoa Físicas                  |
|       2 - Pessoa Jurídica                 |
|                                           |
|       0 - Sair                            |
=============================================");
string ? opcao;
do{
    Console.Write("-> ");
    opcao = Console.ReadLine();//Console.ReadLine();

    switch(opcao)
    {
        case "1":   Console.WriteLine($"Pessoa Física");
                    Console.WriteLine($"Pressione qualquer tecla para continuar");
                    Console.ReadKey();
                    break;

        case "2":   Console.WriteLine($"Pessoa Juridica");
                    Console.WriteLine($"Pressione qualquer tecla para continuar");
                    Console.ReadKey();
                    break;

        case "0":   Console.WriteLine($"Saindo");
                    Console.WriteLine($"Pressione qualquer tecla para continuar");
                    Console.ReadKey();
                    break;

        default:    Console.WriteLine($"Opção Inválida! Tente novamente!");
                    Console.WriteLine();
                    break;
    }
}while(/*(opcao != "1")&&(opcao != "2")&&*/(opcao != "0"));

Console.Clear();
//***** CADASTRO PESSOA FÍSICA 1 *****

Endereco endpf1 = new Endereco();
endpf1.logradouro = "Rua do Joaquim";
endpf1.numero = 250;
endpf1.comercial = false;

PessoaFisica pf1 = new PessoaFisica();

pf1.nome = "Joaquim da Silva";
pf1.cpf = "12345678901";
pf1.dataNascimento = new DateTime(1981,01,10);
pf1.rendimento = 4000;
pf1.endereço = endpf1;

//***** CADASTRO PESSOA JURÍDICA 1 *****

Endereco endpj1 = new Endereco();
endpj1.logradouro = "Rua da Bahia";
endpj1.numero = 2180;
endpj1.comercial = true;

PessoaJuridica pj1 = new PessoaJuridica();

pj1.nome = "Casas Bahia";
pj1.cnpj = "12.345.678/0001-23"; 
//CNPJ válido em formato 1:     12.345.678/0001-23
//CNPJ válido em formato 2:     12345670000123
pj1.endereço = endpj1;

//***** EXIBE DADOS DA PESSOA FÍSICA 1 *****

// Console.WriteLine(pf1.nome);
// Console.WriteLine(pf1.cpf);
// Console.WriteLine(pf1.dataNascimento);
Console.WriteLine();
// Console.WriteLine(
// @$"{pf1.nome} 
// CPF: {pf1.cpf}
// nascido em: {pf1.dataNascimento:MM/dd/yyyy}");
Console.WriteLine($"{pf1.nome}\r\nCPF: {pf1.cpf}");
if(pf1.validarDataNascimento(pf1.dataNascimento.Value) == true)
{
    Console.WriteLine($"nascido em: {pf1.dataNascimento:MM/dd/yyyy}");
}

Console.WriteLine($"Endereço: {pf1.endereço.logradouro}, {pf1.endereço.numero} - Comercial: {pf1.endereço.comercial} ");
Console.WriteLine("Salário: R$ " + pf1.rendimento);
Console.WriteLine($"O imposto que {pf1.nome} deve pagar é R$ {pf1.pagarImposto()}");
Console.WriteLine();


Console.Write("trabalha em: " );
Console.WriteLine();
Console.WriteLine();

//***** EXIBE DADOS DA PESSOA JURÍDICA 1 *****

Console.Write($"{pj1.nome} - CNPJ: {pj1.cnpj} - " );
pj1.validarCNPJ(pj1.cnpj);
Console.WriteLine("Endereço: " + pj1.endereço.logradouro + ", "+ pj1.endereço.numero + " - Comercial: "+ pj1.endereço.comercial);
pj1.rendimento = 50000.00f;
Console.WriteLine($"Receita: R$ {pj1.rendimento}");
Console.WriteLine($"O imposto que {pj1.nome} deve pagar é R$ {pj1.pagarImposto(50000)}");
Console.WriteLine();