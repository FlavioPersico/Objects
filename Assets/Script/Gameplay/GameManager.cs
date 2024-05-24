using System;
using System.Collections;
using System.Runtime.CompilerServices;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;
using Scene = UnityEngine.SceneManagement.Scene;


public class GameManager : MonoBehaviour
{
    public static GameManager singleton;

    public ScoreManager scoreManager;

    [SerializeField] Enemy[] EnemyPrefab;
    [SerializeField] Transform[] spanwPositions;
    [SerializeField] float dificultLevelControl;
	[SerializeField] float dificultLevelTimer;
	[SerializeField] float dificultLevelTimerIncreaser;
	[SerializeField] float minDificultLevel;
	[SerializeField] float maxDificultLevel;
	[SerializeField] float enemyLimiter;
	[SerializeField] private float timer;
	[SerializeField] private AudioClip playAudio;
	private float maxTimer;
    private Scene scene;

	private void Awake()
	{
		singleton = this;
		dificultLevelControl = minDificultLevel;
		dificultLevelTimer = dificultLevelTimerIncreaser;
		scene = SceneManager.GetActiveScene();
	}

	// Update is called once per frame
	void Update()
    {
        if(scene.name == "game")
        {
			timer = Time.timeSinceLevelLoad;

			if (timer > dificultLevelTimer && dificultLevelControl > maxDificultLevel)
			{
				IncreaseDificult();
			}

			if (timer >= maxTimer && !CheckEnemyCounter())
			{
				maxTimer = timer + dificultLevelControl;
				StartCoroutine(SpawnEnemy());
			}
		}
    }

	private bool CheckEnemyCounter()
	{
		var foundEnemies = FindObjectsOfType<Enemy>();

		if(foundEnemies == null)
		{
			Debug.Log($"Enemies on the screen: {foundEnemies.Length}");
			return false;
		}
		else
		{
			Debug.Log($"Enemies on the screen: {foundEnemies.Length}");
			return enemyLimiter <= foundEnemies.Length ? true : false;
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

    private void IncreaseDificult()
    {
		dificultLevelTimer = dificultLevelTimerIncreaser + Time.timeSinceLevelLoad;
		dificultLevelControl--;
		Debug.Log($"dificultLevelControl: {dificultLevelControl}");

		// dificultLevelControl -= actualDifficult;
		// actualDifficult++;
		//dificultLevelTimer -= Time.deltaTime;
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

	public void StartGame()
	{
		SoundControl.audioPlayer.PlayOneShot(playAudio);
		Invoke("LoadGame", 2f);
	}
}
