using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
	[SerializeField]
	private float speed = 3f;
	private float damage = 1f;
	private Vector3 startPos = Vector3.zero;

	public void SetUp(float _damage)
	{
		damage = _damage;
		startPos = transform.position;
	}

	void Update()
	{
		transform.position += transform.forward * speed * Time.deltaTime;
		CheckCollision();
		if (Vector3.Distance(transform.position, startPos) >= 20f)  //Magic number - max distance
			Destroy();
	}

	void CheckCollision()
	{
		RaycastHit hit;
		float moveStep = speed * Time.deltaTime;
		Ray ray = new Ray(transform.position, transform.forward);
		if (Physics.Raycast(ray, out hit, moveStep))
		{
			IDamagable damagable = hit.collider.gameObject.GetComponent<IDamagable>();
			if (damagable != null)
				OnHit(damagable);
		}
	}

	void OnHit(IDamagable damagable)
	{
		damagable.TakeDamage(damage);
		Destroy();
	}

	void Destroy()
	{
		this.gameObject.SetActive(false);
	}
}
