using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Key : MonoBehaviour
{
    private GameManager gameManager;
    private Button button;
    private TextMeshProUGUI textMeshPro;

    private void Awake()
    {
        gameManager = FindFirstObjectByType<GameManager>();
    }
    void Start()
    {
        button = GetComponent<Button>();
        textMeshPro = GetComponentInChildren<TextMeshProUGUI>();
        button.onClick.AddListener(() => gameManager.KeyboardPress(textMeshPro.text));
    }

    private void OnClick()
    {
        Debug.Log(textMeshPro.text);
    }
}
