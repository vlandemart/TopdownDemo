using UnityEngine;
using System.Collections.Generic;

[RequireComponent(typeof(PlayerMovement))]
public class Player : MonoBehaviour, IDamagable
{
	public bool Dead { get; private set; }
	public float Health { get; private set; }
	[SerializeField]
	private float startHealth = 5f;
	[SerializeField]
	private Gun currentWeapon = null;
	[SerializeField]
	private Transform hand = null;
	private PlayerMovement playerMovement = null;
	public IInteractable Interactable = null;

	void Start()
	{
		playerMovement = GetComponent<PlayerMovement>();
		hand = transform.GetChild(0);
		Health = startHealth;
	}

	void Update()
	{
		if (Dead)
			return;
		GetInput();
	}

	private void GetInput()
	{
		Vector3 moveVector = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
		playerMovement.MoveVector = moveVector;

		if (currentWeapon)
		{
			if (Input.GetMouseButton(0))
				currentWeapon.Shoot();
			if (Input.GetKeyDown(KeyCode.R))
				currentWeapon.Reload();
		}

		if (Input.GetKeyDown(KeyCode.E))
			Interact();
	}

	private void Interact()
	{
		if (Interactable != null)
			Interactable.Interact();
	}

	public void EquipWeapon(Gun gunToEquip)
	{
		if (currentWeapon)
			DropWeapon();
		currentWeapon = gunToEquip;
		currentWeapon.EquipGun(hand);
	}

	public void DropWeapon()
	{
		currentWeapon.DropGun();
		currentWeapon = null;
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
