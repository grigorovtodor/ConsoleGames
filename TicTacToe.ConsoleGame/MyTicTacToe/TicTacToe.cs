namespace MyTicTacToe
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class TicTacToe
    {
        //Fields
        string[,] ticTacArr = new string[9, 11];

        //Constructors
        public TicTacToe()
        {

        }

        //Prperties
        public string[,] TicTacArr
        {
            get
            {
                return this.ticTacArr;
            }
            set
            {
                this.ticTacArr = value;
            }
        }


        //Methods
        public void PopulateMatrix()
        {
            int counter = 1;
            int rowForNumber = 1;
            int colForNumber = 1;
            int rowForFirstUnderscoreLine = 2;
            int rowForSecondUnderscoreLine = 5;
            int colForFirstPipe = 3;
            int colForSecondPipe = 7;

            for (int i = 0; i < this.TicTacArr.GetLength(0); i++)
            {
                int colCounter = 0;

                for (int j = 0; j < this.TicTacArr.GetLength(1); j++)
                {
                    if (rowForNumber == i && colForNumber == j)
                    {
                        this.TicTacArr[i, j] = counter.ToString();
                        counter++;
                        colForNumber += 4;
                        colCounter++;
                    }
                    else if (j == colForFirstPipe || j == colForSecondPipe)
                    {
                        this.TicTacArr[i, j] = "|";
                    }
                    else if (i == rowForFirstUnderscoreLine || i == rowForSecondUnderscoreLine)
                    {
                        this.TicTacArr[i, j] = "_";
                    }
                    else
                    {
                        this.TicTacArr[i, j] = " ";
                    }
                    if (colCounter == 3)
                    {
                        rowForNumber += 3;
                        colForNumber = 1;
                        colCounter = 0;
                    }
                }
            }
        }

        public void DisplayTicTacToe()
        {
            for (int i = 0; i < this.TicTacArr.GetLength(0); i++)
            {
                for (int j = 0; j < this.TicTacArr.GetLength(1); j++)
                {
                    string current = this.TicTacArr[i, j];
                    Console.Write(current);
                }

                Console.WriteLine();
            }
        }

        private bool CheckWinner(Player player)
        {
            var result = false;

            for (int row = 1; row < this.TicTacArr.GetLength(0); row += 3)
            {
                var fieldWithSameSignCounter = 0;

                for (int col = 1; col < this.TicTacArr.GetLength(1); col += 4)
                {
                    var currentField = this.TicTacArr[row, col];

                    if (player.Sign == currentField)
                    {
                        fieldWithSameSignCounter++;
                    }
                }

                if (fieldWithSameSignCounter == 3)
                {
                    return result = true;
                }
            }

            for (int col = 1; col < this.TicTacArr.GetLength(1); col += 4)
            {
                var fieldWithSameSignCounter = 0;

                for (int row = 1; row < this.TicTacArr.GetLength(0); row += 3)
                {
                    var currentField = this.TicTacArr[row, col];

                    if (player.Sign == currentField)
                    {
                        fieldWithSameSignCounter++;
                    }
                }

                if (fieldWithSameSignCounter == 3)
                {
                    return result = true;
                }
            }

            var fieldWithSameDiagonalSignCounter = 0;

            for (int row = 1, col = 1; row < this.TicTacArr.GetLength(0); row += 3, col += 4)
            {
                var currentField = this.TicTacArr[row, col];

                if (player.Sign == currentField)
                {
                    fieldWithSameDiagonalSignCounter++;
                }

                if (col == 9)
                {
                    break;
                }
            }

            if (fieldWithSameDiagonalSignCounter == 3)
            {
                return result = true;
            }

            fieldWithSameDiagonalSignCounter = 0;

            for (int row = 1, col = 9; row < this.TicTacArr.GetLength(0); row += 3, col -= 4)
            {
                var currentField = this.TicTacArr[row, col];

                if (player.Sign == currentField)
                {
                    fieldWithSameDiagonalSignCounter++;
                }

                if (col == 1)
                {
                    break;
                }
            }

            if (fieldWithSameDiagonalSignCounter == 3)
            {
                return result = true;
            }

            return result;
        }

        private bool CheckForDrawGame(Player player1, Player player2)
        {
            var result = false;
            var fieldWithPlayerSignsCounter = 0;

            for (int row = 0; row < this.TicTacArr.GetLength(0); row++)
            {
                for (int col = 0; col < this.TicTacArr.GetLength(1); col++)
                {
                    var currentField = this.TicTacArr[row, col];

                    if (player1.Sign == currentField || player2.Sign == currentField)
                    {
                        fieldWithPlayerSignsCounter++;
                    }
                }
            }


            if (fieldWithPlayerSignsCounter == 9)
            {
                return result = true;
            }


            return result;
        }


        public void PlayGame(Player playerOne, Player playerTwo)
        {
            var winner = false;
            var draw = false;

            while (!winner && !draw)
            {
                while (playerOne.Turn && winner != true && draw != true)
                {
                    Console.Write($"{playerOne.Name}: Choose your field! ");
                    var input = Console.ReadLine();
                    int testInt;

                    if (int.TryParse(input, out testInt))
                    {
                        playerOne.ChooseField(input, this);
                        Console.Clear();
                        DisplayTicTacToe();
                        winner = CheckWinner(playerOne);
                        draw = CheckForDrawGame(playerOne, playerTwo);
                        playerOne.Turn = false;
                        playerTwo.Turn = true;

                        if (winner)
                        {
                            Console.WriteLine($"Congratulations! {playerOne.Name} has won the game!");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Please enter a number!");
                        input = Console.ReadLine();
                    }
                }

                while (playerTwo.Turn && winner != true && draw != true)
                {
                    Console.Write($"{playerTwo.Name}: Choose your field! ");
                    var input = Console.ReadLine();
                    int testInt;

                    if (int.TryParse(input, out testInt))
                    {
                        playerTwo.ChooseField(input, this);
                        Console.Clear();
                        DisplayTicTacToe();
                        winner = CheckWinner(playerTwo);
                        draw = CheckForDrawGame(playerOne, playerTwo);
                        playerTwo.Turn = false;
                        playerOne.Turn = true;

                        if (winner)
                        {
                            Console.WriteLine($"Congratulations! {playerTwo.Name} has won the game!");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Please enter a number!");
                        input = Console.ReadLine();
                    }
                }

                if (draw && !winner)
                {
                    Console.WriteLine($"Nobody won the game! DRAW!");
                }
            }

        }
    }
}
