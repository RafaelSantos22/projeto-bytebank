using System;
using System.Globalization;
using System.Reflection.Metadata.Ecma335;
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

            Console.Write("Digite o cpf: ");
            string cpfTitular = Console.ReadLine();

            int indiceCpf = cpfs.FindIndex(cpf => cpf == cpfTitular);

            if (indiceCpf == -1)
            {
                cpfs.Add(cpfTitular);

                Console.Write("Digite o nome: ");
                titulares.Add(Console.ReadLine());

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
            Console.WriteLine();

            if (indexParaDeletar == -1)
            {
                Console.Clear();
                Console.WriteLine("Conta não encontrada!\n");
            }
            else
            {
                Console.Write("Digite sua senha: ");
                string senha = Console.ReadLine();

                while (senha != senhas[indexParaDeletar])
                {
                    Console.Write("Senha incorreta! Digite novamente: ");
                    senha = Console.ReadLine();
                }
                cpfs.Remove(cpfParaDeletar);
                titulares.RemoveAt(indexParaDeletar);
                senhas.RemoveAt(indexParaDeletar);
                saldos.RemoveAt(indexParaDeletar);
            }
            Console.Clear();
            Console.WriteLine("Conta deletada com sucesso!\n");
        }

        static void ListarTodasAsContas(List<string> cpfs, List<string> titulares, List<double> saldos)
        {
            for (int i = 0; i < cpfs.Count; i++)
            {
                if (cpfs.Count > 0)
                {
                    ApresentaConta(i, cpfs, titulares, saldos);
                }
                else
                {
                    Console.WriteLine("Não há contas cadastradas!");
                }
            }
        }

        static void ApresentarUsuario(List<string> cpfs, List<string> titulares, List<double> saldos)
        {
            Console.Write("Digite o cpf: ");
            string cpfParaApresentar = Console.ReadLine();
            int indexParaApresentar = cpfs.FindIndex(cpf => cpf == cpfParaApresentar);

            if (indexParaApresentar == -1)
            {
                Console.WriteLine("Não foi possível apresentar esta Conta");
                Console.WriteLine("MOTIVO: Conta não encontrada.");
            }

            ApresentaConta(indexParaApresentar, cpfs, titulares, saldos);
        }

        static void ApresentarValorAcumulado(List<double> saldos)
        {
            Console.WriteLine($"Total acumulado no banco: {saldos.Sum()}");
            //return saldos.Aggregate(0.0, (x, y) => x + y);
        }

        static void ApresentaConta(int index, List<string> cpfs, List<string> titulares, List<double> saldos)
        {
            Console.WriteLine($"CPF = {cpfs[index]} | Titular = {titulares[index]} | Saldo = R$ {saldos[index]:F2}");
            Console.WriteLine("--------------------------------------------");
        }

        static void ManipularConta(List<string> cpfs, List<string> titulares, List<string> senhas, List<double> saldos)
        {
            Console.Clear();
            Console.WriteLine("===== Deletando um usuário =====\n");

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
                MenuDaConta(titulares, saldos);
            }
        }

        static void MenuDaConta(List<string> titulares, List<double> saldos)
        {
            bool escolheuSair = false;

            while (escolheuSair == false)
            {
                for (int i = 0; i < titulares.Count; i++)
                {
                    Console.WriteLine($"Seja Bem Vindo {titulares[i]}\n");
                    Console.WriteLine("1 - Para depositar");
                    Console.WriteLine("2 - Para sacar");
                    Console.WriteLine("3 - Para transferencia");
                    Console.WriteLine("4 - Voltar para o menu principal");
                }

                int opcao = int.Parse(Console.ReadLine());

                MenuSecundario escolha = (MenuSecundario)opcao;

                switch (escolha)
                {
                    case MenuSecundario.Depositar:
                        Depositar();
                        break;
                    case MenuSecundario.Sacar:
                        break;
                    case MenuSecundario.Transferir:
                        break;
                    case MenuSecundario.Sair:
                        Console.Clear();
                        escolheuSair = true;
                        break;
                }
            }
        }

        static void Depositar()
        {

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

                switch (option)
                {
                    case 0:
                        Console.WriteLine("Programa encerrado!");
                        break;
                    case 1:
                        RegistrarNovoUsuario(cpfs, titulares, senhas, saldos);
                        break;
                    case 2:
                        DeletarUsuario(cpfs, titulares, senhas, saldos);
                        break;
                    case 3:
                        ListarTodasAsContas(cpfs, titulares, saldos);
                        break;
                    case 4:
                        ApresentarUsuario(cpfs, titulares, saldos);
                        break;
                    case 5:
                        ApresentarValorAcumulado(saldos);
                        break;
                    case 6:
                        ManipularConta(cpfs, titulares, senhas, saldos);
                        break;
                }
            } while (option != 0);
        }
    }
}