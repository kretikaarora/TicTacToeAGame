using System;

namespace TicTacToeGameSimulator
{
     public class TicTacToeGame
    {
        char[] board = new char[10];
        bool[] positionOccupied = new bool[10];
        static void Main(string[] args)
        {
            TicTacToeGame ticTacToeGame = new TicTacToeGame();
            char[] board= ticTacToeGame.BoardFormation();
        }
        
        public char[] BoardFormation()
        {
            // initialising new board 

            int position;
            // assigning empty value to board 
            for (position = 1; position < board.Length; position++)
            {
                board[position] = ' ';
                positionOccupied[position] = false;

            }
            return board;

        }
    }
}
