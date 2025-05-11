using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Score : MonoBehaviour
{
    public TextMeshProUGUI txtScore;
    
    private int point = 0;
    public int Point
    {
        get {  return point; }

        set
        {
            point = value;
            txtScore.text = "Score : " + point;
        }
    }
}
