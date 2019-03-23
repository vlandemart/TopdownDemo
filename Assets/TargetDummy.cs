using UnityEngine;

public class TargetDummy : PooledBehaviour, IDamagable
{
	public float Health { get; private set; }
	public bool Dead { get; private set; }
	[SerializeField]
	private float startHealth = 5f;

	void Start()
	{
		SetUp();
	}

	public override void SetUp()
	{
		base.SetUp();
		Health = startHealth;
		Dead = false;
	}

	public void TakeDamage(float damage)
	{
		if (Dead)
			return;

		Health -= damage;
		if (Health <= 0)
			Die();
	}

	void Die()
	{
		Dead = true;
		GameController.Instance.AddScore(100);
		ReturnToPool();
	}
}
