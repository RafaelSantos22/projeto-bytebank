using System;
using System.Globalization;

namespace Projeto_ByteBank
{
    public class Program
    {
        static void ShowMenu()
        {
            Console.WriteLine("1 - Inserir novo usuário");
            Console.WriteLine("2 - Deletar um usuário");
            Console.WriteLine("3 - Listar todas as contas registradas");
            Console.WriteLine("4 - Detalhes de um usuário");
            Console.WriteLine("5 - Total armazenado no banco");
            Console.WriteLine("6 - Manipular a conta");
            Console.WriteLine("0 - Para sair do programa");
            Console.WriteLine("--------------------------------------------");
            Console.Write("Digite a opção desejada: ");
        }

        static void RegistrarNovoUsuario(List<string> cpfs, List<string> titulares, List<string> senhas, List<double> saldos)
        {
            Console.Write("Digite o cpf: ");
            cpfs.Add(Console.ReadLine());

            Console.Write("Digite o nome: ");
            titulares.Add(Console.ReadLine());

            Console.Write("Digite a senha: ");
            senhas.Add(Console.ReadLine());

            saldos.Add(0);
        }

        static void ListarTodasAsContas(List<string> cpfs, List<string> titulares, List<double> saldos)
        {
            for(int i = 0; i < cpfs.Count; i++)
            {
                Console.WriteLine($"Usuário {i}: CPF = {cpfs[i]} | Titular = {titulares[i]} | Saldo = R${saldos[i]:F2}");
            }
                Console.WriteLine("--------------------------------------------");
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

                switch(option)
                {
                    case 0: 
                        Console.WriteLine("Programa encerrado!");
                        break;
                    case 1:
                        RegistrarNovoUsuario(cpfs, titulares, senhas, saldos);
                        break;
                    case 3:
                        ListarTodasAsContas(cpfs, titulares, saldos);   
                        break;
                }
            } while (option != 0);
        }
    }
}