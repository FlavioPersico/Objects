using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] private int totalScore;
    public static ScoreManager singleton;
	private int highScore;

	private void Awake()
	{
		singleton = this;
	}

	private void Start()
	{
		highScore = PlayerPrefs.GetInt("HScore");
		if(highScore != 0)
		{
			UiManager.singleton.UpdateHighScore(highScore);
		}
	}

	public int GetScore()
	{
		return totalScore;
	}

	public int GetHighScore()
	{
		return highScore;
	}

	// Update is called once per frame
	public void IncreaseScore()
    {
        totalScore += 1;
		UiManager.singleton.UpdateScore(totalScore);
    }

	public void SaveHighScore()
	{
		if(totalScore > highScore)
		{
			PlayerPrefs.SetInt("HScore", totalScore);
			highScore = totalScore;
			UiManager .singleton.UpdateHighScore(highScore);
			Debug.Log($"HIGHER SCORE: {highScore}");
		}
	}
}
