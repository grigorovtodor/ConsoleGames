namespace MyTicTacToe
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Player
    {
        string name;
        string sign;

        public Player()
        {

        }

        public Player(string name, string sign, bool turn)
        {
            this.Name = name;
            this.Sign = sign;
            this.Turn = turn;
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                this.name = value;
            }
        }

        public string Sign
        {
            get
            {
                return this.sign;
            }
            set
            {
                this.sign = value;
            }
        }

        public bool Turn { get; set; }
        public TicTacToe TictacToe { get; set; }


        public void ChooseField(string input, TicTacToe ticTacToe)
        {
            int inputNum;

            if (int.TryParse(input, out inputNum))
            {
                for (int i = 0; i < ticTacToe.TicTacArr.GetLength(0); i++)
                {
                    for (int j = 0; j < ticTacToe.TicTacArr.GetLength(1); j++)
                    {
                        var current = ticTacToe.TicTacArr[i, j];
                        if (current == input)
                        {
                            ticTacToe.TicTacArr[i, j] = this.Sign;
                            return;
                        }
                    }
                }

                Console.WriteLine("Incorect input! Please use another field!");
            }
            else
            {
                Console.WriteLine("Please enter a number!");
            }
        }
    }
}
