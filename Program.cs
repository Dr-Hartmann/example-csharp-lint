using System; // IDE0005
namespace MessyCode // IDE0130
{
    class Program
    {
        private readonly static string userName = "Alex"; // IDE1006
        private string userSurname = "Smith"; // IDE0044
        private readonly string userAge = "25"; // IDE0051

        static void Main(string[] args)
        {
            var helper = new Helper();
            helper.PrintMessage("Привет, мир!"); // Лишние пробелы
        }
    }
    class Helper
    {
        private string _message; // CS8618
        public void PrintMessage(string msg)
        {
            this._message = msg; // IDE0003
            if (msg != null) {
                Console.WriteLine(_message); // Фигурные скобки не на новой строке
            }
            else
            {
                Console.WriteLine("Пусто"); // Сбиты отступы (mix пробелов и табуляции)
            }
        }
    }
}
