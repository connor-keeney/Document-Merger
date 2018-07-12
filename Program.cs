using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            string mrgAgnResponse = "";
            bool mergeAgain = true;
            bool filecheck = false;
            string filename = "";
            string filename2 = "";

            string w = Path.GetFileNameWithoutExtension(filename);
            string y = Path.GetFileNameWithoutExtension(filename2);
            string comboFile = w + y + ".txt";

            while (mergeAgain == true)
            {
                Console.WriteLine("Document Merger");
                filecheck = false;

                while (filecheck == false) {
                    filename = Console.ReadLine();
                    filecheck = File.Exists(filename);
                }
                filecheck = false;
                while (filecheck == false)
                {
                    filename2 = Console.ReadLine();
                    filecheck = File.Exists(filename2);
                }

                StreamReader sr1 = new StreamReader(filename);
                StreamReader sr2 = new StreamReader(filename2);
                StreamWriter sw1 = new StreamWriter(comboFile);

                try
                {
                    string line1 = sr1.ReadLine();
                    while (line1 != null)
                    {
                        Console.WriteLine(line1);
                        sw1.WriteLine(line1);
                        line1 = sr1.ReadLine();
                    }
                    line1 = null;
                    string line2 = sr2.ReadLine();
                    while (line2 != null)
                    {
                        Console.WriteLine(line2);
                        sw1.WriteLine(line2);
                        line2 = sr2.ReadLine();
                    }
                    line2 = null;

                }
                catch (Exception e)
                {

                    Console.WriteLine(e.Message);
                }


                finally
                {
                    sw1.Close();
                    sr1.Close();
                    sr2.Close();

                    Console.WriteLine("Would you like to merge two more documents? Enter yes if you would.");
                   mrgAgnResponse = Console.ReadLine();
                    if (mrgAgnResponse == "yes")
                    {
                        mergeAgain = true;
                    }
                    else
                    {
                        mergeAgain = false;
                    }
                }
            }
        }
    }
}
