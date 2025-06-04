using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;
using System;

public class GameOverScreen : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI sentence;
    [SerializeField] private Button button;
    [SerializeField] private TextMeshProUGUI buttonText;


    // Gestion des conditions de victoire ou defaite dans le Game Over

    public void SetGameOverScreen(bool win,string curWord,Action action=null)
    {
        gameObject.SetActive(true);
        button.onClick.RemoveAllListeners();
        if (win) 
        { 
            sentence.text= "Félicitations ! Vous avez trouvé le mot " + curWord;
            // Active le "Continue"
            buttonText.text = "Continue";
            button.onClick.AddListener(() => { action(); gameObject.SetActive(false); });
        }
        else
        {
            sentence.text = "Dommage ! Vous n'avez pas trouvé le mot " + curWord;
            // Active le "Restart"
            buttonText.text = "Restart";
            button.onClick.AddListener(()=>RestartButton());
        }
    }
    private void RestartButton()
    {
        SceneManager.LoadScene("Game");
    }

    public void ExitButton()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
