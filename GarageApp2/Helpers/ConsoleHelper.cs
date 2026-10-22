using GarageClassLibrary.Validators;

namespace GarageApp2.Helpers
{
    public static class ConsoleHelper
    {
        public static TEnum ReadEnum<TEnum>(string prompt) where TEnum : struct
        {
            var valueInput = string.Empty;
            TEnum value;

            do
            {
                Console.Write(prompt);
                valueInput = Console.ReadLine();
            }
            while (Enum.TryParse<TEnum>(valueInput, out value) == false);

            return value;
        }

        public static float ReadFloat(string prompt, Func<float, bool> func)
        {
            var valueInput = string.Empty;
            var value = 0.0f;

            do
            {
                Console.Write(prompt);
                valueInput = Console.ReadLine();
            }
            while (float.TryParse(valueInput, out value) == false || func(value));

            return value;
        }

        public static int ReadInt(string prompt, Func<float, bool> func)
        {
            var valueInput = string.Empty;
            var value = 0;

            do
            {
                Console.Write(prompt);
                valueInput = Console.ReadLine();
            }
            while (int.TryParse(valueInput, out value) == false || func(value));

            return value;
        }

        public static string ReadRegistrationNumber(string prompt)
        {
            var registrationNumber = string.Empty;

            do
            {
                Console.Write(prompt);
                registrationNumber = Console.ReadLine();
            }
            while (registrationNumber != null && RegistrationNumberValidator.Validate(registrationNumber.ToUpper()) == false);

            return registrationNumber!;
        }

        public static bool ReadYesNo(string prompt)
        {
            var answerInput = string.Empty;

            do
            {
                Console.Write(prompt);
                answerInput = Console.ReadLine();
            }
            while (answerInput != null
                && answerInput.Equals("y", StringComparison.CurrentCultureIgnoreCase) == false
                && answerInput.Equals("n", StringComparison.CurrentCultureIgnoreCase) == false);

            return answerInput!.Equals("y", StringComparison.CurrentCultureIgnoreCase);
        }

        public static void WriteErrorLine(string message)
        {
            Console.BackgroundColor = ConsoleColor.Red;
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write(message);
            Console.ResetColor();
            Console.WriteLine();
        }

        public static void WriteInfoLine(string message)
        {
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write(message);
            Console.ResetColor();
            Console.WriteLine();
        }

        public static void WriteSuccessLine(string message)
        {
            Console.BackgroundColor = ConsoleColor.Green;
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write(message);
            Console.ResetColor();
            Console.WriteLine();
        }
    }
}
