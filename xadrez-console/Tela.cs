using System;
using tabuleiro;
using xadrez;

namespace xadrez_console
{
    class Tela
    {
        public static void imprimirTabuleiro(Tabuleiro tab)
        {
            int numeroReferenciador = 8;
            string barraReferenciador = "| ";
            string letrasReferenciadores = "   A B C D E F G H";

            for (int i = 0; i < tab.Linhas; i++)
            {
                ConsoleColor auxiliar = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write(numeroReferenciador - i + barraReferenciador);
                Console.ForegroundColor = auxiliar;
       
                for (int j = 0; j < tab.Colunas; j++)
                {
                    imprimirPeca(tab.peca(i, j));
                }
                Console.WriteLine();
            }
            ConsoleColor aux = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(" -----------------\n" + letrasReferenciadores);
            Console.ForegroundColor = aux;
        }

        public static void imprimirTabuleiro(Tabuleiro tab, bool[,] posicoesPossiveis)
        {
            ConsoleColor fundoOriginal = Console.BackgroundColor;
            ConsoleColor fundoAlterado = ConsoleColor.DarkGray;
            int numeroReferenciador = 8;
            string barraReferenciador = "| ";
            string letrasReferenciadores = "   A B C D E F G H";

            for (int i = 0; i < tab.Linhas; i++)
            {
                ConsoleColor auxiliar = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write(numeroReferenciador - i + barraReferenciador);
                Console.ForegroundColor = auxiliar;

                for (int j = 0; j < tab.Colunas; j++)
                {
                    if (posicoesPossiveis[i, j])
                    {
                        Console.BackgroundColor = fundoAlterado;
                    }
                    else
                    {
                        Console.BackgroundColor = fundoOriginal;
                    }
                    imprimirPeca(tab.peca(i, j));
                    Console.BackgroundColor = fundoOriginal;
                }
                Console.WriteLine();
            }
            
            ConsoleColor aux = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(" -----------------\n" + letrasReferenciadores);
            Console.ForegroundColor = aux;
            Console.BackgroundColor = fundoOriginal;
        }

        public static PosicaoXadrez lerPosicaoXadrez()
        {
            string s = Console.ReadLine();
            char coluna = s[0];
            int linha = int.Parse(s[1] + "");
            return new PosicaoXadrez(coluna, linha);
        }
        public static void imprimirPeca(Peca peca)
        {
            if (peca == null)
            {
                Console.Write("- ");
            }
            else
            {
                if (peca.Cor == Cor.Branca)
                {
                    Console.Write(peca);
                }
                else
                {
                    ConsoleColor aux = Console.ForegroundColor;
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write(peca);
                    Console.ForegroundColor = aux;
                }
                Console.Write(" ");
            }
        }
    }
}
