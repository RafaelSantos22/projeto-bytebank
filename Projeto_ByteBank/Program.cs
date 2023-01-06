using System;
using Projeto_ByteBank.Enums;

namespace Projeto_ByteBank
{
    public class Program
    {
        static void ShowMenu()
        {
            Console.WriteLine();
            Console.WriteLine("=============== BYTE BANK ===============\n");
            Console.WriteLine("1 - Inserir novo usuário");
            Console.WriteLine("2 - Deletar um usuário");
            Console.WriteLine("3 - Listar todas as contas registradas");
            Console.WriteLine("4 - Detalhes de um usuário");
            Console.WriteLine("5 - Total armazenado no banco");
            Console.WriteLine("6 - Manipular a conta");
            Console.WriteLine("0 - Para sair do programa\n");
            Console.WriteLine("=========================================\n");
            Console.Write("Digite a opção desejada: ");
        }

        static void RegistrarNovoUsuario(List<string> cpfs, List<string> titulares, List<string> senhas, List<double> saldos)
        {
            Console.Clear();
            Console.WriteLine("===== Registrando novo usuário =====\n");

            Console.Write("Digite o nome: ");
            titulares.Add(Console.ReadLine());

            Console.Write("Digite o cpf: ");
            string cpfTitular = Console.ReadLine();

            int indiceCpf = cpfs.FindIndex(cpf => cpf == cpfTitular);

            if (indiceCpf == -1)
            {
                cpfs.Add(cpfTitular);

                Console.Write("Digite a senha: ");
                senhas.Add(Console.ReadLine());
                Console.WriteLine();

                saldos.Add(0);

                Console.Clear();
                Console.WriteLine("Usuário registrado com sucesso!\n");
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Usuário já está cadastrado no banco!");
            }
        }

        static void DeletarUsuario(List<string> cpfs, List<string> titulares, List<string> senhas, List<double> saldos)
        {

            Console.Clear();
            Console.WriteLine("===== Deletando um usuário =====\n");

            Console.Write("Digite o cpf: ");
            string cpfParaDeletar = Console.ReadLine();
            int indexParaDeletar = cpfs.FindIndex(cpf => cpf == cpfParaDeletar);

            if (indexParaDeletar == -1)
            {
                Console.Clear();
                Console.WriteLine("Conta não encontrada!\n");
            }
            else
            {
                Console.Write("Digite sua senha: ");
                string senha = Console.ReadLine();
                Console.WriteLine();

                while (senha != senhas[indexParaDeletar])
                {
                    Console.Write("Senha incorreta! Digite novamente: ");
                    senha = Console.ReadLine();
                }
                cpfs.Remove(cpfParaDeletar);
                titulares.RemoveAt(indexParaDeletar);
                senhas.RemoveAt(indexParaDeletar);
                saldos.RemoveAt(indexParaDeletar);
                Console.Clear();
                Console.WriteLine("Conta deletada com sucesso!\n");
            }
        }

        static void ListarTodasAsContas(List<string> cpfs, List<string> titulares, List<double> saldos)
        {
            Console.Clear();
            Console.WriteLine("===== Contas registradas no BYTE BANK =====\n");

            if (cpfs.Count > 0)
            {
                for (int i = 0; i < cpfs.Count; i++)
                {
                    ApresentaConta(i, cpfs, titulares, saldos);
                }
            }
            else
            {
                Console.WriteLine("Não há contas cadastradas!\n");
            }
        }

        static void DetalhesUsuario(List<string> cpfs, List<string> titulares, List<string> senhas, List<double> saldos)
        {
            Console.Clear();
            Console.WriteLine("===== Detalhes do usuário ======\n");

            Console.Write("Digite o cpf: ");
            string cpfParaApresentar = Console.ReadLine();
            int indexParaApresentar = cpfs.FindIndex(cpf => cpf == cpfParaApresentar);

            if (indexParaApresentar == -1)
            {
                Console.WriteLine("Não foi possível apresentar esta Conta\n");
                Console.WriteLine("MOTIVO: Conta não encontrada.\n");
            }
            else
            {
                Console.Write("Digite sua senha: ");
                string senha = Console.ReadLine();

                while (senha != senhas[indexParaApresentar])
                {
                    Console.Write("Senha incorreta! Digite novamente: ");
                    senha = Console.ReadLine();
                }
                Console.WriteLine();
                ApresentaConta(indexParaApresentar, cpfs, titulares, saldos);
            }
        }

        static void ApresentarValorAcumulado(List<double> saldos)
        {
            Console.Clear();
            Console.WriteLine($"Total acumulado no banco: R$ {saldos.Sum()}\n");
            //return saldos.Aggregate(0.0, (x, y) => x + y);
        }

        static void ApresentaConta(int index, List<string> cpfs, List<string> titulares, List<double> saldos)
        {
            Console.WriteLine($"Titular: {titulares[index]} | CPF: {cpfs[index]} | Saldo = R$ {saldos[index]:F2}\n");
        }

        static void ManipularConta(List<string> cpfs, List<string> titulares, List<string> senhas, List<double> saldos)
        {
            Console.Clear();
            Console.WriteLine("===== Manipular conta =====\n");

            Console.Write("Digite o cpf: ");
            string cpfTitular = Console.ReadLine();
            int cpfAcesso = cpfs.FindIndex(cpf => cpf == cpfTitular);

            if (cpfAcesso == -1)
            {
                Console.Clear();
                Console.WriteLine("Usuário não encontrado!");
            }
            else
            {
                Console.Write("Digite sua senha: ");
                string senha = Console.ReadLine();

                while (senha != senhas[cpfAcesso])
                {
                    Console.Write("Senha incorreta! Digite novamente: ");
                    senha = Console.ReadLine();
                }

                Console.Clear();
                bool escolheuSair = false;
                Console.WriteLine($"Seja Bem Vindo(a) {titulares[cpfAcesso]}\n");

                while (escolheuSair == false)
                {
                    Console.WriteLine("1 - Ver saldo");
                    Console.WriteLine("2 - Para depositar");
                    Console.WriteLine("3 - Para sacar");
                    Console.WriteLine("4 - Para transferencia");
                    Console.WriteLine("0 - Fazer Logout\n");
                    Console.Write("Digite sua opção: ");

                    int opcao = int.Parse(Console.ReadLine());

                    MenuSecundario escolha = (MenuSecundario)opcao;

                    switch (escolha)
                    {
                        case MenuSecundario.VerSaldo:
                            VerSaldo(saldos, cpfAcesso);
                            break;
                        case MenuSecundario.Depositar:
                            Depositar(saldos, cpfAcesso);
                            break;
                        case MenuSecundario.Sacar:
                            Sacar(saldos, cpfAcesso);
                            break;
                        case MenuSecundario.Transferir:
                            Transferir(saldos, cpfAcesso, cpfs);
                            break;
                        case MenuSecundario.Sair:
                            Console.Clear();
                            escolheuSair = true;
                            break;
                    }
                }
            }
        }

        static void VerSaldo(List<double> saldos, int cpfAcesso)
        {
            Console.Clear();
            Console.WriteLine($"Saldo atual: R$ {saldos[cpfAcesso]:F2}\n");
        }

        static void Depositar(List<double> saldos, int cpfAcesso)
        {
            Console.Clear();
            Console.WriteLine("===== Deposito ======\n");
            Console.Write("Digite o valor para depósito: R$ ");
            double quantia = double.Parse(Console.ReadLine());

            saldos[cpfAcesso] += quantia;

            Console.WriteLine();
            Console.WriteLine($"Valor depositado com sucesso! Saldo: R$ {saldos[cpfAcesso]:F2}\n");
        }

        static void Sacar(List<double> saldos, int cpfAcesso)
        {
            Console.Clear();
            Console.WriteLine("===== Saque =====");
            Console.Write("Digite o valor para saque: R$ ");
            double quantia = double.Parse(Console.ReadLine());

            if (saldos[cpfAcesso] > 0 && saldos[cpfAcesso] > quantia)
            {
                saldos[cpfAcesso] -= quantia;
                Console.WriteLine();
                Console.WriteLine($"Saque realizado com sucesso! Saldo: R$ {saldos[cpfAcesso]:F2}\n");
            } else
            {
                Console.WriteLine();
                Console.WriteLine("Saldo insuficiente para saque!\n");
                Console.WriteLine($"Saldo: R$ {saldos[cpfAcesso]:F2}\n");
            }
        }

        static void Transferir(List<double> saldos, int cpfAcesso, List<string> cpfs)
        {
            Console.Clear();
            Console.WriteLine("===== Transferência ======");
            Console.Write("Digite o CPF do titular para transferência: ");
            string contaDestino = Console.ReadLine();
            int cpfContaDestino = cpfs.FindIndex(cpf => cpf == contaDestino);
            Console.WriteLine();
            
            if (cpfContaDestino == -1)
            {
                Console.WriteLine("Esta conta não está cadastrada no banco\n");
            }
            else
            {
                Console.WriteLine($"Saldo: R$ {saldos[cpfAcesso]:F2}\n");
                Console.Write($"Digite o valor para transferir: R$ ");
                double quantia = double.Parse(Console.ReadLine());

                if (saldos[cpfAcesso] > 0 && saldos[cpfAcesso] > quantia)
                {
                    Console.WriteLine();
                    saldos[cpfAcesso] -= quantia;
                    saldos[cpfContaDestino] += quantia;

                    Console.WriteLine($"Transferência realizada com sucesso! Saldo atual: R$ {saldos[cpfAcesso]:F2}\n");
                }
                else
                {
                    Console.WriteLine();
                    Console.WriteLine("Saldo insuficiente para transferência!\n");
                }
            }
        }

        static void Main(string[] args)
        {
            List<string> cpfs = new List<string>();
            List<string> titulares = new List<string>();
            List<string> senhas = new List<string>();
            List<double> saldos = new List<double>();

            int option;

            do
            {
                ShowMenu();
                option = int.Parse(Console.ReadLine());
                MenuPrincipal escolha = (MenuPrincipal)option;

                switch (escolha)
                {
                    case MenuPrincipal.Sair:
                        Console.WriteLine("Programa encerrado!");
                        break;
                    case MenuPrincipal.Inserir:
                        RegistrarNovoUsuario(cpfs, titulares, senhas, saldos);
                        break;
                    case MenuPrincipal.Deletar:
                        DeletarUsuario(cpfs, titulares, senhas, saldos);
                        break;
                    case MenuPrincipal.Listar:
                        ListarTodasAsContas(cpfs, titulares, saldos);
                        break;
                    case MenuPrincipal.DetalharConta:
                        DetalhesUsuario(cpfs, titulares, senhas, saldos);
                        break;
                    case MenuPrincipal.TotalBanco:
                        ApresentarValorAcumulado(saldos);
                        break;
                    case MenuPrincipal.ManipularConta:
                        ManipularConta(cpfs, titulares, senhas, saldos);
                        break;
                }
            } while (option != 0);
        }
    }
}