using System;

namespace TicTacToeGameSimulator
{
    public class TicTacToeGame
    {
        char[] board = new char[10];
        bool[] positionOccupied = new bool[10];
        char computerChoice;
        char userChoice;
        const int HEAD = 1;
        const int TAIL = 0;
        int chances = 0;
        Random rand = new Random();
        
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to TicTacToeGame");
            TicTacToeGame ticTacToeGame = new TicTacToeGame();
            char[] board = ticTacToeGame.BoardFormation();
            ticTacToeGame.CharacterChoice();
            ticTacToeGame.Toss();
            
            
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
            positionOccupied[0] = true;
            return board;

        }
        public void CharacterChoice()
        {
            Console.WriteLine("1. enter 1 for choosing X \n2. enter 2 for choosing O");
            int choice = Convert.ToInt32(Console.ReadLine());
            switch (choice)
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
                    break;

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
        public void UserMovement()
        {
            
            while (EmptySpace())
            {
                bool flag = true;
                while (flag)
                {
                    Console.WriteLine("enter the position you want to fill");
                    int position = Convert.ToInt32(Console.ReadLine());
                    if (position >= 1 && position <= 9 && positionOccupied[position])
                    {
                        Console.WriteLine("position occupied is already filled");
                    }
                    else if (position < 1 || position > 9)
                    {
                        Console.WriteLine("invalid entry");
                    }
                    else
                    {
                        board[position] = userChoice;
                        positionOccupied[position] = true;
                        chances++;
                        flag = false;
                    }
                    ShowBoard();
                    if (chances < 10)
                    {
                        ComputerMovement();
                    }
                }
            }
        }
        public void ComputerMovement()
        {  
            bool flag = true;
          
            while (flag)
            {
                int position = rand.Next(1,10);
                if(!positionOccupied[position])
                {
                    board[position] = computerChoice;
                    positionOccupied[position] = true;
                    chances++;
                    flag = false;
                }

            }
            ShowBoard();
        }
        public void Toss()
        {
            int choice = rand.Next(0, 2);
            switch(choice)
            {
                case HEAD:
                    UserMovement();
                    break;
                case TAIL:
                    ComputerMovement();
                    UserMovement();
                    break;
            }
        }
        public bool EmptySpace()
        {
            for (int i = 0; i <= 10; i++)
            {
                if (!positionOccupied[i])
                {
                    return true;
                }
            }
            return false;
        }

    }
}


