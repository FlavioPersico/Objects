using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UiManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI healthValue;
    [SerializeField] private TextMeshProUGUI scoreValue;
    [SerializeField] private TextMeshProUGUI highScoreValue;
    [SerializeField] private GameObject gameOverScreen;

    public static UiManager singleton;

	private void Awake()
	{
		singleton = this;
	}

	public void UpdateHealth(int valueParam)
    {
        healthValue.text = valueParam.ToString();
    }

    public void UpdateScore(int valueParam)
    {
        scoreValue.text = valueParam.ToString();
    }

	public void UpdateHighScore(int valueParam)
	{
	    highScoreValue.text = valueParam.ToString();
	}

    public void GameOverScreen(int scoreParam, int highScoreParam)
    {
        gameOverScreen.gameObject.SetActive(true);
        gameOverScreen.GetComponent<GameOverManager>().UpdateGameOverScreen(scoreParam, highScoreParam);
    }

    public void ReturnMainMenu()
    {
        SceneManager.LoadScene("menu");
    }

    public void TryAgain()
    {
        SceneManager.LoadScene("game");
    }
}
