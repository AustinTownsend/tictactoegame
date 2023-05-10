namespace tictactoegame
{
    internal class TicTacToe
    {

        static char[,] playField =
        {
            {'1', '2', '3' },
            {'4', '5', '6' },
            {'7', '8', '9' }
        };
        static int turns = 0;
        static int playerScore1 = 0;
        static int playerScore2 = 0;


        static void Main(string[] args)
        {
            int player = 2; // to make sure player 1 starts
            int input = 0;
            bool inputCorrect = true;
            string playerName1;
            string playerName2;

            Console.WriteLine("Hello, welcome to my two player game of TicTacToe!\n\nHopefully you already know the basics, but if not it is really simple.\n" +
                "You will be asked to input a number to update the board with you sign.\nPlayer 1 will be O and player 2 will be X.  Have you sign in a straight or diagnonal line, and you win!\n" +
                "You'll only have 9 turns total so make sure to strategize as you go.  \nLet me ask you a few questions and we can get started!");
            Console.WriteLine("\n\nNow, could I please have player 1's name?");
            playerName1 = Console.ReadLine();
            Console.WriteLine("Great, so player 1 will be {0}.  Now could you please enter player 2's name?", playerName1);
            playerName2 = Console.ReadLine();
            Console.WriteLine("{0} will be playing against {1}.  Press any key to get started!", playerName1, playerName2);
            Console.ReadKey();
              

            // Using continuous do loop with while always true in order to have the game cotinuously run.
            do
            {
                

                if (player == 2)
                {
                    player = 1;
                    EnterXorO(player, input);
                }
                    
                else if (player == 1)
                {
                    player = 2;
                    EnterXorO(player, input);
                }

                SetField();

                #region // Check winning condition

                char[] playerChars = { 'X', 'O' };

                foreach(char playerChar in playerChars)
                {
                    if (((playField[0, 0] == playerChar) && (playField[0, 1] == playerChar) && (playField[0, 2] == playerChar))
                    || ((playField[1, 0] == playerChar) && (playField[1, 1] == playerChar) && (playField[1, 2] == playerChar))
                    || ((playField[2, 0] == playerChar) && (playField[2, 1] == playerChar) && (playField[2, 2] == playerChar))
                    || ((playField[0, 0] == playerChar) && (playField[1, 0] == playerChar) && (playField[2, 0] == playerChar))
                    || ((playField[0, 1] == playerChar) && (playField[1, 1] == playerChar) && (playField[2, 1] == playerChar))
                    || ((playField[0, 2] == playerChar) && (playField[1, 2] == playerChar) && (playField[2, 2] == playerChar))
                    || ((playField[0, 0] == playerChar) && (playField[1, 1] == playerChar) && (playField[2, 2] == playerChar))
                    || ((playField[0, 2] == playerChar) && (playField[1, 1] == playerChar) && (playField[2, 0] == playerChar))
                    )
                    {
                        if (playerChar == 'O')
                        {
                            Console.WriteLine("\n{0}, you have won the game of tictactoe!  Congrats to you.", playerName1);
                            playerScore1++;
                            Console.WriteLine("{0}, your total score is now {1}.", playerName1, playerScore1);
                            Console.WriteLine("Press any key to reset the game.");
                            Console.ReadKey();
                            ResetField();
                            break;
                        }
                        else
                        {
                            Console.WriteLine("\n{0}, you have won the game of tictactoe!  Congrats to you.", playerName2);
                            playerScore2++;
                            Console.WriteLine("{0}, your total score is now {1}.", playerName2, playerScore2);
                            Console.WriteLine("Press any key to reset the game.");
                            Console.ReadKey();
                            ResetField();
                            break;
                        }
                    }
                    else if (turns == 10)
                    {
                        Console.WriteLine("We have a tie, perhaps someone will prevail next time. \nPress any key to reset the game!");
                        Console.ReadKey();
                        ResetField();
                        break;
                    }

                }

                #endregion


                #region // Ask for input and check if field is already taken
                do
                {
                    if(player == 1)
                    {
                        Console.WriteLine("{0} make your move!  Enter 1-9 to choose a space left on the board.", playerName1);
                    }
                    else if(player == 2)
                    {
                        Console.WriteLine("{0} make your move!  Enter 1-9 to choose a space left on the board.", playerName2);
                    }
                    try
                    {
                        input = Convert.ToInt32(Console.ReadLine());
                    }
                    catch
                    {
                        Console.WriteLine("Please enter a number!");
                    }

                    if (input == 1 && (playField[0, 0] == '1'))
                        inputCorrect = true;
                    else if (input == 2 && (playField[0, 1] == '2'))
                        inputCorrect = true;
                    else if (input == 3 && (playField[0, 2] == '3'))
                        inputCorrect = true;
                    else if (input == 4 && (playField[1, 0] == '4'))
                        inputCorrect = true;
                    else if (input == 5 && (playField[1, 1] == '5'))
                        inputCorrect = true;
                    else if (input == 6 && (playField[1, 2] == '6'))
                        inputCorrect = true;
                    else if (input == 7 && (playField[2, 0] == '7'))
                        inputCorrect = true;
                    else if (input == 8 && (playField[2, 1] == '8'))
                        inputCorrect = true;
                    else if (input == 9 && (playField[2, 2] == '9'))
                        inputCorrect = true;
                    else
                    {
                        Console.WriteLine("\n Someone already has that field, choose another!");
                        inputCorrect = false;
                    }

                }
                while(!inputCorrect);
                {
                }
                #endregion
            }

            while (true);
            {

            }
           
        }
        
        public static void ResetField()
        {
             char[,] playFieldInitial =
           {
            {'1', '2', '3' },
            {'4', '5', '6' },
            {'7', '8', '9' }
           };
            playField = playFieldInitial;
            SetField();
            turns = 0;
        }

        public static void SetField()
        {
            Console.Clear();
            Console.WriteLine("     |     |     ");
            Console.WriteLine(" {0}   |  {1}  |  {2}", playField[0,0], playField[0, 1], playField[0, 2]);
            Console.WriteLine("_____|_____|_____");
            Console.WriteLine("     |     |     ");
            Console.WriteLine(" {0}   |  {1}  |  {2}", playField[1, 0], playField[1, 1], playField[1, 2]);
            Console.WriteLine("_____|_____|_____");
            Console.WriteLine("     |     |     ");
            Console.WriteLine(" {0}   |  {1}  |  {2}", playField[2, 0], playField[2, 1], playField[2, 2]);
            turns++;
        }

        public static void EnterXorO(int player, int input)
        {
            char playerSign = ' ';

            if (player == 1)
                playerSign = 'X';
            else if (player == 2)
                playerSign = 'O';

            switch (input)
            {
                case 1:
                    playField[0, 0] = playerSign; break;
                case 2:
                    playField[0, 1] = playerSign; break;
                case 3:
                    playField[0, 2] = playerSign; break;
                case 4:
                    playField[1, 0] = playerSign; break;
                case 5:
                    playField[1, 1] = playerSign; break;
                case 6:
                    playField[1, 2] = playerSign; break;
                case 7:
                    playField[2, 0] = playerSign; break;
                case 8:
                    playField[2, 1] = playerSign; break;
                case 9:
                    playField[2, 2] = playerSign; break;
            }
        }

    }


}