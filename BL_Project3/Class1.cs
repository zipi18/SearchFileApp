using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using DAL_Project3;

namespace BL_Project3
{
    public static class Class1
    {
        public static SearchFilesDBEntities1 ent = new SearchFilesDBEntities1();

        //יצירת רשימה שלתוכה יכנסו תוצאות החיפוש
        public static List<string> fileList = new List<string>();

        //פונקציה המקבלת מסלול לחיפוש + שם קובץ ומדפיסה את תוצאות החיפוש
        public static List<string> DirSearch(string c, string word)

        {

            try
            {


                try
                {
                    // חיפוש תיקיות משנה בכל תיקיה
                    foreach (string d in Directory.GetDirectories(c))
                    {
                        try
                        {
                            //ריצה על כל הקבצים בתוך התיקייה הנתונה
                            foreach (string f in Directory.GetFiles(c, "*", SearchOption.AllDirectories))
                            {
                                // אם בשם הקובץ הנתון יש את מחרוזת החיפוש הנתונה- אז תוסיף אותו לרשימה + תדפיס אותו
                                if (f.IndexOf(word, StringComparison.CurrentCultureIgnoreCase) > -1)
                                {
                                    fileList.Add(f);


                                    Console.WriteLine(f);




                                }


                            }
                        }
                        catch (Exception)

                        {

                        }
                        DirSearch(d, word);
                    }

                }

                catch (Exception)
                {
                }

            }

            catch (Exception)
            {
                Console.WriteLine("ERROR");

            }
            return fileList;
        }

        public static void insertToDataBase(string fileName, string dirName, string result, DateTime startTime)
        {
            
            ent.SearchFileTBL.Add(new SearchFileTBL
            {
                
                FILE_NAME = fileName,
                DIR_NAME= dirName,
                DATE = startTime,
                RESULT = result
            });
            ent.SaveChanges();
            
        }



    }
}
