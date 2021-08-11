using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UI_AcakKata : MonoBehaviour
{
    private AcakKata manager;
    public WordUI[] wordUI;

    public TMP_Text resultTextUI;
    public TMP_Text questionTextUI;
    private string result;

    [Header("Timer and Score")]
    public TMP_Text timerText;
    public TMP_Text scoreText;

    [Header("Panel")]
    public GameObject gameOverPanel;
    public TMP_Text scoreAtGameOver;

    public ParticleSystem winEffect;

    public void Setup(AcakKata manager)
    {
        this.manager = manager;

        for (int i = 0; i < wordUI.Length; i++)
        {
            wordUI[i].Setup(this);
        }

        SetTimer(0);
        SetScore();
    }

    public void ShowText(string dataName, string pertanyaan)
    {
        ClearResult();

        for (int i = 0; i < dataName.Length; i++)
        {
            wordUI[i].Set(dataName[i]);
        }

        questionTextUI.text = pertanyaan;
    }

    public void AddResult(char c)
    {
        result += c;
        resultTextUI.text = result;

        manager.CheckResult(result);
    }

    public void Win()
    {
        SetScore();
        winEffect.Play();
    }

    private void SetScore()
    {
        scoreText.text = $"{manager.ScorePoint}";
    }

    public void SetTimer(float time)
    {
        int seconds = Mathf.CeilToInt(time);
        timerText.text = $"{seconds} s";
    }

    public void Gameover()
    {
        gameOverPanel.SetActive(true);
        scoreAtGameOver.text = $"{manager.ScorePoint}";
    }

    public void ClearResult()
    {
        result = string.Empty;
        resultTextUI.text = result;

        for (int i = 0; i < wordUI.Length; i++)
        {
            wordUI[i].ActiveButton(true);
        }

        manager.CheckResult(result);
    }
}
