using System;
using tabuleiro;
using xadrez;

namespace xadrez_console
{
    class Tela
    {
        public static void imprimirTabuleiro(Tabuleiro tab)
        {
            CorReferenciadores referenciador = new CorReferenciadores();
  
            for (referenciador.I = 0; referenciador.I < tab.Linhas; referenciador.I++)
            {
                
                referenciador.imprimirNumeroReferenciador();

                for (int j = 0; j < tab.Colunas; j++)
                {
                    imprimirPeca(tab.peca(referenciador.I, j));
                }
                Console.WriteLine();
            }
            referenciador.imprimirLetrasReferenciadores();
        }

        public static void imprimirTabuleiro(Tabuleiro tab, bool[,] posicoesPossiveis)
        {
            CorReferenciadores referenciador = new CorReferenciadores();

            for (referenciador.I = 0; referenciador.I < tab.Linhas; referenciador.I++)
            {
                referenciador.imprimirNumeroReferenciador();

                for (int j = 0; j < tab.Colunas; j++)
                {
                    if (posicoesPossiveis[referenciador.I, j])
                    {
                        Console.BackgroundColor = referenciador.FundoAlterado;
                    }
                    else
                    {
                        Console.BackgroundColor = referenciador.FundoOriginal;
                    }
                    imprimirPeca(tab.peca(referenciador.I, j));
                    Console.BackgroundColor = referenciador.FundoOriginal;
                }
                Console.WriteLine();
            }

            referenciador.imprimirLetrasReferenciadores();
            Console.BackgroundColor = referenciador.FundoOriginal;
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
