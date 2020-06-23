namespace P02.Re_Volt
{
    using System;
    using System.Linq;

    class Program
    {
        static void Main()
        {

            int matrixDimension = int.Parse(Console.ReadLine());
            int commandsNumber = int.Parse(Console.ReadLine());

            int[] playerPosition = new int[2];

            char[,] playground = new char[matrixDimension, matrixDimension];
            for (int i = 0; i < matrixDimension; i++)
            {
                char[] input = Console.ReadLine().ToCharArray();
                for (int j = 0; j < matrixDimension; j++)
                {
                    if (input[j] == 'f')
                    {
                        playerPosition[0] = i;
                        playerPosition[1] = j;
                    }
                    playground[i, j] = input[j];
                }
            }

            bool playerWin = false;

            for (int i = 0; i < commandsNumber; i++)
            {
                if (!playerWin)
                {
                    string command = Console.ReadLine();
                    int[] lastPlayerPosition = playerPosition.ToArray();

                    MovePlayer(matrixDimension, playerPosition, command);

                    if (playground[playerPosition[0], playerPosition[1]] == 'B')
                    {
                        MovePlayer(matrixDimension, playerPosition, command);
                    }

                    else if (playground[playerPosition[0], playerPosition[1]] == 'T')
                    {
                        playerPosition = lastPlayerPosition;
                    }

                    if (playground[playerPosition[0], playerPosition[1]] == 'F')
                    {
                        playerWin = true;
                    }

                    RefreshPlayground(playerPosition, playground, lastPlayerPosition);
                }
            }
            if (playerWin)
            {
                Console.WriteLine("Player won!");
            }
            else
            {
                Console.WriteLine("Player lost!");
            }
            PrintMatrix(playground);
        }

        private static void RefreshPlayground(int[] playerPosition, char[,] playground, int[] lastPlayerPosition)
        {
            playground[lastPlayerPosition[0], lastPlayerPosition[1]] = '-';
            playground[playerPosition[0], playerPosition[1]] = 'f';
        }
        private static void PrintMatrix(char[,] playground)
        {
            for (int i = 0; i < playground.GetLength(0); i++)
            {
                for (int j = 0; j < playground.GetLength(1); j++)
                {
                    Console.Write(playground[i, j]);
                }
                Console.WriteLine();
            }
        }
        private static void MovePlayer(int matrixDimension, int[] playerPosition, string command)
        {
            if (command == "up")
            {
                if (playerPosition[0] - 1 >= 0)
                {
                    playerPosition[0]--;
                }
                else
                {
                    playerPosition[0] = matrixDimension - 1;
                }
            }
            else if (command == "down")
            {
                if (playerPosition[0] + 1 < matrixDimension)
                {
                    playerPosition[0]++;
                }
                else
                {
                    playerPosition[0] = 0;
                }
            }
            else if (command == "left")
            {
                if (playerPosition[1] - 1 >= 0)
                {
                    playerPosition[1]--;
                }
                else
                {
                    playerPosition[1] = matrixDimension - 1;
                }
            }
            else if (command == "right")
            {
                if (playerPosition[1] + 1 < matrixDimension)
                {
                    playerPosition[1]++;
                }
                else
                {
                    playerPosition[1] = 0;
                }
            }
        }
    }
}
