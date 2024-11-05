using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Net.Http.Headers;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;

public class ManageTextFiles : MonoBehaviour
{
   
    /*
     * It is required to know the name of the file you are trying to retrieve a particular line from
     * Key is used to search for a tagged piece of text
     */
    public static string GetLineAtKey(string key, string fileName)
    {
        string temp = "";

        string path = Application.dataPath + "/FlavourText/" + fileName; 
   
        string[] lines = File.ReadAllLines(path);

        foreach (string line in lines)
        {
            if (line.Substring(0, key.Length).Equals(key))
            {
                temp = line.Substring(key.Length);
            }
        }
        return temp;
    }

    public static List<string> GetLineStopAtKey(string key, string fileName)
    {
        string path = Application.dataPath + "/FlavourText/" + fileName;

        string[] lines = File.ReadAllLines(path);

        List<string> temp = new List<string>();
        bool flag = false;

       for(int i = 0; i < lines.Length && !flag; i++)
        {
            if (lines[i].Substring(0, key.Length).Equals(key))
            {
                flag = true;
            } else
            {
                temp.Add(lines[i]);

            }
        }
        return temp;
    }
    public static string[] GetAllLines(string fileName)
    {
       

        string path = Application.dataPath + "/FlavourText/" + fileName;
        string[] lines = File.ReadAllLines(path);

        return lines;
    }
    public static string ReplaceText(string text, string replacement, string key)
    {

        string temp = "";
        int counter = 0;
        bool flag = false;

        for (int i = 0; i < text.Length && !flag; i++)
        {
          
                if (text.Substring(i, 1).Equals(key))
                {
                    flag = true;
                }
                counter++;
           

        }
        
        if (flag)
        {
            temp = text.Substring(0, counter-1)  + replacement + text.Substring(counter);
        }
        
        return temp;
    }
}
