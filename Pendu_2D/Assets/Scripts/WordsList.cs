using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WordsList

{
    private List<string> lstWords = new List<string>();
    private List<string> usedWords = new List<string>();
    public string curWord;
    private int defaultSize;


    // Gestion du tirage de mots dans la liste

    public WordsList() // Constructeur
    {

        lstWords.Add("GAIN");
        lstWords.Add("REUSSITE");
        lstWords.Add("PARFAIT");
        lstWords.Add("SUCCES");
        lstWords.Add("CHEF D'OEUVRE");
        lstWords.Add("SANS-FAUTE");
        // Recupere la taille de la liste
        defaultSize = lstWords.Count;

    }

    public string GetWord()
    {    

        if (usedWords.Count==defaultSize)
        {       
            lstWords = new List<string>(usedWords);             
            usedWords.Clear();
        }

        curWord = lstWords[Random.Range(0, lstWords.Count)];
        usedWords.Add(curWord);
        lstWords.Remove(curWord);
        return curWord;       
                
    }

}
