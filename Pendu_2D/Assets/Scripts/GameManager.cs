using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class GameManager : MonoBehaviour
{
    private WordsList word = new WordsList();
    private string curWord;
    [SerializeField] private TextMeshProUGUI txt;
    private string reponse;
    private bool win = false;
    [SerializeField] private Sprite[] sp;
    [SerializeField] private AudioClip SfxCorrect, SfxFailed;
    private AudioSource audiosource;
    [SerializeField] private GameObject pendu;
    private int i = 0;
    [SerializeField] private GameOverScreen gameOver;
    private Score score;
    private Sprite initial;
    private Button[] btns;


    private void Awake()
    {  
        audiosource = GetComponent<AudioSource>();
        score = GetComponent<Score>();
        initial = pendu.GetComponent<Image>().sprite;
        btns = FindObjectsOfType<Button>();
        SetWord();
    }

    // Validation des lettres du mot de la liste

    public void KeyboardPress(string letter)
    {
        Validation(letter);
    }

    private void Validation(string letter)
    {
        reponse = "";
        win = false;

        for (int i = 0; i < word.curWord.Length; i++)
        {
            if (txt.text.Substring(i, 1) == "_")
            {
                if (word.curWord.Substring(i, 1) == letter)
                {
                    reponse += letter;
                    win = true;
                }
                else
                {
                    reponse += "_";
                }
            }
            else
            {
                reponse += txt.text.Substring(i, 1);
            }
        }

        txt.text = reponse;
        Verification();
    }

    // Verification du mot de la liste et des conditions de victoire ou defaite

    void Verification()
    {
        if (win)
        {
            audiosource.PlayOneShot(SfxCorrect);

            if (txt.text == curWord)
            {
                gameOver.SetGameOverScreen(win,curWord,Continue);      
                score.Point++;           
            }
        }
        else
        {
            pendu.GetComponent<Image>().sprite = sp[i];
            i++;
            audiosource.PlayOneShot(SfxFailed);

            if(i==6)
            {
                gameOver.SetGameOverScreen(win,curWord);                        
            }
        }
    }
     
    private void SetWord()
    {
        curWord = word.GetWord();
        txt.text = "";

        // Genere les caracteres du mot de la liste

        foreach (char item in curWord)
        {
            if (item.ToString() == " ")
            {
                txt.text += " ";
            }
            else if (item.ToString() == "'")
            {
                txt.text += "'";
            }
            else if (item.ToString() == "-")
            {
                txt.text += "-";
            }
            else
            {
                txt.text += "_";
            }
        }

    }

    private void Continue()
    {               
        SetWord();                                 
        pendu.GetComponent<Image>().sprite = initial;
        BtnInteractableOn();
        i = 0;
    }

    void BtnInteractableOn()
    {        
        foreach (var item in btns)
        {
            item.interactable = true;
        }
    }
    
}
        
    

