using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace Gomoku.Models
{
    public class Game
    {
        public Board Board { get; set; }

        public Game() { }

        public void Start()
        {
            Console.WriteLine("Game Start!");
            Console.WriteLine("Set the size of your board!");
            Console.WriteLine("What is the number of rows?");
            string rowCount = Console.ReadLine();
            Console.WriteLine("What is the number of columns?");
            string colCount = Console.ReadLine();
            Board = new Board(Convert.ToInt32(rowCount), Convert.ToInt32(colCount));
            bool isTurnPlayerOne = true;
            while (true)
            {
                Board.Print();
                SpotValue spotValue = isTurnPlayerOne ? SpotValue.Black : SpotValue.White;
                string player = isTurnPlayerOne ? "Player 1" : "Player 2";
                Console.WriteLine($"{player}, please place a chess:");
                Console.WriteLine("Which row?");
                int row = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Which column?");
                int col = Convert.ToInt32(Console.ReadLine());
                if (Board.PlaceChess(row, col, spotValue))
                {
                    if (Board.VerifyBoard(row, col))
                    {
                        Console.WriteLine($"{player} wins!");
                        break;
                    }
                    isTurnPlayerOne = !isTurnPlayerOne;
                }
            }
            Console.WriteLine("Game ends!");
        }
    }
}
