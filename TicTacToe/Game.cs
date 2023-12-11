namespace TicTacToe
{
    class Game
    {
        static char[] cell = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' }; //ячейки поля
        static int player = 1;  //выбор игрока. По дефолту стоит 1
        static int mark;        //позволяет отметить 'X' или 'O' на поле
        static int flag = 0;    //проверяет, кто выиграл: если -1, то ничья;
                                //если 0, то матч  выполняется;
                                //если 1, то кто-то выиграл

        public Game()
        {
            // Будет выполняться, пока все ячейки не будут заполнены
            //или кто-то не выиграет
            do
            {
                Console.Clear();
                Console.BackgroundColor = ConsoleColor.White; Console.ForegroundColor = ConsoleColor.Black;
                Console.SetCursorPosition(10, 0); Console.WriteLine("Игра \"Крестики-нолики\""); Console.ResetColor();
                Console.WriteLine("Игрок 1: X\nИгрок 2: O\n");

                if (player % 2 == 0) // говорит, чей ход
                {
                    Console.BackgroundColor = ConsoleColor.White; Console.ForegroundColor = ConsoleColor.Black;
                    Console.SetCursorPosition(12, 4); Console.WriteLine("Ходит Игрок 2"); Console.ResetColor();
                }
                else
                {
                    Console.BackgroundColor = ConsoleColor.White; Console.ForegroundColor = ConsoleColor.Black;
                    Console.SetCursorPosition(12, 4); Console.WriteLine("Ходит Игрок 1"); Console.ResetColor();
                }
                Console.WriteLine("\n");
                Board();
                mark = int.Parse(Console.ReadLine());

                if (mark < 1 || mark > 9)
                {
                    Console.WriteLine("Извините, введенное вами число неверно. Число должно находиться в диапазоне от 1 до 9");
                    Console.WriteLine("\nПодождите 5 секунд. Доска снова загрузится...");
                    Thread.Sleep(5000);
                }
                else
                {
                    // проверяет, сделал ли игрок ход
                    if (cell[mark] != 'X' && cell[mark] != 'O')
                    {
                        if (player % 2 == 0)
                        {
                            cell[mark] = 'O';
                            player++;
                        }
                        else
                        {
                            cell[mark] = 'X';
                            player++;
                        }
                    }
                    else
                    //Если игрок попытается отметить уже занятую ячейку,
                    //то выведется сообщение 
                    {
                        Console.WriteLine("Извините, ячейка {0} уже отмечена {1}", mark, cell[mark]);
                        Console.WriteLine("\nПодождите 5 секунд. Доска снова загрузится...");
                        Thread.Sleep(5000);
                    }
                    flag = CheckingWinner();
                }
            }
            while (flag != 1 && flag != -1);

            Console.Clear();
            Board();
            if (flag == 1)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.SetCursorPosition(11, 16);
                Console.WriteLine("Игрок {0} выиграл!", (player % 2) + 1);
                Console.ResetColor();
                Console.ReadKey();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.SetCursorPosition(16, 16);
                Console.WriteLine("Ничья!");
                Console.ResetColor();
                Console.ReadKey();
            }
        }
        // Создание игровой доски
        private static void Board()
        {
            Console.SetCursorPosition(10, 6); Console.WriteLine("     |     |      ");
            Console.SetCursorPosition(10, 7); Console.WriteLine("  {0}  |  {1}  |  {2}", cell[1], cell[2], cell[3]);
            Console.SetCursorPosition(10, 8); Console.WriteLine("_____|_____|_____ ");
            Console.SetCursorPosition(10, 9); Console.WriteLine("     |     |      ");
            Console.SetCursorPosition(10, 10); Console.WriteLine("  {0}  |  {1}  |  {2}", cell[4], cell[5], cell[6]);
            Console.SetCursorPosition(10, 11); Console.WriteLine("_____|_____|_____ ");
            Console.SetCursorPosition(10, 12); Console.WriteLine("     |     |      ");
            Console.SetCursorPosition(10, 13); Console.WriteLine("  {0}  |  {1}  |  {2}", cell[7], cell[8], cell[9]);
            Console.SetCursorPosition(10, 14); Console.WriteLine("     |     |      ");
        }
        // Проверка на победителя (условия или комбинации выигрышей)
        private static int CheckingWinner()
        {
            //Горизонтальные комбинации выигрыша
            if (cell[1] == cell[2] && cell[2] == cell[3])
            {
                return 1;
            }
            else if (cell[4] == cell[5] && cell[5] == cell[6])
            {
                return 1;
            }
            else if (cell[6] == cell[7] && cell[7] == cell[8])
            {
                return 1;
            }

            //Вертикальные комбинации выигрыша
            else if (cell[1] == cell[4] && cell[4] == cell[7])
            {
                return 1;
            }
            else if (cell[2] == cell[5] && cell[5] == cell[8])
            {
                return 1;
            }
            else if (cell[3] == cell[6] && cell[6] == cell[9])
            {
                return 1;
            }

            //Диагональные комбинации выигрыша
            else if (cell[1] == cell[5] && cell[5] == cell[9])
            {
                return 1;
            }
            else if (cell[3] == cell[5] && cell[5] == cell[7])
            {
                return 1;
            }
            //Проверка на ничью 
            else if (cell[1] != '1' && cell[2] != '2' && cell[3] != '3' && cell[4] != '4' && cell[5] != '5' && cell[6] != '6' && cell[7] != '7' && cell[8] != '8' && cell[9] != '9')
            {
                return -1;
            }
            //Игра продолжается
            else
            {
                return 0;
            }
        }
    }
}