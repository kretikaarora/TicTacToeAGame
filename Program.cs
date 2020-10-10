﻿using System;

namespace TicTacToeGameSimulator
{
     public class TicTacToeGame
    {
        char[] board = new char[10];
        bool[] positionOccupied = new bool[10];
        char computerChoice;
        char userChoice;
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to TicTacToeGame");
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
        public void CharacterChoice()
        {
            Console.WriteLine("1. enter 1 for choosing X \n2. enter 2 for choosing O");
            int choice = Convert.ToInt32(Console.ReadLine());
            switch(choice)
            {
                case 1:
                    userChoice = 'X';
                    computerChoice = 'O';
                    break;
                case 2:
                    userChoice = 'O';
                    computerChoice = 'X';
                    break;
                default:
                    userChoice = 'X';
                    computerChoice = 'O';
                    Console.WriteLine("invalid input \n userchoice is alotted X and computerchoice is O");

            }

        }
        public void ShowBoard()
        {
            Console.WriteLine("|{0} |{1} |{2} |", board[1], board[2], board[3]);
            Console.WriteLine("___________ ");
            Console.WriteLine("|{0} |{1} |{2} |", board[4], board[5], board[6]);
            Console.WriteLine("___________");
            Console.WriteLine("|{0} |{1} |{2} |", board[7], board[8], board[9]);
        }
    }
}
