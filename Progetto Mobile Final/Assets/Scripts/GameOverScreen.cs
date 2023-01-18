using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverScreen : MonoBehaviour
{

    public Text scoreText;
    public Text bestscoreText;

    public void Setup(float score, int bestscore)
    {
        gameObject.SetActive(true);
        scoreText.text = score.ToString();
        bestscoreText.text = "Best: " + bestscore.ToString();

    }

    public void RestartButton()
    {
        SceneManager.LoadScene("DarkScene");
    }

}
