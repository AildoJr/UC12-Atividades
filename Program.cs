﻿// See https://aka.ms/new-console-template for more information
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Pessoas.Classes;

PessoaFisica pf1 = new PessoaFisica();

pf1.nome = "Joaquim da Silva";
pf1.cpf = "12345678901";
pf1.dataNascimento = new DateTime(1981,01,10);


PessoaJuridica pj1 = new PessoaJuridica();

pj1.nome = "Casas Bahia";
pj1.cnpj = "123";


Console.WriteLine(pf1.nome);
Console.WriteLine(pf1.cpf);
Console.WriteLine(pf1.dataNascimento);
Console.WriteLine($"{pf1.nome} - cpf: {pf1.cpf} - nascido em: {pf1.dataNascimento}" );
Console.WriteLine("trabalha em: " );
Console.WriteLine($"{pj1.nome} - cnpj: {pj1.cnpj}" );
