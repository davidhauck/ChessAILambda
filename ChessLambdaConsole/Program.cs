using ChessLambda;
using System;

namespace ChessLambdaConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            BestMoveFinder bmf = new BestMoveFinder();
            var move = bmf.FindBestMove("8/1q2k3/8/8/8/1Q6/8/4K3 b - - 0 1");
            Console.WriteLine($"FromX: {move.FromX} FromY: {move.FromY} DestX: {move.DestX} DestY: {move.DestY}");
        }
    }
}
