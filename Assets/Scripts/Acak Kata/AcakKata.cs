using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AcakKata : MonoBehaviour
{
    public static string alphabet = "abcdefghijklmnopqrstuvwxyz";
    [SerializeField] PrimataData[] dataList;
    [SerializeField] int recommendShuffleWordLength = 12;
    private PrimataData currentData;

    [Header("Timer")]
    [SerializeField] float answerTime;
    private float answerTimeCounter;
    private Coroutine answerTimerCoroutine;

    [Header("Score")]
    [SerializeField] float answerScore;
    public float ScorePoint { get; private set; }

    
    [SerializeField] UI_AcakKata uiAcakKata;

    private void Start()
    {
        uiAcakKata.Setup(this);

        PlayNewRound();
    }

    public void PlayNewRound()
    {
        int dataIndex = Random.Range(0, dataList.Length);
        currentData = dataList[dataIndex];
        string pertanyaan = currentData.pertanyaan[Random.Range(0, currentData.pertanyaan.Length)];

        uiAcakKata.ShowText(ShuffleWord(GenerateWord(currentData.PrimataName)), pertanyaan);

        if (answerTimerCoroutine != null)
            StopCoroutine(answerTimerCoroutine);
        answerTimerCoroutine = StartCoroutine(StartTimer());
    }

    IEnumerator StartTimer()
    {
        float time = answerTime;
        while (time > 0)
        {
            uiAcakKata.SetTimer(time);
            time -= Time.deltaTime;
            yield return null;
        }

        GameOver();
    }

    private void GameOver()
    {
        uiAcakKata.Gameover();
        Time.timeScale = 0;
    }

    public void Exit()
    {
        Time.timeScale = 1;
        Debug.Log("Exit");
    }

    public void Restart()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private char[] GenerateWord(string primataName)
    {
        if (primataName.Length < 1) return null;

        int nameLength = primataName.Length;
        string shuffledWord = currentData.name;

        if (nameLength < recommendShuffleWordLength)
        {
            int jumlahKataYangKurang = recommendShuffleWordLength - nameLength;

            for (int i = 0; i < jumlahKataYangKurang; i++)
            {
                shuffledWord += GetRandomAlphabet();
            }
        }

        shuffledWord = shuffledWord.ToUpper();

        return shuffledWord.ToCharArray();
    }

    private char GetRandomAlphabet()
    {
        char c = alphabet[Random.Range(0, alphabet.Length)];
        return c;
    }

    private string ShuffleWord(char[] characters)
    {
        int n = characters.Length;
        while (n > 1)
        {
            int k = Random.Range(0, n);
            var value = characters[k];
            characters[k] = characters[n-1];
            characters[n-1] = value;
            n--;
        }

        return new string(characters);
    }

    public void CheckResult(string result)
    {
        if(string.Equals(result, currentData.PrimataName))
        {
            //WIN
            ScorePoint += answerScore;

            uiAcakKata.Win();

            if (answerTimerCoroutine != null)
                StopCoroutine(answerTimerCoroutine);

            Invoke("PlayNewRound", 2f);
        }
    }
}
