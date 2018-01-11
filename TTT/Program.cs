using System;
using System.Threading;

namespace TTT
{
    class Program
    {

        static char[] board = {'1', '2', '3', '4', '5', '6', '7', '8', '9' };
        static int turn = 1; 
        static int choice;
        static int gameState = 0; // 0 playing; 1 someone has won; -1 draw
        static int playerScore = 0;
        static int compScore = 0;
        
        static void Main(string[] args)
        {

            GreetPlayer();

            do
            {
                Console.Clear();
                Console.WriteLine("Player plays: X \nComputer plays O");
                Console.WriteLine("\n");
                if (turn % 2 == 0)
                {
                    Console.WriteLine("Computer is making 'difficult' calculations...");
                    ComputerMove();
                }
                else
                {
                    Console.WriteLine("Player move");
                    PlayerMove();
                }

                gameState = CheckGameState();

            } while (gameState != 1 && gameState != -1);

            
            Console.Clear();
            Console.WriteLine("Player plays: X \nComputer plays O");
            Console.WriteLine("\n");
            DrawBoard();
            if (gameState == 1)
            {
                string message;
                if (turn % 2 == 0)
                {
                    message = "\nGAME OVER You have won \n\nPress 'ENTER' to exit.";
                    playerScore++;
                    
                }
                else
                {
                    message = "\nGAME OVER Computer has won \n\nPress 'ENTER' to exit.";
                    compScore++;
                }
                Console.WriteLine(message);
            }
            else
            {
                Console.WriteLine("Nobody wins");
            }
            Console.ReadLine();
        }

        private static void PlayerMove()
        {
            Console.WriteLine("\n");
            DrawBoard();
            string choice = Console.ReadLine();
            if (Int32.TryParse(choice, out int number) && !(Int32.Parse(choice) > 9) && !(Int32.Parse(choice)<1))
            {
                if (board[number - 1] != 'X' && board[number - 1] != 'O')
                {
                    board[number - 1] = 'X';
                    turn++;
                }
                else
                {
                    Console.WriteLine("Sorry this has already been taken. Press 'Enter' to make another choice.");
                    Console.ReadKey();
                    Console.WriteLine("\n");
                }
            }
            else
            {
                Console.WriteLine("{0} is not valid choice. Press 'Enter' to change", choice);
                Console.ReadLine();
            }           
        }

        private static void ComputerMove()
        {
            Random random = new Random();
            Console.WriteLine("\n");
            DrawBoard();
            choice = random.Next(1, 10);

            Thread.Sleep(700);
            if (board[choice - 1] != 'X' && board[choice - 1] != 'O')
            {
                board[choice - 1] = 'O';
                turn++;
            }
            else
            {
                ComputerMove();
            }
        }

        private static void DrawBoard()
        {
           
            for (int i=0; i < 9; i++)
            {
                Console.Write(board[i] + " ");
                if ((i+1) % 3 == 0)
                {
                    Console.WriteLine();
                }
            }
        }



        /// <summary>
        /// NEEDS refactoring, ugly but works
        /// 
        /// 0 1 2
        /// 3 4 5
        /// 6 7 8
        /// 
        /// All possible winning conditions and draw conditions are checked
        /// </summary>
        /// <returns> 1 if winning position is found,-1 if draw position is found, 0 if game continues</returns>

        private static int CheckGameState()
        {
            if (board[0] == board[1] && board[1] == board[2] || board[3] == board[4] && board[4] == board[5] ||
               board[6] == board[7] && board[7] == board[8] || board[0] == board[3] && board[3] == board[6] ||
               board[1] == board[4] && board[4] == board[7] || board[2] == board[5] && board[5] == board[8] ||
               board[0] == board[4] && board[4] == board[8] || board[2] == board[4] && board[4] == board[6])
            {
                return 1;
            }

            else if (board[0] != '1' && board[1] != '2' && board[2] != '3' && board[3] != '4'
                && board[4] != '5' && board[5] != '6' && board[6] != '7' && board[7] != '8' && board[8] != '9')
            {
                return -1;
            }
            else
            {
                return 0;
            }
        }

        private static void GreetPlayer()
        {

            Console.WriteLine("----------------------------");
            Console.WriteLine("Welcome to Single player Tic Tac Toe game");
            Console.WriteLine("----------------------------\n");
            Console.WriteLine();
            Console.WriteLine("You always start first and play 'X'");
            Console.WriteLine("The player who succeeds in placing three of their marks \nin a horizontal, vertical, or diagonal row wins the game");
            Console.WriteLine();
            Console.WriteLine("Press 'ENTER' to start a game");
            Console.ReadLine();
 
        }

        private static void DrawHeader() {
            throw new NotImplementedException();
        }

    }

}
