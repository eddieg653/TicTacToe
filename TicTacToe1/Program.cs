using System;
using System.Threading;

namespace TicTacToe1
{
    class Program
    {
        static void Main(string[] args)
        {
            char[,] TicTacToe = new char[3, 3];
            InitalizeMyBoard(TicTacToe);
            int movedPlayed = 0;

            bool EndGame = false;
            char player = 'X';

            while (EndGame == false)
            {
                PrintBoard(TicTacToe);
                Console.Write($"Player {player} choose a row: ");
                int row = int.Parse(Console.ReadLine());
                Console.Write($"Player {player} choose a column: ");
                int column = int.Parse(Console.ReadLine());

                bool taken = false;
                while (taken == false)
                {
                    if (TicTacToe[row, column] == '-')
                    {
                        TicTacToe[row, column] = player;
                        taken = true;
                    }
                    else if (TicTacToe[row, column] != '-')
                    {
                        Console.WriteLine("Spot is taken, choose another area!!");
                        Console.Write($"Player {player} choose a row: ");
                        row = int.Parse(Console.ReadLine());
                        Console.Write($"Player {player} choose a column: ");
                        column = int.Parse(Console.ReadLine());
                    }
                }

                TicTacToe[row, column] = player;
                EndGame = WhoWins(TicTacToe, player);

                movedPlayed = movedPlayed + 1;
                if (movedPlayed == 9)
                {
                    Console.WriteLine("It is a draw!");
                    break;
                }
                player = ChangePlayerTurn(player);
            }
        }
        static bool WhoWins(char[,] board, char player)
        {
            bool EndGame = false;
            //checks for rows
            if (player == board[0, 0] && player == board[0, 1] && player == board[0, 2])
            {
                Console.WriteLine(player + " has won the game");
                EndGame = true;
            }
            if (player == board[1, 0] && player == board[1, 1] && player == board[1, 2])
            {
                Console.WriteLine(player + " has won the game");
                EndGame = true;
            }
            if (player == board[2, 0] && player == board[2, 1] && player == board[2, 2])
            {
                Console.WriteLine(player + " has won the game");
                EndGame = true;
            }
            //checks for columns
            if (player == board[0, 0] && player == board[1, 0] && player == board[2, 0])
            {
                Console.WriteLine(player + " has won the game");
                EndGame = true;

            }
            if (player == board[0, 1] && player == board[1, 1] && player == board[2, 1])
            {
                Console.WriteLine(player + " has won the game");
                EndGame = true;
            }
            if (player == board[0, 2] && player == board[1, 2] && player == board[2, 2])
            {
                Console.WriteLine(player + " has won the game");
                EndGame = true;
            }
            //Checks for diagonal
            if (player == board[0, 0] && player == board[1, 1] && player == board[2, 2])
            {
                Console.WriteLine(player + " has won the game");
                EndGame = true;
            }
            if (player == board[0, 2] && player == board[1, 1] && player == board[2, 0])
            {
                Console.WriteLine(player + " has won the game");
                EndGame = true;
            }
            return EndGame;
        }
        static char ChangePlayerTurn(char currentPlayer)
        {
            if (currentPlayer == 'X')
            {
                return 'O';
            }
            else
            {
                return 'X';
            }
        }
        static void InitalizeMyBoard(char[,] MyBoard)
        {
            for (int row = 0; row < 3; row++)
            {
                for (int column = 0; column < 3; column++)
                {
                    MyBoard[row, column] = '-';
                }
            }
        }
        static void PrintBoard(char[,] TicTacToe)
        {
            Console.WriteLine(" | 0 | 1 | 2 |");
            for (int row = 0; row < 3; row++)
            {
                Console.Write(row + "| ");
                for (int column = 0; column < 3; column++)
                {
                    Console.Write(TicTacToe[row, column]);
                    Console.Write(" | ");
                }
                Console.WriteLine();
            }
        }

    }
}