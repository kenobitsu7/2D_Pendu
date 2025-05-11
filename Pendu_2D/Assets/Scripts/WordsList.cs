using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WordsList

{
    private List<string> lstWords = new List<string>();
    public string curWord;

    public WordsList ()
    {
        lstWords.Add("PRISE");
        lstWords.Add("GAIN");
        lstWords.Add("REUSSITE");
        lstWords.Add("PARFAIT");
        lstWords.Add("SUCCES");
        lstWords.Add("EXPLOIT");
        lstWords.Add("TRIOMPHE");
        lstWords.Add("FORTUNE");
    }

    public string GetWord()
    {
        curWord = lstWords[Random.Range(0, lstWords.Count)];
        return curWord;
    }
}
