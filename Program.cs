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

Utils.loading("Iniciando", 4, 400, ConsoleColor.Green);

List<PessoaFisica> listaPf = new List<PessoaFisica>();
List<PessoaJuridica> listaPj = new List<PessoaJuridica>();

string? opcao;

do
{
    Console.WriteLine(@$"
=============================================
|       Escolha uma das opções abaixo:      |
|                                           |
|       1 - Pessoa Física                   |
|       2 - Pessoa Jurídica                 |
|                                           |
|       0 - Sair                            |
=============================================");
    Console.Write("-> ");
    opcao = Console.ReadLine();//Console.ReadLine();
    Console.Clear();

    switch (opcao)
    {
        case "1": //SUBMENU PESSOA FÍSICA
            string? opcaoPF;
            do
            {
                Console.WriteLine(@$"
=============================================
|       Escolha uma das opções abaixo:      |
|                                           |
|       1 - Cadastrar Pessoa Física         |
|       2 - Listar Pessoas Físicas          |
|                                           |
|       0 - Retornar ao menu anterior       |
=============================================");
                Console.Write("-> ");
                opcaoPF = Console.ReadLine();
                Console.Clear();
                switch (opcaoPF)
                {
                    case "1":
                        //***** CADASTRO PESSOA FÍSICA 1 *****

                        PessoaFisica pf1 = new PessoaFisica();

                        Console.Write("Digite o nome: ");
                        pf1.nome = Console.ReadLine();
                        do{
                            Console.WriteLine("");
                            Console.WriteLine("Digite o CPF: ");
                            Console.WriteLine(@"(Formatos válidos: 123.456.789-01 e 12345678901)");
                            Console.Write("-> ");
                            pf1.cpf = Console.ReadLine();
                        }while(pf1.validarCPF(pf1.cpf)==false);
                        //CPF válido em formato 1:     123.456.789-01
                        //CPF válido em formato 2:     12345678901
                        // Console.Write("Digite o CPF: ");
                        // pf1.cpf = Console.ReadLine();
                        pf1.dataNascimento = new DateTime(1981, 01, 10);

                        //TESTE DE DATA
                        var testedata = true;
                        DateTime dataprovisoria = new DateTime();
                        do{
                            Console.Write("Digite a Data de nascimento: (dd/mm/aaaa): ");
                            //Formatos Aceitos: (dd-mm-aaaa), (dd/mm/aaaa)
                            string datanasc = Console.ReadLine();
                            testedata = DateTime.TryParse(datanasc, out dataprovisoria);
                            if(testedata==false)
                                Console.WriteLine("Data Inválida! Tente Novamente!");
                        }while(testedata!=true);
                        pf1.dataNascimento = dataprovisoria;

                        Console.Write("Digite o rendimento bruto: ");
                        pf1.rendimento = float.Parse(Console.ReadLine());

                        Endereco endpf1 = new Endereco();
                        Console.Write("Digite o endereço: ");
                        endpf1.logradouro = Console.ReadLine();
                        Console.Write("Digite o número: ");
                        endpf1.numero = int.Parse(Console.ReadLine());

                        string leituraEnd;
                        
                        // Se endpf1.comercial não puder assumir valor nulo, então assumirá o valor de Falso por padrão e o teste abaixo não funcionará
                        do{
                            Console.Write($"O endereço é comercial? (S/N): ");
                            leituraEnd = Console.ReadLine();
                            //Console.WriteLine(leituraEnd);
                            if(leituraEnd.ToUpper()=="S"){
                                endpf1.comercial = true;
                            }else{
                                if(leituraEnd.ToUpper()=="N"){
                                    endpf1.comercial = false;
                                }
                                else{
                                    Console.WriteLine("Inválido,favor digitar novamente!");
                                    //Console.WriteLine(endpf1.comercial);
                                    
                                }
                            }
                        }while((endpf1.comercial != true) && (endpf1.comercial != false));


                        pf1.endereço = endpf1;

                        listaPf.Add(pf1);

                        Utils.ParadaNoConsole("Pessoa Física cadastrada com sucesso!");
                        Console.Clear();
                        break;
                    case "2":
                        //***** EXIBE DADOS DA PESSOA FÍSICA 1 *****
                        foreach (var pessoaf in listaPf)
                        {
                            // Console.WriteLine(pessoaf.nome);
                            // Console.WriteLine(pessoaf.cpf);
                            // Console.WriteLine(pessoaf.dataNascimento);
                            Console.WriteLine();
                            // Console.WriteLine(
                            // @$"{pessoaf.nome} 
                            // CPF: {pessoaf.cpf}
                            // nascido em: {pessoaf.dataNascimento:MM/dd/yyyy}");
                            Console.WriteLine($"{pessoaf.nome}\r\nCPF: {pessoaf.cpf}");
                            if (pessoaf.validarDataNascimento(pessoaf.dataNascimento.Value) == true)
                            {
                                Console.WriteLine(@$"Nascido(a) em: {pessoaf.dataNascimento:dd/MM/yyyy}");
                            }

                            Console.Write($"Endereço: {pessoaf.endereço.logradouro}, {pessoaf.endereço.numero} - Comercial: ");
                            //Console.WriteLine(pessoaf.endereço.comercial?"Sim":"Não");
                            if(pessoaf.endereço.comercial == true){
                                Console.WriteLine("Sim");
                            }
                            else{
                                Console.WriteLine("Não");
                            }
                            
                            Console.WriteLine("Salário: R$ " + pessoaf.rendimento);
                            Console.WriteLine($"O imposto que {pessoaf.nome} deve pagar é R$ {pessoaf.pagarImposto()}");

                        }

                        Utils.ParadaNoConsole("Fim da lista de Pessoas Físicas!");
                        Console.Clear();
                        break;
                    case "0":
                        Utils.ParadaNoConsole($"Retornando ao menu principal");
                        Console.Clear();
                        break;
                    default:
                        Utils.ParadaNoConsole("Opção Inválida! Tente novamente! "); //\n\n1 - Pessoa Físicas \n2 - Pessoa Jurídica    \n0 - Sair 
                        Console.Clear();
                        break;

                }
            } while (opcaoPF != "0");
            break;

        case "2":

            string? opcaoPJ;
            do
            {
                Console.WriteLine(@$"
=============================================
|       Escolha uma das opções abaixo:      |
|                                           |
|       1 - Cadastrar Pessoa Jurídica       |
|       2 - Listar Pessoas Jurídicas        |
|                                           |
|       0 - Retornar ao menu anterior       |
=============================================");
                Console.Write("-> ");
                opcaoPJ = Console.ReadLine();
                Console.Clear();
                switch (opcaoPJ)
                {
                    case "1": //***** CADASTRO PESSOA JURÍDICA 1 *****


                        PessoaJuridica pj1 = new PessoaJuridica();

                        Console.Write("Digite o nome: ");
                        pj1.nome = Console.ReadLine();
                        do{
                            Console.WriteLine("");
                            Console.WriteLine("Digite o CNPJ: ");
                            Console.WriteLine(@"(Formatos válidos: 12.345.678/0001-23 e 12345670000123)");
                            Console.Write("-> ");
                            pj1.cnpj = Console.ReadLine();
                        }while(pj1.validarCNPJ(pj1.cnpj)==false);
                        //CNPJ válido em formato 1:     12.345.678/0001-23
                        //CNPJ válido em formato 2:     12345670000123

                        
                        Endereco endpj1 = new Endereco();
                        
                        Console.Write("Digite o endereço: ");
                        endpj1.logradouro = Console.ReadLine();
                        
                        Console.Write("Digite o número: ");
                        endpj1.numero = int.Parse(Console.ReadLine());
                        string leituraEnd;

                        // Se endpj1.comercial não puder assumir valor nulo, então assumirá o valor de Falso por padrão e o teste abaixo não funcionará
                        do{
                            Console.Write($"O endereço é comercial? (S/N): ");
                            leituraEnd = Console.ReadLine();
                            //Console.WriteLine(leituraEnd);
                            if(leituraEnd.ToUpper()=="S"){
                                endpj1.comercial = true;
                            }else{
                                if(leituraEnd.ToUpper()=="N"){
                                    endpj1.comercial = false;
                                }
                                else{
                                    Console.WriteLine("Inválido,favor digitar novamente!");
                                    //Console.WriteLine(endpj1.comercial);
                                    
                                }
                            }
                        }while((endpj1.comercial != true) && (endpj1.comercial != false));

                        pj1.endereço = endpj1;

                        
                        Console.Write("Digite o rendimento bruto: ");
                        pj1.rendimento = float.Parse(Console.ReadLine());

                        listaPj.Add(pj1);

                        Utils.ParadaNoConsole("Pessoa jurídica cadastrada com sucessso!");
                        Console.Clear();
                        break;


                    case "2": //***** EXIBE DADOS DA PESSOA JURÍDICA 1 *****

                        foreach (var pessoaj in listaPj)
                        {
                            
                            Console.WriteLine();
                            Console.WriteLine($"{pessoaj.nome} - CNPJ: {pessoaj.cnpj} ");
                            //pessoaj.validarCNPJ(pessoaj.cnpj);
                            //Console.WriteLine("Endereço: " + pessoaj.endereço.logradouro + ", " + pessoaj.endereço.numero + " - Comercial: " + pessoaj.endereço.comercial);
                            Console.Write($"Endereço: {pessoaj.endereço.logradouro}, {pessoaj.endereço.numero} - Comercial: ");
                            //Console.WriteLine(pessoaj.endereço.comercial?"Sim":"Não");
                            if(pessoaj.endereço.comercial == true){
                                Console.WriteLine("Sim");
                            }
                            else{
                                Console.WriteLine("Não");
                            }
                            //pessoaj.rendimento = 50000.00f;
                            Console.WriteLine($"Receita: R$ {pessoaj.rendimento}");
                            Console.WriteLine($"O imposto que {pessoaj.nome} deve pagar é R$ {pessoaj.pagarImposto(pessoaj.rendimento)}");
                        }

                        Utils.ParadaNoConsole("Fim da lista de pessoas jurídicas!");
                        Console.Clear();
                        break;

                    case "0":
                        Utils.ParadaNoConsole($"Retornando ao menu principal");
                        Console.Clear();
                        break;

                    default:
                        Utils.ParadaNoConsole("Opção Inválida! Tente novamente! "); //\n\n1 - Pessoa Físicas \n2 - Pessoa Jurídica    \n0 - Sair 
                        Console.Clear();
                        break;
                }
            
            } while (opcaoPJ != "0");
            break;


        case "0":
            Utils.ParadaNoConsole("Obrigado por utilizar nosso programa!");
            Console.Clear();
            break;

        default:
            Utils.ParadaNoConsole("Opção Inválida! Tente novamente! "); //\n\n1 - Pessoa Físicas \n2 - Pessoa Jurídica    \n0 - Sair 
            Console.Clear();
            break;
    }
} while (opcao != "0");

Utils.loading("Finalizando", 4, 400);


