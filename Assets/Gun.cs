using UnityEngine;
using System.Collections;

public class Gun : MonoBehaviour
{
	[SerializeField]
	private float shootCD = 1f;
	[SerializeField]
	private float damage = 1f;
	[SerializeField]
	private Projectile projectile = null;
	[SerializeField]
	private int clipSize = 5;
	[SerializeField]
	private float reloadTime = .6f;
	[SerializeField]
	private int ammoPerReload = 5;
	[SerializeField]
	private Transform shootingPoing = null;
	[SerializeField]
	protected float inaccuracy = 5f;

	private float currentCD = 0;
	private int currentClipSize;
	private bool reloading = false;

	protected virtual void Start()
	{
		currentClipSize = clipSize;
	}

	/// <summary>
	/// Method handles shooting cooldown, reloading and ammo wasting.
	/// Returns true if the shot was successful.
	/// </summary>
	public virtual bool Shoot()
	{
		if (currentClipSize <= 0)
		{
			Reload();
			return false;
		}
		if (currentCD > Time.time)
			return false;
		if (reloading)
			StopReloading();

		currentCD = Time.time + shootCD;
		currentClipSize--;
		HUDManager.Instance.UpdateAmmoCounter(currentClipSize, clipSize);
		//TODO shoot sound
		return true;
	}

	protected virtual void StartProjectile(Quaternion rot)
	{
		if (rot == Quaternion.identity)
			rot = Quaternion.Euler(0, Random.Range(-inaccuracy, inaccuracy), 0);
		Instantiate(projectile, shootingPoing.transform.position, transform.rotation * rot);
	}

	/// <summary>
	/// Reload the gun.
	/// </summary>
	public void Reload()
	{
		if (reloading)
			return;
		//TODO start reload sound
		Debug.Log("Starting reload");
		StartCoroutine(ReloadCoroutine());
	}

	private void StopReloading()
	{
		reloading = false;
		StopAllCoroutines();
	}

	private IEnumerator ReloadCoroutine()
	{
		reloading = true;
		while (currentClipSize < clipSize)
		{
			yield return new WaitForSeconds(reloadTime);
			//TODO insert ammo sound
			currentClipSize += ammoPerReload;
			HUDManager.Instance.UpdateAmmoCounter(currentClipSize, clipSize);
		}
		reloading = false;
	}
}
