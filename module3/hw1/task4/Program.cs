using System;

namespace task4
{
    //Сорри, но forward и backward мимо/
    // Еще по приколу написал так что кажется, что он идет в реальном времени.
    // И чтобы красиво отрисовывать врезание в стенку пришлось использовать события :(
    class Robot
    {
        event Move Crash;
        string[][] matrix;

        int x;
        int y;

        public Robot(string[][] matrix)
        {
            this.matrix = matrix;
            Crash += Console.Clear;
            Crash += Program.DisplayControls;
            Crash += PrintCurrent;

        }

        public void Initialise()
        {
            x = 1;
            y = 1;
        }

        public void Left()
        {

            x -= 1;
        }
        public void Right()
        {
            x += 1;
        }
        public void Down()
        {
            y += 1;
        }
        public void Up()
        {
            y -= 1;
        }

        public void Plus()
        {

            matrix[y][x] = "+";

        }

        public void Star()
        {
            if (x > matrix[0].Length - 2 || x < 1 || y < 1 || y > matrix.Length - 2)
            {
                matrix[y][x] = "\x1b[31m*\x1b[0m";
                Crash?.Invoke();
                Console.WriteLine("Matrix borders exceeded. Crash :(");
                Environment.Exit(0);

            }
            else
            {
                matrix[y][x] = "\x1b[31m*\x1b[0m";
            }

        }


        //public void PrintCoords()
        //{
        //    Console.WriteLine($"x:{x} y:{y}");
        //}

        public void PrintCurrent()
        {
            for (int i = 0; i < matrix.Length; i++)
            {
                for (int j = 0; j < matrix[0].Length; j++)
                {
                    Console.Write(matrix[i][j]);
                    Console.Write(' ');
                }
                Console.WriteLine();
            }
        }



    }

    delegate void Move();



    class Program
    {
        static string command;
        static int n;
        static int m;

        static void Delay()
        {
            System.Threading.Thread.Sleep(100);
        }
        public static void DisplayControls()
        {
            Console.WriteLine($"Command: {command}");
            Console.WriteLine($"Dimentions: {n}x{m}");
        }
        static void Main(string[] args)
        {
            Console.Write("Enter dimentions of the field(n,m): ");
            string dimentions = Console.ReadLine().Trim();
            Console.WriteLine();
            if (DimentionsVerifier(dimentions, out n, out m))
            {
                Console.Write("Insert command: ");
                command = Console.ReadLine();
                Console.WriteLine();

                if (CommandVerifier(command))
                {
                    string[][] matrix = new string[n + 2][];
                    for (int i = 0; i < n + 2; i++)
                    {
                        matrix[i] = new string[m + 2];
                        if (i == 0 | i == n + 1)
                        {
                            for (int j = 0; j < m + 2; j++)
                            {
                                matrix[i][j] = "#";
                            }
                        }
                        else
                        {
                            matrix[i][0] = "#";
                            matrix[i][m + 1] = "#";
                            for (int j = 1; j < m + 1; j++)
                            {
                                matrix[i][j] = " ";
                            }
                        }

                    }

                    Robot robot = new Robot(matrix);
                    Move move = robot.Initialise;

                    CommandHandler(command, robot, ref move);
                    move?.Invoke();
                }
                else
                {
                    Console.WriteLine("Incorrect command.");
                }
            }
            else
            {
                Console.WriteLine("Incorrect dimentions.");
            }
        }

        static bool CommandVerifier(string command)
        {
            foreach (char ch in command)
            {
                if (ch == 'L' || ch == 'R' || ch == 'D' || ch == 'U')
                {
                    continue;
                }
                else
                {
                    return false;
                }
            }
            return true;
        }

        static void CommandHandler(string command, Robot robot, ref Move move)
        {

            foreach (char ch in command)
            {
                move += robot.Plus;
                switch (ch)
                {
                    case 'L':
                        move += robot.Left;
                        break;
                    case 'R':
                        move += robot.Right;
                        break;
                    case 'D':
                        move += robot.Down;
                        break;
                    case 'U':
                        move += robot.Up;
                        break;
                }
                move += robot.Star;
                move += Console.Clear;
                move += DisplayControls;
                move += robot.PrintCurrent;
                move += Delay;
                //move += robot.PrintCoords;
            }
        }

        static bool DimentionsVerifier(string dimentions, out int n, out int m)
        {
            string[] numbers = dimentions.Split(' ');
            if (numbers.Length == 2)
            {
                return int.TryParse(numbers[0], out n) & int.TryParse(numbers[1], out m) & n > 0 & m > 0;
            }
            else
            {
                n = 0;
                m = 0;
                return false;
            }
        }

    }
}
