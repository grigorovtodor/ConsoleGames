namespace MyTicTacToe
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Startup
    {
        public static void Main(string[] args)
        {
            var playerOne = new Player("Player 1", "O", true);
            var playerTwo = new Player("Player 2", "X", false);
            var myTicTacToeGame = new TicTacToe();
            myTicTacToeGame.PopulateMatrix();
            myTicTacToeGame.DisplayTicTacToe();
            myTicTacToeGame.PlayGame(playerOne, playerTwo);


            //string[,] ticTacArr = new string[9, 11];
            //PopulateMatrix(ticTacArr);
            //DisplayMatrix(ticTacArr);
            //PlayGame(ticTacArr);


            Console.ReadLine();
        }

        //public static void PopulateMatrix(string[,] ticTacArr)
        //{
        //    int counter = 1;
        //    int rowForNumber = 1;
        //    int colForNumber = 1;
        //    int rowForFirstUnderscoreLine = 2;
        //    int rowForSecondUnderscoreLine = 5;
        //    int colForFirstPipe = 3;
        //    int colForSecondPipe = 7;

        //    for (int i = 0; i < ticTacArr.GetLength(0); i++)
        //    {
        //        int colCounter = 0;

        //        for (int j = 0; j < ticTacArr.GetLength(1); j++)
        //        {
        //            if (rowForNumber == i && colForNumber == j)
        //            {
        //                ticTacArr[i, j] = counter.ToString();
        //                counter++;
        //                colForNumber += 4;
        //                colCounter++;
        //            }
        //            else if (j == colForFirstPipe || j == colForSecondPipe)
        //            {
        //                ticTacArr[i, j] = "|";
        //            }
        //            else if (i == rowForFirstUnderscoreLine || i == rowForSecondUnderscoreLine)
        //            {
        //                ticTacArr[i, j] = "_";
        //            }
        //            else
        //            {
        //                ticTacArr[i, j] = " ";
        //            }
        //            if (colCounter == 3)
        //            {
        //                rowForNumber += 3;
        //                colForNumber = 1;
        //                colCounter = 0;
        //            }
        //        }
        //    }
        //}

        //public static void DisplayMatrix(string[,] matrix)
        //{
        //    for (int i = 0; i < matrix.GetLength(0); i++)
        //    {
        //        for (int j = 0; j < matrix.GetLength(1); j++)
        //        {
        //            string current = matrix[i, j];
        //            Console.Write(current);
        //        }

        //        Console.WriteLine();
        //    }
        //}

        //public static void ChooseField(string input, string playerSign, string[,] ticTacArr)
        //{
        //    int inputNum;

        //    if (int.TryParse(input, out inputNum))
        //    {
        //        for (int i = 0; i < ticTacArr.GetLength(0); i++)
        //        {
        //            for (int j = 0; j < ticTacArr.GetLength(1); j++)
        //            {
        //                var current = ticTacArr[i, j];
        //                if (current == input)
        //                {
        //                    ticTacArr[i, j] = playerSign;
        //                    return;
        //                }
        //            }
        //        }

        //        Console.WriteLine("Incorect input! Please use another field!");
        //    }
        //    else
        //    {
        //        Console.WriteLine("Please enter a number!");
        //    }
        //}

        //public static bool CheckWinner(Player player, string[,] ticTacArr)
        //{
        //    var result = false;

        //    for (int row = 1; row < ticTacArr.GetLength(0); row += 3)
        //    {
        //        var fieldWithSameSignCounter = 0;

        //        for (int col = 1; col < ticTacArr.GetLength(1); col += 4)
        //        {
        //            var currentField = ticTacArr[row, col];

        //            if (player.Sign == currentField)
        //            {
        //                fieldWithSameSignCounter++;
        //            }
        //        }

        //        if (fieldWithSameSignCounter == 3)
        //        {
        //            return result = true;
        //        }
        //    }

        //    for (int col = 1; col < ticTacArr.GetLength(1); col += 4)
        //    {
        //        var fieldWithSameSignCounter = 0;

        //        for (int row = 1; row < ticTacArr.GetLength(0); row += 3)
        //        {
        //            var currentField = ticTacArr[row, col];

        //            if (player.Sign == currentField)
        //            {
        //                fieldWithSameSignCounter++;
        //            }
        //        }

        //        if (fieldWithSameSignCounter == 3)
        //        {
        //            return result = true;
        //        }
        //    }

        //    var fieldWithSameDiagonalSignCounter = 0;

        //    for (int row = 1, col = 1; row < ticTacArr.GetLength(0); row += 3, col += 4)
        //    {
        //        var currentField = ticTacArr[row, col];

        //        if (player.Sign == currentField)
        //        {
        //            fieldWithSameDiagonalSignCounter++;
        //        }

        //        if (col == 9)
        //        {
        //            break;
        //        }
        //    }

        //    if (fieldWithSameDiagonalSignCounter == 3)
        //    {
        //        return result = true;
        //    }

        //    fieldWithSameDiagonalSignCounter = 0;

        //    for (int row = 1, col = 9; row < ticTacArr.GetLength(0); row += 3, col -= 4)
        //    {
        //        var currentField = ticTacArr[row, col];

        //        if (player.Sign == currentField)
        //        {
        //            fieldWithSameDiagonalSignCounter++;
        //        }

        //        if (col == 1)
        //        {
        //            break;
        //        }
        //    }

        //    if (fieldWithSameDiagonalSignCounter == 3)
        //    {
        //        return result = true;
        //    }

        //    return result;
        //}

        //public static bool CheckForDrawGame(Player player1, Player player2, string[,] ticTacArr)
        //{
        //    var result = false;
        //    var fieldWithPlayerSignsCounter = 0;

        //    for (int row = 0; row < ticTacArr.GetLength(0); row++)
        //    {
        //        for (int col = 0; col < ticTacArr.GetLength(1); col++)
        //        {
        //            var currentField = ticTacArr[row, col];

        //            if (player1.Sign == currentField || player2.Sign == currentField)
        //            {
        //                fieldWithPlayerSignsCounter++;
        //            }
        //        }
        //    }


        //    if (fieldWithPlayerSignsCounter == 9)
        //    {
        //        return result = true;
        //    }


        //    return result;
        //}

        //public static void PlayGame(string[,] ticTacArr)
        //{
        //    var playerOne = new Player("Player 1", "O", true);
        //    var playerTwo = new Player("Player 2", "X", false);
        //    var winner = false;
        //    var draw = false;

        //    while (!winner && !draw)
        //    {
        //        while (playerOne.Turn && winner != true && draw != true)
        //        {
        //            Console.Write($"{playerOne.Name}: Choose your field! ");
        //            var input = Console.ReadLine();
        //            int testInt;

        //            if (int.TryParse(input, out testInt))
        //            {
        //                ChooseField(input, playerOne.Sign, ticTacArr);
        //                Console.Clear();
        //                DisplayMatrix(ticTacArr);
        //                winner = CheckWinner(playerOne, ticTacArr);
        //                draw = CheckForDrawGame(playerOne, playerTwo, ticTacArr);
        //                playerOne.Turn = false;
        //                playerTwo.Turn = true;

        //                if (winner)
        //                {
        //                    Console.WriteLine($"Congratulations! {playerOne.Name} has won the game!");
        //                }
        //            }
        //            else
        //            {
        //                Console.WriteLine("Please enter a number!");
        //                input = Console.ReadLine();
        //            }
        //        }

        //        while (playerTwo.Turn && winner != true && draw != true)
        //        {
        //            Console.Write($"{playerTwo.Name}: Choose your field! ");
        //            var input = Console.ReadLine();
        //            int testInt;

        //            if (int.TryParse(input, out testInt))
        //            {
        //                ChooseField(input, playerTwo.Sign, ticTacArr);
        //                Console.Clear();
        //                DisplayMatrix(ticTacArr);
        //                winner = CheckWinner(playerTwo, ticTacArr);
        //                draw = CheckForDrawGame(playerOne, playerTwo, ticTacArr);
        //                playerTwo.Turn = false;
        //                playerOne.Turn = true;

        //                if (winner)
        //                {
        //                    Console.WriteLine($"Congratulations! {playerTwo.Name} has won the game!");
        //                }
        //            }
        //            else
        //            {
        //                Console.WriteLine("Please enter a number!");
        //                input = Console.ReadLine();
        //            }
        //        }

        //        if (draw)
        //        {
        //            Console.WriteLine($"Nobody won the game! DRAW!");
        //        }
        //    }
        //}
    }
}
