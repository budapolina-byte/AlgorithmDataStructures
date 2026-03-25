//// Задание 1. Задача: Напишите функцию, которая проверяет,
//// можно ли из букв одной строки составить другую
//// public bool CanConstruct(string ransomNote,string magagine){
////Подсказка: Отсортируйте обе строки и используйте два указателя для сравнения.



//using System;

//namespace TwoPointer
//{
//    class Program
//    {
//        static void Main(string[] args)
//        {
//            var solution = new Program();

//            bool result = solution.CanConstruct("йоу", "вассап");
//            bool result2 = solution.CanConstruct("hello", "helloworld");
//            Console.WriteLine(result);
//            Console.WriteLine(result2);

//        }

//        public bool CanConstruct(string ransomNote, string magazine)
//        {
//            if (ransomNote.Length > magazine.Length)
//                return false;

//            // Преобразуем строки в массивы символов и сортируем их
//            char[] ransomChars = ransomNote.ToCharArray();
//            char[] magazineChars = magazine.ToCharArray();
//            Array.Sort(ransomChars);
//            Array.Sort(magazineChars);

//            int i = 0; // Указатель для ransomNote
//            int j = 0; // Указатель для magazine

//            while (i < ransomChars.Length && j < magazineChars.Length)
//            {
//                // Если  буква в журнале меньше, чем в записке,
//                // двигаем указатель журнала дальше
//                if (magazineChars[j] < ransomChars[i])
//                {
//                    j++;
//                }
//                // Если буквы совпали, двигаем оба указателя
//                else if (magazineChars[j] == ransomChars[i])
//                {
//                    i++;
//                    j++;
//                }
//                // Если буква в журнале больше, чем нужная, значит,
//                // нужной буквы в журнале нет
//                else
//                {
//                    return false;
//                }
//            }

//            return i == ransomChars.Length;
//        }
//    }
//}


// Задание 2. Задача: Напишите функцию, которая находит "счастливое число"
// в массиве (число, которое встречается столько раз, каково его значение).
//Подсказка: Отсортируйте массив и используйте slow для подсчета, fast для прохода.

//using System;

//namespace TwoPointer
//{
//    class Program
//    {
//        static void Main(string[] args)
//        {
//            var solution = new Program();

//            //  Счастливое число 2
//            int[] arr1 = { 2, 2, 3, 4 };
//            int lucky1 = solution.FindLucky(arr1);
//            foreach (int num in arr1)
//            {
//                Console.Write(num + ", ");
//            }
//            Console.WriteLine($"Счастливое число: {lucky1}");
//        }

//        public int FindLucky(int[] arr)
//        {
//            if (arr.Length == 0) return -1;

//            Array.Sort(arr);

//            int maxLucky = -1;
//            int slow = 0; // Медленный указатель - начало группы одинаковых чисел

//            // Быстрый указатель проходит по массиву
//            for (int fast = 0; fast < arr.Length; fast++)
//            {
//                // Если достигли конца группы одинаковых чисел
//                if (fast == arr.Length - 1 || arr[fast] != arr[fast + 1])
//                {
//                    // Длина группы = fast - slow + 1
//                    int count = fast - slow + 1;

//                    // Проверяем условие "счастливого числа"
//                    if (arr[slow] == count)
//                    {
//                        // Сохраняем максимальное счастливое число
//                        if (arr[slow] > maxLucky)
//                            maxLucky = arr[slow];
//                    }

//                    // Перемещаем медленный указатель на начало следующей группы
//                    slow = fast + 1;
//                }
//            }

//            return maxLucky;
//        }
//    }
//}


// Задание 3. Задача: Напишите функцию, которая находит максимальное количество единиц в массиве,
// если можно заменить не более k нулей на единицы.
//Подсказка: Используйте окно с счетчиком нулей.

using System;

namespace TwoPointer
{
    class Program
    {
        static void Main(string[] args)
        {
            var solution = new Program();

            //  заменить 2 нуля
            int[] nums1 = { 1, 1, 0, 0, 1, 1, 1, 0, 1, 1 };
            int k1 = 2;
            int maxOnes1 = solution.LongestOnes(nums1, k1);
            foreach (int num in nums1)
            {
                Console.Write(num + ". ");
            }
            Console.WriteLine($"Можно заменить нулей: {k1}");
            Console.WriteLine($"Максимальное количество единиц: {maxOnes1}");
        }

        public int LongestOnes(int[] nums, int k)
        {
            int left = 0;          // Левый указатель окна
            int zeroCount = 0;     // Счетчик нулей в текущем окне
            int maxLength = 0;     // Максимальная длина окна

            // Правый указатель движется по массиву, расширяя окно
            for (int right = 0; right < nums.Length; right++)
            {
                //  встретили ноль, увеличиваем счетчик нулей
                if (nums[right] == 0)
                {
                    zeroCount++;
                }

                // Если нулей в окне стало больше,
                // сдвигаем левый указатель, чтобы уменьшить окно
                while (zeroCount > k)
                {
                    if (nums[left] == 0)
                    {
                        zeroCount--;
                    }
                    left++;
                }

                // Вычисляем текущую длину окна и обновляем максимальную
                int currentLength = right - left + 1;
                maxLength = Math.Max(maxLength, currentLength);
            }

            return maxLength;
        }
    }
}