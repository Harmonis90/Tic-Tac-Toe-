using System;

namespace Tic_Tac_Toe_ {
    class Program {

      

        public static Player player1 = new Player();
        public static Player player2 = new Player();

        public static int isPlayer1Turn = 0;
        public static int isPlayer2Turn = 1;
        public static int turnCounter = 0;

        public static Player playerTurn = player1;

        public static string playerInput;

        public static string[] possiblePlayerInput = new string[] { "1", "2", "3", "4", "5", "6", "7", "8", "9" };

        public static bool isGameRunning = false;

        public static int gameResult = 0;
   
        


        //static Board board = new Board();
        public static void Main(string[] args) {
           
            PlayerSetup();
            StartGame();
           

        }

        public static void StartGame() {
            do {
                
                isGameRunning = true;

                turnCounter = 0;
                // gets p1 and p2 names and assigns X and O
                GetPlayerInput();

            } while (isGameRunning);

            switch (gameResult) {
                case 2:

                    Console.WriteLine("Game is a Draw!");
                    break;
                case 1:
                    Console.WriteLine("{0} Won!", playerTurn.Name);
                    break;

            }
            ResetGame();
        }

        public static void ResetGame() {
            Console.WriteLine("Would you like to play again?");
            string input = Console.ReadLine();
            if (input.ToUpper().StartsWith('Y')) {
                possiblePlayerInput = new string[] { "1", "2", "3", "4", "5", "6", "7", "8", "9" };
                turnCounter = 0;
                StartGame();
            }
            if (input.ToUpper().StartsWith('N')) {
                Console.WriteLine("Thank you for playing!");
            }
        }

        public static void PlayerSetup() {
            Player1Setup();
            Player2Setup();
        
        }
        
        
        
        public static void Player1Setup() {
            
          
           
            // Get and Set player1 name
            Console.WriteLine("Player 1, what is your name?");
            player1.Name = Console.ReadLine();
            
            
            Console.WriteLine("{0}, would you like to be 'X' or 'O'?", player1.Name);
            while (true) {
                // Set player 1 token to either x or o and make sure their token is valad
                
                string examineToken = Console.ReadLine();
            
                if (examineToken.ToUpper() == "X" || examineToken.ToUpper() == "O") {

                    player1.Token = examineToken.ToUpper();
                     
                    break;
                }
                else {
                    Console.WriteLine("Please select either 'X' or 'O'");
                    
                }
            }
        }

        public static void Player2Setup() {

          

            // Get and Set player2 name
            Console.WriteLine("Player 2, what is your name?");
            player2.Name = Console.ReadLine();
           
            // Turnary NOT logic to set player 2 token
            player2.Token = player1.Token.ToUpper() == "X" ? player2.Token = "O" : player2.Token = "X";
            Console.WriteLine("{0} will be {1}.", player2.Name, player2.Token);
            
        }
    
        public static void DrawBoard() {
            Console.Clear();
            Console.WriteLine("     |     |    ");
            Console.WriteLine("  {0}  |  {1}  |  {2}", possiblePlayerInput[6], possiblePlayerInput[7], possiblePlayerInput[8]);
            Console.WriteLine("-----+-----+-----");
            Console.WriteLine("  {0}  |  {1}  |  {2}", possiblePlayerInput[3], possiblePlayerInput[4], possiblePlayerInput[5]);
            Console.WriteLine("-----+-----+-----");
            Console.WriteLine("  {0}  |  {1}  |  {2}", possiblePlayerInput[0], possiblePlayerInput[1], possiblePlayerInput[2]); 
            Console.WriteLine("     |     |    ");
        }


        public static void GetPlayerInput() {
            DrawBoard();
            while (true) {
               
                Console.WriteLine("{0}s turn. Please choose a space to place your {1}", playerTurn.Name, playerTurn.Token);
                playerInput = Console.ReadLine();
               
                if (CheckPlayerInput(playerInput)) {
                    int playerInputInt = int.Parse(playerInput);
                    possiblePlayerInput.SetValue(playerTurn.Token, playerInputInt - 1);
                    if (WinCheck(playerTurn.Token)) {
                        DrawBoard();
                        gameResult = 1;
                        isGameRunning = false;
                        break;
                    }
                    
                    playerTurn = (playerTurn == player1 ? player2 : player1);
                    DrawBoard();
                    
                    turnCounter++;
                    if (turnCounter == 9) {
                        isGameRunning = false;
                        gameResult = 2;
                        break;
                    }
                }
            
                /*if (CheckPlayerInput(playerInput) == false) {
                    Console.WriteLine("Please select a valid number.");
                    continue;
                }*/
            }

        }
        public static bool CheckPlayerInput(string input) {
                
            foreach (string strNum in possiblePlayerInput) {
               if (strNum == input) {
                    return true;
                    
                }
            }
            return false;
            
        }

        public static bool WinCheck(string playerToken){

            if (playerToken == possiblePlayerInput[0] && playerToken == possiblePlayerInput[1] && playerToken == possiblePlayerInput[2]) {
                return true;
            }
            else if (playerToken == possiblePlayerInput[3] && playerToken == possiblePlayerInput[4] && playerToken == possiblePlayerInput[5]) {
                return true;
            }
            else if (playerToken == possiblePlayerInput[6] && playerToken == possiblePlayerInput[7] && playerToken == possiblePlayerInput[8]) {
                return true;
            }
            else if (playerToken == possiblePlayerInput[0] && playerToken == possiblePlayerInput[3] && playerToken == possiblePlayerInput[6]) {
                return true;
            }
            else if (playerToken == possiblePlayerInput[1] && playerToken == possiblePlayerInput[4] && playerToken == possiblePlayerInput[7]) {
                return true;
            }
            else if (playerToken == possiblePlayerInput[2] && playerToken == possiblePlayerInput[5] && playerToken == possiblePlayerInput[8]) {
                return true;
            }
            else if (playerToken == possiblePlayerInput[0] && playerToken == possiblePlayerInput[4] && playerToken == possiblePlayerInput[8]) {
                return true;
            }
            else if (playerToken == possiblePlayerInput[2] && playerToken == possiblePlayerInput[4] && playerToken == possiblePlayerInput[6]) {
                return true;
            }
            




            return false;
        }
    }   
}
