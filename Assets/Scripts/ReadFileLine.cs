using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

//Ce script permet de lire un fichier txt

public class ReadFileLine
{
    public List<string> Lecture(string fileName)
    {
        FileInfo theSourceFile = null;
        StreamReader reader = null;
        List<string> text = new List<string>();
        
        theSourceFile = new FileInfo (Application.dataPath + "/" + fileName);
        if ( theSourceFile != null && theSourceFile.Exists ) {reader = theSourceFile.OpenText();}

        if ( reader == null )
        {
        Debug.Log("txt not found or not readable");
        }
        else
        {
            string line;
            while (true)
            {
                // lecture de la ligne
                line=reader.ReadLine();
                // si la ligne est vide on arrête
                if (line==null) break;
                // on affiche la ligne
                text.Add(line);
            }
        }
		
        reader.Close();
        return text;

    }
}
