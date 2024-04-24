using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameOverManager : MonoBehaviour
{
	[SerializeField] private TextMeshProUGUI scoreValue;
	[SerializeField] private TextMeshProUGUI highScoreValue;
	[SerializeField] private TextMeshProUGUI newRecord;

	public void UpdateGameOverScreen(int scoreParam, int highScoreParam)
	{
		scoreValue.text = scoreParam.ToString();
	    highScoreValue.text = highScoreParam.ToString();
		if(scoreParam >= highScoreParam)
		{
			newRecord.gameObject.SetActive(true);
		}
	}
}
