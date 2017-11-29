using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PZ_2.WorkWhithFile
{
    class WorkWithData
    {
        IDictionary<string,string> usingCode;
        ChangeFile changeFile;
        List<string> code;
        List<string> dataToCoding;
        string namefolderdata;
        string namefoldercode;
        bool isnewcod;
        List<string> toWrite;


        public WorkWithData(List<string> dataToCoding, List<string> code, string namefolder, bool isnewcoding,string namefoldercode)
        {
            this.code=code;
            this.dataToCoding=dataToCoding;
            changeFile=new ChangeFile();
            usingCode = new SortedDictionary<string, string>();
            this.namefolderdata = namefolder;
            this.isnewcod = isnewcoding;
            this.namefoldercode = namefoldercode;
        }
        public WorkWithData(string namefolderdata,string namefoldercode)
        {
            this.namefolderdata = namefolderdata;
            this.namefoldercode = namefoldercode;
            changeFile = new ChangeFile();
        }
       

        private string CodingNewSimvol(string simvolToCoding, List<string> massCode)
        {
           
            Random rand = new Random();           
            bool next=false;
            string cod;
            int i = 0;
            int j = 0;


            do
            {
                i = 0;
                j = 0;
                 cod = massCode[rand.Next(0,massCode.Count)];

                 foreach (var item in usingCode)
                 {
                     if (item.Value!= cod)
                     {
                         i++;
                     }
                 }

                 foreach (var item in usingCode)
                 {
                     if (item.Value != cod)
                     {
                         j++;
                     }
                 }


                if(usingCode.Count==0 || i==usingCode.Count && j==usingCode.Count)
                    next = true;
                                     


            }while(!next);

            usingCode.Add(simvolToCoding,cod);
            return cod;
        }
        private string CodingExistSimvol(string simvolToCoding)
        {
            string cod="";

            foreach(var item in usingCode)
            {
                if (item.Key == simvolToCoding)
                {
                    cod = item.Value;
                    break;
                }
            }


            return cod;
        }


        public void CodingData()
        {
           
            if(!isnewcod)
                usingCode = changeFile.ReadKey("Resalt//" + namefoldercode + "//Key");



                  toWrite = new List<string>();

                    foreach(var itemSimvol in dataToCoding)
                     {
                        bool isExist = false;
                        foreach(var itemCode in usingCode)
                         {
                             if (itemSimvol == itemCode.Key)
                               {
                                 isExist = true;
                                 break;
                                }
                              else
                            isExist = false;
                          }

                if(isExist)
                {
                    toWrite.Add(CodingExistSimvol(itemSimvol));
                }
                else
                {
                    toWrite.Add(CodingNewSimvol(itemSimvol,code));
                }

                Random rand = new Random();
                int between = rand.Next(0,10);

                if(between<5)
                {
                    toWrite.Add(" ");
                }
                else
                {
                    toWrite.Add(",");
                }
            }
                    try
                    {
                        changeFile.Write(toWrite, usingCode, namefolderdata);
                    }
            catch(Exception ex)
                    {
                        Console.WriteLine(ex);
                    }
            
        }

        public List<string> DecodingData()
        {
            List<string> decodedData = new List<string>();
            List<string> decoded = new List<string>();
            usingCode = new SortedDictionary<string, string>();


            decoded = changeFile.ReadFile("Resalt//" + namefolderdata + "//CodeData", false, true);
            usingCode = changeFile.ReadKey("Resalt//" + namefoldercode + "//Key"); 
           
            foreach(var item in decoded)
            {
                foreach (var itemCod in usingCode)
                {
                    if(item==itemCod.Value)
                    {
                        decodedData.Add(itemCod.Key);
                    }
                }
            }

            changeFile.Write(decodedData,namefolderdata);

            return decodedData;
        }
    }
}
