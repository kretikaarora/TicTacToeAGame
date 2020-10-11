using System;
using System.Runtime.CompilerServices;
/// <summary>
/// TicTacToe game with a smart computer 
/// </summary>
namespace TicTacToeGameSimulator
{
    public class TicTacToeGame
    {
        //Global Variables
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

           
            bool flag = true;
            while(flag)
            {
                Console.WriteLine("1. Press Y to play  game");
                Console.WriteLine("1. Press N to Exit game");
                char anotherGame = Convert.ToChar(Console.ReadLine());
                if(anotherGame == 'Y')
                {

                    Console.WriteLine("Welcome to TicTacToeGame");
                    TicTacToeGame ticTacToeGame = new TicTacToeGame();
                    char[] board = ticTacToeGame.BoardFormation();
                    ticTacToeGame.CharacterChoice();
                    ticTacToeGame.Toss();

                }
                else
                {
                    flag = false;
                }
            }

        }
        /// <summary>
        /// initialising empty positions to board array 
        /// initialising false values to positionOcupied Array(bool array)
        /// </summary>
        /// <returns></returns>
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
        /// <summary>
        /// Choosing X or O for TicTacToe
        /// </summary>
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
        /// <summary>
        /// Displaying board structure for convinience of users
        /// </summary>
        public void ShowBoard()
        {
            Console.WriteLine("|{0} |{1} |{2} |", board[1], board[2], board[3]);
            Console.WriteLine("___________ ");
            Console.WriteLine("|{0} |{1} |{2} |", board[4], board[5], board[6]);
            Console.WriteLine("___________");
            Console.WriteLine("|{0} |{1} |{2} |", board[7], board[8], board[9]);
        }
        /// <summary>
        /// movement of user 
        /// </summary>
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
                    //checking if user has won or not after every move
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
                // calling computer to move in the turn
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
        // tie condition
           if(chances==9)
            Console.WriteLine("it is a tie");
        }
        public void ComputerMovement()

        {

            while (EmptySpace())

            {
                //defence attack to not let user win
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
                            chances++;
                            ShowBoard();
                            return;

                        }
                        else
                            board[j] = ' ';
                    }

                }
                //moving strategically by computer to win
                for (int i = 1; i < 10; i++)
                {
                    if (!positionOccupied[i])
                    {
                        board[i] = computerChoice;
                        string winner = HasWon();
                        if (winner == "Computer")
                        {
                            positionOccupied[i] = true;
                            Console.WriteLine("computer marks at {0}", i);
                            chances++;
                            Console.WriteLine("computer worked strategically");

                            ShowBoard();
                            return;
                        }
                        else
                            board[i] = ' ';
                    }
                }

                //occupying corner position first if empty
                int[] cornerPosition = new int[] {1, 3, 7, 9 };
                int position = cornerPosition[rand.Next(4)];
                if (!positionOccupied[position])
                {
                    board[position] = computerChoice;
                    positionOccupied[position] = true;
                    Console.WriteLine("occupied corner position");
                    chances++;
                    ShowBoard();
                    return;
                }
               //occupying center position after that 
                int emptyPosition = 5;
                if (!positionOccupied[emptyPosition])
                {
                    board[emptyPosition] = computerChoice;
                    positionOccupied[emptyPosition] = true;
                    chances++;
                    Console.WriteLine("occupied center position");
                    ShowBoard();
                    return;
                }
                //occupying center position after that 
                int[] sidePosition = new int[] {2,4,6,8 };
                int position2 = sidePosition[rand.Next(4)];
                if (!positionOccupied[position2])
                {
                    board[position2] = computerChoice;
                    positionOccupied[position2] = true;
                    Console.WriteLine("occupied side position");
                    chances++;
                    ShowBoard();
                    return;
                }

            }


        }
        /// <summary>
        /// toss to find who plays first user or computer
        /// </summary>
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
        /// <summary>
        /// checking if empty space available or not 
        /// </summary>
        /// <returns></returns>
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
        /// <summary>
        /// to check winning condition
        /// </summary>
        /// <returns></returns>
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


