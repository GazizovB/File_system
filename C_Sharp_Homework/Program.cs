using System.IO;
using System.Text;
using static System.Console;

namespace Stream
{
    class Program
    {
        static void WriteFile(string filePath)
        {
            using (FileStream fs = new FileStream(filePath,
            FileMode.Create, FileAccess.Write,
            FileShare.None))
            {
                // получаем данные для записи в файл
                WriteLine("Enter the data to write to the file: ");
                string writeText = ReadLine();
                // преобразуем строку в массив байт
                byte[] writeBytes = Encoding.Default.
                GetBytes(writeText);
                // записываем данные в файл
                fs.Write(writeBytes, 0, writeBytes.Length);
                WriteLine("Information recorded!");
            }
        }
        static string ReadFile(string filePath)
        {
            using (FileStream fs = new FileStream(filePath,
            FileMode.Open, FileAccess.Read,
            FileShare.Read))
            {
                byte[] readBytes = new byte[(int)fs.Length];
                // считываем данные из файла
                fs.Read(readBytes, 0, readBytes.Length);
                // преобразуем байты в строку
                return Encoding.Default.
                GetString(readBytes);
            }
        }

        static int Add(int x, int y)
        {
            return x + y;
        }

        static void Main(string[] args)
        {

            int result = Add(1, 4);
            WriteLine(result);

            string filePath = "Add.txt";
            WriteFile(filePath);
            // выводим результат на консоль
            WriteLine($"\nData read from the file:{ ReadFile(filePath)}");

            ReadLine();
        }
    }
}