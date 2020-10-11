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
        int index = 0;

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
                        Console.WriteLine("enter the other position you want to fill");
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

                    string result = HasWon();
                    if (result == "User")
                    {
                        Console.WriteLine("user is the winner");
                        return;
                    }
                    else if (result == "Computer")
                    {
                        Console.WriteLine("computer is the winner");
                        return;
                    }
                    else
                    {
                        Console.WriteLine("continue playing");
                    }                   
                }
                ComputerMovement();
                string result1 = HasWon();

                if (result1 == "Computer")
                {
                    Console.WriteLine("computer is the winner");
                    return;
                }
                else
                {
                    Console.WriteLine("continue playing");
                }
            }
            if (chances==9)
            Console.WriteLine("it is a tie");
        }
        public void ComputerMovement()
        { bool flag = true;
         while (flag)
            {
                DefenceAttack();
                if (index == 2)
                {
                    Console.WriteLine(" good work ,computer moved with defence");
                    chances++;
                    flag = false;
                }
                else
                {
                    FindCanWon();
                    if(index == 1)
                    {
                        Console.WriteLine(" good work ,computer moved with strategy");
                        chances++;
                        flag = false;
                    }
                    else
                    {
                        int position = rand.Next(1, 10);
                        if (!positionOccupied[position])
                        {
                            board[position] = computerChoice;
                            positionOccupied[position] = true;
                            chances++;
                            ShowBoard();
                            flag = false;
                        }
                    }
                }
                
         }           
        }
        public void Toss()
        {
            int choice = rand.Next(0, 2);
            switch (choice)
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
            for (int i = 1; i < 10; i++)
            {
                if (!positionOccupied[i])
                {
                    return true;
                }
            }
            return false;
        }
        public string HasWon()
        {
            for (int i = 1; i < 8; i = i + 3)
            {
                if (board[i] == board[i + 1] && board[i + 1] == board[i + 2] && board[i] != ' ')
                {
                    if (board[i] == userChoice)
                        return "User";
                    else
                        return "Computer";
                }

            }
            for (int i = 1; i <= 3; i++)
            {

                if (board[i] == board[i + 3] && board[i + 3] == board[i + 6] && board[i] != ' ')

                {
                    if (board[i] == userChoice)
                        return "User";
                    else
                        return "Computer";
                }
            }

            if (board[1] == board[5] && board[5] == board[9] && board[1] != ' ')
            {
                if (board[1] == userChoice)
                    return "User";
                else
                    return "Computer";
            }
            if (board[3] == board[5] && board[5] == board[7] && board[3] != ' ')
            {
                if (board[3] == userChoice)
                    return "User";
                else
                    return "Computer";
            }
            return "Play";
        }
        public void FindCanWon()
        { 
            for (int i = 1; i < 10; i++)
            {
              if(!positionOccupied[i])
                {
                    board[i] = computerChoice;
                    string winner = HasWon();
                    if (winner == "Computer")
                    {
                        positionOccupied[i] = true;
                        Console.WriteLine("computer marks at {0}", i);
                        index = 1;
                        ShowBoard();
                        return;
                    }
                    else
                        board[i] = ' ';
                  
                }
            }
        }
        public void DefenceAttack()
        {
            for (int j = 1; j < 10; j++)
            {
                if (!positionOccupied[j])
                {
                    board[j] = userChoice;
                    string winner1 = HasWon();
                    if (winner1 == "User")
                    {
                        board[j] = computerChoice;
                        positionOccupied[j] = true;
                        Console.WriteLine("computer defence attack");
                        index = 2;
                        ShowBoard();
                        return;

                    }
                    else
                        board[j] = ' ';
                }

            }

        }
    }
}


