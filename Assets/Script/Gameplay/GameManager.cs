using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager singleton;

    public ScoreManager scoreManager;

    [SerializeField] Enemy[] EnemyPrefab;
    [SerializeField] Transform[] spanwPositions;
	private float timer;
	private float maxTimer;

	private void Awake()
	{
		singleton = this;
	}

	void Start()
    {

	}

    // Update is called once per frame
    void Update()
    {
        timer = Time.timeSinceLevelLoad;
		if (timer >= maxTimer)
        {
			maxTimer = timer + 1f;
            StartCoroutine(SpawnEnemy());
        }
    }

    IEnumerator SpawnEnemy()
    {
        yield return new WaitForSeconds(4f);
		Transform randomEnemyPosition = spanwPositions[Random.Range(0, spanwPositions.Length)];
        Enemy randomEnemyPrefab = EnemyPrefab[Random.Range(0,EnemyPrefab.Length)];
		Enemy enemy = Instantiate(randomEnemyPrefab, randomEnemyPosition.position, Quaternion.identity);
		enemy.SetUpEnemy(1);
	}

    public void EndGame()
    {
        StopAllCoroutines();
        scoreManager.SaveHighScore();
        UiManager.singleton.GameOverScreen(scoreManager.GetScore(), scoreManager.GetHighScore());
    }

    public void LoadGame()
    {
        SceneManager.LoadScene("game");
    }
}
