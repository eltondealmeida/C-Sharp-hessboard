using System;
using System.Collections.Generic;
using tabuleiro;
using xadrez;

namespace xadrez_console
{
    class Tela
    {
        public static void imprimirPartida(PartidaDeXadrez partida)
        {
            imprimirTabuleiro(partida.Tab);
            Console.WriteLine();
            imprimirPecasCapturadas(partida);
            Console.WriteLine("\n\nTurno: " + partida.Turno);
            Console.WriteLine("Aguardando jogada: " + partida.JogadorAtual);
            if (partida.Xeque)
            {
                Console.WriteLine("\nXEQUE!");
            }
        }
        public static void imprimirPecasCapturadas(PartidaDeXadrez partida)
        {
            Console.WriteLine("\nPeças capturadas: ");
            Console.Write("Brancas: ");
            imprimirConjunto(partida.pecasCapturadas(Cor.Branca));
            Console.Write("\nPretas: ");
            ConsoleColor aux = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Red;
            imprimirConjunto(partida.pecasCapturadas(Cor.Preta));
            Console.ForegroundColor = aux;
        }
        public static void imprimirConjunto(HashSet<Peca> conjunto)
        {
            Console.Write("[");
            foreach (Peca x in conjunto)
            {
                Console.Write(x + " ");
            }
            Console.Write("]");
        }
        public static void imprimirTabuleiro(Tabuleiro tab)
        {
           
            CorReferenciadores corRef = new CorReferenciadores();

            for (corRef.I = 0; corRef.I < tab.Linhas; corRef.I++)
            {
                corRef.imprimirNumeroReferenciador();

                for (int j = 0; j < tab.Colunas; j++)
                {
                    imprimirPeca(tab.peca(corRef.I, j));
                }
                Console.WriteLine();
            }
            corRef.imprimirLetrasReferenciadores();
        }

        public static void imprimirTabuleiro(Tabuleiro tab, bool[,] posicoesPossiveis)
        {
            CorReferenciadores corRef = new CorReferenciadores();

            for (corRef.I = 0; corRef.I < tab.Linhas; corRef.I++)
            {
                corRef.imprimirNumeroReferenciador();

                for (int j = 0; j < tab.Colunas; j++)
                {
                    if (posicoesPossiveis[corRef.I, j])
                    {
                        Console.BackgroundColor = corRef.FundoAlterado;
                    }
                    else
                    {
                        Console.BackgroundColor = corRef.FundoOriginal;
                    }
                    imprimirPeca(tab.peca(corRef.I, j));
                    Console.BackgroundColor = corRef.FundoOriginal;
                }
                Console.WriteLine();
            }

            corRef.imprimirLetrasReferenciadores();
            Console.BackgroundColor = corRef.FundoOriginal;
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
