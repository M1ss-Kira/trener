using System;

class FitnessSimulator
{
    static void Main()
    {
        // Данные пользователя
        double weight = 0;
        double height = 0;
        int age = 0;
        char gender = ' ';
        string bodyType = "";

        // Цели на день
        double calorieGoal = 0;
        double proteinGoal = 0;
        double waterGoal = 0;

        // Потреблено за день
        double caloriesConsumed = 0;
        double proteinsConsumed = 0;
        double waterConsumed = 0;

        // Тренировки
        string[] exercises = new string[5];
        int[] exerciseGoals = new int[5];
        int[] exercisesCompleted = new int[5];

        Console.WriteLine("Привет( это мой первый хейт я очень волнуюсь..");


        void StartNewDay()
        {
            Console.Clear();
            Console.WriteLine("===НЬЮ ДЕЙ ===");


            caloriesConsumed = 0;
            proteinsConsumed = 0;
            waterConsumed = 0;
            exercisesCompleted = new int[5];

            Console.Write("Введите ваш вес (кг): ");
            weight = double.Parse(Console.ReadLine());

            Console.Write("Введите ваш рост (см): ");
            height = double.Parse(Console.ReadLine());

            Console.Write("Введите ваш возраст: ");
            age = int.Parse(Console.ReadLine());

            Console.Write("Введите ваш пол (м/ж): ");
            gender = char.Parse(Console.ReadLine().ToLower());

            // Определение типа телосложения
            double bmi = weight / Math.Pow(height / 100, 2);
            if (bmi < 18.5)
            {
                bodyType = "Соломка";
                exercises = new string[] { "Приседания(газани)", "Отжимания(сильно газани)", "Подтягивания", "Планка (сек)", "" };
                exerciseGoals = new int[] { 50, 30, 15, 120, 0 };
            }
            else if (bmi < 25)
            {
                bodyType = "Нормик";
                exercises = new string[] { "Приседания(газани)", "Отжимания(сильно газани)", "Подтягивания", "Планка (сек)", "Берпи" };
                exerciseGoals = new int[] { 70, 50, 20, 180, 20 };
            }
            else
            {
                bodyType = "Толерашки обидятся";
                exercises = new string[] { "Приседания(газани)", "Отжимания(сильно газани)", "Планка (сек)", "Скакалка (прыжков)", "Бег (мин)" };
                exerciseGoals = new int[] { 100, 70, 240, 300, 20 };
            }

            if (gender == 'м')
                calorieGoal = (weight * 9.99) + (height * 6.25) - (age * 4.92) - 161;
            else
                calorieGoal = (weight * 9.99) + (height * 6.25) - (age * 4.92) + 5;

            proteinGoal = 90;
            waterGoal = weight * 0.03;

            Console.WriteLine("\nСейв. День пошел");
        }

        // Инициализация первого дня
        StartNewDay();

        // Главный цикл программы
        while (true)
        {
            Console.WriteLine("\n=== ГЛАВНОЕ МЕНЮ ===");
            Console.WriteLine($"Тип телосложения: {bodyType}");
            Console.WriteLine("1 - Показать рекомендации по питанию");
            Console.WriteLine("2 - Показать план тренировок");
            Console.WriteLine("3 - Отметить выполнение упражнения");
            Console.WriteLine("4 - Отметить прием пищи");
            Console.WriteLine("5 - Показать прогресс за день");
            Console.WriteLine("6 - Начать новый день");
            Console.WriteLine("7 - Выход");
            Console.Write("Выберите действие: ");

            int choice = int.Parse(Console.ReadLine());

            if (choice == 1)
            {
                Console.WriteLine("\nОбээд:");
                Console.WriteLine($"- Калории: {calorieGoal:F0} ккал/день (осталось: {calorieGoal - caloriesConsumed:F0})");
                Console.WriteLine($"- Белки: {proteinGoal:F0} г/день (осталось: {proteinGoal - proteinsConsumed:F0})");
                Console.WriteLine($"- Вода: {waterGoal:F1} л/день (осталось: {waterGoal - waterConsumed:F1})");
            }
            else if (choice == 2)
            {
                Console.WriteLine("\nтрени на сегодня:");
                for (int i = 0; i < exercises.Length; i++)
                {
                    if (!string.IsNullOrEmpty(exercises[i]))
                        Console.WriteLine($"{i + 1}. {exercises[i]} - {exerciseGoals[i]}");
                }
            }
            else if (choice == 3)
            {
                Console.WriteLine("\nСписок упражнений:");
                for (int i = 0; i < exercises.Length; i++)
                {
                    if (!string.IsNullOrEmpty(exercises[i]))
                        Console.WriteLine($"{i + 1}. {exercises[i]} - {exerciseGoals[i]}");
                }

                Console.Write("номер упражнения: ");
                int exNum = int.Parse(Console.ReadLine()) - 1;

                if (exNum >= 0 && exNum < exercises.Length && !string.IsNullOrEmpty(exercises[exNum]))
                {
                    Console.Write($"На сколько {exercises[exNum]} хватило? ");
                    exercisesCompleted[exNum] += int.Parse(Console.ReadLine());
                    Console.WriteLine("Сейв");
                }
                else
                {
                    Console.WriteLine("Нема");
                }
            }
            else if (choice == 4)
            {
                Console.WriteLine("\nОтметить прием пищи:");

                Console.Write("Калории (ккал): ");
                caloriesConsumed += double.Parse(Console.ReadLine());

                Console.Write("Белки (г): ");
                proteinsConsumed += double.Parse(Console.ReadLine());

                Console.Write("Вода (мл): ");
                waterConsumed += double.Parse(Console.ReadLine()) / 1000;

                Console.WriteLine("Сейв");
            }
            else if (choice == 5)
            {
                Console.WriteLine("\n=== ПРОГРЕСС ЗА ДЕНЬ ===");

                Console.WriteLine("\nТренировки:");
                Console.WriteLine("Упражнение       | Выполнено | Осталось");
                Console.WriteLine("----------------------------------------");

                for (int i = 0; i < exercises.Length; i++)
                {
                    if (!string.IsNullOrEmpty(exercises[i]))
                    {
                        int remaining = exerciseGoals[i] - exercisesCompleted[i];
                        Console.WriteLine($"{exercises[i],-16} | {exercisesCompleted[i],-9} | {remaining}");
                    }
                }

                Console.WriteLine("\nПитание:");
                Console.WriteLine($"- Калории: {caloriesConsumed:F0} | {calorieGoal:F0} ккал");
                Console.WriteLine($"- Белки: {proteinsConsumed:F0} | {proteinGoal:F0} г");
                Console.WriteLine($"- Вода: {waterConsumed:F1} | {waterGoal:F1} л");
            }
            else if (choice == 6)
            {
                StartNewDay();
            }
            else if (choice == 7)
            {
                break;
            }
            else
            {
                Console.WriteLine("Нема.");
            }
        }
    }
}
