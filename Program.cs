// See https://aka.ms/new-console-template for more information
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Pessoas.Classes;

PessoaFisica pf1 = new PessoaFisica();

pf1.nome = "Joaquim da Silva";
pf1.cpf = "12345678901";
pf1.dataNascimento = new DateTime(1981,01,10);
pf1.rendimento = 4000;


PessoaJuridica pj1 = new PessoaJuridica();

pj1.nome = "Casas Bahia";
pj1.cnpj = "12.345.678/0001-23"; 
//CNPJ válido em formato 1:     12.345.678/0001-23
//CNPJ válido em formato 2:     12345670000123


// Console.WriteLine(pf1.nome);
// Console.WriteLine(pf1.cpf);
// Console.WriteLine(pf1.dataNascimento);
Console.WriteLine();
Console.WriteLine($"{pf1.nome} - CPF: {pf1.cpf} - nascido em: {pf1.dataNascimento:MM/dd/yyyy}" );
Console.Write("trabalha em: " );
Console.Write($"{pj1.nome} - CNPJ: {pj1.cnpj} - " );
pj1.validarCNPJ(pj1.cnpj);
Console.WriteLine($"O imposto que {pf1.nome} deve pagar é R$ {pf1.pagarImposto()}");
Console.WriteLine($"O imposto que {pj1.nome} deve pagar é R$ {pj1.pagarImposto(50000)}");
Console.WriteLine();