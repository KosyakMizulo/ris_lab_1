using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ris_lab_1
{
    class Dialog
    {
        private ArrayList NamesArray = new ArrayList();
        private ArrayList YearsArray = new ArrayList();
        private ArrayList ValuesArray = new ArrayList();


        public void ChoosingAction()
        {
            Console.WriteLine("Выберите действие!");
            Console.WriteLine("1 - Просмотреть список машин");
            Console.WriteLine("2 - Добавить новую машину");
            Console.WriteLine("3 - Удалить машину из списка");
            Console.WriteLine("4 - Сортировать");
            Console.WriteLine("5 - Фильтровать");
            Console.WriteLine("6 - Выход");
            Console.WriteLine("Ввод:");
            int choose = int.Parse(Console.ReadLine());

            switch (choose)
            {
                case 1: View(); break;
                case 2: Add(); break;
                case 3: Delete(); break;
                //case 4: Sort(); break;
                //case 5: Filter(); break;
                //case 6: Close(); break;
                default:
                    Console.Clear();
                    Console.WriteLine("Выберите значение от 1 до 6!");
                    ChoosingAction();
                    break;

            }
        }

        public void ReadFile()
        {
            string line = "";
            StreamReader file = new StreamReader(@"C:\Users\Костя\Documents\Visual Studio 2017\Projects\ris_lab_1\ris_lab_1\CarShowroom.txt");
            int point1 = 0;
            int point2 = 0;
            int point3 = 0;
            while ((line = file.ReadLine()) != null)
            {
                point1 = line.IndexOf(';');
                NamesArray.Add(line.Substring(0, point1));
                point2 = line.IndexOf(';', point1 + 1);
                YearsArray.Add(line.Substring(point1 + 1, point2 - point1 - 1));
                point3 = line.IndexOf(';', point2 + 1);
                ValuesArray.Add(line.Substring(point2 + 1, point3 - point2 - 1));
            }
            file.Close();
        }
        public void DeleteInformation()
        {
            NamesArray.Clear();
            YearsArray.Clear();
            ValuesArray.Clear();
        }
        public void View()
        {
            Console.Clear();
            ReadFile();
            for (int i = 0; i < NamesArray.Count; i++)
            {
                Console.WriteLine(NamesArray[i] + ", " + YearsArray[i] + "г., " + ValuesArray[i] + " кубов.");
            }
            Console.ReadLine();
            Console.Clear();
            DeleteInformation();
            ChoosingAction();
        }
        public void Add()
        {
            Console.Clear();
            Console.WriteLine("Введите модель машины:");
            string name = Console.ReadLine();
            Console.WriteLine("Введите год выпуска:");
            string year = Console.ReadLine();
            Console.WriteLine("Введите объем двигателя:");
            string cc = Console.ReadLine();
            string line = name + ";" + year + ";" + cc + ";";
            using (StreamWriter sw = new StreamWriter(@"C:\Users\Костя\Documents\Visual Studio 2017\Projects\ris_lab_1\ris_lab_1\CarShowroom.txt", true, System.Text.Encoding.Default))
            {
                sw.Write("\n" + line);
            }
            Console.WriteLine("Добавлена новая машина: \n{0}, {1}, {2}", name, year, cc);
            Console.ReadLine();
            Console.Clear();
            ChoosingAction();
        }
        public void Delete()
        {
            ReadFile();
            Console.Clear();
            Console.WriteLine("Какую запись удалить?");
            for (int i = 0; i < NamesArray.Count; i++)
            {
                Console.WriteLine(i + 1 + " - {0}, {1}, {2}", NamesArray[i], YearsArray[i], ValuesArray[i]);
            }
            int choose = int.Parse(Console.ReadLine()) - 1;
            Console.Clear();
            Console.WriteLine("Вы точно хотите удалить запись?\n{0}, {1}, {2}\n1 - Да\n2 - Нет", NamesArray[choose], YearsArray[choose], ValuesArray[choose]);
            int sure = int.Parse(Console.ReadLine());
            if (sure == 1)
            {
                Console.WriteLine("Запись удалена!");

                NamesArray.RemoveAt(choose);
                YearsArray.RemoveAt(choose);
                ValuesArray.RemoveAt(choose);

                StreamWriter stwr = new StreamWriter(@"C:\Users\Костя\Documents\Visual Studio 2017\Projects\ris_lab_1\ris_lab_1\CarShowroom.txt", false);
                for (int i = 0; i < NamesArray.Count; i++)
                {
                    stwr.WriteLine(NamesArray[i] + ";" + YearsArray[i] + ";" + ValuesArray[i] + ";");
                }
                stwr.Close();
            }
            else if (sure > 2)
            {
                Console.WriteLine("Вы ввели некорректное значение, запись не будет удалена!");
            }
            Console.Clear();
            DeleteInformation();
            ChoosingAction();
        }
    }
}