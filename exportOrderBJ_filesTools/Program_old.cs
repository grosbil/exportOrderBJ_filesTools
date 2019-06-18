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
                    //Path = "C:\\OpenFlux\\ECHANGES\\BJ\\WebCSI\\BL\\temp\\";
                    string PathFileIn = Path + "BL.txt";
                    String delimiteurFile = "#BEGIN#";

                    string[] fichier = File.ReadAllLines(PathFileIn, Encoding.UTF8);
              
                List<string> newlines = new List<string>();

                File.WriteAllLines(PathFileIn, fichier, Encoding.UTF8);

                for (int i = 0; i < fichier.Length && i<200; i++ )
                {
                    // recherche de chaine delimiteur 
                    int index = fichier[i].IndexOf(delimiteurFile);
                    // Récupération de la partie jusqu'à la chaine pour alimenter la variable du nom de fichier
                    String filename = fichier[i].Substring(0, index);
                    // récupération de la partie restante pour alimenter le fichier
                    fichier[i] = fichier[i].Substring(index + 7);


                    // remplacement de contenu en fonction du flux Openflux
                    fichier[i] = fichier[i].Replace("|", "\n");
                    fichier[i] = fichier[i].Replace(";\n", "\n");

                    // récupération de la ligne
                    newlines.Add(fichier[i]);

                    //construction du fichier 
                    string PathFileOut = Path + filename + ".txt";
                    File.WriteAllLines(PathFileOut, newlines);

                    // vidage de la ligne pour passer à la suivante
                    newlines.Clear();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Problème: {0}", ex.Message);
                Console.ReadKey();
            }

            
        }
       

}
}
