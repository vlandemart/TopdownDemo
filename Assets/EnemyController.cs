using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
	public static EnemyController Instance;

	[SerializeField]
	private TargetDummy enemyPrefab = null;
	private List<TargetDummy> enemies = new List<TargetDummy>();

	private void Awake()
	{
		if (Instance != null)
			return;
		Instance = this;
	}

	public TargetDummy PickEnemy()
	{
		foreach (var enemy in enemies)
		{
			if (enemy.IsActive() == false)
			{
				enemy.PickFromPool();
				return enemy;
			}
		}
		TargetDummy newEnemy = AddToPool();
		newEnemy.PickFromPool();
		return newEnemy;
	}

	private TargetDummy AddToPool()
	{
		TargetDummy enemy = Instantiate(enemyPrefab);
		enemies.Add(enemy);
		enemy.ReturnToPool();
		return enemy;
	}
}
