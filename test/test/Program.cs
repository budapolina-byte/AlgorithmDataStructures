namespace prog_2
{
    // Главный класс программы, реализующий игру "Угадай число".
    internal class Program
    {
        static void Main(string[] args) // main главный метод, создает генератор случайных чисел,
                                        // запускает игровой цикл и выводит итоговую статистику
                                        // args - Аргументы командной строки
        {
            // Инициализация переменных для статистики
            int min = 0;
            int max = 0;
            int count = 0;
            int countGame = 0;

            Random rnd = new Random(); // Создание генератора случайных чисел

            // Запуск основного игрового цикла
            RunGameLoop(rnd, ref min, ref max, ref count, ref countGame);

            // Вывод итоговой статистики
            DisplayStatistics(min, max, count, countGame);
        }

        // метод RunGameLoop - запускает игры повторно, пока пользователь отвечает 'Y'
        static void RunGameLoop(Random rnd, ref int min, ref int max, ref int count, ref int countGame)
        {
            char answer = 'Y';  // Флаг продолжения игры. Инициализируется значением 'Y',
                                // чтобы цикл выполнился хотя бы один раз. После каждой игры
                                // получает новое значение от пользователя.

            do  // do-while гарантирует, что игра запустится как минимум один раз,
                // После каждой игры проверяет, хочет ли пользователь сыграть снова.
            {
                // метод PlaySingleGame - проводит одну полную игру 
                // Генерирует число и организует процесс угадывания
                int counter = PlaySingleGame(rnd); // Запуск одной игры и получение количества попыток

                // метод UpdateStatistics - Обновление статистики
                UpdateStatistics(counter, ref min, ref max, ref count, ref countGame);

                Console.WriteLine("Do you want to play again?");
                answer = Convert.ToChar(Console.Read()); // Console.Read() считывает один символ
                                                         // Convert.ToChar() преобразует значение в тип char.
                Console.ReadLine(); // Очистка буфера ввода после Console.Read()
            } while (answer == 'Y');
        }

        // метод PlaySingleGame - проводит одну полную игру
        // Генерирует число и организует процесс угадывания
        // Возвращает количество попыток
        static int PlaySingleGame(Random rnd)
        {
            int counter = 0;
            int number = rnd.Next(1, 101); // Генерация числа от 1 до 100

            while (true)
            {
                counter++; // Увеличивает счетчик попыток на 1 при каждом новом вводе числа.

                // метод GetUserNumber - получение числа от пользователя
                int userNumber = GetUserNumber();

                // метод CheckGuess - сравнение чисел и проверка победы
                if (CheckGuess(userNumber, number))
                {
                    Console.WriteLine("You won");
                    return counter; // Возвращаем количество попыток при победе
                }
            }
        }

        // метод GetUserNumber - получение числа от пользователя
        // Запрашивает число, дает 3 попытки на верный ввод
        // Возвращает корректное число от 1 до 100
        static int GetUserNumber()
        {
            Console.WriteLine("Input number from [1;100]"); // Выводит ввод числа в консоль и
                                                            // указывает диапазон значений от 1 до 100.
            int userNumber = 0; // Объявляет переменную для хранения числа, введенного пользователем.

            for (int i = 0; i < 3; i++) // Цикл for для ограничения количества попыток некорректного ввода.
                                        // Предоставляет пользователю 3 попытки ввести корректное число
            {
                if (!int.TryParse(Console.ReadLine(), out userNumber) // Проверка верности введенного числа.
                        || userNumber > 100
                        || userNumber < 1)
                {
                    Console.WriteLine("Input number from [1;100]");
                }
                else
                {
                    return userNumber; // При успешном и корректном вводе сразу возвращаем число
                }

                if (i == 2) // является ли текущая попытка третьей
                {
                    Console.WriteLine("You are stupid");
                    Environment.Exit(0); // Завершаем программу
                }
            }
            return 0; // Эта строка никогда не выполнится, но нужна для компиляции
        }

        // метод CheckGuess - сравнение чисел и проверка победы
        // Сравнивает введенное число с загаданным
        // Возвращает true - если числа равны (победа), false - в противном случае
        static bool CheckGuess(int userNumber, int secretNumber)
        {
            if (userNumber > secretNumber) // Если число пользователя больше загаданного,
                                           // выводится подсказка.
            {
                Console.WriteLine("Your number is greater");
                return false;
            }
            else if (userNumber < secretNumber)
            {
                Console.WriteLine("Your number is less");
                return false;
            }
            else
            {
                return true; // Числа равны - победа
            }
        }

        // метод UpdateStatistics - Обновление статистики
        // Обновляет min, max, count, countGame после победы
        static void UpdateStatistics(int counter, ref int min, ref int max, ref int count, ref int countGame)
        {
            if (min == 0 || min > counter) min = counter; // min хранит наименьшее количество попыток за все игры
            max = max < counter ? counter : max; // Тернарный оператор как замена if-else:
                                                 // если max меньше counter, то max получает значение counter,
                                                 // иначе max без изменений.
                                                 // max хранит наибольшее количество попыток за все игры
            countGame++;
            count += counter; // К общему счетчику count добавляется количество попыток.
        }

        // метод DisplayStatistics - Вывод итоговой статистики
        // Вычисляет среднее арифметическое и выводит результаты
        static void DisplayStatistics(int min, int max, int count, int countGame)
        {
            // Формула расчета среднего арифметического: сумма попыток / количество игр
            Console.WriteLine($"min = {min} max={max} avg= {count * 1.0 / countGame}");
        }
    }
}