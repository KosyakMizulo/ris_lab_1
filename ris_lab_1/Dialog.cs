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
            Console.WriteLine("4 - Поиск");
            Console.WriteLine("5 - Сортировать");
            Console.WriteLine("6 - Выход");
            Console.WriteLine("Ввод:");
            string choose = Console.ReadLine();

            switch (choose)
            {
                case "1": View(); break;
                case "2": Add(); break;
                case "3": Delete(); break;
                case "4": Search(); break;
                case "5": Sort(); break;
                case "6": Close(); break;
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
        public string ChoosingParameterForSearch()
        {
            Console.WriteLine("Выберите параметр поиска записи:");
            Console.WriteLine("1 - по модели автомобиля");
            Console.WriteLine("2 - по году выпуска автомобиля");
            Console.WriteLine("3 - по объему двигателя автомобиля");
            Console.WriteLine("4 - конкретный автомобиль");
            Console.WriteLine("5 - отмена");
            string choose = Console.ReadLine();
            Console.Clear();
            return choose;
        }
        public void SearchByModel()
        {
            Console.WriteLine("Введите модель авто:");
            string model = Console.ReadLine();
            int countOfAuto = 0;
            for(int i = 0; i < NamesArray.Count; i++)
            {
                if (NamesArray[i].Equals(model))
                {
                    countOfAuto++;
                    Console.WriteLine("{0}, {1}, {2}", NamesArray[i], YearsArray[i], ValuesArray[i]);
                }   
            }
            if (countOfAuto == 0)
            {
                Console.WriteLine("Такие авто не найдены!");
            }
            Console.ReadLine();
        }
        public void SearchByYear()
        {
            Console.WriteLine("Введите год выпуска:");
            string year = Console.ReadLine();
            int countOfAuto = 0;
            for (int i = 0; i < NamesArray.Count; i++)
            {
                if (YearsArray[i].Equals(year))
                {
                    countOfAuto++;
                    Console.WriteLine("{0}, {1}, {2}", NamesArray[i], YearsArray[i], ValuesArray[i]);
                }
            }
            if (countOfAuto == 0)
            {
                Console.WriteLine("Такие авто не найдены!");
            }
            Console.ReadLine();
        }
        public void SearchByCC()
        {
            Console.WriteLine("Введите объем двигателя:");
            string cc = Console.ReadLine();
            int countOfAuto = 0;
            for (int i = 0; i < NamesArray.Count; i++)
            {
                if (YearsArray[i].Equals(cc))
                {
                    countOfAuto++;
                    Console.WriteLine("{0}, {1}, {2}", NamesArray[i], YearsArray[i], ValuesArray[i]);
                }
            }
            if (countOfAuto == 0)
            {
                Console.WriteLine("Такие авто не найдены!");
            }
            Console.ReadLine();
        }
        public void SearchByConcretAuto()
        {
            Console.WriteLine("Введите параметры автомобиля!");
            Console.WriteLine("Модель:");
            string model = Console.ReadLine();
            Console.WriteLine("Год выпуска:");
            string year = Console.ReadLine();
            Console.WriteLine("Объем двигателя:");
            string cc = Console.ReadLine();
            int countOfAuto = 0;
            for(int i = 0; i < NamesArray.Count; i++)
            {
                if (NamesArray[i].Equals(model) && YearsArray[i].Equals(year) && ValuesArray[i].Equals(cc))
                {
                    countOfAuto++;
                    Console.WriteLine("{0}, {1}, {2}", NamesArray[i], YearsArray[i], ValuesArray[i]);
                }
            }
            if (countOfAuto == 0)
            {
                Console.WriteLine("Такие авто не найдены!");
                Console.ReadLine();
                Console.Clear();
                ChoosingAction();
            }
            Console.ReadLine();
        }
        public string ChoosingParameterForSort()
        {
            Console.WriteLine("Выберите параметр сортировки:");
            Console.WriteLine("1 - по модели (от А до Я)");
            Console.WriteLine("2 - по году выпуска");
            Console.WriteLine("3 - по объему двигателя");
            Console.WriteLine("4 - отмена");
            string choose = Console.ReadLine();
            int intChoose = int.Parse(choose);
            if (intChoose < 1 && intChoose > 4)
            {
                Console.WriteLine("Вы ввели некорректное значение!");
                DeleteInformation();
                Sort();
            }
            return choose;
        }
        public void SortByModel()
        {
            ArrayList Record = new ArrayList();
            for(int i = 0; i < NamesArray.Count; i++)
            {
                Record.Add(NamesArray[i]+", "+YearsArray[i]+", "+ValuesArray[i]);
            }
            Record.Sort();
            for(int i = 0; i < Record.Count; i++)
            {
                Console.WriteLine(Record[i]);
            }
            Console.ReadLine();
            Console.Clear();
            ChoosingAction();
        }
        public void SortByYear()
        {
            ArrayList Records = new ArrayList();
            for(int i = 0; i < NamesArray.Count; i++)
            {
                Records.Add(YearsArray[i] + ";" + NamesArray[i] + ";" + ValuesArray[i] + ";");
            }
            Records.Sort();
            string name = "";
            string year = "";
            string cc = "";
            int point1 = 0;
            int point2 = 0;
            int point3 = 0;
            for(int i = 0; i <Records.Count; i++)
            {
                point1 = Records[i].ToString().IndexOf(";");
                year = Records[i].ToString().Substring(0, point1);
                point2 = Records[i].ToString().IndexOf(";", point1 + 1);
                name = Records[i].ToString().Substring(point1 + 1, point2 - point1 - 1);
                point3 = Records[i].ToString().IndexOf(";", point2 + 1);
                cc = Records[i].ToString().Substring(point2 + 1, point3 - point2 - 1);
                Console.WriteLine("{0}, {1}, {2}", name, year, cc);
            }
            Console.ReadLine();
            DeleteInformation();
            Console.Clear();
            ChoosingAction();
        }
        public void SortByCC()
        {
            ArrayList Records = new ArrayList();
            for (int i = 0; i < NamesArray.Count; i++)
            {
                Records.Add(ValuesArray[i] + ";" + NamesArray[i] + ";" + YearsArray[i] + ";");
            }
            string name = "";
            string year = "";
            string cc = "";
            int point1 = 0;
            int point2 = 0;
            int point3 = 0;
            string[,] matrix = new string[YearsArray.Count, 3];
            for (int i = 0; i < Records.Count; i++)
            {
                point1 = Records[i].ToString().IndexOf(";");
                cc = Records[i].ToString().Substring(0, point1);
                point2 = Records[i].ToString().IndexOf(";", point1 + 1);
                name = Records[i].ToString().Substring(point1 + 1, point2 - point1 - 1);
                point3 = Records[i].ToString().IndexOf(";", point2 + 1);
                year = Records[i].ToString().Substring(point2 + 1, point3 - point2 - 1);
                matrix[i, 0] = cc;
                matrix[i, 1] = name;
                matrix[i, 2] = year;
            }
            string[] temp = new string[3];
            for(int i = 0; i < YearsArray.Count - 1; i++)
            {
                for(int j = i + 1; j < YearsArray.Count; j++)
                {
                    if(int.Parse(matrix[i, 0]) > int.Parse(matrix[j, 0]))
                    {
                        temp[0] = matrix[i, 0];
                        temp[1] = matrix[i, 1];
                        temp[2] = matrix[i, 2];
                        matrix[i, 0] = matrix[j, 0];
                        matrix[i, 1] = matrix[j, 1];
                        matrix[i, 2] = matrix[j, 2];
                        matrix[j, 0] = temp[0];
                        matrix[j, 1] = temp[1];
                        matrix[j, 2] = temp[2];
                    }
                }
            }

            for(int i = 0; i < YearsArray.Count; i++)
            {
                Console.WriteLine("{0}, {1}, {2}", matrix[i, 1], matrix[i, 2], matrix[i, 0]);
            }


            Console.ReadLine();
            DeleteInformation();
            Console.Clear();
            ChoosingAction();
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
        public void Search()
        {
            ReadFile();
            Console.Clear();
            string choose = ChoosingParameterForSearch();
            switch (choose)
            {
                case "1": SearchByModel();break;
                case "2": SearchByYear();break;
                case "3": SearchByCC();break;
                case "4": SearchByConcretAuto();break;
                case "5": Console.Clear();
                    ChoosingAction();break;
                default: Console.WriteLine("Вы ввели некорректное значение!");
                    Console.ReadLine();
                    DeleteInformation();
                    Console.Clear();
                    ChoosingAction();break;
            }
            DeleteInformation();
            Console.Clear();
            ChoosingAction();
        }
        public void Sort()
        {
            Console.Clear();
            ReadFile();
            string choose = ChoosingParameterForSort();
            Console.Clear();
            switch (choose)
            {
                case "1": SortByModel();break;
                case "2": SortByYear();break;
                case "3": SortByCC();break;
                case "4": DeleteInformation();
                    Console.Clear();
                    ChoosingAction();break;
            }
        }
        public void Close()
        {
            Environment.Exit(0);
        }
    }
}