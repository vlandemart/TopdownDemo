using UnityEngine;

public class TargetDummy : MonoBehaviour, IDamagable
{
	[SerializeField]
	private float startHealth = 5f;
	public float Health { get; private set; }
	public bool Dead { get; private set; }

	void Start()
	{
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
		Debug.Log("I am dead");
	}
}
