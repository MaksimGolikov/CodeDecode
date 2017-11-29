using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace PZ_2.WorkWhithFile
{
     class ChangeFile
    {

        public ChangeFile()
        {

        }

        public IDictionary<string, string> ReadKey(string nameFiles)
        {
             IDictionary<string,string> rd=new SortedDictionary<string,string>();
             string[] lines = File.ReadAllLines(nameFiles + ".txt",Encoding.Default);
             bool key = true;
             string data="";
             string dates="";



             foreach (string line in lines)
             {
                 foreach (char c in line)
                 {
                     if (c != '-' && key)
                     {
                          data = Convert.ToString(c);
                          key = false;
                     }
                     else if (c != '-' && !key)
                     {
                         dates = Convert.ToString(c);
                         key = true;
                         rd.Add(data, dates);
                     }
                 }
                 
             }   

             return rd;
        }
     
        public List<string> ReadFile(string nameFiles, bool iscode, bool codeData)
        {
            List<string> DataLists = new List<string>();

            string[] lines = File.ReadAllLines(nameFiles+ ".txt",Encoding.Default);
          
            if(iscode)
            {
                foreach (string line in lines)
                {
                    foreach (char c in line)
                    {
                        if(c!=' ')
                        {
                            string data = Convert.ToString(c);
                            DataLists.Add(data);
                        }
                    }
                }
            }

            else if (!iscode && codeData)
            {
                foreach (string line in lines)
                {
                    foreach (char c in line)
                    {
                        if (c != ' ' && c!=',')
                        {
                            string data = Convert.ToString(c);
                            DataLists.Add(data);
                        }
                    }
                }
            }

            else if (!iscode && !codeData)
            {
                foreach (string line in lines)
                {
                    foreach (char c in line)
                    {
                        string data = Convert.ToString(c);
                        DataLists.Add(data);                       
                    }
                }
            }


            return DataLists;
        }
     

        public void Write(List<string> dataList, IDictionary<string, string> usingCode, string namefolder)
        {
            StreamWriter file;
            bool exit = false;

                do
                {
                    CreateFolder(namefolder);


                    file = new StreamWriter("Resalt//" + namefolder + "//CodeData.txt");

                    for (int i = 0; i < dataList.Count; i++)
                    {
                        string wr = dataList[i];
                        file.Write(wr);
                    }
                    file.Close();

                    file = new StreamWriter("Resalt//" + namefolder + "//Key.txt");

                    foreach (var item in usingCode)
                    {
                        string wr = item.Key + "-" + item.Value;
                        file.WriteLine(wr);
                    }
                    file.Close();
                    exit = true;
                    

                } while (!exit);
             
        }
        public void Write(List<string> dataList, string namefolder)
        {
               StreamWriter file;               
               file = new StreamWriter("Resalt//" + namefolder + "//DeCodedData.txt");

                for (int i = 0; i < dataList.Count; i++)
                {
                    string wr = dataList[i];
                    file.Write(wr);
                }
                file.Close();
            
        }

        public void CreateFolder(string namefolder)
        {
                Directory.CreateDirectory("Resalt//" + namefolder);
        }

        
      }
}
