using System;
using tabuleiro;
using xadrez;

namespace xadrez_console
{
    class Tela
    {
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
