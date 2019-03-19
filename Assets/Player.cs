using UnityEngine;

[RequireComponent(typeof(PlayerMovement))]
public class Player : MonoBehaviour, IDamagable
{
	public bool Dead { get; private set; }
	public float Health { get; private set; }
	[SerializeField]
	private float startHealth = 5f;
	[SerializeField]
	private Gun currentGun = null;
	private PlayerMovement playerMovement = null;

	void Start()
	{
		playerMovement = GetComponent<PlayerMovement>();
		Health = startHealth;
	}

	void Update()
	{
		GetInput();
	}

	private void GetInput()
	{
		Vector3 moveVector = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
		playerMovement.MoveVector = moveVector;

		if (currentGun)
		{
			if (Input.GetMouseButton(0))
				currentGun.Shoot();
			if (Input.GetKeyDown(KeyCode.R))
				currentGun.Reload();
		}
	}

	public void TakeDamage(float damage)
	{
		if (Dead)
			return;
		Health -= damage;
		if (Health <= 0)
			Die();
	}

	private void Die()
	{
		Dead = true;
		Debug.Log("Player is dead");
	}
}
