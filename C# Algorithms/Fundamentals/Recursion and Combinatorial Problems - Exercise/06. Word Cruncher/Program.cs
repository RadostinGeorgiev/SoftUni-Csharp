namespace _06._Word_Cruncher
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection.Metadata.Ecma335;

    class Program
    {
        private static string[] pieces;
        private static Dictionary<int, List<string>> piecesByIndex;
        private static Dictionary<string, int> piecesCount;
        private static List<string> usedPieces;
        private static string target;

        static void Main(string[] args)
        {
            pieces = Console.ReadLine().Split(", ");

            target = Console.ReadLine();

            piecesByIndex = new Dictionary<int, List<string>>();
            piecesCount = new Dictionary<string, int>();

            foreach (var piece in pieces)
            {
                if (!target.Contains(piece))
                {
                    continue;
                }

                AddPiecesByIndex(piece);
                AddPiecesCount(piece);
            }

            usedPieces = new List<string>();
            GetSolutions(0);
        }

        private static void AddPiecesCount(string piece)
        {
            if (!piecesCount.ContainsKey(piece))
            {
                piecesCount.Add(piece, 0);
            }

            piecesCount[piece]++;
        }

        private static void AddPiecesByIndex(string piece)
        {
            int index = -1;
            while ((index = target.IndexOf(piece, index + 1)) != -1)
            {
                if (!piecesByIndex.ContainsKey(index))
                {
                    piecesByIndex.Add(index, new List<string>());
                }

                if (piecesByIndex[index].Contains(piece))
                {
                    continue;
                }
                piecesByIndex[index].Add(piece);
            }
        }

        private static void GetSolutions(int index)
        {
            if (index >= target.Length)
            {
                Console.WriteLine(string.Join(' ', usedPieces));
                return;
            }

            if (!piecesByIndex.ContainsKey(index))
            {
                return;
            }

            foreach (var piece in piecesByIndex[index])
            {
                if (piecesCount[piece] == 0)
                {
                    continue;
                }

                usedPieces.Add(piece);
                piecesCount[piece]--;
                GetSolutions(index + piece.Length);
                piecesCount[piece]++;
                usedPieces.RemoveAt(usedPieces.Count - 1);
            }
        }
    }
}