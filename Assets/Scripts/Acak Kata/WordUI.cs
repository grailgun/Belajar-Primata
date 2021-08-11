using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class WordUI : MonoBehaviour
{
    private UI_AcakKata uiAcakkata;

    public Image imageRender;
    public TMP_Text textRender;
    public Button wordButton;

    private char word;

    public void Setup(UI_AcakKata uiAcakKata)
    {
        uiAcakkata = uiAcakKata;

        wordButton.onClick.AddListener(() =>
        {
            uiAcakkata.AddResult(word);
            ActiveButton(false);
        });
    }

    public void Set(char c)
    {
        word = c;
        textRender.text = word.ToString();

    }

    public void ClearChar()
    {
        word = '\0';
        textRender.text = word.ToString();
    }

    public void ActiveButton(bool condition)
    {
        wordButton.interactable = condition;
    }
}
