using System;
using System.Collections;
using UnityEngine;
using Vector3 = UnityEngine.Vector3;
using Random = UnityEngine.Random;

public class GameController : MonoBehaviour
{
	public static GameController Instance;

	public event Action<int> OnScoreChange;
	[SerializeField]
	private Vector2 gameArea = new Vector2(50, 50);
	private int score = 0;
	private Player player = null;
	private float secondsBetweedEnemiesRespawn = 5f;

	private void Awake()
	{
		if (Instance != null)
		{
			return;
		}
		Instance = this;
	}

	private void Start()
	{
		player = FindObjectOfType<Player>();
		StartCoroutine(EnemySpawnCoroutine());
	}

	public void AddScore(int scoreToAdd)
	{
		score += scoreToAdd;
		OnScoreChange?.Invoke(score);
	}

	private IEnumerator EnemySpawnCoroutine()
	{
		yield return null;
		while (true)
		{
			SpawnEnemy();
			yield return new WaitForSeconds(secondsBetweedEnemiesRespawn);
		}
	}

	private void SpawnEnemy()
	{
		TargetDummy enemy = EnemyController.Instance.PickEnemy();
		float posX = Random.Range(-gameArea.x, gameArea.x);
		float posZ = Random.Range(-gameArea.y, gameArea.y);
		enemy.transform.position = new Vector3(posX, 1, posZ);
		enemy.transform.LookAt(player.transform);
	}
}
