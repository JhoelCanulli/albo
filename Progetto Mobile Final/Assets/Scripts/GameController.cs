using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{

    public static GameController instance { get; private set; }

    public bool isGameStarted = false;

    [SerializeField] private float score;
    [SerializeField] private int bestScore;

    public Text scoreText;
    public Text timerText;
    public Text adviceText;

    public GameObject gameplayPanel;

    public GameOverScreen GameOverScreen;
  


    private void Awake()
    {
        if (instance == null){
            instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    private void Start()
    {
        score = 0;
        bestScore = GetBestscore();

        StartCoroutine(StartGame());
    }

    IEnumerator StartGame()
    {
        
        int timer = 3;
        timerText.text = timer.ToString();
        timerText.gameObject.SetActive(true);

        while (timer >= 0)
        {
            yield return new WaitForSeconds(1);
            Debug.Log("timer " + timer);
            timer -= 1;
            if (timer == 0)
            {
                timerText.text = "VIA";
            }
            else
            {
                timerText.text = timer.ToString();
            }
          
        }


        adviceText.gameObject.SetActive(false);
        timerText.gameObject.SetActive(false);
        isGameStarted = true;

        GameObject.FindGameObjectWithTag("Player").GetComponent<movimentiMaghetto>().NascondiNuvoletta();
        GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody2D>().gravityScale = 1;
       


    }

    public float GetScore()
    {
        return score;
    }

    private int GetBestscore()
    {
        int value = PlayerPrefs.GetInt("Bestscore");
        return value;
    }


    private void SaveBestScore()
    {
        PlayerPrefs.SetInt("Bestscore", bestScore);
    }

    private void CheckForBestScore()
    {
        if (score > bestScore)
        {
            bestScore = (int)score;
            SaveBestScore();
        }
    }
    public void SetScore(float value)
    {
        score = value;
        
    }

    public void GameOver()
    {
        Debug.Log("Game oiver");
        gameplayPanel.SetActive(false);
        CheckForBestScore();
        GameOverScreen.Setup(score, bestScore);
    }
}
