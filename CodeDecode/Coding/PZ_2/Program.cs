using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PZ_2
{
    class Program
    {
        

        static void Main(string[] args)
        {
            bool exit = false;
            WorkWhithFile.ChangeFile changeFile = new WorkWhithFile.ChangeFile();
            WorkWhithFile.WorkWithData wWD;
            string name="";        
            string fileforcoding = "";
            List<string> Tex;
            DirectoryInfo dinfo;
            FileInfo[] files;

            do
            {
                Console.Clear();
                string rl;
                Console.WriteLine(" iput W, R ");
                rl = Console.ReadLine();
               


                if (rl == "W")
                {
                    Console.Clear();
                    List<string> code = new List<string>();
                    List<string> text = new List<string>();

                    Console.WriteLine(" iput name of the folder where will be saved you file");
                    name = Console.ReadLine();

                    Console.WriteLine("do you wont to use new code? Y N");
                    string isnewcoding = Console.ReadLine();

                    switch(isnewcoding)
                    {
                        case"Y":

                            Tex = new List<string>();
                            Console.WriteLine("you have next file:");
                            dinfo = new DirectoryInfo("text");
                            files = dinfo.GetFiles();
                              foreach (FileInfo filenames in files)
                                 {
                                   Tex.Add(Convert.ToString(filenames));
                                 }
                              for (int i = 0; i < Tex.Count;i++ )
                              {
                                  Console.WriteLine(Tex[i]);
                              }


                              Console.WriteLine("enter name of the file for coding");
                              fileforcoding = Console.ReadLine();

                            
                             code = changeFile.ReadFile("Code//Code", true, false);
                             text = changeFile.ReadFile("text//"+fileforcoding, false, false);

                             wWD = new WorkWhithFile.WorkWithData(text,code,name,true,null);
                             
                             wWD.CodingData();

                             Console.WriteLine(" it`s done");  

                            break;

                        case"N":

                            Console.WriteLine("you have next folder:");
                              DirectoryInfo dir = new DirectoryInfo("Resalt");
                               foreach (var item in dir.GetDirectories())
                                  {
                                     Console.WriteLine(item.Name);
                                  }
                               Console.WriteLine("   ");   
                               Console.WriteLine("enter name of the folder whith nessesary coding");
                               string newcoding = Console.ReadLine();

                              code = changeFile.ReadFile("Resalt//" + newcoding + "//Key", true, false);
                              Console.WriteLine(" ");



                              Console.WriteLine("you have next file:");
                              Tex = new List<string>();
                             
                            dinfo = new DirectoryInfo("text");
                            files = dinfo.GetFiles();
                              foreach (FileInfo filenames in files)
                                 {
                                   Tex.Add(Convert.ToString(filenames));
                                 }
                              for (int i = 0; i < Tex.Count;i++ )
                              {
                                  Console.WriteLine(Tex[i]);
                              }

                              Console.WriteLine("   ");   
                              Console.WriteLine("enter name of the file for coding");
                              fileforcoding = Console.ReadLine();


                              text = changeFile.ReadFile("text//"+fileforcoding, false, false);

                              wWD = new WorkWhithFile.WorkWithData(text, code, name,false,newcoding);
                              wWD.CodingData();

                             Console.WriteLine(" it`s done");  

                            break;

                        default:
                            break;
                    }



                                     
                }

                else if (rl == "R")
                {
                    Console.Clear();

                    Console.WriteLine("you have next folder:");
                    DirectoryInfo dir = new DirectoryInfo("Resalt");
                    foreach (var item in dir.GetDirectories())
                    {
                        Console.WriteLine(item.Name);
                    }
                    Console.WriteLine("   ");
                    Console.WriteLine(" iput name of the folder whith nessesary file");
                    name = Console.ReadLine();
                    Console.WriteLine("   ");

                    Console.WriteLine("you have next folder:");
                    DirectoryInfo di = new DirectoryInfo("Resalt");
                    foreach (var item in di.GetDirectories())
                    {
                        Console.WriteLine(item.Name);
                    }

                    Console.WriteLine("   ");
                    Console.WriteLine("enter name of the folder whith nessesary coding");
                    string newcoding = Console.ReadLine();
                    Console.WriteLine("   ");                   

                    

                    wWD = new WorkWhithFile.WorkWithData(name,newcoding);
                    wWD.DecodingData();
                    Console.WriteLine(" it`s done");
                }

                string l;
                Console.WriteLine("exit e");
                l = Console.ReadLine();
                if (l == "e")
                    exit = true;

            }while(!exit);
           
        }
    }
}
