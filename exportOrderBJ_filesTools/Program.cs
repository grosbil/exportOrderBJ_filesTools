using System;
using System.Collections.Generic;
using System.IO;

using System.Text;
namespace exportOrderBJ_filesTools
{
    class Program
    { 
        static void Main(string[] args)
        {

            try
            {
  
            string Path = args[0];
    
            string PathFileIn = Path + "BL.txt";
            String Delim_DebutFile = "#BEGIN#";
            String delim_Filename = "#FILENAME#";
            String delim_ligne1 = "#L1#";
            String delim_ligne2 = "#L2#";
            String delim_toDel = "#DEL#";
            String delim_EAN = "#EAN#";
            String fileName = "";
              

            string[] fichier = File.ReadAllLines(PathFileIn, Encoding.UTF8);      
            
            File.WriteAllLines(PathFileIn, fichier, Encoding.UTF8);

            string content = fichier[0];
            string contents = "";

                while (content.IndexOf(Delim_DebutFile) != -1)
                {

                    int indexBeginFile = content.IndexOf(Delim_DebutFile);
                    int indexFilename = content.IndexOf(delim_Filename);

                    fileName = content.Substring(indexBeginFile + 8, indexFilename - 9);
                    content = content.Substring(indexFilename + 13);

                    int indexLigne1 = content.IndexOf(delim_ligne1);
                    string L1 = content.Substring(0,indexLigne1);
                    contents += L1+"\n";
                    content = content.Substring(indexLigne1 + 5);

                    int indexLigne2 = content.IndexOf(delim_ligne2);
                    string L2 = content.Substring(0, indexLigne2);
                    contents += L2 + "\n";
                    content = content.Substring(indexLigne2 + 5);


                    while ((content.IndexOf(delim_EAN) != -1) && ((content.IndexOf(Delim_DebutFile)> content.IndexOf(delim_EAN)|| content.IndexOf(Delim_DebutFile)==-1)))
                    {
                        int IndexToDel = content.IndexOf(delim_toDel);
                        content = content.Substring(IndexToDel + 6);
                        int indexEAN = content.IndexOf(delim_EAN);
                        string EANQte = content.Substring(0,indexEAN);
                        contents += EANQte+ "\n";
                        content = content.Substring(indexEAN + 5); 
                    }
                    
                    string PathFileOut = Path + fileName + ".txt";
                   
                    File.WriteAllText(PathFileOut, contents.Replace("\r\n", ""));
                   
                    contents = "";

                }

            
               
                       
            }
            catch (Exception ex)
            {
                
                String pathLog = "C:\\Openflux\\tools\\logtoolsSplit_Bj_Files.txt";
                string[] contents = { "Problème le : "+ DateTime.UtcNow +" : "+ ex.Message };
                File.AppendAllLines(pathLog, contents);
                
            }

     }

       

    }
}
