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
    [SerializeField] private GameObject Pendu;
    private int i = 0;
    [SerializeField] private GameObject GameOver;

    private Score score;

    private Sprite initial;

    private Button[] btns;
    private void Awake()
    {  
        audiosource = GetComponent<AudioSource>();
        score = GetComponent<Score>();
        initial = Pendu.GetComponent<Image>().sprite;
        btns = FindObjectsOfType<Button>();
        SetWord();
    }
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

    void Verification()
    {
        if (win)
        {
            audiosource.PlayOneShot(SfxCorrect);

            if (txt.text == curWord)
            {
                GameOver.SetActive(true);
                GameOver.GetComponentInChildren<TextMeshProUGUI>().text = "Félicitations ! Vous avez trouvé le mot " + curWord;
                score.Point++;
                StartCoroutine(Restart());
            }
        }
        else
        {
            Pendu.GetComponent<Image>().sprite = sp[i];
            i++;
            audiosource.PlayOneShot(SfxFailed);

            if(i==6)
            {
                GameOver.SetActive(true);
                GameOver.GetComponentInChildren<TextMeshProUGUI>().text = "Dommage ! Vous n'avez pas trouvé le mot " + curWord;
                StartCoroutine(Restart());
            }
        }
    }
     
    private void SetWord()
    {
        curWord = word.GetWord();
        txt.text = "";

        // Genere le nombre de caractere "_" 

        foreach (char item in curWord)
        {
            txt.text += "_";
        }
    }
    IEnumerator Restart()
    {
        yield return new WaitForSeconds(5f);

        if (win)
        {
           SetWord();
           
           GameOver.SetActive(false);
           Pendu.GetComponent<Image>().sprite = initial;
           BtnInteractableOn();
           i = 0;

        }
        else
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene("Game");
        }
    }

    void BtnInteractableOn()
    {
        
        foreach (var item in btns)
        {
            item.interactable = true;
        }
    }
}
        
    

