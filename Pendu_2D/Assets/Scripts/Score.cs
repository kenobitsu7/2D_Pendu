using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    public TextMeshProUGUI txtScore;  
    private int point = 0;


    // Gestion du Score 

    public int Point
    {
        get 
        { 
            return point; 
        }

        // Met a jour le champ texte du Score

        set
        {
            point = value;
            txtScore.text = "Score : " + point;
        }
    }
}
