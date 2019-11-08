using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BL_Project3;

namespace UI_Project3
{
   public static class Program
    {
        static void Main(string[] args)
        {

          
            void main2()
            {




                Console.WriteLine("MENU");
                Console.WriteLine("1.Enter file name to search.");
                Console.WriteLine("2.Enter file name to search + parent directory to search in.");
                Console.WriteLine("3.Exit");
                Console.WriteLine("--------------");
                Console.WriteLine("enter your choise here:");
                string option = Console.ReadLine();
                    while (option != "1" && option != "2" && option != "3")
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Error! Please chek 1 or 2 or 3");
                        Console.ResetColor();
                        Console.WriteLine("--------------");
                        option = Console.ReadLine();


                    }

                switch (option)
                {

                    case "1":
                        enter(option);
                        break;

                    case "2":
                        enter(option);
                        break;

                    case "3":
                        break;

                    default:
                        main2();
                        break;



                }



            }
            void enter(string option)
            {



                string file = string.Empty;
                string dir = "d:\\";
                DateTime startTime = DateTime.Now;


                Console.WriteLine("Please enter file name:");
                file = Console.ReadLine();
                while (file == string.Empty)
                {
                    Console.WriteLine("Please enter file name:");
                    file = Console.ReadLine();
                }

                if (option == "2")
                {
                    Console.WriteLine("Please enter directory name:");
                    dir += Console.ReadLine();
                    while (dir == "d:\\")
                    {
                        Console.WriteLine("Please enter directory name:");
                        dir += Console.ReadLine();
                    }

                }
                List<string> newFiles = Class1.DirSearch(dir, file);


                if (newFiles.Count == 0)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("file or directory is not found");
                    Console.ResetColor();
                    Class1.insertToDataBase(file, dir, "File Not Found",startTime);
                }
                foreach (var item in newFiles)
                {
                    Class1.insertToDataBase(file, dir,item, startTime);

                }

                Console.WriteLine("--------------end search--------------");

                Console.WriteLine();
                main2();

                Console.ReadLine();

            }
            main2();
        }
    }
        
           
}

