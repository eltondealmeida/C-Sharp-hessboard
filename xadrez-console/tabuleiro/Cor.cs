using System;

namespace tabuleiro
{
    enum Cor
    {
        Branca,
        Preta
    }
    class CorReferenciadores
    {
        public int NumeroReferenciador { get; private set; }
        public int I { get; set; }
        public ConsoleColor FundoOriginal { get; private set; }
        public ConsoleColor FundoAlterado { get; private set; }
        public ConsoleColor ForegroundGreen { get; private set; }

        public CorReferenciadores()
        {
            NumeroReferenciador = 8;
            I = 0;
            FundoOriginal = Console.BackgroundColor;
            FundoAlterado = ConsoleColor.DarkGray;
        }
        public void imprimirLetrasReferenciadores()
        {
            ForegroundGreen = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(" -----------------\n   A B C D E F G H");
            Console.ForegroundColor = ForegroundGreen;
        }
        public void imprimirNumeroReferenciador()
        {
            ForegroundGreen = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(NumeroReferenciador - I + "| ");
            Console.ForegroundColor = ForegroundGreen;
        }
    }
}
